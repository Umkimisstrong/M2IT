using CommunityToolkit.Mvvm.ComponentModel;
using Rutinus.Entities;
using Rutinus.Models;
using Rutinus.Services;
using System.Diagnostics;
using System.Windows.Input;

namespace Rutinus.ViewModels
{
    public partial class RoutineViewModel : ObservableObject
    {
        [ObservableProperty] string routineName;
        [ObservableProperty] string description;
        [ObservableProperty] DateTime startDate = DateTime.Today;
        [ObservableProperty] double defaultWeight = 20;
        [ObservableProperty] bool receiveNotifications = true;
        [ObservableProperty] List<string> bodyParts = new() { "가슴", "등", "하체", "어깨", "팔" };
        [ObservableProperty] string selectedBodyPart;
        [ObservableProperty] string bodyPart;


        public ICommand ButtonCommand { get; }
        private bool _canExecuteButton = true;

        public RoutineViewModel()
        {
            ButtonCommand = new Rutinus.Command.RelayCommand(OnButtonClicked, CanExecuteButton);
        }

        // 버튼 활성화 여부를 판단하는 메소드
        private bool CanExecuteButton()
        {
            return _canExecuteButton;
        }

        // CanExecute 상태를 변경하고, 이벤트를 호출
        public void UpdateButtonState(bool canExecute)
        {
            _canExecuteButton = canExecute;
            ((Rutinus.Command.RelayCommand)ButtonCommand).RaiseCanExecuteChanged();
        }

        /// <summary>
        /// OnButtonClicked : 버튼 클릭시 실행되는 메소드
        /// </summary>
        private async void OnButtonClicked()
        {
            // ViewModel 에서는 UI 선언된 변수를 그대로 사용할 수 있다.
            // 사용 시 입력된 값을 가져온다.
            // 

            RoutineService _api = new RoutineService();

            try
            {
                RoutineModel request = new RoutineModel();
                request.routineName = routineName;
                request.defaultWeight = defaultWeight;
                request.selectedBodyPart = selectedBodyPart;
                request.startDate = startDate;
                request.bodyParts = new List<string>();
                request.bodyPart = selectedBodyPart;
                request.description = description;
                request.receiveNotifications = receiveNotifications;
                RoutineEntity entity = await _api.SaveRoutine(request);

                await Shell.Current.GoToAsync("///RoutineList");

            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }

        }
    }
}
