using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities_FrameWork.Models;
using BusinessLayer_FrameWork;

namespace GUI_Framework_v2
{
    internal class ButiksregisterClass
    {
        public int ArtikelID { get; set; }
        public string UtrustningSort { get; set; } // alpint
        public string UtrustningsTyp { get; set; } // pjäxor
        public bool Tillgänglig { get; set; }
    }
}
