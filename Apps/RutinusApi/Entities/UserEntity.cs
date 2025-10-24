using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RutinusApi.Entities
{
    /// <summary>
    /// UserEntity : 유저 테이블
    /// </summary>
    [Table("tb_cmm_user")]
    public class UserEntity
    {
        [Key]
        [Column("USER_ID")]
        public string UserId { get; set; } = "";
        [Column("USER_NM")]
        public string UserNm { get; set; } = "";
        [Column("USER_PWD")]
        public string UserPwd { get; set; } = "";
        [Column("USER_EMAIL")]
        public string UserEmail { get; set; } = "";
        [Column("TRIAL_DT")]
        public DateTime? TrialDt { get; set; }
        [Column("ACTIVATED_DT")]
        public DateTime? ActivatedDt { get; set; }
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
