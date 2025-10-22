using System.ComponentModel.DataAnnotations.Schema;

namespace RutinusApi.Entities
{
    /// <summary>
    /// RuleEntity : 룰 테이블
    /// </summary>
    [Table("tb_cmm_rule")]
    public class RuleEntity
    {
        [Column("BODY_PART_CD")]
        public string BodyPartCd {  get; set; }
        [Column("RTN_CD")]
        public string RtnCd { get; set; }
        [Column("CREATE_ID")]
        public string CreatedBy { get; set; } = "";

        [Column("CREATE_DT")]
        public DateTime CreatedAt { get; set; }

        [Column("UPDATE_ID")]
        public string UpdatedBy { get; set; } = "";

        [Column("UPDATE_DT")]
        public DateTime UpdatedAt { get; set; }
    }
}
