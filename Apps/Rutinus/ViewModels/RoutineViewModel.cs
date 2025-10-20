using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Rutinus.Entities;
using Rutinus.Models;
using Rutinus.Services;
using System.Diagnostics;
using System.Threading.Tasks;


namespace Rutinus.ViewModels
{
    public partial class RoutineViewModel : ObservableObject
    {
        [ObservableProperty]
        private string routineName = string.Empty;

        [ObservableProperty]
        private string routineDescription = string.Empty;

        [ObservableProperty]
        private string routinePart = string.Empty;

        [ObservableProperty]
        private bool alertEnabled;

        // 명령은 AsyncRelayCommand 사용
        public IAsyncRelayCommand SaveCommand { get; }

        private readonly RoutineService _service;

        public RoutineViewModel()
        {
            _service = new RoutineService();
            SaveCommand = new AsyncRelayCommand(OnSaveAsync);
        }

        private async Task OnSaveAsync()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(routineName))
                {
                    await App.Current.MainPage.DisplayAlert("오류", "루틴 이름을 입력하세요.", "확인");
                    return;
                }

                var routine = new RoutineModel
                {
                    RoutineName = routineName,
                    RoutinePart = routinePart,
                    RoutineDescription = routineDescription,
                    AlertYn = alertEnabled ? "Y" : "N"
                };

                ApiResponse<RoutineModel> result = await _service.SaveRoutine(routine);

                if (result.Success)
                {
                    await App.Current.MainPage.DisplayAlert("성공", "루틴이 저장되었습니다.", "확인");
                    await Shell.Current.GoToAsync("///RoutineList");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("실패", "저장에 실패했습니다.", "확인");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[SaveRoutine Error] {ex.Message}");
                await App.Current.MainPage.DisplayAlert("오류", ex.Message, "확인");
            }
        }
    }
}