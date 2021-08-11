using BusinessEntities_FrameWork.Models;
using DataLayer_FrameWork.Context;
using DataLayer_FrameWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer_FrameWork.Models
{
    public class SysAdminRepository : GenericRepository<SysAdmin>, ISysAdminRepository
    {
        public SysAdminRepository(DatabaseContext context) : base(context)
        {

        }

        // Metod för logga in för systemadministratör 
        public SysAdmin Login(string användarnamn, string password)
        {
            return Context.SysAdmin.Where(x => användarnamn.ToLower() == användarnamn.ToLower() && x.Lösenord.ToString().Equals(password.ToString())).SingleOrDefault();
        }
    }
}
