using Rutinus.Models;

namespace Rutinus
{
    public partial class App : Application
    {
        public AppLoginUserInfo CurrentUser { get; set; }
      
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = new Window(new AppShell());

            // 앱 실행 시 로그인 상태에 따라 이동
            window.Created += async (_, _) =>
            {
                if (IsUserLoggedIn())
                {
                    // 로그인된 상태 → 메인페이지로 바로 이동
                    await Shell.Current.GoToAsync("//MainPage");
                }
                else
                {
                    // 로그인 안 됨 → 로그인 페이지로 이동
                    await Shell.Current.GoToAsync("//LoginPage");
                }
            };

            return window;
        }

        public void Logout()
        {
            CurrentUser = null;
            // 로그아웃 시 로그인 페이지로 이동
            Shell.Current.GoToAsync("//LoginPage");
        }

        public bool IsUserLoggedIn()
        {
            return CurrentUser != null;
        }

    }
}