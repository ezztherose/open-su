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
    // GenericRepository används för att kunna används av alla entiteter av databasen
    public class KonferensRepository : GenericRepository<Konferens>, IKonferensRepository
    {
        public KonferensRepository(DatabaseContext context) : base(context)
        {

        }

        // Lista på alla existerande konferenser 
        // Returnerar konferensID 

        public List<Konferens>KonferensPåBokningsID(Bokning bokning)
        {
            return Context.Konferens.Where(x => x.Bokning.BokningsID == bokning.BokningsID).ToList();
        }
           
        public List<Konferens> SearchKonferens(string search)
        {
            return Context.Konferens.Where(x => x.KonferensID.ToString().Contains(search)).ToList();
        }

        // Lista på vald konferens, storlek stor 
        // Returnerar den valda konferenstypen som heter "konferensStor"
        public List<Konferens> GetKonferensStor()
        {
            return Context.Konferens.Where(x => x.KonferensTyp == "KonferensStor").ToList();
        }

        // Lista på vald konferens, storlek liten
        // Returnerar den valda konferenstypen som heter "Konferensliten"
        public List<Konferens> GetKonferensLiten()
        {
            return Context.Konferens.Where(x => x.KonferensTyp == "KonferensLiten").ToList();
        }

        public List<Konferens> GetKonferensPreBokingCompany(FöretagsKund f, PreBokning pre)
        {
            return Context.Konferens.Where(x => x.PreBokning.FöretagsKund.FöretagKundID == f.FöretagKundID && x.PreBokning.BokningsID == pre.BokningsID)
               .Include(x => x.PreBokning).ToList();
        }
    }
}
