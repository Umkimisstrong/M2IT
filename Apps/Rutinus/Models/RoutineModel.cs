using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace Rutinus.Models
{
    /// <summary>
    /// RoutineModel : 루틴 테이블과 매치
    /// </summary>
    public partial class RoutineModel : ObservableObject
    {
        public int RoutineId { get; set; }
        public string RoutineName { get; set; } = "";
        public string RoutineDescription { get; set; } = "";
        public string RoutinePart { get; set; } = "";
        public string RoutinePartName { get; set; } = "";
        public bool AlertEnabled => AlertYn == "Y";
        public string AlertYn { get; set; } = "N";

        public string CreatedBy { get; set; } = "";
        public string UpdatedBy { get; set; } = "";

        [ObservableProperty]
        private ObservableCollection<TrainingModel> trainings = new();


        // 팝업에서 사용하기 위한 추가 속성
        public bool IsSelected { get; set; } = false;
    }
}
