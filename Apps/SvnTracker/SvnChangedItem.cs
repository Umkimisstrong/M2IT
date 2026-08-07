using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvnTracker
{
    public class SvnChangedItem
    {
        public string path { get; set; }

        public string fileName { get; set; }

        public string status { get; set; }

        public string modifyNm { get; set; }

        public DateTime modifyTime { get; set; }

        /*
         path
         fileName
         status
         modifyNm
         modifyTime
         */
    }


}
