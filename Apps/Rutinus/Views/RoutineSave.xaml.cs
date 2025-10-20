using Rutinus.ViewModels;

namespace Rutinus
{
    public partial class RoutineSave : ContentPage
    {
        int count = 0;

        public RoutineSave()
        {
            InitializeComponent();
            BindingContext = new RoutineViewModel();
        }

    }
}
