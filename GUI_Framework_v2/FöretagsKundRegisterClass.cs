using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities_FrameWork.Models;
using BusinessLayer_FrameWork;

namespace GUI_Framework_v2
{   // En klass för register av företagskunder 
    internal class FöretagsKundRegisterClass
    {
        public string Företagsnamn { get; set; }
        public string OrgNummer { get; set; }
        public string FöretagTelefonNummer { get; set; }
        public string FöretagEpostadress { get; set; }
        public string Gatuadress { get; set; }
        public string FöretagPostnummer { get; set; }
        public string FöretagPostort { get; set; }
        public string Faktureringsadress { get; set; }
        public string FöretagFaktureringPostnummer { get; set; }
        public string FöretagFaktureringPostort { get; set; }

        public FöretagsKundRegisterClass()
        {

        }
    }
}
