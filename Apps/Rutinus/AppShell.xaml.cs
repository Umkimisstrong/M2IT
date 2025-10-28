namespace Rutinus
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(SignUpPage), typeof(SignUpPage));
            Routing.RegisterRoute(nameof(RoutineSave), typeof(RoutineSave));
            Routing.RegisterRoute(nameof(RoutineList), typeof(RoutineList));
            Routing.RegisterRoute(nameof(TrainingSaveList), typeof(TrainingSaveList));
            Routing.RegisterRoute(nameof(RoutineList), typeof(RoutineList));
        }
    }
}
