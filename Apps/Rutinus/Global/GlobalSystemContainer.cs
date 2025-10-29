using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rutinus.Global
{
    /// <summary>
    /// GlobalSystemContainer : 시스템 변수를 담는 전역 클래스
    /// </summary>
    public class GlobalSystemContainer
    {
        public GlobalSystemSettings GlobalSystemSettings { get; set; } = new GlobalSystemSettings();
    }
}
