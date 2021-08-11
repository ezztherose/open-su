using BusinessEntities_FrameWork.Models;
using DataLayer_FrameWork.UnitOfWork;
using DataLayer_FrameWork.Context;
using DataLayer_FrameWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer_FrameWork.Models
{
    public class SkidLektionRepository : GenericRepository<SkidLektion>, ISkidLektionRepository
    {
        public SkidLektionRepository(DatabaseContext context) : base(context)
        {
            
        }

        // Metod för att hämta ett specifikt pris för skidlektion
        public SkidLektion HämtaSpecifiktPris()
        {
            SkidLektion s = Context.SkidLektion.Where(x => x.Dagar == 1 && x.TypAvLektion.ToString() == "Privat").FirstOrDefault();
            return s;
        }

        // Metod för att hämta ett specifikt pris för gruppskidlektion 
        public SkidLektion HämtaSpecifiktPrisGrupp(string typ, int dagar)
        {
            SkidLektion s = Context.SkidLektion.Where(x => x.Dagar == dagar && x.TypAvLektion.ToString() == typ).FirstOrDefault();
            return s;
        }

        // Metod som hämtar fram ett specifikt pris för gruppskidlektion
        public double GetPriceForSpecificGroupLesson(int day, string color)
        {
            SkidLektion s = Context.SkidLektion.Where(x => x.Dagar == day && x.TypAvLektion.ToString() == color).FirstOrDefault();
            return s.Pris;
        }
    }
}
