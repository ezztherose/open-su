using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities_FrameWork.Models;
using BusinessLayer_FrameWork.Interfaces;
using DataLayer_FrameWork.Context;
using DataLayer_FrameWork.UnitOfWork;

//Klient kallar på facade, vilket skapar startup struktur för skidlektion -> bygg design.

namespace BusinessLayer_FrameWork.Models
{
    public class FacadeBokningSkidlektion : IFacadeBokningSkidlektion
    {
        public UnitOfWork UnitOfWork { get; set; }

        public FacadeBokningSkidlektion(DatabaseContext context)
        {
            UnitOfWork = new UnitOfWork(context);
        }

        public List<Gruppskidlektion> Gruppskidlektion(string search)
        {
            List<Gruppskidlektion> temp = new List<Gruppskidlektion>();
            temp.AddRange(UnitOfWork.GruppskidlektionRepository.GetAll().ToList());
            return UnitOfWork.GruppskidlektionRepository.GetAll().ToList();
        }
    }
}
