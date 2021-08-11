using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities_FrameWork.Models;
using BusinessLayer_FrameWork.Interfaces;
using DataLayer_FrameWork.Context;
using DataLayer_FrameWork.Models;
using DataLayer_FrameWork.UnitOfWork;

//Klient kallar på facade, vilket skapar startup struktur för privatkund -> bygg design.

namespace BusinessLayer_FrameWork.Models
{
    public class FacadePrivatKund : IFacadePrivatKund
    {
        public UnitOfWork UnitOfWork { get; set; }

        public FacadePrivatKund(DatabaseContext context)
        {
            UnitOfWork = new UnitOfWork(context);
        }

        public void LäggTillKund(PrivatKund nyKund)
        {
            UnitOfWork.PrivatKundRepository.Add(nyKund);
            UnitOfWork.Complete();
        }


        public List<PrivatKund> GetAllPKunder()
        {
            List<PrivatKund> privatKunder = new List<PrivatKund>();
            privatKunder.AddRange(UnitOfWork.PrivatKundRepository.GetAll());
            return privatKunder;
        }
      

        public List<PrivatKund> SearchPrivatKund(string search)
        {
            List<PrivatKund> kundLista = new List<PrivatKund>();
            foreach (PrivatKund privatKund in UnitOfWork.PrivatKundRepository.SearchPrivatKund(search.ToLower()))
                kundLista.Add(privatKund);
            return kundLista;
        }

        public void UppdateraPrivatkund(PrivatKund privatKund, int PrivatKundID)
        {
            UnitOfWork.PrivatKundRepository.Update(privatKund, PrivatKundID);
            UnitOfWork.Complete();
        }

        public PrivatKund HämtaPrivatKund(int ID)
        {
            return UnitOfWork.PrivatKundRepository.Get(ID);
        }

        public void RemovePrivatkund(PrivatKund privatkund)
        {
            List<Faktura> ListaFaktura = UnitOfWork.FakturaRepository.GetAll().ToList();
            List<Uthyrning> ListaUthyrningar = UnitOfWork.UthyrningRepository.GetAll().ToList();
            List<Bokning> BokningarLista = UnitOfWork.BokningRepository.GetAll().ToList();

            for (int i = 0; i < ListaFaktura.Count; i++)
                if (ListaFaktura[i].Privat == privatkund)
                    ListaFaktura[i].Privat = null;


            for (int i = 0; i < ListaUthyrningar.Count; i++)
                if (ListaUthyrningar[i].PrivatKund == privatkund)
                    ListaUthyrningar[i].PrivatKund = null;

            for (int i = 0; i < BokningarLista.Count; i++)
                if (BokningarLista[i].PrivatKund == privatkund)
                    BokningarLista[i].PrivatKund = null;

            privatkund.Bokningar = null;
            privatkund.Fakturor = null;
            PrivatKund pk = UnitOfWork.PrivatKundRepository.TaBortPrivatKund(privatkund);
            UnitOfWork.PrivatKundRepository.Update(privatkund, privatkund.PrivatKundID);
            UnitOfWork.Complete();
            UnitOfWork.BokningRepository.RemoveprivatKund(pk, pk.PrivatKundID);
            UnitOfWork.Complete();
        }

        public bool KontrolleraRabatt(PrivatKund pk)
        {
            List<Bokning> listaBokningar = new List<Bokning>();
            listaBokningar.AddRange(UnitOfWork.BokningRepository.GetAll());
            DateTime test = DateTime.Now.AddYears(-1).Date;
            
            for (int i = 0; i < listaBokningar.Count; i++)
                if (listaBokningar[i].PrivatKund != null )
                    if (pk.PrivatKundID == listaBokningar[i].PrivatKund.PrivatKundID)
                        if (listaBokningar[i].InCheckningsDatum.Year == DateTime.Now.AddYears(-1).Year || listaBokningar[i].InCheckningsDatum.Year == DateTime.Now.Year) 
                            return true;
            return  false;
        }

        public List<PrivatKund> SearchUthyrningByFullName(string searchWord)
        {
            // Hämtar alla privata kunder i databasen
            List<PrivatKund> ListForSorting = UnitOfWork.PrivatKundRepository.GetAll().ToList();
            // Instansierar en ny lista för träffat på sökningen
            List<PrivatKund> SearchResult = new List<PrivatKund>();
            searchWord.ToLower(); // Sätter till lower-case för att förenka sökningen
            // Loopar igenom listan
            for (int i = 0; i < ListForSorting.Count; i++)
            {
                // Konkatinerar för- och efternamn
                string fullName = $"{ListForSorting[i].PrivatFörnamn} {ListForSorting[i].PrivatEfternamn}";
                // Letar efter fullt namn som matchar sökordet
                if (fullName.ToLower().StartsWith(searchWord.ToLower()))
                    SearchResult.Add(ListForSorting[i]); // Lägger till matchat namn till returlista
            }
            return SearchResult; // Skickar tillbaka de matchande träffarna 
        }
    }
}
