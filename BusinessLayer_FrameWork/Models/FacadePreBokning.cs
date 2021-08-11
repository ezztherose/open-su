using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities_FrameWork.Models;
using BusinessLayer_FrameWork.Interfaces;
using DataLayer_FrameWork.Context;
using DataLayer_FrameWork.UnitOfWork;

//Klient kallar på facade, vilket skapar startup struktur för Prebokning -> bygg design.

namespace BusinessLayer_FrameWork.Models
{
    public class FacadePreBokning : IFacadePreBokning
    {
        public UnitOfWork UnitOfWork { get; set; }
        public FacadePreBokning(DatabaseContext context)
        {
            UnitOfWork = new UnitOfWork(context);
        }

        public void Add(PreBokning pre)
        {
            UnitOfWork.PreBokningRepository.Add(pre);
        }

        public List<PreBokning> SearchPreBokning(string search)
        {
            List<PreBokning> SökPreBokning = new List<PreBokning>();
            foreach (PreBokning pb in UnitOfWork.PreBokningRepository.SearchPreBokning(search.ToLower()))
                SökPreBokning.Add(pb);
            return SökPreBokning;
        }

        public void BokningPrivatPre(double pris, string typ, PreBokning pre, int ID, DateTime start, DateTime slut)
        {
            start = DateTime.Now;
            slut = start.AddMonths(1);
            pre.InCheckningsDatum = start;
            pre.UtCheckningsDatum = slut;
            pre.PrivatKund = HämtaPrivatKund(ID); // konstig
            pre.FöretagsKund = null;
            pre.BokningsTyp = typ;
            UnitOfWork.PreBokningRepository.Add(pre);
            UnitOfWork.Complete();
        }
        public void BokningFöretagPre(double pris, string typ, PreBokning pre, int ID, DateTime start, DateTime slut)
        {
            start = DateTime.Now;
            slut = start.AddMonths(1);
            pre.InCheckningsDatum = start;
            pre.UtCheckningsDatum = slut;
            pre.BokningsTyp = typ;
            pre.FöretagsKund = HämtaFöretagKund(ID); // konstig
            pre.PrivatKund = null;
            UnitOfWork.PreBokningRepository.Add(pre);
            UnitOfWork.Complete();
        }

        public List<PreBokning> GetAllPreBokning()
        {
            List<PreBokning> prebokning = new List<PreBokning>();
            prebokning.AddRange(UnitOfWork.PreBokningRepository.GetAll());
            return prebokning;
        }

        public void RemovePreBokning(PreBokning pre)
        {
            
            UnitOfWork.PreBokningRepository.Remove(pre.BokningsID);
            UnitOfWork.Complete();
        }    

        public Bokning PreBokningTillBokning(Bokning bk, PreBokning pre, int ID )
        {
            PrivatKund privatKund = HämtaPrivatKund(ID);
           List<Logi> listalogi = HämtaLogiPreBokning(privatKund, pre);
            foreach (Logi item in listalogi)
                bk.LogiTillBokning.Add(item);

            // Konverterar prebokning till bokning
            bk.BokningsPris = pre.BokningsPris;
            bk.BokningsTyp = pre.BokningsTyp;
            bk.InCheckningsDatum = pre.InCheckningsDatum;
            bk.UtCheckningsDatum = pre.UtCheckningsDatum;
            bk.Moms = pre.Moms;
            bk.Bruttopris = pre.Bruttopris;
            bk.Status = pre.Status;
            bk.Nettopris = pre.Nettopris;
            bk.FöretagsKund = null;
            bk.BokningsTyp = "Bokning";
            bk.PrivatKund = HämtaPrivatKund(ID);
            UnitOfWork.BokningRepository.Add(bk);
            UnitOfWork.PreBokningRepository.Remove(pre.BokningsID);
            return bk;
        }

        public List<Logi> HämtaLogiPreBokning(PrivatKund privatKund, PreBokning pre)
        {
            List<Logi> listaLogi =  UnitOfWork.LogiRepository.HämtaLogiPreBokning(privatKund, pre);
            return listaLogi;
        }

        public List<Logi> HämtaLogiPreBokningFöretag(FöretagsKund företagsKund, PreBokning pre)
        {
            List<Logi> listaLogi = UnitOfWork.LogiRepository.HämtaLogiPreBokningFöretag(företagsKund, pre);
            
            return listaLogi;
        }
        public List<Konferens> HämtaKonferensPreBokningFöretag(FöretagsKund fk, PreBokning pre)
        {
            List<Konferens> listaKonferens = UnitOfWork.KonferensRepository.GetKonferensPreBokingCompany(fk, pre);
            return listaKonferens;
        }
        
        public Faktura FakturaPreBokning(Bokning bk, PreBokning pre, int ID)
        {
           
            //Skapar faktura för bokning
            Faktura faktura = new Faktura();
            faktura.Pris = bk.BokningsPris * 0.8;
            faktura.FaktureringsDatum = bk.InCheckningsDatum;
            faktura.FörfalloDatum = bk.UtCheckningsDatum.AddMonths(1);
            faktura.Typ = "Bokning";
            faktura.Status = false;
            faktura.Bokning = bk;
            faktura.Privat = HämtaPrivatKund(ID);
            faktura.Privat.Fakturor.Add(faktura);
            faktura.Privat.Bokningar.Add(faktura.Bokning);
            UnitOfWork.FakturaRepository.Add(faktura);

            Faktura delbetalning = new Faktura();
            delbetalning.FaktureringsDatum = DateTime.Now;
            delbetalning.FörfalloDatum = DateTime.Now.AddMonths(1);
            delbetalning.Pris = faktura.Bokning.BokningsPris * 0.2;
            delbetalning.Typ = "Delfaktura";
            delbetalning.Bokning = bk;
            delbetalning.Privat = faktura.Privat;
            faktura.Privat.Fakturor.Add(delbetalning);

            UnitOfWork.Complete();
            return faktura;
        }

        public Bokning FöretagPreBokningTillBokning(Bokning bk, PreBokning pre, int ID)
        {
            FöretagsKund företagsKund = HämtaFöretagKund(ID);
            List<Logi> listalogi = HämtaLogiPreBokningFöretag(företagsKund, pre);
            foreach (Logi item in listalogi)
                bk.LogiTillBokning.Add(item);

            List<Konferens> listaKonferens = HämtaKonferensPreBokningFöretag(företagsKund, pre);
            foreach (Konferens item in listaKonferens)
            {
                bk.Konferenser.Add(item);
            }

            // Konverterar prebokning till bokning
            bk.BokningsPris = pre.BokningsPris;
            bk.BokningsTyp = "Bokning";
            bk.InCheckningsDatum = pre.InCheckningsDatum;
            bk.UtCheckningsDatum = pre.UtCheckningsDatum;
            bk.Moms = pre.Moms;
            bk.Bruttopris = pre.Bruttopris;
            bk.Status = pre.Status;
            bk.Nettopris = pre.Nettopris;
            bk.FöretagsKund = HämtaFöretagKund(ID);

            bk.PrivatKund = null;
            UnitOfWork.BokningRepository.Add(bk);
            UnitOfWork.PreBokningRepository.Remove(pre.BokningsID);
            UnitOfWork.Complete();
            return bk;
        }
        public Faktura FöretagPreBokningFaktura(Bokning bk, int ID)
        {
            //Skapar faktura för bokning
            Faktura fk = new Faktura();
            fk.Pris = bk.BokningsPris;
            fk.FaktureringsDatum = DateTime.Now;
            fk.FörfalloDatum = DateTime.Now.AddMonths(1);
            fk.Typ = "Bokning";
            fk.Status = false;
            fk.Bokning = bk;
            fk.Företag = HämtaFöretagKund(ID);
            UnitOfWork.FakturaRepository.Add(fk);
            UnitOfWork.Complete();
            return fk;
        }

        public PreBokning HämtaPreBokning(int ID)
        {
            return UnitOfWork.PreBokningRepository.Get(ID);
        }

        public PrivatKund HämtaPrivatKund(int ID)
        {
            return UnitOfWork.PrivatKundRepository.Get(ID);
        }

        public FöretagsKund HämtaFöretagKund(int ID)
        {
            return UnitOfWork.FöretagsKundRepository.Get(ID);
        }

        public PrivatKund HittaKund(int id)
        {
            PreBokning pb = UnitOfWork.PreBokningRepository.Get(id);
            PrivatKund kund_privat = UnitOfWork.PreBokningRepository.GetSpecifikPrivatKund(pb);
            PreBokning pre = UnitOfWork.PreBokningRepository.GetPreBokningMedPrivatkund(pb);
            return kund_privat;
        }

        public PrivatKund HittaPrivatKundTillPreBokning(PreBokning pre)
        {
            PreBokning temp = UnitOfWork.PreBokningRepository.GetPreBokningMedPrivatkund(pre);
            if (temp != null)
                return temp.PrivatKund;
            return null;
        }
        public FöretagsKund HittaFöretagsKundTillPreBokning(PreBokning pre)
        {
            PreBokning temp = UnitOfWork.PreBokningRepository.GetPreBokningMedFöretagsKund(pre);
            if (temp != null)
                return temp.FöretagsKund;
            return null;
        }

        // Funkar ej
        public void TaBortFkFrånPre(PreBokning pre)
        {
            UnitOfWork.PreBokningRepository.TestaLogiTaBortKey(pre);
        }

        public void AvslåPreBokning(PreBokning pre)
        {
            List<Logi> Logi = UnitOfWork.LogiRepository.AvslagAvPrebokning(pre);

            for (int i = 0; i < Logi.Count; i++)
            {
                Logi[i].PreBokning = null;
                UnitOfWork.LogiRepository.Update(Logi[i], Logi[i].LogiID);
            }

            UnitOfWork.PreBokningRepository.Remove(pre.BokningsID);
            UnitOfWork.Complete();
        }

        public void SparaPreBokning()
        {
            UnitOfWork.Complete();
        }

        public void UpdatePreBoking(PreBokning pre, int id)
        {
            UnitOfWork.PreBokningRepository.Update(pre, id);
            SparaPreBokning();
        }

        public PreBokning GetPrebokningToBokning(PreBokning pre)
        {
            PreBokning tepmPre = UnitOfWork.PreBokningRepository.GetPreWithOwner(pre);
            if (pre.FöretagsKund != null)
            {
                //PreBokning temp = UnitOfWork.PreBokningRepository.GetPrebokningToBokning(pre);
                PreBokning temp = UnitOfWork.PreBokningRepository.GetPreBokningMedFöretagsKund(tepmPre);

                return temp;

            }
            if (pre.FöretagsKund == null)
            {
                PreBokning temp = UnitOfWork.PreBokningRepository.GetPreBokningMedPrivatkund(tepmPre);
                return temp;
            }
            return null;
            
        }
    }
}



