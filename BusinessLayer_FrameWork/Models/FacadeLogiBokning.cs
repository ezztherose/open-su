using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer_FrameWork.Interfaces;
using DataLayer_FrameWork.Context;
using DataLayer_FrameWork.UnitOfWork;

//Klient kallar på facade, vilket skapar startup struktur för logiBokning -> bygg design.

namespace BusinessLayer_FrameWork.Models
{
    public class FacadeLogiBokning : IFacadeLogiBokning
    {
        public UnitOfWork UnitOfWork { get; set;  }

        public FacadeLogiBokning(DatabaseContext context)
        {
            UnitOfWork = new UnitOfWork(context);
        }
    }
}
