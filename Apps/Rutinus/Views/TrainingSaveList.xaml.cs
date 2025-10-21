using Rutinus.Models;
using Rutinus.ViewModels;
using System.Threading.Tasks;

namespace Rutinus
{
    [QueryProperty(nameof(RoutineId), "routineId")]
    public partial class TrainingSaveList : ContentPage
    {
        private TrainingSaveListViewModel _viewModel = new();

        public string? RoutineId { get; set; }

        public TrainingSaveList()
        {
            InitializeComponent();
            BindingContext = _viewModel;
        }

        protected override async void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);

            if (int.TryParse(RoutineId, out var id))
            {
                await _viewModel.InitializeAsync(id);
            }
            
        }
        /*
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (int.TryParse(RoutineId, out var id))
            {
                await _viewModel.InitializeAsync(id);
            }
        }
        */

    }
}
