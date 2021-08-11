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
    public interface IFacadePrivatKund
    {
        public void LäggTillKund(PrivatKund nyKund);
        public List<PrivatKund> GetAllPKunder();
        public List<PrivatKund> SearchPrivatKund(string search);
        public void UppdateraPrivatkund(PrivatKund privatKund, int privatKundID);
        public PrivatKund HämtaPrivatKund(int ID);
        public bool KontrolleraRabatt(PrivatKund pk);
        public void RemovePrivatkund(PrivatKund privatkund);
        public List<PrivatKund> SearchUthyrningByFullName(string searchWord);
    }

}
