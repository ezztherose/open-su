using BusinessEntities_FrameWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer_FrameWork.Interfaces
{
    public interface IMarknadsChefRepository : IGenericRepository<MarknadsChef>
    {
        MarknadsChef Login(string användarnamn, string password);
        public List<PreBokning> SearchPreBokning(string search);
        public List<Bokning> searchMånad(DateTime start, DateTime slut, string lägenhetstyp);
        public List<Logi> hämtares(string lägenhetstyp, DateTime start, DateTime slut);
    }
}
