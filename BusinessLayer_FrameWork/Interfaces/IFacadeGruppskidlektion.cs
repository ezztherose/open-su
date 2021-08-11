using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities_FrameWork.Models;

// Bygger specifikt gränssnitt och implementerar datan från respektive modul. 
// Användaren kan göra specfika val utan att påverka alla subklasser.

namespace BusinessLayer_FrameWork.Interfaces
{
    public interface IFacadeGruppskidlektion
    {
        //public void LäggTillGruppskidlektion(Gruppskidlektion gl, double pris, string typ, int dagar, PrivatKund pk, FöretagsKund fk);
        //
        //
        //public Faktura FakturaSkidskola(PrivatKund pk, FöretagsKund fk, string typ, int dagar);
        //
        //
        //

        // ---- För nya guit nedan ------------
        public string RegisterToLesson(List<Deltagare> u, string color, int days);
        public double GetParticipandPrice(int _sendDays, string _sendColor);
        public List<PrivatKund> SearchCustomer(string searchName);
        public string GenerateInvoice(PrivatKund p, FöretagsKund f, double price);
        public void CreateLessonsForNewWeek();
        public List<Gruppskidlektion> GetAllGrupplektioner();
        public List<Deltagare> GetDeltagare(int id);
        public List<Gruppskidlektion> SearchGruppskidlektion(string search, int Dagar);
        public List<Gruppskidlektion> GetAll();
    }
}
