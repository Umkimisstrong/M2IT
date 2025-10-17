using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rutinus.ViewModels
{
    public partial class RoutineViewModel : ObservableObject
    {
        [ObservableProperty] string routineName;
        [ObservableProperty] string description;
        [ObservableProperty] DateTime startDate = DateTime.Today;

        [ObservableProperty] double defaultWeight = 20;

        [ObservableProperty] bool receiveNotifications = true;

        [ObservableProperty] List<string> bodyParts = new() { "가슴", "등", "하체", "어깨", "팔" };
        [ObservableProperty] string selectedBodyPart;
        [ObservableProperty] string bodyPart;


    }
}
