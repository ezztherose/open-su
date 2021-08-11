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
    public class KonferensPrisRepository : GenericRepository<KonferensPris>,IKonferensPrisRepository
    {
        public KonferensPrisRepository(DatabaseContext context) : base(context)
        {
            
        }

        // Metod för konferenspriser 
        // Returnerar priset genom vald konferenstyp, tidtyp & vecka 
        public KonferensPris GetPrisKonferens(string veckoTyp, string tidTyp, int _konferensVecka)
        {
            return Context.KonferensPris.Where(x => x.KonferensTyp == veckoTyp && x.TidTyp == tidTyp && x.Vecka == _konferensVecka).FirstOrDefault();
        }
    }
}
