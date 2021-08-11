using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities_FrameWork.Models;
using BusinessLayer_FrameWork.Interfaces;
using DataLayer_FrameWork.Context;
using DataLayer_FrameWork.UnitOfWork;

//Klient kallar på facade, vilket skapar startup struktur för företagskund -> bygg design. 

namespace BusinessLayer_FrameWork.Models
{
    public class FacadeFöretagsKund : IFacadeFöretagsKund
    {
        public UnitOfWork UnitOfWork { get; set; }
        private double _tax = 1.12;

        public FacadeFöretagsKund(DatabaseContext context)
        {
            UnitOfWork = new UnitOfWork(context);
        }

        public void LäggTillKund(FöretagsKund nyKund)
        {
            UnitOfWork.FöretagsKundRepository.Add(nyKund);
            UnitOfWork.Complete();
        }
        public void RemoveFöretagsKund(FöretagsKund företagsKund)
        {
            List<Faktura> ListaFaktura = UnitOfWork.FakturaRepository.GetAll().ToList();
            List<Uthyrning> ListaUthyrningar = UnitOfWork.UthyrningRepository.GetAll().ToList();
            List<Bokning> BokningarLista = UnitOfWork.BokningRepository.GetAll().ToList();

            for (int i = 0; i < ListaFaktura.Count; i++)
                if (ListaFaktura[i].Företag == företagsKund)
                    ListaFaktura[i].Privat = null;

            for (int i = 0; i < ListaUthyrningar.Count; i++)
                if (ListaUthyrningar[i].FöretagsKund == företagsKund)
                    ListaUthyrningar[i].PrivatKund = null;

            for (int i = 0; i < BokningarLista.Count; i++)
                if (BokningarLista[i].FöretagsKund == företagsKund)
                    BokningarLista[i].FöretagsKund = null;

            företagsKund.Bokningar = null;
            företagsKund.Fakturor = null;
            FöretagsKund fk = UnitOfWork.FöretagsKundRepository.TaBortFöretagsKund(företagsKund);
            UnitOfWork.FöretagsKundRepository.Update(företagsKund, företagsKund.FöretagKundID);
            UnitOfWork.Complete();
            UnitOfWork.BokningRepository.RemoveföretagsKund(företagsKund, företagsKund.FöretagKundID);
            UnitOfWork.Complete();
        }

        public List<FöretagsKund> GetAllFöretagKunder()
        {
            List<FöretagsKund> företagsKunder = new List<FöretagsKund>();
            företagsKunder.AddRange(UnitOfWork.FöretagsKundRepository.GetAll());
            return företagsKunder;
        }
       
        public List<FöretagsKund> SearchFöretagsKund(string search)
        {
            List<FöretagsKund> kundListaFöretag = new List<FöretagsKund>();
            foreach (FöretagsKund företagsKund in UnitOfWork.FöretagsKundRepository.SearchFöretagsKund(search.ToLower()))
                kundListaFöretag.Add(företagsKund);
            return kundListaFöretag;
        }

        public bool KontrolleraRabatt(FöretagsKund fk)
        {
            if (fk.FöretagRabatt > 0)
            {
                return true;
            }
            return false;
        }

        public void UppdateraFöretagsKund(FöretagsKund företagsKund, int företagKundID)
        {
            UnitOfWork.FöretagsKundRepository.Update(företagsKund, företagKundID);
            UnitOfWork.Complete();
        }

        public FöretagsKund HämtaFöretagsKund(int ID)
        {
            return UnitOfWork.FöretagsKundRepository.Get(ID);
        }

        /*
         * RÖR EJ!!!!!
         * Prisuträkningar och borttagning av konferens eller logi 
         */
        #region Prisuträkningar och borttagning från listor
        public List<Logi> RemoveLogiFromList(List<Logi> LogiList, Logi item)
        {
            LogiList.Remove(item);
            return LogiList;
        }

        public List<Konferens> RemoveKonferensFromList(List<Konferens> KonferensList, Konferens item)
        {
            KonferensList.Remove(item);
            return KonferensList;
        }

        private double AdditionDouble(double x, double y)
        {
            return x + y;
        }

        public double RecalcualtePrice(List<Logi> LogiList, List<Konferens> KonferensList)
        {
            double netto = 0;
            double logiNetto = LogiPriceFromList(LogiList);
            double konferenceNetto = KonferensPriceFromList(KonferensList);
            netto = AdditionDouble(logiNetto, konferenceNetto);
            return netto;
        }

        private double LogiPriceFromList(List<Logi> LogiList)
        {
            double price = 0;
            if (LogiList == null) return 0;
            for (int i = 0; i < LogiList.Count; i++)
                price += LogiList[i].LogiPris;
            return price;
        }

        private double KonferensPriceFromList(List<Konferens> KonferensList)
        {
            double price = 0;
            if (KonferensList == null) return 0;
            for (int i = 0; i < KonferensList.Count; i++)
                price += KonferensList[i].Pris;
            return price;
        }

        public double GetTaxOnPrice(double netto)
        {
            double brutto = 0;
            brutto = netto * _tax;
            return brutto;
        }

        public double GetTax(double netto)
        {
            double taxing = 0;
            taxing = netto * (_tax - 1);
            return taxing;
        }

        public double GetCompanyDiscount(FöretagsKund fk)
        {
            double _decimal = 0;
            if (fk != null)
            {
                _decimal = ConvertFromProcentToDecimal(fk.FöretagRabatt);
                return _decimal;
            }
            return 0;
        }

        private double ConvertFromProcentToDecimal(double procent)
        {
            double discount = 0;
            discount = (100 - procent) / 100;
            return discount;
        }

        public double CalculateDiscount(double brutto, double discount)
        {
            double price = 0;
            price = brutto * discount;
            return price;
        }
        #endregion

    }
}

