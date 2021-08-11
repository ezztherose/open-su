using BusinessEntities_FrameWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Bygger specifikt gränssnitt och implementerar datan från respektive modul. 
// Användaren kan göra specfika val utan att påverka alla subklasser.

namespace BusinessLayer_FrameWork.Interfaces
{
    public interface IFacadeLogi
    {
        public List<Logi> GetAllLedigaLägenheter();
        public List<Logi> GetAllLogiPris();
        public List<Logi> GetAllLogi();
        public void RemoveLogidata(Logi Logi);
        public int HämtaLogiPåTyp(string lägenhetstyp);
        public List<Logi> LogiPåBokningsID(Bokning Bokning);
        public List<Logi> SearchLogi(string search);
        public List<Logi> GetTillgängligStor();
        public List<Logi> GetTillgängligLiten();
        Logi HämtaLogi(string logityp);
        public List<Logi> GetAllCamping();
    }
}
