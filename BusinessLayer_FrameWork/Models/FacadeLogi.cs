using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities_FrameWork.Models;
using BusinessLayer_FrameWork.Interfaces;
using DataLayer_FrameWork.Context;
using DataLayer_FrameWork.UnitOfWork;

//Klient kallar på facade, vilket skapar startup struktur för logi -> bygg design.

namespace BusinessLayer_FrameWork.Models
{
    public class FacadeLogi : IFacadeLogi
    {
        public UnitOfWork UnitOfWork { get; set; }

        public FacadeLogi(DatabaseContext context)
        {
            UnitOfWork = new UnitOfWork(context);
        }

        public List<Logi> GetAllLedigaLägenheter()
        {
            List<Logi> temp = new List<Logi>();
            foreach (Logi obj in UnitOfWork.LogiRepository.GetAll().ToList())
                if (obj.Tillgänglighet == true) temp.Add(obj);
            return temp;
        }

        public List<Logi> GetTillgängligStor()
        {
            List<Logi> temp = new List<Logi>();
            foreach (Logi obj in UnitOfWork.LogiRepository.GetAll().ToList())
                if (obj.Tillgänglighet == true && obj.LogiTyp == "Stor") temp.Add(obj);
            return temp;
        }

        public List<Logi> GetAllCamping()
        {
            List<Logi> temp = new List<Logi>();
            foreach (Logi obj in UnitOfWork.LogiRepository.GetAll().ToList())           
                if (obj.Tillgänglighet == true && obj.LogiTyp == "Camping") temp.Add(obj);
            return temp;
        }

        public List<Logi> GetTillgängligLiten()
        {
            List<Logi> temp = new List<Logi>();
            foreach (Logi obj in UnitOfWork.LogiRepository.GetAll().ToList())
                if (obj.Tillgänglighet == true && obj.LogiTyp == "Liten") temp.Add(obj);
            return temp;
        }
        public List<Logi> LogiPåBokningsID(Bokning Bokning)
        {
            List<Logi> temp = UnitOfWork.LogiRepository.LogiPåBokningsID(Bokning);
            return temp;
        }

        public Logi HämtaLogi(string logityp)
        {
            foreach (Logi item in UnitOfWork.LogiRepository.GetAll())
                if (item.Tillgänglighet == true && item.LogiTyp == (logityp))
                {
                    item.Tillgänglighet = false;
                    return item;
                }
            return null;
        }

        public List<Logi> GetAllLogiPris()
        {
            throw new NotImplementedException();
        }

        public int HämtaLogiPåTyp(string lägenhetstyp)
        {
            return UnitOfWork.LogiRepository.HämtaLogiPåTyp(lägenhetstyp);
        }

        public List<Logi> GetAllLogi()
        {
             return UnitOfWork.LogiRepository.GetAll().ToList();
        }

        public List<Logi> SearchLogi(string search)
        {
            List<Logi> söklogi = new List<Logi>();
            foreach (Logi l in UnitOfWork.LogiRepository.SearchLogi(search.ToLower()))
                söklogi.Add(l);
            return söklogi;
        }

        public void RemoveLogidata(Logi Logi)
        {
            UnitOfWork.LogiRepository.Remove(Logi.LogiID);
            UnitOfWork.Complete();
        }
    }
}
