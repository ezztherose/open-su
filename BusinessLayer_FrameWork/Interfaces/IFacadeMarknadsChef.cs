using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities_FrameWork.Models;

// Bygger specifikt gränssnitt och implementerar datan från respektive modul. 
// Användaren kan göra specfika val utan att påverka alla subklasser.

namespace BusinessLayer_FrameWork.Interfaces
{
    public interface IFacadeMarknadsChef
    {
        public List<PreBokning> SearchPreBokning(string search);
        public MarknadsChef LoginMarknadsChef(string användarnamn, string lösenord);
        public List<Bokning> searchMånad(DateTime start, DateTime slut, string lägenhetstyp);
        public List<Logi> HämtaReserverade(string lägenhetstyp, DateTime start, DateTime slut);
        public int TillgängligaLägenheter(DateTime start, DateTime slut, string lägenhetstyp);
    }
}
