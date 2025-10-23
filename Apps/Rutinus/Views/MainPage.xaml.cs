namespace Rutinus
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (!((App)Application.Current).IsUserLoggedIn() )
            {
                DisplayAlert("알림", "로그인 후 이용 가능합니다.", "확인");
                Shell.Current.GoToAsync("///LoginPage");
            }
        }

        private async void OnRoutineCreate_Click(object? sender, EventArgs e)
        {
            //await Navigation.PushAsync(new RoutineList());
            await Shell.Current.GoToAsync("///RoutineList");
        }

       
        private async void OnTodayExcercise_Click(object? sender, EventArgs e)
        {
            bool confirmed = await DisplayAlert("확인", "운동기록을 하시겠습니까?", "예", "아니오");
            if (confirmed)
            {

            }
        }

        private async void OnHistory_Click(object? sender, EventArgs e)
        {
            bool confirmed = await DisplayAlert("확인", "히스토리보시겠습니까?", "예", "아니오");
            if (confirmed)
            {

            }
        }

    }
}
