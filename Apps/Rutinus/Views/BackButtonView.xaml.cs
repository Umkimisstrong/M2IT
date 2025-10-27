using Rutinus.ViewModels;

namespace Rutinus
{
    public partial class BackButtonView : ContentView
    {


        public BackButtonView()
        {
            InitializeComponent();
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PopAsync();
        }

    }
}
