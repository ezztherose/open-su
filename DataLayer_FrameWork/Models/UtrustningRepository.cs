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
    public class UtrustningRepository : GenericRepository<Utrustning>, IUtrustningRepository
    {
        public UtrustningRepository(DatabaseContext context) : base(context)
        {

        }

        public List<Utrustning> SearchUtrustning(string search)
        {
            return Context.Utrustning.Where(x => x.ArtikelID.ToString().Contains(search)).ToList();
        }

        // Lista på utrustning med hjälp av uthyrningsID 
        public List<Utrustning> UtrustningPåUthyrningsID(Uthyrning Uthyrning)
        {
            return Context.Utrustning.Where(x => x.Uthyrning.UthyrningsID == Uthyrning.UthyrningsID).ToList();
        }
    }
}
