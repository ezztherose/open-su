using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities_FrameWork.Models;
using DataLayer_FrameWork.Context;
using DataLayer_FrameWork.Interfaces;

namespace DataLayer_FrameWork.Models
{   // GenericRepository används för att kunna används av alla entiteter av databasen
    public class KundregisterRepository : GenericRepository<Kundregister>, IKundregisterRepository
    {
        public KundregisterRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
