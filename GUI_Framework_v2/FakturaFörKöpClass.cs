using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities_FrameWork.Models;
using BusinessLayer_FrameWork;


namespace GUI_Framework_v2
{   // Klass för faktura 
    internal class FakturaFörKöpClass
    {
        public int FakturaID { get; set; }
        public double Pris { get; set; }
        public DateTime FaktureringsDatum { get; set; }
        public DateTime FörfalloDatum { get; set; }
        public string Typ { get; set; }
        public bool Status { get; set; }
    }
}
