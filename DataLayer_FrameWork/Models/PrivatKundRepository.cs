using BusinessEntities_FrameWork.Models;
using DataLayer_FrameWork.Context;
using DataLayer_FrameWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer_FrameWork.Models
{   
    // GenericRepository används för att kunna används av alla entiteter av databasen
    public class PrivatKundRepository : GenericRepository<PrivatKund>, IPrivatKundRepository
    {
        public PrivatKund privatKund { get; set; }

        public PrivatKundRepository(DatabaseContext context) : base(context)
        {
            
        }

        // Lista på alla privatkunder 
        public List<PrivatKund> SearchPrivatKund (string search)
        {
            return Context.PrivatKund.Where(x => x.PrivatEfternamn.ToString().Equals(search)).ToList();
        }

        // Metod för att ta bort en privatkund 
        public PrivatKund TaBortPrivatKund(PrivatKund pk)
        {
            using (var db = new DatabaseContext())
            {
                var temp = db.PrivatKund.Where(x => x.PrivatKundID == pk.PrivatKundID).Include(x => x.Bokningar).FirstOrDefault();
                return temp;
            }
        }
        public PrivatKund GetPreBokningPrivatKund(PreBokning pre)
        {
            var temp = Context.PrivatKund.Where(x => x.PrivatKundID == pre.PrivatKund.PrivatKundID).
                    Include(x => x.PreBokningar).SingleOrDefault();
            return temp;
        }
    }
}
