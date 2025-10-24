using System.Windows.Input;

namespace Rutinus.Command
{
    /// <summary>
    /// RelayCommand : ICommand 를 상속받는 클래스
    /// </summary>
    public class RelayCommand : ICommand
    {
        // Event 를 핸들링 한다.
        // Button, TextBox 등 특정 요소에서 ViewModel 을 통해 Command 를 주입하기 위함
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;


        public RelayCommand(Action execute, Func<bool> canExecute = null)
        { 
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }


        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        public void Execute(object parameter)
        {
            _execute();
        }

        // CanExecuteChanged 이벤트를 직접 호출하는 메소드
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
