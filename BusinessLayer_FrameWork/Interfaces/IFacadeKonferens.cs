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
    public interface IFacadeKonferens
    {
        public List<Konferens> GetAllKonferens();
        public void RemoveKonferensInfo(Konferens Konferens);
        public List<Konferens> SearchKonferens(string search);
        public void RemoveAllKonferens(List<Konferens> Konferens);
        double GetPrisKonferens(string konferensTyp, string tidTyp, int veckaKonferens);
        public List<Konferens> GetKonferensLiten();
        public List<Konferens> GetKonferensStor();
        public List<Konferens> KonferensPåBokningsID(Bokning bokning);

    }
}
