using BusinessEntities_FrameWork.Models;
using DataLayer_FrameWork.Context;
using DataLayer_FrameWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer_FrameWork.Models
{   
    // GenericRepository används för att kunna används av alla entiteter av databasen
    public class HyrPrisRepository : GenericRepository<Hyrpris>, IHyrPrisRepository
    {
        public HyrPrisRepository(DatabaseContext context) : base(context)
        {
 
        }

        // Metod för hyrpris som hämtar alla priser för utrustning 
        // Returnerar antaldagar, utrustningsort & utrustningstyp som har valts 
        public Hyrpris HämtaPrisUtrustning(string dagar, string sort, string typ)
        {
            int d = int.Parse(dagar);
            return Context.Hyrpris.Where(x => x.AntalDagar == d && x.UtrustningSort.ToString() == typ && x.UtrustningsTyp.Equals(sort)).FirstOrDefault();
        }
    }
}
