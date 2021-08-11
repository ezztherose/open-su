using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities_FrameWork.Models;
using BusinessLayer_FrameWork;

namespace GUI_Framework_v2
{
   internal class PrivatKundRegisterClass
    {
        public string PrivatFörnamn { get; set; }
        public string PrivatEfternamn { get; set; }
        public string PrivatGatuadress { get; set; }
        public string PrivatPostnummer { get; set; }
        public string PrivatPostort { get; set; }
        public string PrivatTelefonnummer { get; set; }
        public string PrivatEpostadress { get; set; }

        public PrivatKundRegisterClass()
        {

        }
    }
}
