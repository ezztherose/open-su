using BusinessEntities_FrameWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer_FrameWork.Interfaces
{
    public interface IKonferensPrisRepository : IGenericRepository<KonferensPris>
    {
        public KonferensPris GetPrisKonferens(string veckoTyp, string tidTyp, int _konferensVecka);
    }
}
