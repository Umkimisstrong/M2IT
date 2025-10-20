using Rutinus.ViewModels;
using System.Threading.Tasks;

namespace Rutinus
{
    public partial class RoutineList : ContentPage
    {
        int count = 0;

        public RoutineList()
        {
            InitializeComponent();
            BindingContext = new RoutineListViewModel();
        }

        private async void OnRoutineSelected(object sender, SelectionChangedEventArgs e)
        {
            var selected = e.CurrentSelection.FirstOrDefault() as RoutineViewModel;
            if (selected is not null)
            {
                // 페이지 이동 또는 상세 보기 처리
                await DisplayAlert("루틴 선택", $"{selected.RoutineName} 루틴을 선택했습니다", "확인");

                // 선택 초기화 (선택된 상태 유지 안 하도록)
                ((CollectionView)sender).SelectedItem = null;
            }
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new RoutineSave());
            await Shell.Current.GoToAsync("///RoutineSave");

        }
    }
}
