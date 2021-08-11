using BusinessEntities_FrameWork.Models;
using DataLayer_FrameWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer_FrameWork.Interfaces
{
    public interface IKonferensRepository : IGenericRepository<Konferens>
    {
        List<Konferens> SearchKonferens(string k);
        public List<Konferens> GetKonferensLiten();
        public List<Konferens> GetKonferensStor();
        public List<Konferens> GetKonferensPreBokingCompany(FöretagsKund f, PreBokning pre);
        public List<Konferens> KonferensPåBokningsID(Bokning bokning);

    }

}
