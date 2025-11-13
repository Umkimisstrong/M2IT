using CommunityToolkit.Mvvm.ComponentModel;

namespace Rutinus.Models
{
    /// <summary>
    /// ScheduleModel : 일정 테이블과 매치
    /// </summary>
    public class ScheduleModel : ObservableObject
    {
        public int ScheduleId { get; set; } = 0;
        public int RoutineId { get; set; } = 0;
        public string ScheduleYmd { get; set; } = string.Empty;
        public string ScheduleHms { get; set; } = string.Empty;
        public string ScheduleUser { get; set; } = string.Empty;

        public string RoutineName { get; set; } = "";
        public string RoutineDescription { get; set; } = "";
        public string RoutinePart { get; set; } = "";
        public string AlertYn { get; set; } = "N";
        public string RoutinePartName { get; set; } = "";

        public int TrainingId { get; set; } = 0;
        public string TrainingNm { get; set; } = "";
        public string TrainingDesc { get; set; } = "";
        public string TrainingCd { get; set; } = "";
        public string TrainingCdName { get; set; } = "";
        public int TrainingSet { get; set; } = 0;
        public int TrainingReps { get; set; } = 0;
        public int TrainingWeight { get; set; } = 0;

        public DateTime? NoticeDt { get; set; }
        public DateTime? StartDt { get; set; }
        public DateTime? EndDt { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // 팝업에서 사용하기 위한 추가 속성
        public bool IsSelected { get; set; } = false;
        public List<string> TimeSlots { get; set; } = new();
        public List<string> Trainings { get; set; } // ex: ["벤치프레스", "덤벨프레스", "펙덱플라이"]
    }
}
