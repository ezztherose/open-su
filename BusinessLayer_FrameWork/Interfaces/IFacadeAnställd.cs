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
    public interface IFacadeAnställd
    {
        Anställd LoginAnställd(string användarnamn, string password);
        public void UppdateraAnställd(Anställd anställd, int AnställningsID);
        public void RemovePersonal(Anställd Anställda);
        public void AddAnställd(Anställd Anställd);
        public List<Anställd> SearchAnställdEfternamn(string search);
        public List<Anställd> GetAllAnställd();
    }
}
