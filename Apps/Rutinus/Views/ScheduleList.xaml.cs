using CommunityToolkit.Maui.Extensions;
using Rutinus.Models;
using Rutinus.ViewModels;
using System.Threading.Tasks;

namespace Rutinus
{
    public partial class ScheduleList : ContentPage
    {

        public string? RoutineId { get; set; }
        private string _loginUserId = string.Empty;

        public ScheduleList()
        {
            InitializeComponent();
            _loginUserId = ((App)(Application.Current)).CurrentUser.LoginUserId;
        }

        private void CreateScheduleBtn_Clicked(object sender, EventArgs e)
        {
            if (BindingContext is ScheduleListViewModel vm)
            { 
                var selectedDate= vm.SelectedDate;
                string ymd = selectedDate.Date.ToString("yyyyMMdd");
                ScheduleSave popUp = new ScheduleSave(ymd, _loginUserId);
                this.ShowPopup(popUp);
            }
            
            
        }
    }
}
