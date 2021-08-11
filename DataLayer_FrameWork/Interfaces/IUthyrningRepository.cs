using BusinessEntities_FrameWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer_FrameWork.Interfaces
{
    public interface IUthyrningRepository : IGenericRepository<Uthyrning>
    {
        public List<Uthyrning> SökEfterUthyrning(string sökterm);
        public Faktura HämtaUthyrningsFaktura(int uId, int pId);
        public Uthyrning SearchUthyrning(string id);
        public List<Uthyrning> GetAllEjReturnerade(PrivatKund pk);
        public List<Utrustning> GetEjReturneradePK(int Id);
      
    }
}
