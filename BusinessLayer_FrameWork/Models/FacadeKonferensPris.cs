using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities_FrameWork.Models;
using BusinessLayer_FrameWork.Interfaces;
using DataLayer_FrameWork.Context;
using DataLayer_FrameWork.UnitOfWork;

//Klient kallar på facade, vilket skapar startup struktur för konferensPris -> bygg design.

namespace BusinessLayer_FrameWork.Models
{
    public class FacadeKonferensPris : IFacadeKonferensPris
    {
        public UnitOfWork UnitOfWork { get; set; }

        public FacadeKonferensPris(DatabaseContext context)
        {
            UnitOfWork = new UnitOfWork(context);
        }

        public List<KonferensPris> HämtaKonferensPris()
        {
            return UnitOfWork.KonferensPrisRepository.GetAll().ToList();
        }

        public void UppdateraKonferensPris(KonferensPris konferensPris, int konferensprisID)
        {
            UnitOfWork.KonferensPrisRepository.Update(konferensPris, konferensprisID);
        }
    }
}
