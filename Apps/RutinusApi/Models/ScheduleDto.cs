namespace RutinusApi.Models
{
    /// <summary>
    /// ScheduleDto : 통신에 사용될 일정 모델
    /// </summary>
    public class ScheduleDto
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
    }
}
