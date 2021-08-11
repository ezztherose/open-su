using BusinessEntities_FrameWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer_FrameWork.Interfaces
{
    public interface ISkidLektionRepository : IGenericRepository<SkidLektion>
    {
        public SkidLektion HämtaSpecifiktPrisGrupp(string typ, int dagar);
        public SkidLektion HämtaSpecifiktPris();

        // ----- ny grupp form och kod ------
        double GetPriceForSpecificGroupLesson(int day, string color);
    }
}
