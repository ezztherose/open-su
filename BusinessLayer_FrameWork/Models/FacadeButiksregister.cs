using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities_FrameWork.Models;
using BusinessLayer_FrameWork.Interfaces;
using DataLayer_FrameWork.Context;
using DataLayer_FrameWork.UnitOfWork;

//Klient kallar på facade, vilket skapar startup struktur för butiksregister -> bygg design.

namespace BusinessLayer_FrameWork.Models
{
    public class FacadeButiksregister : IFacadeButiksregister
    {
        public UnitOfWork UnitOfWork { get; set; }

        public FacadeButiksregister(DatabaseContext context)
        {
            UnitOfWork = new UnitOfWork(context);
        }

        public List<Utrustning> GetAllProdukter()
        {
            List<Utrustning> utrustningsList = new List<Utrustning>();
            utrustningsList.AddRange(UnitOfWork.UtrustningRepository.GetAll());
            return utrustningsList;
        }
    }
}
