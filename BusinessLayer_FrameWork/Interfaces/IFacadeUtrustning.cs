using BusinessEntities_FrameWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Bygger specifikt gränssnitt och implementerar datan från respektive modul. 
// Användaren kan göra specfika val utan att påverka alla subklasser.

namespace BusinessLayer_FrameWork.Interfaces
{
    public interface IFacadeUtrustning
    {
        public Utrustning GetSkida(string typ);
        public Utrustning GetPjäxa(string typ);
        public Utrustning GetStavar(string typ);
        public Utrustning GetSkoter(string typ);
        public Utrustning GetSnowboard(string typ);
        public Utrustning GetSkor(string typ);
        public Utrustning GetHjälm(string typ);
        public List<Utrustning> GetAllProdukter();
        public List<Utrustning> SearchUtrustning(string search);
        public void RemoveUtrustning(Utrustning u);
        public List<Utrustning> UtrustningPåUthyrningsID(Uthyrning Uthyrning);
        
    }
}
