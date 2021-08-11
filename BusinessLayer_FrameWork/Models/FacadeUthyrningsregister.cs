using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities_FrameWork.Models;
using BusinessLayer_FrameWork.Interfaces;
using DataLayer_FrameWork.Context;
using DataLayer_FrameWork.UnitOfWork;

//Klient kallar på facade, vilket skapar startup struktur för uthyrningsregister -> bygg design.

namespace BusinessLayer_FrameWork.Models
{
    public class FacadeUthyrningsregister : IFacadeUthyrningsregister
    {
        public UnitOfWork UnitOfWork { get; set; }

        public FacadeUthyrningsregister(DatabaseContext context)
        {
            UnitOfWork = new UnitOfWork(context);
        }

        public List<Uthyrningsregister> GetAllUthyrningar()
        {
            return null;
        }
    }
}
