using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities_FrameWork.Models;
using DataLayer_FrameWork.Context;
using DataLayer_FrameWork.Interfaces;

namespace DataLayer_FrameWork.Models
{    
    // GenericRepository används för att kunna används av alla entiteter av databasen
    public class PreBokningRepository : GenericRepository<PreBokning>, IPreBokningRepository
    {
        public PreBokningRepository(DatabaseContext context) : base(context)
        {

        }
        // Metod för preliminärbokningar för privatkunder 
        public PreBokning GetPre(int id)
        {
            return (PreBokning)Context.PreBokning.Where(x => x.BokningsID == id).Include(x => x.PrivatKund);
        }

        // Lista för preliminärbokningar för privatkund 
        public List<PreBokning> SearchPreBokning(string search)
        {
            return Context.PreBokning.Where(x => x.BokningsTyp.ToLower().Contains(search)).Include(x => x.PrivatKund).ToList();
        }

        // Metod som hämtar en specifik privatkund via preliminärbokning
        public PrivatKund GetSpecifikPrivatKund(PreBokning pre)
        {
            using (var db = new DatabaseContext())
            {
                return null;
            }
        }

        /// <summary>
        /// Används för att ta fram referensen till privatkund i prebokning
        /// </summary>
        /// <param name="pre"></param>
        /// <returns></returns>
        public PreBokning GetPreBokningMedPrivatkund(PreBokning pre)
        {
            var temp = Context.PreBokning.Where(x => x.BokningsID == pre.BokningsID)
                    .Include(x => x.PrivatKund).SingleOrDefault();
            return temp;
        }

        public PreBokning GetPreBokningMedFöretagsKund(PreBokning pre)
        {
             var temp = Context.PreBokning.Where(x => x.BokningsID == pre.BokningsID)
                    .Include(x => x.FöretagsKund).SingleOrDefault();
            return temp;
        }

        public void TestaLogiTaBortKey(PreBokning pre)
        {
            using (var dbContext = new DatabaseContext())
            {
                var PreLogi = dbContext.Set<Logi>().Include(m => m.PreBokning)
                    .Select(p => p.PreBokning.BokningsID == pre.BokningsID)
                    .SingleOrDefault();
                dbContext.SaveChanges();
            }
        }

        public PreBokning GetPrebokningToBokning(PreBokning pre)
        {
            var temp = Context.PreBokning.Where(x => x.BokningsID == pre.BokningsID).
                    Include(x => x.FöretagsKund).SingleOrDefault();
            return temp;
        }

        public PreBokning GetPreWithOwner(PreBokning pre)
        {
            var temp = Context.PreBokning.Where(x => x.BokningsID == pre.BokningsID).
                    Include(x => x.FöretagsKund).Include(x => x.PrivatKund).SingleOrDefault();
            return temp;
        }
    }
}
