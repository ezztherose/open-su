using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities_FrameWork.Models;
using BusinessLayer_FrameWork.Interfaces;
using DataLayer_FrameWork.Context;
using DataLayer_FrameWork.UnitOfWork;

//Klient kallar på facade, vilket skapar startup struktur för utrustning -> bygg design.

namespace BusinessLayer_FrameWork.Models
{
    public class FacadeUtrustning : IFacadeUtrustning
    {

        public UnitOfWork UnitOfWork { get; set; }

        public FacadeUtrustning(DatabaseContext context)
        {
            UnitOfWork = new UnitOfWork(context);
        }

        public List<Utrustning> UtrustningPåUthyrningsID(Uthyrning Uthyrning)
        {
            List<Utrustning> temp = UnitOfWork.UtrustningRepository.UtrustningPåUthyrningsID(Uthyrning);
            return temp;
        }
        public List<Utrustning> GetAllProdukter()
        {
            List<Utrustning> utrustningList = new List<Utrustning>();
            utrustningList.AddRange(UnitOfWork.UtrustningRepository.GetAll());
            return utrustningList;
        }

        public Utrustning GetSkida(string sort)
        {
            foreach (Utrustning item in UnitOfWork.UtrustningRepository.GetAll())
                if (item.Tillgänglig == true && item.UtrustningsTyp.Equals("Skidor") && item.UtrustningSort.Equals(sort))
                {
                    item.Tillgänglig = false;
                    UnitOfWork.DBContext.SaveChanges(); // Denna borde egentligen komma senare, när man faktiskt bokar. Men fungerar för tillfället. 
                    return item;
                } 
            return null;
        }
       

        public Utrustning GetPjäxa(string sort)
        {
            foreach (Utrustning item in UnitOfWork.UtrustningRepository.GetAll())
                if (item.Tillgänglig == true && item.UtrustningsTyp.Equals("Pjäxor") && item.UtrustningSort.Equals(sort))
                {
                    item.Tillgänglig = false;
                    return item;
                }
            return null;
        }

        public Utrustning GetStavar(string sort)
        {
            foreach (Utrustning item in UnitOfWork.UtrustningRepository.GetAll())
                if (item.Tillgänglig == true && item.UtrustningsTyp.Equals("Stavar") && item.UtrustningSort.Equals(sort))
                {
                    item.Tillgänglig = false;
                    return item;
                    
                }
            return null;
        }

        public Utrustning GetSkoter(string sort)
        {
            foreach (Utrustning item in UnitOfWork.UtrustningRepository.GetAll())
                if (item.Tillgänglig == true && item.UtrustningsTyp.Equals("Skoter") && item.UtrustningSort.Equals(sort))
                {
                    item.Tillgänglig = false;
                    return item;
                }
            return null;
        }

        public Utrustning GetSnowboard(string sort)
        {
            foreach (Utrustning item in UnitOfWork.UtrustningRepository.GetAll())
                if (item.Tillgänglig == true && item.UtrustningsTyp.Equals("Snowboard") && item.UtrustningSort.Equals(sort))
                {
                    item.Tillgänglig = false;
                    return item;
                }
            return null;
        }

        public Utrustning GetSkor(string sort)
        {
            foreach (Utrustning item in UnitOfWork.UtrustningRepository.GetAll())
                if (item.Tillgänglig == true && item.UtrustningsTyp.Equals("Skor") && item.UtrustningSort.Equals("Skor"))
                {
                    item.Tillgänglig = false;
                    return item;
                }
            return null;
        }

        public Utrustning GetHjälm(string sort)
        {
            sort = "Alpint";
            foreach (Utrustning item in UnitOfWork.UtrustningRepository.GetAll())
                if (item.Tillgänglig == true && item.UtrustningsTyp.Equals("Hjälm") && item.UtrustningSort.Equals("Hjälm"))
                {
                    item.Tillgänglig = false;
                    return item;
                }
            return null;
        }

        public List<Utrustning> SearchUtrustning(string search)
        {
            List<Utrustning> utrustnings = new List<Utrustning>();
            foreach (Utrustning u in UnitOfWork.UtrustningRepository.SearchUtrustning(search.ToLower()))
                utrustnings.Add(u);
            return utrustnings;
        }

        public void RemoveUtrustning(Utrustning utrustning)
        {
            UnitOfWork.UtrustningRepository.Remove(utrustning.ArtikelID);
            UnitOfWork.Complete();
        }
    }
}
