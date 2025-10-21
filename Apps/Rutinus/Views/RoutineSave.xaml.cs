using Rutinus.Models;
using Rutinus.Services;
using Rutinus.ViewModels;

namespace Rutinus
{
    [QueryProperty(nameof(RoutineIdString), "routineId")]
    public partial class RoutineSave : ContentPage
    {
        public string? RoutineIdString { get; set; }
        private int? _parsedRoutineId;
        int count = 0;
        private readonly RoutineViewModel _routineViewModel;


        public RoutineSave()
        {
            InitializeComponent();
            _routineViewModel = new RoutineViewModel();
            BindingContext = _routineViewModel;
        }

        protected override async void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);

            if (int.TryParse(RoutineIdString, out var id))
            {
                Title = "Update";
                await _routineViewModel.LoadRoutineAsync(id);
            }
            else
            {
                Title = "Create";
                _routineViewModel.ResetFields();
            }
        }

        /*
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (int.TryParse(RoutineIdString, out var id))
            {
                _parsedRoutineId = id;
                await _routineViewModel.LoadRoutineAsync(id);  // ViewModel에 ID 전달
                Title = "루틴 수정";
            }
            else
            {
                Title = "루틴 생성";
            }
        }
        */

    }
}
