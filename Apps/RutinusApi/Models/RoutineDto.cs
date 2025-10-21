using RutinusApi.Entities;

namespace RutinusApi.Models
{
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
