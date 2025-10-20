using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RutinusApi.Tables
{
    [Table("tb_rtn_routine")]  // MySQL 테이블 이름
    public class Routine
    {
        [Key]
        [Column("ROUTINE_ID")]
        public int RoutineId { get; set; }

        [Column("ROUTINE_NM")]
        public string RoutineName { get; set; } = string.Empty;

        [Column("ROUTINE_DESC")]
        public string RoutineDesc { get; set; } = string.Empty;

        [Column("ROUTINE_PART")]
        public string RoutinePart { get; set; } = string.Empty;

        [Column("ROUTINE_ALERT_YN")]
        public string RoutineAlertYn { get; set; } = string.Empty;

        [Column("ROUTINE_CREATE_ID")]
        public string RoutineCreateId { get; set; } = string.Empty;

        [Column("ROUTINE_CREATE_DT")]
        public DateTime RoutineCreateDt { get; set; } = DateTime.Now;

        [Column("ROUTINE_UPDATE_ID")]
        public string RoutineUpdateId { get; set; } = string.Empty;

        [Column("ROUTINE_UPDATE_DT")]
        public DateTime RoutineUpdateDt { get; set; } = DateTime.Now;

        /*
        public int ROUTINE_ID { get; set; }
        public string ROUTINE_NM { get; set; }
        public string ROUTINE_DESC { get; set; }
        public string ROUTINE_PART { get; set; }
        public string ROUTINE_ALERT_YN { get; set; }
        public string ROUTINE_CREATE_ID { get; set; }
        public DateTime ROUTINE_CREATE_DT { get; set; }
        public string ROUTINE_UPDATE_ID { get; set; }
        public DateTime ROUTINE_UPDATE_DT { get; set; }
        
         */
    }
}
