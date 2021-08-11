using BusinessEntities_FrameWork.Models;
using BusinessLayer_FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_Framework_v2
{   // Klass för beläggningsstatistik
    internal class BelStatistikClass
    {
        public string Lägenhetstyp { get; set; }
        public int Tillgängliga { get; set; }
        public int Reserverade { get; set; }
        public int Månad { get; set; }


        public BelStatistikClass()
        {

        }
    }
}
