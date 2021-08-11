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
    public interface IFacadeUthyrning
    {
        public void SparaKontantUthyrning(Uthyrning u);

        public void TaBortBokning(Uthyrning u);
        public string LäggTillFakturaTillUthyrning(Faktura f, Uthyrning u);
        public List<Uthyrning> GetAllUtnyrningar();
        public void UthyrningTillUtskrift(Uthyrning u);
        public void UthyrningtillÅterlämnad(Uthyrning uthyrning);
        public void TaBortUthyrning(Uthyrning u, int pId);
        public List<Uthyrning> SökEfterUthyrning(string sökterm);
        public Uthyrning SearchUthyrning(string id);
        public List<Uthyrning> GetAllEjReturnerade(PrivatKund pk);
        public List<Utrustning> GetEjReturneradePK(int Id);
        public void UtrustningTillÅterlämning(Utrustning utrustning);
        public void StatusTillgänglig(Uthyrning uthyrning);

        // test för sök med hela namnet
        //public List<Uthyrning> SearchUthyrningByFullName(string searchWord)


    }
}
