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
        public DateTime? NoticeDt { get; set; }
        public DateTime? StartDt { get; set; }
        public DateTime? EndDt { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
