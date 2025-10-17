using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private void OnButtonClicked()
        {
            // ViewModel 에서는 UI 선언된 변수를 그대로 사용할 수 있다.
            // 사용 시 입력된 값을 가져온다.
            // 
            System.Diagnostics.Debug.WriteLine(routineName);
            System.Diagnostics.Debug.WriteLine(description);
            System.Diagnostics.Debug.WriteLine(startDate);
            System.Diagnostics.Debug.WriteLine(defaultWeight);
            System.Diagnostics.Debug.WriteLine(selectedBodyPart);


        }
    }
}
