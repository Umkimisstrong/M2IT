using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RutinusApi.Entities
{
    [Table("tb_rtn_routine")]
    public class RoutineEntity
    {
        [Key]
        [Column("ROUTINE_ID")]
        public int RoutineId { get; set; }

        [Column("ROUTINE_NM")]
        public string RoutineName { get; set; } = "";

        [Column("ROUTINE_DESC")]
        public string RoutineDescription { get; set; } = "";

        [Column("ROUTINE_PART")]
        public string RoutinePart { get; set; } = "";

        [Column("ROUTINE_ALERT_YN")]
        public string AlertYn { get; set; } = "N";

        [Column("ROUTINE_CREATE_ID")]
        public string CreatedBy { get; set; } = "";

        [Column("ROUTINE_CREATE_DT")]
        public DateTime CreatedAt { get; set; }

        [Column("ROUTINE_UPDATE_ID")]
        public string UpdatedBy { get; set; } = "";

        [Column("ROUTINE_UPDATE_DT")]
        public DateTime UpdatedAt { get; set; }
    }
}
