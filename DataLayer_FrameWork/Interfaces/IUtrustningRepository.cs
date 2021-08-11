using BusinessEntities_FrameWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer_FrameWork.Interfaces
{
    public interface IUtrustningRepository : IGenericRepository<Utrustning>
    {
        List<Utrustning> SearchUtrustning(string utrustnings);
        public List<Utrustning> UtrustningPåUthyrningsID(Uthyrning Uthyrning);
    }
}
