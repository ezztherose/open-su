using BusinessEntities_FrameWork.Models;
using DataLayer_FrameWork.Context;
using DataLayer_FrameWork.Interfaces;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer_FrameWork.Models
{   
    // Representerar en kombination av UnitofWork och repository mönster för att kunna fråga från en databas
    //  och gruppera ändringar tillsammans tillbaka till arkivet som en enhet. 
    public class FakturaRepository : GenericRepository<Faktura>, IFakturaRepository
    {
        public FakturaRepository(DatabaseContext context) : base(context)
        {

        }
        // Hämtar en lista på alla fakturor för logi 
        public List<Faktura> FakturorFörLogi()
        {
            DatabaseContext dbContext = new DatabaseContext();
            var fakturas = from Faktura in dbContext.Faktura
                           where Faktura.Typ == "Bokning"
                           orderby Faktura.Typ descending
                           select Faktura;
            return fakturas.ToList();
        }
        // Metod för delbetalning för bokningar 
        public Faktura HämtaDelbetalning(string typ, Bokning bokning)
        {
            return Context.Faktura.Where(x=> x.Bokning.BokningsID == bokning.BokningsID && x.Typ == typ).FirstOrDefault();
        }

        // En lista för icke utskrivana fakturor från privatakunder, uthyrningar, bokningar, företagskunder 
        public List<Faktura> GetEjUtskrivna()
        {
            return Context.Faktura.Where(x => x.Status == false).Include(x=>x.Privat).Include(x=>x.Uthyrning).Include(x=>x.Bokning).Include(x=>x.Företag).ToList();
        }
    }
}
