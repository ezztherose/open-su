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
    public class LogiRepository : GenericRepository<Logi>, ILogiRepository
    {
        public LogiRepository(DatabaseContext context) : base(context)
        {

        }

        // Hämtar fram logi på den lägenhetstyp som väljs 
        public int HämtaLogiPåTyp(string lägenhetstyp)
        {
            return Context.Logi.Where(x => x.LogiTyp == lägenhetstyp).Count();
        }

        // Lista på preliminärbokningar på logi för privatkund 
        public List<Logi> HämtaLogiPreBokning(PrivatKund privatKund, PreBokning pre)
        {
            return Context.Logi.Where(x => x.PreBokning.PrivatKund.PrivatKundID == privatKund.PrivatKundID && x.PreBokning.BokningsID == pre.BokningsID).ToList();
        }

        // Lista på preliminärbokningar på logi för företagskund 
        public List<Logi> HämtaLogiPreBokningFöretag(FöretagsKund företagsKund, PreBokning pre)
        {
            return Context.Logi.Where(x => x.PreBokning.FöretagsKund.FöretagKundID == företagsKund.FöretagKundID && x.PreBokning.BokningsID == pre.BokningsID)
                .Include(x => x.PreBokning).ToList();
        }

        // Lista på alla logier 
        public List<Logi> SearchLogi(string search)
        {
            return Context.Logi.Where(x => x.LogiID.ToString().Contains(search)).ToList();
        }

        // Lista på alla logier genom bokningsID 
        public List<Logi> LogiPåBokningsID(Bokning Bokning)
        {
            return Context.Logi.Where(x => x.Bokning.BokningsID == Bokning.BokningsID).ToList();
        }

        // Lista på preliminärbokningar som har fått avslag 
        public List<Logi> AvslagAvPrebokning(PreBokning pre)
        {
            return Context.Logi.Where(x => x.PreBokning.BokningsID == pre.BokningsID).ToList();
        }
    }
}
