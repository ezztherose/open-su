using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities_FrameWork.Models;
using BusinessLayer_FrameWork;

namespace GUI_Framework_v2
{
    // En klass för bokningar för logi 
    internal class BokningarClass
    {
        public int BokningsID { get; set; }
        public DateTime InCheckningsDatum { get; set; }
        public DateTime UtCheckningsDatum { get; set; }
        public string BokningsTyp { get; set; }
        public double BokningsPris { get; set; }
        public double Moms { get; set; }
    }
}
