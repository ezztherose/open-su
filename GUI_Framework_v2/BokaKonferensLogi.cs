using BusinessEntities_FrameWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_Framework_v2
{   // En klass för bokning av konferens 
    internal class BokaKonferensLogi
    {

        public BokaKonferensLogi()
        {
           
        }
        public string Typ { get; set; }
        public double Pris { get; set; }
        public string Vecka { get; set; }
        public int Id { get; set; }



    }
}
