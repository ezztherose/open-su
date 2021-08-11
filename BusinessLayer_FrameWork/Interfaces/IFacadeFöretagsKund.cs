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
    public interface IFacadeFöretagsKund
    {
        public void LäggTillKund(FöretagsKund nyKund);
        public List<FöretagsKund> GetAllFöretagKunder();
        public List<FöretagsKund> SearchFöretagsKund(string search);
        public void UppdateraFöretagsKund(FöretagsKund företagsKund, int företagsKundID);
        public FöretagsKund HämtaFöretagsKund(int ID);
        public bool KontrolleraRabatt(FöretagsKund fk);
        public void RemoveFöretagsKund(FöretagsKund företagsKund);

        //------------------- NYA PRIS OCH TABORT METODER ---------------------
        public List<Logi> RemoveLogiFromList(List<Logi> LogiList, Logi item);
        public List<Konferens> RemoveKonferensFromList(List<Konferens> KonferensList, Konferens item);
        public double RecalcualtePrice(List<Logi> LogiList, List<Konferens> KonferensList);
        public double GetTaxOnPrice(double netto);
        public double GetTax(double netto);
        public double GetCompanyDiscount(FöretagsKund fk);
        public double CalculateDiscount(double brutto, double discount);
    }
}

