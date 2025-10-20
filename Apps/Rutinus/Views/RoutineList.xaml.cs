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
