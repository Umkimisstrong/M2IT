namespace Rutinus.Global
{
    /// <summary>
    /// GlobalSystemSettings : 시스템 변수 
    /// </summary>
    public class GlobalSystemSettings
    {
        public string SystemName { get; set; } = string.Empty;
        public string SystemMail { get; set; } = string.Empty;
        public string SystemPwd { get; set; } = string.Empty;

        public string SystemHost { get; set; } = string.Empty;
        public int SystemPort { get; set; } = 0;
    }
}
