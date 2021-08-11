using BusinessEntities_FrameWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer_FrameWork.Interfaces
{
    public interface IGruppskidlektionRepository : IGenericRepository <Gruppskidlektion> 
    {
        public List<Gruppskidlektion> SearchGruppskidlektion(string search, int dagar);
        public List<Deltagare> GetDeltagare(int id);
    }
}
