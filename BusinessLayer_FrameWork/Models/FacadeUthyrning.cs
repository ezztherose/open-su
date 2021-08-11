using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities_FrameWork.Models;
using BusinessLayer_FrameWork.Interfaces;
using DataLayer_FrameWork.Context;
using DataLayer_FrameWork.UnitOfWork;

//Klient kallar på facade, vilket skapar startup struktur för uthyrning -> bygg design.
namespace BusinessLayer_FrameWork.Models
{
    public class FacadeUthyrning : IFacadeUthyrning
    {
        public UnitOfWork UnitOfWork { get; set; }

        public FacadeUthyrning(DatabaseContext context)
        {
            UnitOfWork = new UnitOfWork(context);
        }

        public void TaBortBokning(Uthyrning u)
        {
            UnitOfWork.UthyrningRepository.Remove(u.UthyrningsID);
            UnitOfWork.Complete();
        }
      
        public string LäggTillFakturaTillBokning(Faktura f, Uthyrning u)
        {
            // Datum till faktura
            f.FaktureringsDatum = DateTime.Today;
            f.FörfalloDatum = DateTime.Today.AddDays(30);
            UnitOfWork.FakturaRepository.Add(f);

            //
            u.PrivatKund = f.Privat;
            u.UthyrningsDatum = DateTime.Today;
            u.Faktura = f;

            // PRISER

            // kollar om den håller sig innanför prisramen
            //if (u.UthyrningsPris >= 20000)
            //{
            //    PreBokning temp = new PreBokning();
            //    temp.Bokning = u;
            //    UnitOfWork.PreBokningRepository.Add(temp);
            //    return "Bokning överskrider kredit, bokningen är parkerad";
            //}
            //else if (b.Nettopris < 20000)
            //{
            //    UnitOfWork.BokningRepository.Add(b);
            //    return "Bokningen är tillagd";
            //}
            UnitOfWork.UthyrningRepository.Add(u);
            UnitOfWork.Complete();
            return "Uthyring är tillagd";
        }
        public void SparaKontantUthyrning(Uthyrning u)
        {
            UnitOfWork.UthyrningRepository.Add(u);
            UnitOfWork.Complete();
        }

        public void StatusTillgänglig(Uthyrning uthyrning)
        {
            uthyrning.Status = true;
            UnitOfWork.UthyrningRepository.Update(uthyrning, uthyrning.UthyrningsID);
            UnitOfWork.Complete();
        }

        public Uthyrning SearchUthyrning(string id)
        {
            Uthyrning Uthyrning = UnitOfWork.UthyrningRepository.SearchUthyrning(id);
            return Uthyrning;
        }

        //public List<Uthyrning> SearchUthyrningByFullName(string searchWord)
        //{
        //    List<Uthyrning> ListForSorting = UnitOfWork.UthyrningRepository.GetAll().ToList();
        //    List<Uthyrning> SearchResult = new List<Uthyrning>();
        //    for (int i = 0; i < ListForSorting.Count; i++)
        //    {
        //        string fullName = ListForSorting[i].PrivatKund.PrivatFörnamn + " " + ListForSorting[i].PrivatKund.PrivatEfternamn;
        //        if (fullName.Contains(searchWord))
        //        {
        //            SearchResult.Add(ListForSorting[i]);
        //        }
        //    }
        //    return SearchResult;
        //}

        public List<Uthyrning> GetAllUtnyrningar()
        {
            return UnitOfWork.UthyrningRepository.GetAll().ToList();
        }
        public List<Uthyrning> GetAllEjReturnerade(PrivatKund pk)
        {
            return UnitOfWork.UthyrningRepository.GetAllEjReturnerade(pk);
        }
        public List<Utrustning> GetEjReturneradePK(int Id)
        {
            return UnitOfWork.UthyrningRepository.GetEjReturneradePK(Id);
            
        }
        public void UthyrningTillUtskrift(Uthyrning u)
        {

        }
        public Uthyrning HämtaUthyrning(int ID)
        {
            return UnitOfWork.UthyrningRepository.Get(ID);
        }

        public void UppdateraUthyrning(Uthyrning ValdUthyrning, int ID)
        {
            UnitOfWork.UthyrningRepository.Update(ValdUthyrning, ID);
        }

        public string LäggTillFakturaTillUthyrning(Faktura f, Uthyrning u)
        {
            throw new NotImplementedException();
        }

        public void TaBortUthyrning(Uthyrning u, int pId)
        {
            HämtaUthyrningsFaktura(u, pId);
        }

        private void HämtaUthyrningsFaktura(Uthyrning u, int uthyrnintPrivatKundId)
        {
            // Hämtar fakturan som är kopplad till Uthyrningen
            Faktura f = UnitOfWork.UthyrningRepository.HämtaUthyrningsFaktura(u.UthyrningsID, uthyrnintPrivatKundId);
            f.Uthyrning = null;
            u.Faktura = null;
           
            // Uppdatera nycklar till null för att ta bort relationen
            UnitOfWork.FakturaRepository.Update(f, f.FakturaID);
            UnitOfWork.UthyrningRepository.Update(u, u.UthyrningsID);
           
            // Tar bort de separata fakturan samt uthyrningen för sig
            UnitOfWork.FakturaRepository.Remove(f.FakturaID);
            UnitOfWork.UthyrningRepository.Remove(u.UthyrningsID);

            // Sparar efter borttagning
            UnitOfWork.Complete();
        }

        public void UthyrningtillÅterlämnad(Uthyrning uthyrning)
        {
            List<Utrustning> temp = uthyrning.UtrustningsTillUthyrning.ToList();
            uthyrning.UtrustningsTillUthyrning.Clear();
            for (int i = 0; i < temp.Count; i++)
                if (temp[i].Tillgänglig != true)
                {
                    temp[i].Tillgänglig = true;
                    temp[i].Uthyrning = null;
                    uthyrning.Status = true;
                }
            uthyrning.UtrustningsTillUthyrning = temp;
            UnitOfWork.UthyrningRepository.Update(uthyrning, uthyrning.UthyrningsID);
            UnitOfWork.Complete();
        }
        public void UtrustningTillÅterlämning(Utrustning utrustning)
        {
            if(utrustning.Tillgänglig != true)
            {
                utrustning.Tillgänglig = true;
                utrustning.Uthyrning = null;
                utrustning.PaketStatus = false;
            }
            UnitOfWork.UtrustningRepository.Update(utrustning, utrustning.ArtikelID);
            UnitOfWork.Complete();
        }

        public List<Uthyrning> SökEfterUthyrning(string sökterm)
        {
            UnitOfWork.UthyrningRepository.SökEfterUthyrning(sökterm);
            return null;
        }
    }
}
