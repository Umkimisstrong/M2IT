using Rutinus.ViewModels;

namespace Rutinus
{
    public partial class LoginPage : ContentPage
    {

        private readonly LoginViewModel _loginViewModel;

        public LoginPage()
        {
            InitializeComponent();
            _loginViewModel = new LoginViewModel();
            BindingContext = _loginViewModel;
        }

    

    }
}
