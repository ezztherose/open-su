using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities_FrameWork.Models;
using BusinessLayer_FrameWork.Interfaces;
using DataLayer_FrameWork.Context;
using DataLayer_FrameWork.UnitOfWork;

//Klient kallar på facade, vilket skapar startup struktur för deltagare -> bygg design.

namespace BusinessLayer_FrameWork.Models
{
    public class FacadeDeltagare : IFacadeDeltagare
    {
        public UnitOfWork UnitOfWork { get; set; }

        public FacadeDeltagare(DatabaseContext context)
        {
            UnitOfWork = new UnitOfWork(context);
        }

        public List<Deltagare> HämtaAllaDeltagare()
        {
            return UnitOfWork.DeltagareRepository.GetAll().ToList();
        }

        public List<Deltagare> HämtaDeltagarePåId(int id)
        {
            return UnitOfWork.DeltagareRepository.HämtaDeltagarePåId(id);
        }

        public void Remove(int id)
        {
            UnitOfWork.DeltagareRepository.Remove(id);
        }
    }
}
