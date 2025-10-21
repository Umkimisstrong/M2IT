namespace RutinusApi.Models
{
    /// <summary>
    /// RoutineDto : 통신에 사용될 루틴 모델
    /// </summary>
    public class RoutineDto
    {
        public int RoutineId { get; set; }
        public string RoutineName { get; set; } = "";
        public string RoutineDescription { get; set; } = "";
        public string RoutinePart { get; set; } = "";
        public string AlertYn { get; set; } = "N";
        public string RoutinePartName { get; set; } = "";
    }
}
