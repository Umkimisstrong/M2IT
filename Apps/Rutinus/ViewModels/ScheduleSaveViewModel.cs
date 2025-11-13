using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Rutinus.Models;
using Rutinus.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Rutinus.ViewModels
{
    public partial class ScheduleSaveViewModel : ObservableObject
    {
        private readonly ScheduleService _service;
        private readonly RoutineService _routineService;

        [ObservableProperty]
        private ObservableCollection<ScheduleModel> scheduleModels = new();

        [ObservableProperty]
        private ObservableCollection<RoutineModel> routineModels = new();

        // RoutineGroupModels을 외부에서 바인딩할 수 있도록 ObservableCollection으로 변경
        [ObservableProperty]
        private ObservableCollection<RoutineGroupModel> routineGroupModels = new();

        [ObservableProperty]
        private string scheduleYmd = string.Empty;
        private string _scheduleUser = string.Empty;

        /// <summary>
        /// 생성자
        /// </summary>
        public ScheduleSaveViewModel()
        {
            _service = new ScheduleService();
            _routineService = new RoutineService();
        }

        [RelayCommand]
        private async Task SaveSchedule()
        {
            if (RoutineModels != null && RoutineModels.Count > 0)
            {
                List<ScheduleModel> list = new List<ScheduleModel>();
                for (int i = 0; i < RoutineModels.Count; i++)
                {
                    if (RoutineModels[i] != null && RoutineModels[i].IsSelected == true)
                    { 
                        ScheduleModel scheduleModel = new ScheduleModel();
                        scheduleModel.RoutineId = RoutineModels[i].RoutineId;
                        scheduleModel.ScheduleYmd = ScheduleYmd;
                        scheduleModel.ScheduleUser = _scheduleUser;
                        scheduleModel.CreatedBy = _scheduleUser;
                        scheduleModel.CreatedAt = DateTime.Now;
                        scheduleModel.UpdatedBy = _scheduleUser;
                        scheduleModel.UpdatedAt = DateTime.Now;

                        list.Add(scheduleModel);
                    }
                }


                var response = await _service.SaveSchedule(list);
                if (response != null && response.Success) 
                {
                    await InitLoadScheduleAsync(ScheduleYmd, _scheduleUser);
                }

            }
            
        }

        /// <summary>
        /// 루틴 목록 로드
        /// </summary>
        private async Task LoadRoutine(string scheduleUser)
        {
            var routine = await _routineService.GetRoutineListAsync(scheduleUser);
            if (routine != null)
            {
                RoutineModels.Clear();
                if (routine.Data.Count > 0)
                {
                    if (ScheduleModels != null && ScheduleModels.Count > 0)
                    {
                        foreach (var item in routine.Data)
                        {
                            bool isSameRoutine = ScheduleModels.Any(s => s.RoutineId == item.RoutineId);
                            if (!isSameRoutine)
                            {
                                RoutineModels.Add(item);
                            }
                        }
                    }
                    else
                    {
                        foreach (var item in routine.Data)
                        {
                            RoutineModels.Add(item);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 스케줄 초기 로드 및 RoutineGroupModels 생성
        /// </summary>
        public async Task InitLoadScheduleAsync(string scheduleYmd, string scheduleUser)
        {
            ScheduleYmd = scheduleYmd;
            _scheduleUser = scheduleUser;
            // 1. 기존 스케줄 불러오기
            var schedule = await _service.GetScheduleListAsync(scheduleYmd, scheduleUser);
            ScheduleModels.Clear();
            if (schedule != null)
            {
                foreach (var item in schedule.Data)
                {
                    ScheduleModels.Add(item);
                }
            }

            // 2. 루틴 목록 불러오기
            await LoadRoutine(scheduleUser);

            // 3. RoutineGroupModels 생성 (루틴별 그룹화)
            RoutineGroupModels.Clear();

            var grouped = ScheduleModels
                .GroupBy(s => new { s.RoutineId, s.RoutineName, s.RoutinePartName })
                .Select(g => new RoutineGroupModel
                {
                    RoutineId = g.Key.RoutineId,
                    RoutineName = g.Key.RoutineName,
                    Trainings = g.Select(s => s.TrainingCdName).ToList(),
                    RoutinePartName = g.Key.RoutinePartName,
                    SelectedTime = g.FirstOrDefault()?.ScheduleHms ?? string.Empty // 기본 시간
                });

            foreach (var group in grouped)
            {
                RoutineGroupModels.Add(group);
            }
        }
    }

    public class RoutineGroupModel : ObservableObject
    {
        public int RoutineId { get; set; }
        public string RoutineName { get; set; } // ex: "가슴루틴"
        public string RoutinePartName { get; set; } // ex: "가슴루틴"
        public List<string> Trainings { get; set; } = new(); // ex: ["벤치프레스", "덤벨프레스", "펙덱플라이"]

        private string selectedTime = string.Empty;
        public string SelectedTime
        {
            get => selectedTime;
            set => SetProperty(ref selectedTime, value);
        }
    }
}
