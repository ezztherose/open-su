using BusinessLayer_FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_Framework_v2
{   // Klass för register av fakturor 
    internal class FakturaRegisterClass
    {
        public int FakturaID { get; set; }
        public double Pris { get; set; }
        public string Status { get; set; }
        public DateTime FaktureringsDatum { get; set; }
        public DateTime FörfalloDatum { get; set; }
    }
}
