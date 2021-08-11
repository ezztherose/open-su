using BusinessEntities_FrameWork.Models;
using DataLayer_FrameWork.Context;
using DataLayer_FrameWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer_FrameWork.Models
{
    class FöretagsKundRepository : GenericRepository<FöretagsKund>, IFöretagsKundRepository
    {
        public FöretagsKundRepository(DatabaseContext context) : base(context)
        {

        }
        
        // En lista på alla företagskunder genom FöretagskundID 
        public List<FöretagsKund> SearchFöretagsKund(string search)
        {
            return Context.FöretagsKund.Where(x => x.FöretagKundID.ToString().Equals(search)).ToList();
        }

        // Metod för att ta bort företagskunder 
        // Hämtar alla företagskunder via företagsKundID 
        public FöretagsKund TaBortFöretagsKund(FöretagsKund fk)
        {
            using (var db = new DatabaseContext())
            {
                var temp = db.FöretagsKund.Where(x => x.FöretagKundID == fk.FöretagKundID).Include(x => x.Bokningar).FirstOrDefault();
                return temp;
            }
        }

        public FöretagsKund GetPreBokningFöretag(PreBokning pre)
        {
            var temp = Context.FöretagsKund.Where(x => x.FöretagKundID == pre.FöretagsKund.FöretagKundID).
                    Include(x => x.PreBokningar).SingleOrDefault();
            return temp;
        }
    }
}
