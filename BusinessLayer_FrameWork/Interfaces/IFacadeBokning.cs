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
    public interface IFacadeBokning
    {
        public List<Bokning> GetAllBokningar();
        public List<Bokning> SearchBokning(string search);
        public  DateTime veckaDatum(int year, int weekOfYear);
        public int GetVecka(DateTime time);
        public void BokaKonferens(DateTime _fråndatum, DateTime _tillDatum, string konferensTyp, double konferensPris, FöretagsKund fk, Bokning b);
        public string PreToBoking();
        public List<PreBokning> SortPreList();
        public void SingleBoking(PreBokning pre, int id);
        public List<Bokning> GetEjUtskrivnaBokningsbekräftelser();
        public void ÄndraStatusBokning(Bokning bokning);
    }
}
