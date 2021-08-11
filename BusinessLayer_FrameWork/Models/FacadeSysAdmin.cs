using BusinessEntities_FrameWork.Models;
using BusinessLayer_FrameWork.Helper;
using BusinessLayer_FrameWork.Interfaces;
using DataLayer_FrameWork.Context;
using DataLayer_FrameWork.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Klient kallar på facade, vilket skapar startup struktur för sysadmin -> bygg design.

namespace BusinessLayer_FrameWork.Models
{
    public class FacadeSysAdmin : IFacadeSysAdmin
    {
        public UnitOfWork UnitOfWork { get; set; }
        internal DropFKClass DropFKClass { get; set; }

        public FacadeSysAdmin(DatabaseContext context)
        {
            UnitOfWork = new UnitOfWork(context);
            DropFKClass = new DropFKClass(context);
        }

        public SysAdmin LoginSysAdmin(string användarnamn, string password)
        {
            SysAdmin SysAdmin = UnitOfWork.SysAdminRepository.Login(användarnamn, password);
            if (SysAdmin != null && SysAdmin.Lösenord == password)
                return SysAdmin;
            return null;
        }

        public List<LogiPris> GetAllLogiPrice()
        {
            List<LogiPris> logiPris = new List<LogiPris>();
            logiPris.AddRange(UnitOfWork.LogiPrisRepository.GetAll());
            return logiPris;
        }

        public void ResetDB()
        {
           // DropFKClass.Run();
            UnitOfWork.ResetDB();
        }

        public void LäggTillSysAdmin(SysAdmin sa)
        {
            UnitOfWork.SysAdminRepository.Add(sa);
            UnitOfWork.Complete();
        }
    }
}
