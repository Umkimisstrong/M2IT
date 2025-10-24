using Rutinus.ViewModels;

namespace Rutinus
{
    public partial class SignUpPage : ContentPage
    {

        private readonly SignUpViewModel _signUpViewModel;

        public SignUpPage()
        {
            InitializeComponent();
            _signUpViewModel = new SignUpViewModel();
            BindingContext = _signUpViewModel;
            _signUpViewModel.FocusRequested += OnFocusRequested; // ViewModel 에서할당받는 FocusRequest
        }

        protected override async void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);

            _signUpViewModel.ResetFields();
             
        }

        /// <summary>
        /// OnFocusRequested : ViewModel 에서 할당받는 이벤트
        /// </summary>
        /// <param name="focusName">요소명</param>
        private void OnFocusRequested(string focusName)
        {
            // UI 스레드에서 포커스 주기

            ((Entry)(FindByName(focusName))).Focus();
        }


    }
}
