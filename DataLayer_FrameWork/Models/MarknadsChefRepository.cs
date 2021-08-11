using BusinessEntities_FrameWork.Models;
using DataLayer_FrameWork.Context;
using DataLayer_FrameWork.Interfaces;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer_FrameWork.Models
{   
    // GenericRepository används för att kunna används av alla entiteter av databasen
    public class MarknadsChefRepository : GenericRepository<MarknadsChef>, IMarknadsChefRepository
    {
        public Logi Logi { get; set; }
        public Bokning Bokning { get; set; }
        public MarknadsChefRepository(DatabaseContext context) : base(context)
        {

        }

        // Inlogg för marknadschefen där det krävs ett användarnamn och lösenord 
        public MarknadsChef Login(string användarnamn, string password)
        {
            return Context.MarknadsChef.Where(x => användarnamn.ToLower() == användarnamn.ToLower() && x.Lösenord.ToString().Equals(password.ToString())).SingleOrDefault();
        }

        // Lista på preliminärbokningar 
        public List<PreBokning> SearchPreBokning(string search)
        {       
            return Context.PreBokning.Where(x => x.BokningsID.ToString().Contains(search)).ToList();
        }

        // Lista på bokningar genom att söka på månad 
        public List<Bokning> searchMånad(DateTime start, DateTime slut,string lägenhetstyp)
        {   // Lista på alla logier. antingen lägenhetstyp 1 eller 2 
            List<Logi> logiList = new List<Logi>();
            if (lägenhetstyp == "Typ 1 Lägenhet")
                lägenhetstyp = "Liten"; 
            else if (lägenhetstyp == "Typ 2 Lägenhet")
                lägenhetstyp = "Stor";
            return Context.Bokning.Where(x => x.InCheckningsDatum >= start && x.InCheckningsDatum <= slut && x.BokningsTyp == lägenhetstyp).ToList();
        }
        
        public List<Logi> hämtares(string lägenhetstyp, DateTime start, DateTime slut)
        {
            IQueryable ls;
            if (lägenhetstyp == "Typ 1 Lägenhet")
                lägenhetstyp = "Liten";
            else if (lägenhetstyp == "Typ 2 Lägenhet")
                lägenhetstyp = "Stor";

            ls = Context.Logi.Where(x => x.LogiTyp == lägenhetstyp && Context.Bokning.Where(y => y.BokningsID == x.Bokning.BokningsID &&
            (x.Tillgänglighet == false && !(y.InCheckningsDatum >= slut || y.UtCheckningsDatum <= start))).Count() == 0);

            List<Logi> logi = new List<Logi>();
            foreach (Logi l in ls)
                logi.Add(l);
            return logi;
        }
    }
}
