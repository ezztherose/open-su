using BusinessEntities_FrameWork.Models;
using BusinessLayer_FrameWork.Interfaces;
using DataLayer_FrameWork.Context;
using DataLayer_FrameWork.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Klient kallar på facade, vilket skapar startup struktur för bokning -> bygg design.

namespace BusinessLayer_FrameWork.Models
{
    public class FacadeBokning : IFacadeBokning
    {
        public UnitOfWork UnitOfWork { get; set; }
        public Utrustning TempUtrustning { get; set; }

        public FacadeBokning(DatabaseContext context)
        {
            UnitOfWork = new UnitOfWork(context);
            TempUtrustning = new Utrustning();
        }

        public List<Bokning> GetAllBokningar()
        {
            List<Bokning> bokningarList = new List<Bokning>();
            bokningarList.AddRange(UnitOfWork.BokningRepository.GetAll());
            return bokningarList;
        }

        public List<Bokning> SearchBokning(string search)
        {
            List<Bokning> bokningarList = new List<Bokning>();
            foreach (Bokning bokning in UnitOfWork.BokningRepository.SearchBokning(search.ToLower()))
                bokningarList.Add(bokning);
            return bokningarList;
        }

        public void BokaKonferens(DateTime _fråndatum,DateTime _tillDatum, string konferensTyp,double  konferensPris, FöretagsKund fk, Bokning b)
        {
            b.InCheckningsDatum = _fråndatum;
            b.UtCheckningsDatum = _tillDatum;
            b.BokningsTyp = konferensTyp;
            b.BokningsPris = (konferensPris * 1.12);
            b.FöretagsKund = fk;
            b.Moms = 0.12;
            b.Nettopris = konferensPris;
            b.Bruttopris = (konferensPris * 1.12);
            UnitOfWork.BokningRepository.Add(b);
            UnitOfWork.Complete();
        }

        public  DateTime veckaDatum(int year, int weekOfYear)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

            // Use first Thursday in January to get first week of the year as
            // it will never be in Week 52/53
            DateTime firstThursday = jan1.AddDays(daysOffset);
            var cal = CultureInfo.CurrentCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            var weekNum = weekOfYear;
            // As we're adding days to a date in Week 1,
            // we need to subtract 1 in order to get the right date for week #1
            if (firstWeek == 1)
            {
                weekNum -= 1;
            }

            // Using the first Thursday as starting week ensures that we are starting in the right year
            // then we add number of weeks multiplied with days
            var result = firstThursday.AddDays(weekNum * 7);

            // Subtract 3 days from Thursday to get Monday, which is the first weekday in ISO8601
            return result.AddDays(-3);
        }
        // This presumes that weeks start with Monday.
        // Week 1 is the 1st week of the year with a Thursday in it.

        public int GetVecka(DateTime time)
        {
          
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            // Return the week of our adjusted day
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }
        
        public List<Bokning> GetEjUtskrivnaBokningsbekräftelser()
        {
            return UnitOfWork.BokningRepository.GetEjUtskrivnaBokningsbekräftelser();
        }
        public void ÄndraStatusBokning(Bokning bokning)
        {
            if (bokning.Status != true) bokning.Status = true;
            UnitOfWork.BokningRepository.Update(bokning, bokning.BokningsID);
            UnitOfWork.Complete();
        }

        #region PreBokning Till Bokning

        public string PreToBoking()
        {
            string message;
            List<PreBokning> ToBoking = new List<PreBokning>();
            ToBoking = SortPreList();
            GenerateBokings(ToBoking);

            message = $"Antal prebokninger: {ToBoking.Count} är nu tillagda som Bokningar";
            return message;
        }

        public List<PreBokning> SortPreList()
        {
            List<PreBokning> temp = new List<PreBokning>();
            foreach (PreBokning item in UnitOfWork.PreBokningRepository.GetAll().ToList())
                if(item.Status == true) temp.Add(item);
            return temp;
        }

        private void GenerateBokings(List<PreBokning> temp)
        {
            for (int i = 0; i < temp.Count; i++)
            {
                PrivatKund p = new PrivatKund();
                FöretagsKund f = new FöretagsKund();
                p = PreForPrivate(temp[i]);
                f = PreForEnterprise(temp[i]);
                if (p != null) PrivateBoking(temp[i], p.PrivatKundID);
                if (f != null) EnterpriseBoking(temp[i], f.FöretagKundID);
            }
        }

        /*
         * Allt som berör företagskunder finns nedan
         */
        public void SingleBoking(PreBokning pre, int id)
        {
            if (pre.FöretagsKund != null)
            {
            EnterpriseBoking(pre, id);

            }
            else if (pre.PrivatKund != null)
            {
                Bokning b = new Bokning();
                PrivatKund pk = new PrivatKund();
                pk = UnitOfWork.PrivatKundRepository.GetPreBokningPrivatKund(pre);
                List<Logi> LogiList = GetLogiPrivateBoking(pk, pre);

                if (LogiList != null)
                    foreach (Logi item in LogiList)
                        b.LogiTillBokning.Add(item);
               

                b.PrivatKund = pk;
                b = MovePreDataPrivate(b, pre);
                GenerateInvoicePrivate(b, id);
            }
        }

        private void EnterpriseBoking(PreBokning pre, int id)
        {
            Bokning b = new Bokning();
            FöretagsKund fk = new FöretagsKund();
            fk = pre.FöretagsKund;
            List<Konferens> konferensList = UnitOfWork.KonferensRepository.GetKonferensPreBokingCompany(fk ,pre);
            List<Logi> LogiList = GetLogiEnterpriseBoking(fk, pre);
            //List<Konferens> KonferendeList = GetKonferenseEntBoking(fk, pre);

            if (LogiList != null)
                foreach (Logi item in LogiList)
                    b.LogiTillBokning.Add(item);
            if (konferensList != null)
                foreach (Konferens item in konferensList)
                    b.Konferenser.Add(item);

            b.FöretagsKund = fk;
            b = MovePreDataEnterprise(b, pre);
            GenerateInvoideEnterprise(b, id);
        }

        private Bokning MovePreDataEnterprise(Bokning b, PreBokning pre)
        {
            b.BokningsPris = pre.BokningsPris;
            b.BokningsTyp = "Bokning";
            b.InCheckningsDatum = pre.InCheckningsDatum;
            b.UtCheckningsDatum = pre.UtCheckningsDatum;
            b.Moms = pre.Moms;
            b.Rabatt = pre.Rabatt;
            b.Bruttopris = pre.Bruttopris;
            b.Nettopris = pre.Nettopris;
            b.PrivatKund = null;

            UnitOfWork.BokningRepository.Add(b);
            RemovePreBoking(pre);
            return b;
        }

        private void RemovePreBoking(PreBokning pre)
        {
            pre.FöretagsKund = null;
            pre.PrivatKund = null;
            pre.Bokning = null;
            foreach (Logi item in pre.LogiTillBokning)
                item.PreBokning = null;
            foreach(Konferens item in pre.KonferensTillBokning)
                item.PreBokning = null;
            pre.LogiTillBokning = null;
            pre.Status = false;
            UnitOfWork.PreBokningRepository.Remove(pre.BokningsID);
            UnitOfWork.Complete();
        }

        private List<Logi> GetLogiEnterpriseBoking(FöretagsKund f, PreBokning pre)
        {
            List<Logi> listaLogi = UnitOfWork.LogiRepository.HämtaLogiPreBokningFöretag(f, pre);
            return listaLogi;
        }

        private List<Konferens> GetKonferenseEntBoking(FöretagsKund f, PreBokning pre)
        {
            //List<Konferens> konferenslist = UnitOfWork.KonferensRepository.GetKonferensPreBokingCompany(f, pre);
            //return konferenslist;
            return null;
        }

        private FöretagsKund PreForEnterprise(PreBokning pre)
        {
            PreBokning temp = UnitOfWork.PreBokningRepository.GetPreBokningMedFöretagsKund(pre);
            return temp.FöretagsKund;
        }

        /*
         * Allt som berör privatkunder finns nedan
         */
        private PrivatKund PreForPrivate(PreBokning pre)
        {
            PreBokning temp = UnitOfWork.PreBokningRepository.GetPreBokningMedPrivatkund(pre);
            return temp.PrivatKund;
        }

        private void PrivateBoking(PreBokning pre, int id)
        {
            Bokning b = new Bokning();
            PrivatKund p = UnitOfWork.PrivatKundRepository.Get(id);
            List<Logi> LogiList = GetLogiPrivateBoking(p, pre);
            foreach (Logi item in LogiList)
                b.LogiTillBokning.Add(item);
            b.PrivatKund = p;
            b = MovePreDataPrivate(b, pre);
            UnitOfWork.Complete();
            GenerateInvoicePrivate(b, id);
        }

        private List<Logi> GetLogiPrivateBoking(PrivatKund p, PreBokning pre)
        {
            List<Logi> listaLogi = UnitOfWork.LogiRepository.HämtaLogiPreBokning(p, pre);
            return listaLogi;
        }

        private Bokning MovePreDataPrivate(Bokning b, PreBokning pre)
        {
            b.BokningsPris = pre.BokningsPris;
            b.BokningsTyp = "Bokning";
            b.InCheckningsDatum = pre.InCheckningsDatum;
            b.UtCheckningsDatum = pre.UtCheckningsDatum;
            b.Moms = pre.Nettopris*0.12;
            b.Rabatt = pre.Rabatt;
            b.Bruttopris = pre.Bruttopris;
            b.Nettopris = pre.Nettopris;
            b.FöretagsKund = null;

            UnitOfWork.BokningRepository.Add(b);
            UnitOfWork.PreBokningRepository.Remove(pre.BokningsID);

            return b;
        }
        #endregion

        #region Nya Bokningar genererar Faktura
        private void GenerateInvoicePrivate(Bokning b, int id)
        {
            //Faktura faktura = new Faktura();
            //faktura.Pris = b.BokningsPris;
            //faktura.FaktureringsDatum = DateTime.Now;
            //faktura.FörfalloDatum = DateTime.Now.AddMonths(1);
            //faktura.Typ = "Bokning";
            //faktura.Status = false;
            //faktura.Bokning = b;
            //faktura.Privat = UnitOfWork.PrivatKundRepository.Get(id);
            //UnitOfWork.FakturaRepository.Add(faktura);
            //UnitOfWork.Complete();

            //Skapar faktura för bokning
            Faktura faktura = new Faktura();
            faktura.Pris = b.BokningsPris * 0.8;
            faktura.FaktureringsDatum = b.InCheckningsDatum;
            faktura.FörfalloDatum = b.UtCheckningsDatum.AddMonths(1);
            faktura.Typ = "Bokning";
            faktura.Status = false;
            faktura.Bokning = b;
            faktura.Privat = b.PrivatKund;
            UnitOfWork.FakturaRepository.Add(faktura);

            Faktura delbetalning = new Faktura();
            delbetalning.FaktureringsDatum = DateTime.Now;
            delbetalning.FörfalloDatum = DateTime.Now.AddMonths(1);
            delbetalning.Pris = faktura.Bokning.BokningsPris * 0.2;
            delbetalning.Typ = "Delfaktura";
            delbetalning.Bokning = b;
            delbetalning.Privat = faktura.Privat;

            UnitOfWork.Complete();
            faktura.Privat.Fakturor.Add(faktura);
            faktura.Privat.Bokningar.Add(faktura.Bokning);
            faktura.Privat.Fakturor.Add(delbetalning);
            UnitOfWork.Complete();
            

        }

        private void GenerateInvoideEnterprise(Bokning b, int id)
        {
            //Faktura fk = new Faktura();
            //fk.Pris = b.BokningsPris;
            //fk.FaktureringsDatum = DateTime.Now;
            //fk.FörfalloDatum = DateTime.Now.AddMonths(1);
            //fk.Typ = "Bokning";
            //fk.Status = false;
            //fk.Bokning = b;
            //fk.Företag = UnitOfWork.FöretagsKundRepository.Get(id);
            //UnitOfWork.FakturaRepository.Add(fk);
            //UnitOfWork.Complete();


            Faktura faktura = new Faktura();
            faktura.Pris = b.BokningsPris * 0.8;
            faktura.FaktureringsDatum = b.InCheckningsDatum;
            faktura.FörfalloDatum = b.UtCheckningsDatum.AddMonths(1);
            faktura.Typ = "Bokning";
            faktura.Status = false;
            faktura.Bokning = b;
            //faktura.Företag = UnitOfWork.FöretagsKundRepository.Get(id);
            faktura.Företag = b.FöretagsKund;
            UnitOfWork.FakturaRepository.Add(faktura);
          

            Faktura delbetalning = new Faktura();
            delbetalning.FaktureringsDatum = DateTime.Now;
            delbetalning.FörfalloDatum = DateTime.Now.AddMonths(1);
            delbetalning.Pris = faktura.Bokning.BokningsPris * 0.2;
            delbetalning.Typ = "Delfaktura";
            delbetalning.Bokning = b;
            delbetalning.Företag = faktura.Företag;

            UnitOfWork.Complete();
            faktura.Företag.Fakturor.Add(faktura);
            faktura.Företag.Bokningar.Add(faktura.Bokning);
            faktura.Företag.Fakturor.Add(delbetalning);
            UnitOfWork.Complete();

        }
        #endregion
    }
}
