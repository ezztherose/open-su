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
    public interface IFacadeHyrpris
    {
        public double GetUtrustningsHyrpris(string dagar, string sort, string typ);
        public List<Hyrpris> HämtaAllaHyrpris();
        void UppdateraHyrpris(Hyrpris hyrpris, int hyrPirsID);
    }
}
