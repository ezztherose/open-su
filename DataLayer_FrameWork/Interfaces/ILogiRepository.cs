using BusinessEntities_FrameWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer_FrameWork.Interfaces
{
    public interface ILogiRepository : IGenericRepository<Logi>
    {
        public int HämtaLogiPåTyp(string lägenhetstyp);
        List<Logi> SearchLogi(string l);
        public List<Logi> LogiPåBokningsID(Bokning Bokning);
        public List<Logi> HämtaLogiPreBokning(PrivatKund privatKund, PreBokning pre);
        public List<Logi> HämtaLogiPreBokningFöretag(FöretagsKund företagsKund, PreBokning pre);
        public List<Logi> AvslagAvPrebokning(PreBokning pre);

    }
}
