using System.ComponentModel.DataAnnotations.Schema;

namespace RutinusApi.Entities
{
    /// <summary>
    /// CodeEntity : 코드 테이블
    /// </summary>
    [Table("tb_cmm_code")]
    public class CodeEntity
    {
        [Column("SYS_CD")]
        public string SysCd { get; set; } = string.Empty;
        [Column("DIV_CD")]
        public string DivCd { get; set; } = string.Empty;
        [Column("CD")]
        public string Cd { get; set; } = string.Empty;
        [Column("CD_NM")]
        public string CdNm { get; set; } = string.Empty;
        [Column("USE_YN")]
        public string UseYn { get; set; } = string.Empty;
        [Column("SORT_ORDER")]
        public int SortOrder { get; set; } = 0;
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
