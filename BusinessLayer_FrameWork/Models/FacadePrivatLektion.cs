using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities_FrameWork.Models;
using BusinessLayer_FrameWork.Interfaces;
using DataLayer_FrameWork.Context;
using DataLayer_FrameWork.UnitOfWork;

//Klient kallar på facade, vilket skapar startup struktur för privatlektion -> bygg design.

namespace BusinessLayer_FrameWork.Models
{
    public class FacadePrivatLektion : IFacadePrivatLektion
    {
        public UnitOfWork UnitOfWork { get; set; }

        public FacadePrivatLektion(DatabaseContext context)
        {
            UnitOfWork = new UnitOfWork(context);
        }
        
        public List<Privatskidlektion> GetAllPrivatLektion()
        {
            List<SkidLektion> tempskidlektion = UnitOfWork.SkidLektionRepository.GetAll().ToList();
            List<Privatskidlektion> pl = new List<Privatskidlektion>();

            for (int i = 0; i < tempskidlektion.Count; i++)
                if (tempskidlektion[i].Privatskidlektioner != null)
                {
                    Privatskidlektion p = (Privatskidlektion)tempskidlektion[i].Privatskidlektioner;
                    pl.Add(p);
                }

            return pl;
        }
        public List<Privatskidlektion> HämtaAllPrivatLektioner()
        {
           return (List<Privatskidlektion>)UnitOfWork.PrivatLektionRepository.GetAll();
        }

        public void LäggTillPrivatLektion(SkidLektion sl)
        {
            //UnitOfWork.PrivatLektionRepository.Add(sl);
        }

        public void RegistreraLektion(Privatskidlektion pl, double pris , int tid)
        {
            pl = RäknaDeltagare(pl);
            pl.Tid = tid;
            UnitOfWork.PrivatLektionRepository.Add(pl);
            SkidLektion s = UnitOfWork.SkidLektionRepository.HämtaSpecifiktPris();
            pl.SkidLektion = s;
            s.Privatskidlektioner.Add(pl);
            UnitOfWork.Complete();
        }

        private Privatskidlektion RäknaDeltagare(Privatskidlektion pl)
        {
            pl.Antaldeltagare = pl.PrivatDeltagare.Count;
            return pl;
        }

        public void RegistreraLektion(Privatskidlektion pl)
        {
            throw new NotImplementedException();
        }
    }
}


