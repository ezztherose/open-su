using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities_FrameWork.Models;

namespace DataLayer_FrameWork.Interfaces
{
    public interface ISysAdminRepository : IGenericRepository<SysAdmin>
    {
        SysAdmin Login(string användarnamn, string password);
    }
}
