namespace Rutinus.Models
{
    /// <summary>
    /// RoutineModel : 루틴 테이블과 매치
    /// </summary>
    public class RoutineModel
    {
        public int RoutineId { get; set; }
        public string RoutineName { get; set; } = "";
        public string RoutineDescription { get; set; } = "";
        public string RoutinePart { get; set; } = "";
        public string RoutinePartName { get; set; } = "";
        public bool AlertEnabled => AlertYn == "Y";
        public string AlertYn { get; set; } = "N";

        public string CreatedBy { get; set; } = "";
        public string UpdatedBy { get; set; } = "";

    }
}
