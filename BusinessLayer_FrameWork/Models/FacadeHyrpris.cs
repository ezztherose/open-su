using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities_FrameWork.Models;
using BusinessLayer_FrameWork.Interfaces;
using DataLayer_FrameWork.Context;
using DataLayer_FrameWork.UnitOfWork;

//Klient kallar på facade, vilket skapar startup struktur för hyrpris -> bygg design.

namespace BusinessLayer_FrameWork.Models
{
    public class FacadeHyrpris : IFacadeHyrpris
    {     
        public UnitOfWork UnitOfWork { get; set; }
        public Hyrpris Pris { get; set; }

        public FacadeHyrpris(DatabaseContext context)
        {
            UnitOfWork = new UnitOfWork(context);         
            Pris = new Hyrpris();
        }

        public List<Hyrpris> HämtaAllaHyrpris()
        {
            return UnitOfWork.HyrPrisRepository.GetAll().ToList();
        }

        public void UppdateraHyrpris(Hyrpris hyrpris, int hyrprisID)
        {
            UnitOfWork.HyrPrisRepository.Update(hyrpris, hyrprisID);
            UnitOfWork.Complete();
        }

        public double GetUtrustningsHyrpris(string dagar, string sort, string typ)
        {
            double b = 0;
            Pris = UnitOfWork.HyrPrisRepository.HämtaPrisUtrustning(dagar, sort, typ);
            b = Pris.Pris;
            return b;
        }
    }
}
