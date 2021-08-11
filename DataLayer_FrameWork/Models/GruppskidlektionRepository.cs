using BusinessEntities_FrameWork.Models;
using DataLayer_FrameWork.Context;
using DataLayer_FrameWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer_FrameWork.Models
{  
    // Repository för Gruppskidlektion
    public class GruppskidlektionRepository : GenericRepository<Gruppskidlektion>, IGruppskidlektionRepository
    {
        public Gruppskidlektion Gruppskidlektion { get; set; }

        public GruppskidlektionRepository(DatabaseContext context) : base(context)
        {
            
        }

        // En lista på gruppskidlektioner. Hämtar färg och antal dagar som bokas till listan 
        public List<Gruppskidlektion> SearchGruppskidlektion(string search , int dagar)
        {
            return Context.Gruppskidlektion.Where(x => x.Färg.ToString().Equals(search) && x.AntalDagar == dagar).ToList();
        }

        // Lista på deltagare för gruppskidlektion genom gruppskidlektionsID 
        public List<Deltagare> GetDeltagare(int id)
        {
            return Context.Deltagare.Where(x => x.Gruppskidlektion.GruppskidlektionsID == id).ToList();
        }
    }
}
