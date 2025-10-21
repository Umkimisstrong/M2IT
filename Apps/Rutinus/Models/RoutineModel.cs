using Rutinus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rutinus.Models
{
    public class RoutineModel
    {
        public int RoutineId { get; set; }
        public string RoutineName { get; set; } = "";
        public string RoutineDescription { get; set; } = "";
        public string RoutinePart { get; set; } = "";
        public string RoutinePartName { get; set; } = "";
        public bool AlertEnabled => AlertYn == "Y";
        public string AlertYn { get; set; } = "N";
    }
}
