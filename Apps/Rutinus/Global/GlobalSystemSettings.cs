using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rutinus.Global
{
    public class GlobalSystemSettings
    {
        public string SystemName { get; set; } = string.Empty;
        public string SystemMail { get; set; } = string.Empty;
        public string SystemPwd { get; set; } = string.Empty;

        public string SystemHost { get; set; } = string.Empty;
        public int SystemPort { get; set; } = 0;
    }
}
