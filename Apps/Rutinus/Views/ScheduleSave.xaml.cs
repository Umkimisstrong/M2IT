using CommunityToolkit.Maui.Views;
using Rutinus.Models;
using Rutinus.ViewModels;
using System.Threading.Tasks;

namespace Rutinus
{
    public partial class ScheduleSave : Popup
    {
        private readonly string _scheduleYmd;
        private readonly string _scheduleUser;

        private List<ScheduleModel> _allRoutines = new();
        private List<ScheduleModel> _selectedRoutines = new();

        public ScheduleSave()
        {
            InitializeComponent();
        }

        public ScheduleSave(string scheduleYmd, string scheduleUser)
        {
            InitializeComponent();

            _scheduleYmd = scheduleYmd;
            _scheduleUser = scheduleUser;

            //lblHeader.Text = $"{_scheduleYmd} / {_scheduleUser} 루틴 일정 추가";

            // 예시 데이터 (실제 DB나 ViewModel에서 가져올 수 있음)
            _allRoutines = new List<ScheduleModel>
            {
                new() { RoutineId = 1, RoutineName = "아침 스트레칭", RoutinePartName="유연성", TrainingNm="전신 스트레칭" },
                new() { RoutineId = 2, RoutineName = "조깅", RoutinePartName="유산소", TrainingNm="러닝머신 30분" },
                new() { RoutineId = 3, RoutineName = "스쿼트", RoutinePartName="하체", TrainingNm="기초 하체운동" }
            };

            foreach (var r in _allRoutines)
                r.TimeSlots = GenerateTimeSlots();

            //RoutineList.ItemsSource = _allRoutines;
            //SelectedRoutineList.ItemsSource = _selectedRoutines;
        }

        // 시간 목록 생성 (00:00 ~ 23:30)
        private List<string> GenerateTimeSlots()
        {
            var slots = new List<string>();
            for (int h = 0; h < 24; h++)
            {
                slots.Add($"{h:00}:00");
                slots.Add($"{h:00}:30");
            }
            return slots;
        }

        private void OnAddRoutineClicked(object sender, EventArgs e)
        {
            var selected = _allRoutines.Where(r => r.IsSelected).ToList();
            foreach (var r in selected)
            {
                r.IsSelected = false;
                if (!_selectedRoutines.Any(x => x.RoutineId == r.RoutineId))
                {
                    var clone = new ScheduleModel
                    {
                        RoutineId = r.RoutineId,
                        RoutineName = r.RoutineName,
                        RoutinePartName = r.RoutinePartName,
                        TrainingNm = r.TrainingNm,
                        ScheduleYmd = _scheduleYmd,
                        ScheduleUser = _scheduleUser,
                        ScheduleHms = "00:00",
                        TimeSlots = r.TimeSlots
                    };
                    _selectedRoutines.Add(clone);
                }
            }
            RefreshLists();
        }

        private void OnRemoveRoutineClicked(object sender, EventArgs e)
        {
            _selectedRoutines.RemoveAll(r => r.IsSelected);
            RefreshLists();
        }

        private void OnResetClicked(object sender, EventArgs e)
        {
            _selectedRoutines.Clear();
            _allRoutines.ForEach(r => r.IsSelected = false);
            RefreshLists();
        }

        private void OnSaveClicked(object sender, EventArgs e)
        {
            // 실제 저장 로직 (예: DB Insert)
            //Close(_selectedRoutines);
        }

        //private void OnCloseClicked(object sender, EventArgs e) => Close();

        private void RefreshLists()
        {
            /*
            RoutineList.ItemsSource = null;
            RoutineList.ItemsSource = _allRoutines;

            SelectedRoutineList.ItemsSource = null;
            SelectedRoutineList.ItemsSource = _selectedRoutines;
            */
        }


        /// <summary>
        /// btnClose_Clicked : 닫기버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Clicked(object sender, EventArgs e)
        {
            this.CloseAsync();
        }
    }
}
