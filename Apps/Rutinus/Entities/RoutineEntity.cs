using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rutinus.Entities
{
    /// <summary>
    /// RoutineEntity : 루틴 엔티티
    /// </summary>
    public class RoutineEntity
    {
        public int ROUTINE_ID { get; set; }
        public string ROUTINE_NM { get; set; }
        public string ROUTINE_DESC { get; set; }
        public string ROUTINE_PART { get; set; }
        public string ROUTINE_ALERT_YN { get; set; }
        public string ROUTINE_CREATE_ID { get; set; }
        public DateTime ROUTINE_CREATE_DT { get; set; }
        public string ROUTINE_UPDATE_ID { get; set; }
        public DateTime ROUTINE_UPDATE_DT { get; set; }
    }
}
