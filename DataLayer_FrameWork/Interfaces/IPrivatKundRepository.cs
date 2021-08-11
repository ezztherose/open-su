using BusinessEntities_FrameWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer_FrameWork.Interfaces
{
    public interface IPrivatKundRepository : IGenericRepository<PrivatKund>
    {
        public List<PrivatKund> SearchPrivatKund(string search);
        public PrivatKund TaBortPrivatKund(PrivatKund pk);
        public PrivatKund GetPreBokningPrivatKund(PreBokning pre);
    }
}
