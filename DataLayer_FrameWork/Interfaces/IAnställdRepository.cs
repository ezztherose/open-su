using BusinessEntities_FrameWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer_FrameWork.Interfaces
{
    public interface IAnställdRepository : IGenericRepository<Anställd>
    {
        Anställd Login(string användarnamn, string password);
        List<Anställd> SearchAnställdEfternamn(string ae);
    }
}
