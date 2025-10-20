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
        /// <summary>
        /// routineId : 루틴 id
        /// </summary>
        public string routineId { get; set; }
        /// <summary>
        /// routineName : 루틴명
        /// </summary>
        public string routineName {get; set;}
        /// <summary>
        /// description : 설명
        /// </summary>
        public string description {get; set;}
        /// <summary>
        /// startDate : 시작일
        /// </summary>
        public DateTime startDate {get; set;}
        /// <summary>
        /// defaultWeight : 기본중량
        /// </summary>
        public double defaultWeight {get; set;}
        /// <summary>
        /// receiveNotifications : 알림받기여부
        /// </summary>
        public bool receiveNotifications {get; set;}
        /// <summary>
        /// bodyParts : 부위 목록
        /// </summary>
        public List<string> bodyParts {get; set;}
        /// <summary>
        /// selectedBodyPart : 선택한 부위
        /// </summary>
        public string selectedBodyPart {get; set;}
        /// <summary>
        /// bodyPart : 부위
        /// </summary>
        public string bodyPart { get; set; }
    }
}
