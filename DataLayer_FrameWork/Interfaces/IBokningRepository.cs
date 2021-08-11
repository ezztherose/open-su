using BusinessEntities_FrameWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer_FrameWork.Interfaces
{
    public interface IBokningRepository : IGenericRepository<Bokning>
    {
        public List<Bokning> SearchBokning(string search);
        public void RemoveprivatKund(PrivatKund privatKund, int PrivatKundID);
        public void RemoveföretagsKund(FöretagsKund företagsKund, int företagsKundID);
        public List<Bokning> GetEjUtskrivnaBokningsbekräftelser();

    }
}
