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
    public interface IFacadeKonferensPris
    {
        public List<KonferensPris> HämtaKonferensPris();
        public void UppdateraKonferensPris(KonferensPris konferensPris, int konferensprisID);
    }
}
