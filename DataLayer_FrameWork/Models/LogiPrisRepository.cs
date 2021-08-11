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
    public class LogiPrisRepository : GenericRepository<LogiPris>, ILogiPrisRepository
    {
        public LogiPrisRepository(DatabaseContext context) : base(context)
        {

        }

        // Metod för logiPris som hämtar alla logipriser 
        // Returnerar de logipriser som passar med logiTyp, dagar & vecka 
        public LogiPris HämtaPrisLogi(string logityp, int dagar, int vecka)
        {   
            return Context.LogiPris.Where(x => x.LogiTyp == logityp && x.Dagar == dagar && x.Vecka == vecka).FirstOrDefault();
        }

    }
}
