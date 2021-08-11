using BusinessEntities_FrameWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer_FrameWork.Interfaces
{
    public interface ILogiPrisRepository : IGenericRepository<LogiPris>
    {
        public LogiPris HämtaPrisLogi(string logityp, int dagar, int vecka);
    }
}
