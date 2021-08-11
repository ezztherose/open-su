using BusinessEntities_FrameWork.Interfaces;
using BusinessEntities_FrameWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer_FrameWork.Interfaces
{
    public interface IFöretagsKundRepository : IGenericRepository<FöretagsKund>
    {
        public List<FöretagsKund> SearchFöretagsKund(string search);
        public FöretagsKund TaBortFöretagsKund(FöretagsKund fk);
        public FöretagsKund GetPreBokningFöretag(PreBokning pre);
    }
}
