using Rutinus.Models;

namespace Rutinus
{
    public partial class App : Application
    {
        public AppLoginUserInfo CurrentUser { get; set; }

        public void Logout()
        { 
            CurrentUser= null;
            MainPage = new LoginPage();
        }

        public bool IsUserLoggedIn()
        {
            // 예: App.CurrentUser가 null인지 체크
            return CurrentUser != null;
        }

        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}