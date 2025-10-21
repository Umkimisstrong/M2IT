namespace RutinusApi.Models
{
    /// <summary>
    /// CodeDto : 통신에 사용될 코드 모델
    /// </summary>
    public class CodeDto
    {
        public string SysCd { get; set; } = string.Empty;
        public string DivCd { get; set; } = string.Empty;
        public string Cd { get; set; } = string.Empty;
        public string CdNm { get; set; } = string.Empty;
        public string UseYn { get; set; } = string.Empty;
        public int SortOrder { get; set; } = 0;

    }
}
