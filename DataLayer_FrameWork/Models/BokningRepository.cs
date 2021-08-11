using BusinessEntities_FrameWork.Models;
using DataLayer_FrameWork.Context;
using DataLayer_FrameWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer_FrameWork.Models
{   
    // Bokningsrepository finns för att skapa ett lager mellan datalayer och businesslayer
    public class BokningRepository : GenericRepository<Bokning>, IBokningRepository
    {
        public BokningRepository(DatabaseContext context) : base(context)
        {
            
        }

        // En lista där man söker på bokningar 
        public List<Bokning> SearchBokning(string search)
        {
            return Context.Bokning.Where(x => x.BokningsID.ToString().Equals(search)).ToList();
        }
        // Lista som visar alla bokningar 
        public List<Bokning> VisaBokning()
        {
            return null;
        }

        // Metod för att ta bort privatkund 
        // Går in i databasen för att hämta privatkunder genom PrivatkundID som inkluderar bokningar 
        public void RemoveprivatKund(PrivatKund privatKund, int PrivatKundID)
        {
            using (var db = new DatabaseContext())
            {
                var entity = db.PrivatKund.Where(x => x.PrivatKundID == PrivatKundID).Include(x => x.Bokningar).FirstOrDefault();
                db.PrivatKund.Remove(entity);
                db.SaveChanges();
            }
        }

        // Metod för att ta bort företagskund 
        // Går in i databasen för att hämta företagskunder genom FöretagKundID som inkluderar bokningar 
        public void RemoveföretagsKund(FöretagsKund företagsKund, int företagsKundID)
        {
            using (var db = new DatabaseContext())
            {
                var entity = db.FöretagsKund.Where(x => x.FöretagKundID == företagsKund.FöretagKundID).Include(x => x.Bokningar).FirstOrDefault();
                db.FöretagsKund.Remove(entity);
                db.SaveChanges();
            }
        }

        public List<Bokning> GetEjUtskrivnaBokningsbekräftelser()
        {
            return Context.Bokning.Where(x => x.Status == false).Include(x=>x.PrivatKund).Include(x=>x.FöretagsKund).ToList();
        }
    }
}
