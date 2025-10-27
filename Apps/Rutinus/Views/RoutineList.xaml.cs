using Rutinus.Models;
using Rutinus.ViewModels;
using System.Threading.Tasks;

namespace Rutinus
{
    public partial class RoutineList : ContentPage
    {
        private RoutineListViewModel _viewModel;
        public RoutineList()
        {
            InitializeComponent();
            _viewModel = new RoutineListViewModel();
            BindingContext = _viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (!((App)Application.Current).IsUserLoggedIn())
            {
                DisplayAlert("알림", "로그인 후 이용 가능합니다.", "확인");
                Shell.Current.GoToAsync("///LoginPage");
            }

            if (_viewModel.Routines.Count == 0)
                _viewModel.RefreshCommand.Execute(null);
            
        }

        private async void OnRoutineSelected(object sender, SelectionChangedEventArgs e)
        {
            var selected = e.CurrentSelection.FirstOrDefault();
            if (selected is not null)
            {
                await DisplayAlert("루틴 선택", "선택한 루틴을 확인했습니다.", "확인");
                ((CollectionView)sender).SelectedItem = null;
            }
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///RoutineSave");
        }
    }
}
