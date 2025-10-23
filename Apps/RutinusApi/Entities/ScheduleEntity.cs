using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RutinusApi.Entities
{
    [Table("tb_scd_schedule")]
    public class ScheduleEntity
    {
        [Key]
        [Column("SCHEDULE_ID")]
        public int ScheduleId { get; set; } = 0;
        [Column("ROUTINE_ID")]
        public int RoutineId { get; set; } = 0;
        [Column("SCHEDULE_YMD")]
        public string ScheduleYmd { get; set; } = "";
        [Column("SCHEDULE_HMS")]
        public string ScheduleHms { get; set; } = "";
        [Column("SCHEDULE_USER")]
        public string ScheduleUser { get; set; } = "";
        [Column("NOTICE_DT")]
        public DateTime? NoticeDt { get; set; }
        [Column("START_DT")]
        public DateTime? StartDt { get; set; }
        [Column("END_DT")]
        public DateTime? EndDt { get; set; }
        [Column("CREATE_ID")]
        public string CreatedBy { get; set; } = "";

        [Column("CREATE_DT")]
        public DateTime CreatedAt { get; set; }

        [Column("UPDATE_ID")]
        public string UpdatedBy { get; set; } = "";

        [Column("UPDATE_DT")]
        public DateTime? UpdatedAt { get; set; }

    }
}
