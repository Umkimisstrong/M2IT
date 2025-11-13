using CommunityToolkit.Maui.Views;
using Rutinus.Models;
using Rutinus.ViewModels;
using System.Threading.Tasks;

namespace Rutinus
{
    public partial class ScheduleSave : Popup
    {
        private readonly string _scheduleYmd;
        private readonly string _scheduleUser;
        
        private List<ScheduleModel> _allRoutines = new();
        private List<ScheduleModel> _selectedRoutines = new();

        private readonly ScheduleSaveViewModel _scheduleSaveViewModel;
        public ScheduleSave()
        {
            InitializeComponent();
            _scheduleSaveViewModel = new ScheduleSaveViewModel();
            BindingContext = _scheduleSaveViewModel;
        }

        public ScheduleSave(string scheduleYmd, string scheduleUser)
        {
            InitializeComponent();
            _scheduleSaveViewModel = new ScheduleSaveViewModel();

            _scheduleYmd = scheduleYmd;
            _scheduleUser = scheduleUser;
            this.Opened += ScheduleSave_Opened;
            
            BindingContext = _scheduleSaveViewModel;
        }

        private async void ScheduleSave_Opened(object sender, EventArgs e)
        {
            await _scheduleSaveViewModel.InitLoadScheduleAsync(_scheduleYmd, _scheduleUser);
        }



        /// <summary>
        /// btnClose_Clicked : 닫기버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Clicked(object sender, EventArgs e)
        {
            this.CloseAsync();
        }


    }
}
