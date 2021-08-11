using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities_FrameWork.Models;
using BusinessLayer_FrameWork.Interfaces;
using DataLayer_FrameWork.Context;
using DataLayer_FrameWork.UnitOfWork;

//Klient kallar på facade, vilket skapar startup struktur för Anställd -> bygg design.

namespace BusinessLayer_FrameWork.Models
{
    public class FacadeAnställd : IFacadeAnställd
    {
        public UnitOfWork UnitOfWork { get; set; }

        public FacadeAnställd(DatabaseContext context)
        {
            UnitOfWork = new UnitOfWork(context);
        }

        public Anställd LoginAnställd(string användarnamn, string password)
        {
            Anställd anställd = UnitOfWork.AnställdRepository.Login(användarnamn, password);
            if (anställd != null && anställd.Lösenord == password)
                return anställd;
            return null;
        }

        public void UppdateraAnställd(Anställd anställd, int AnställningsID)
        {
            UnitOfWork.AnställdRepository.Update(anställd, AnställningsID);
            UnitOfWork.Complete();
        }

        public void AddAnställd(Anställd Anställd)
        {
            UnitOfWork.AnställdRepository.Add(Anställd);
            UnitOfWork.Complete();
        }

        public void RemovePersonal(Anställd Anställd)
        {
            UnitOfWork.AnställdRepository.Remove(Anställd.AnställningsID);
            UnitOfWork.Complete();
        }

        public List<Anställd> SearchAnställdEfternamn(string search)
        {
            List<Anställd> SökAnställd = new List<Anställd>();
            foreach (Anställd a in UnitOfWork.AnställdRepository.SearchAnställdEfternamn(search.ToLower()))
                SökAnställd.Add(a);
            return SökAnställd;
        }

        public List<Anställd> GetAllAnställd()
        {
            List<Anställd> anställdList = new List<Anställd>();
            anställdList.AddRange(UnitOfWork.AnställdRepository.GetAll());
            return anställdList;
        }
    }
}
