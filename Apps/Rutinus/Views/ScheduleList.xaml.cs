using CommunityToolkit.Maui.Extensions;
using Rutinus.Models;
using Rutinus.ViewModels;
using System.Threading.Tasks;

namespace Rutinus
{
    public partial class ScheduleList : ContentPage
    {

        public string? RoutineId { get; set; }

        public ScheduleList()
        {
            InitializeComponent();
        }

        private void CreateScheduleBtn_Clicked(object sender, EventArgs e)
        {
            ScheduleSave popUp = new ScheduleSave();
            this.ShowPopup(popUp);
            
        }
    }
}
