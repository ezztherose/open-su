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
    public class FacadeSkidlektion : IFacadeSkidlektion
    {
        private double _pris;

        public double Pris
        {
            get { return _pris; }
            set { _pris = value; }
        }

        public UnitOfWork UnitOfWork { get; set; }
        public List<double> Priser { get; set; }

        public FacadeSkidlektion(DatabaseContext context)
        {
            UnitOfWork = new UnitOfWork(context);
        }

        public List<SkidLektion> GetAllSkidLektioner()
        {
            return UnitOfWork.SkidLektionRepository.GetAll().ToList();
        }
        public SkidLektion HämtaSkidLektion(int ID)
        {
            return UnitOfWork.SkidLektionRepository.Get(ID);
        }

        public void RemoveSkidLektion(SkidLektion sl)
        {
            UnitOfWork.SkidLektionRepository.Remove(sl.SkidLektionsID);
            UnitOfWork.Complete();
        }

        public double GetSkidlektionPrisPrivat(string dagar, string typ, string antal)
        {
            //SkidLektion sl = UnitOfWork.SkidLektionRepository.HämtaSkidlektionPrivatPris(dagar, typ, antal);
            //Pris = sl.Pris;
            return Pris;
        }
    }
}
