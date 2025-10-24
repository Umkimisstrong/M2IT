namespace Rutinus.Models
{
    /// <summary>
    /// ScheduleModel : 일정 테이블과 매치
    /// </summary>
    public class ScheduleModel
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
