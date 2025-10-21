namespace Rutinus.Models
{
    /// <summary>
    /// CodeModel : 코드 테이블과 매치
    /// </summary>
    public class CodeModel
    {
        public string SysCd { get; set; } = string.Empty;
        public string DivCd { get; set; } = string.Empty;
        public string Cd { get; set; } = string.Empty;
        public string CdNm { get; set; } = string.Empty;
        public string UseYn { get; set; } = string.Empty;
        public int SortOrder { get; set; } = 0;
    }
}
