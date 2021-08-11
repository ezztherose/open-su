using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities_FrameWork.Models;
using BusinessLayer_FrameWork.Interfaces;
using DataLayer_FrameWork.Context;
using DataLayer_FrameWork.UnitOfWork;

//Klient kallar på facade, vilket skapar startup struktur för marknadschef -> bygg design.

namespace BusinessLayer_FrameWork.Models
{
    public class FacadeMarknadsChef : IFacadeMarknadsChef
    {
        public UnitOfWork UnitOfWork { get; set; }
        public List<Bokning> Bokningar { get; set; }

        public FacadeMarknadsChef(DatabaseContext context)
        {
            Bokningar = new List<Bokning>(); 
            UnitOfWork = new UnitOfWork(context);
        }

        public MarknadsChef LoginMarknadsChef(string användarnamn, string password)
        {
            MarknadsChef administratör = UnitOfWork.MarknadsChefRepository.Login(användarnamn, password);
            if (administratör != null && administratör.Lösenord == password)
                return administratör;
            return null;
        }

        public List<PreBokning> SearchPreBokning(string search)
        {
            List<PreBokning> SökPreBokning = new List<PreBokning>();
            foreach (PreBokning pb in UnitOfWork.MarknadsChefRepository.SearchPreBokning(search.ToLower()))
                SökPreBokning.Add(pb);
            return SökPreBokning;
        }

        public List<Bokning> searchMånad(DateTime start, DateTime slut, string lägenhetstyp)
        {
           Bokningar = UnitOfWork.MarknadsChefRepository.searchMånad(start, slut, lägenhetstyp);
            return Bokningar;
        }

        public List<Logi> HämtaReserverade(string lägenhetstyp , DateTime start, DateTime slut)
        {
            return UnitOfWork.MarknadsChefRepository.hämtares(lägenhetstyp, start, slut) ;
        }

        public int TillgängligaLägenheter(DateTime start, DateTime slut, string lägenhetstyp)
        {
            int tillgänglig = 0;
            DateTime kollaDatum = start;
            while (kollaDatum <= slut)
            {

                tillgänglig += HämtaReserverade(lägenhetstyp, kollaDatum, kollaDatum.AddDays(1).AddHours(-1)).Count();
                kollaDatum = kollaDatum.AddDays(1);
            }
            return tillgänglig;
        }
    }
}
