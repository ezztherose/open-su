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
    public interface IFacadePreBokning
    {
        public void Add(PreBokning pre);
        public List<Logi> HämtaLogiPreBokning(PrivatKund privatKund, PreBokning pre);
        public void TaBortFkFrånPre(PreBokning pre);
        public List<PreBokning> GetAllPreBokning();
        public List<PreBokning> SearchPreBokning(string search);
        public void RemovePreBokning(PreBokning pre);
        public Bokning PreBokningTillBokning(Bokning bk, PreBokning pre, int ID);
        public void BokningPrivatPre(double pris, string typ, PreBokning pb, int ID, DateTime start, DateTime slut);
        public PrivatKund HämtaPrivatKund(int ID);
        public PreBokning HämtaPreBokning(int ID);
        public PrivatKund HittaKund(int id);
        public void BokningFöretagPre(double pris, string typ, PreBokning pb, int ID, DateTime start, DateTime slut);
        public Bokning FöretagPreBokningTillBokning(Bokning bk, PreBokning pre, int ID);
        public Faktura FakturaPreBokning(Bokning bk, PreBokning pre, int ID);
        public Faktura FöretagPreBokningFaktura(Bokning bk, int ID);
        public FöretagsKund HittaFöretagsKundTillPreBokning(PreBokning pre);
        public void AvslåPreBokning(PreBokning pre);
        public PrivatKund HittaPrivatKundTillPreBokning(PreBokning pre);
        public void SparaPreBokning();
        public void UpdatePreBoking(PreBokning pre, int id);
        public PreBokning GetPrebokningToBokning(PreBokning pre);
        public List<Konferens> HämtaKonferensPreBokningFöretag(FöretagsKund fk, PreBokning pre);
    }
}



