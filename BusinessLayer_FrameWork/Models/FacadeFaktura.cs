using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities_FrameWork.Models;
using BusinessLayer_FrameWork.Interfaces;
using DataLayer_FrameWork.Context;
using DataLayer_FrameWork.UnitOfWork;

//Klient kallar på facade, vilket skapar startup struktur för faktura -> bygg design.

namespace BusinessLayer_FrameWork.Models
{
    public class FacadeFaktura : IFacadeFaktura
    {
        public UnitOfWork UnitOfWork { get; set; }

        public FacadeFaktura(DatabaseContext context)
        {
            UnitOfWork = new UnitOfWork(context);
        }

        public List<Faktura> GetAllFakturaShop()
        {
            List<Faktura> fakturaList = new List<Faktura>();
            foreach (Faktura item in UnitOfWork.FakturaRepository.GetAll().ToList())
                if (item.Typ.Equals("Shop"))
                    fakturaList.Add(item);
            return fakturaList;
        }

        public List<Faktura> GetAllFakturaLogi()
        {
            List<Faktura> fakturaList = new List<Faktura>();
            foreach (Faktura item in UnitOfWork.FakturaRepository.GetAll().ToList())
                if (item.Typ.Equals("Logi"))
                    fakturaList.Add(item);

            return fakturaList;
        }

        public List<Faktura> GetAllFakturor()
        {
            return (List<Faktura>)UnitOfWork.FakturaRepository.GetAll();
        }

        public void FakturaShopTillUtskrift(Faktura f)
        {
            if (f.Status != true) f.Status = true;
            UnitOfWork.FakturaRepository.Update(f, f.FakturaID);
            UnitOfWork.Complete();
        }
        public List<Faktura>GetEjUtskrivna()
        {
            return UnitOfWork.FakturaRepository.GetEjUtskrivna(); 
        }
        public void ÄndraStatusFaktura(Faktura faktura)
        {
            if (faktura.Status != true) faktura.Status = true;
            UnitOfWork.FakturaRepository.Update(faktura, faktura.FakturaID);
            UnitOfWork.Complete();
        }
        public Faktura SkidlektionFakturaprivat(DateTime start, DateTime slut, PrivatKund pk, string typ, int antalTimmar, int antalDeltagare)
        {
            typ = "SkidskolaPrivat";
            SkidLektion s = UnitOfWork.SkidLektionRepository.HämtaSpecifiktPris();
            start = DateTime.Now;
            slut = start.AddMonths(1);
            Faktura tempprivat = new Faktura();
            tempprivat.FaktureringsDatum = start;
            tempprivat.FörfalloDatum = slut;
            tempprivat.Typ = typ;
            tempprivat.Privat = pk;
            tempprivat.Pris = s.Pris * antalTimmar * antalDeltagare;

            UnitOfWork.FakturaRepository.Add(tempprivat);
            //LäggTillFakturaTillPrivatKund(tempprivat, pk);
            UnitOfWork.Complete();
            return tempprivat;
        }

        public Faktura UthyrningsFakturaPrivat(double pris, string typ, Uthyrning u, PrivatKund pk, DateTime start, DateTime slut)
        {
            start = DateTime.Now;
            slut = start.AddMonths(1);
            Faktura temp = new Faktura();
            temp.FaktureringsDatum = start;
            temp.FörfalloDatum = slut;
            temp.Pris = pris * 1.12;
            temp.Typ = typ;
            temp.Uthyrning = u;
            temp.Privat = pk;
            u.PrivatKund = pk;

            UnitOfWork.FakturaRepository.Add(temp);
            UnitOfWork.Complete();
            u.Faktura = temp;
            UnitOfWork.Complete();
            return temp;
        }

        public void BokningFakturaFöretag(double pris, string typ, Bokning b, FöretagsKund fk, DateTime start, DateTime slut)
        {
            start = DateTime.Now;
            slut = start.AddMonths(1);
            Faktura testF = new Faktura();
            testF.FaktureringsDatum = b.UtCheckningsDatum;
            testF.FörfalloDatum = b.UtCheckningsDatum.AddMonths(1);
            testF.Pris =  b.BokningsPris * 0.8;
            testF.Typ = typ;
            testF.Bokning = b;
            testF.Företag = fk;
            fk.Bokningar.Add(b);
            fk.Fakturor.Add(testF);
            UnitOfWork.FakturaRepository.Add(testF);

            Faktura delbetalning = new Faktura();
            delbetalning.FaktureringsDatum = start;
            delbetalning.FörfalloDatum = slut;
            delbetalning.Pris = b.BokningsPris * 0.2;
            delbetalning.Typ = "Delfaktura";
            delbetalning.Bokning = b;
            delbetalning.Företag = fk;
            fk.Fakturor.Add(delbetalning);

            UnitOfWork.Complete();
            //return testF;
        }

        public Faktura FakturaKonferens(double pris, string typ, Bokning b, FöretagsKund fk, DateTime start, DateTime slut)
        {
            start = DateTime.Now;
            slut = start.AddMonths(1);
            Faktura testF = new Faktura();
            testF.FaktureringsDatum = start;
            testF.FörfalloDatum = slut;
            testF.Pris = pris;
            testF.Typ = typ;
            testF.Bokning = b;
            testF.Företag = fk;

            fk.Bokningar.Add(b);
            fk.Fakturor.Add(testF);
            UnitOfWork.FakturaRepository.Add(testF);
            UnitOfWork.Complete();
            return testF;
        }

        public Faktura BokningFakturaPrivat(double pris, string typ, Bokning b, PrivatKund pk, DateTime start, DateTime slut)
        {
            double delbetalningspris = pris * 0.2;
            double andrabetalning = pris * 0.8;
            start = DateTime.Now;
            slut = start.AddMonths(1);
            Faktura test = new Faktura();
            test.FaktureringsDatum = b.UtCheckningsDatum;
            test.FörfalloDatum = b.UtCheckningsDatum.AddMonths(1);
            test.Pris = andrabetalning;
            test.Typ = typ;
            test.Bokning = b;
            test.Privat = pk;

            Faktura delbetalning = new Faktura();

            delbetalning.FaktureringsDatum = start;
            delbetalning.FörfalloDatum = slut;
            delbetalning.Pris = delbetalningspris;
            delbetalning.Typ = "Delfaktura";
            delbetalning.Bokning = b;
            delbetalning.Privat = pk;
            pk.Bokningar.Add(b);
            pk.Fakturor.Add(test);
            pk.Fakturor.Add(delbetalning);

            UnitOfWork.FakturaRepository.Add(test);
            UnitOfWork.Complete();
            return test;
        }

        public Faktura SkickaDelFaktura(Bokning bokning)
        {
             string typs = "Delfaktura";
            return UnitOfWork.FakturaRepository.HämtaDelbetalning(typs, bokning);
            
        }

        public List<Faktura> FakturorTillLog()
        {
            return  (List<Faktura>)UnitOfWork.FakturaRepository.FakturorFörLogi();
        }
    }
}



