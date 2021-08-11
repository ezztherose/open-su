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
    public interface IFacadeLogiPris
    {
        public void UppdateraLogiPris(LogiPris logiPris, int logiprisID);
        public List<LogiPris> GetAllLogiPris();
        public List<LogiPris> HämtaLogiPris();
        public double GetLogiPris(string logityp, int dagar, int vecka);
    }
}
