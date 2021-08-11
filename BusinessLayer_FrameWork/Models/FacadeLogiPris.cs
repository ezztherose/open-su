using BusinessEntities_FrameWork.Models;
using BusinessLayer_FrameWork.Interfaces;
using DataLayer_FrameWork.Context;
using DataLayer_FrameWork.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Klient kallar på facade, vilket skapar startup struktur för Logipris -> bygg design.

namespace BusinessLayer_FrameWork.Models
{
    public class FacadeLogiPris : IFacadeLogiPris
    {
        public UnitOfWork UnitOfWork { get; set; }
        public LogiPris Pris { get;  set; }

        public FacadeLogiPris(DatabaseContext context)
        {
            UnitOfWork = new UnitOfWork(context);
        }

        public List<LogiPris> GetAllLogiPris()
        {
            List<LogiPris> LogiPrisList = new List<LogiPris>();
            LogiPrisList.AddRange(UnitOfWork.LogiPrisRepository.GetAll());
            return LogiPrisList;
        }

        public double GetLogiPris(string logityp, int dagar, int vecka)
        {
            double b = 0;
            LogiPris lp = new LogiPris();
            lp = UnitOfWork.LogiPrisRepository.HämtaPrisLogi(logityp, dagar, vecka);
            b = lp.Pris;
            return b;
        }

        public List<LogiPris> HämtaLogiPris()
        {
            return UnitOfWork.LogiPrisRepository.GetAll().ToList();
        }

        public void UppdateraLogiPris(LogiPris lp, int id)
        {
            UnitOfWork.LogiPrisRepository.Update(lp, id);
        }
    }
}
