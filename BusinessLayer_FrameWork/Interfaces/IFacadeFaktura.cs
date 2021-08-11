using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities_FrameWork.Models;

// Bygger specifikt gränssnitt och implementerar datan från respektive modul. 
// Användaren kan göra specfika val utan att påverka alla subklasser.

namespace BusinessLayer_FrameWork.Interfaces
{
    public interface IFacadeFaktura
    {
        public List<Faktura> GetAllFakturor();
        public List<Faktura> GetAllFakturaShop();
        public List<Faktura> GetAllFakturaLogi();
        public Faktura SkickaDelFaktura(Bokning bokning);
        public void FakturaShopTillUtskrift(Faktura f);
        public Faktura UthyrningsFakturaPrivat(double pris, string typ, Uthyrning u, PrivatKund pk, DateTime start, DateTime slut);
        public Faktura BokningFakturaPrivat(double pris, string typ, Bokning b, PrivatKund pk, DateTime start, DateTime slut);
        public void BokningFakturaFöretag(double pris, string typ, Bokning b, FöretagsKund fk, DateTime start, DateTime slut);
        public Faktura FakturaKonferens(double pris, string typ, Bokning b, FöretagsKund fk, DateTime start, DateTime slut);
        public Faktura SkidlektionFakturaprivat(DateTime start, DateTime slut, PrivatKund pk, string typ, int antalTimmar, int antalDeltagare);
        public List<Faktura> FakturorTillLog();
        public List<Faktura> GetEjUtskrivna();
        public void ÄndraStatusFaktura(Faktura faktura);





    }
}


