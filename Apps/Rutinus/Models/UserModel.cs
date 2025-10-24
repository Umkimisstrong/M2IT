namespace Rutinus.Models
{
    /// <summary>
    /// UserModel : 유저 테이블과 매치
    /// </summary>
    public class UserModel
    {
        public string UserId { get; set; } = string.Empty;
        public string UserNm { get; set; } = string.Empty;
        public string UserPwd { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public DateTime? TrialDt { get; set; }
        public DateTime? ActivatedDt { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedAt { get; set; }
    }
}
