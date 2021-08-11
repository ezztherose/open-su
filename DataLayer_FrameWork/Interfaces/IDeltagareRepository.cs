using BusinessEntities_FrameWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer_FrameWork.Interfaces
{
    public interface IDeltagareRepository : IGenericRepository<Deltagare>
    {
        public List<Deltagare> HämtaDeltagarePåId(int id);
    }
}
