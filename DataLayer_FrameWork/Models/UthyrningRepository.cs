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
    public class UthyrningRepository : GenericRepository<Uthyrning>, IUthyrningRepository
    {
        public UthyrningRepository(DatabaseContext context) : base(context)
        {
 
        }

        // Lista för uthyrningar för privatkunder 
        public List<Uthyrning> GetAllEjReturnerade(PrivatKund pk)
        {
            return Context.Uthyrning.Where(x => x.Status == false && x.PrivatKund.PrivatKundID == pk.PrivatKundID).ToList();
        }
        public List<Utrustning> GetEjReturneradePK(int Id)
        {
            return Context.Utrustning.Where(x => x.Tillgänglig == false && x.Uthyrning.UthyrningsID == Id).ToList();
        }

        // Lista för all uthyrning för privatkund 
        public List<Uthyrning> SökEfterUthyrning(string sökterm)
        {
            return Context.Uthyrning.Where(x => x.PrivatKund.PrivatFörnamn.Equals(sökterm)).ToList();
        }

        // Metod som hämtar fakturor för uthyrning 
        public Faktura HämtaUthyrningsFaktura(int uId, int pId)
        {
            return Context.Faktura.Where(x => x.Uthyrning.UthyrningsID == uId && x.Privat.PrivatKundID == pId).SingleOrDefault();
        }

        // Metod för all uthyrning 
        public Uthyrning SearchUthyrning(string id)
        {
            int index = int.Parse(id);
            return Context.Uthyrning.Where(x => x.UthyrningsID == index).SingleOrDefault();
        }
    }
}
