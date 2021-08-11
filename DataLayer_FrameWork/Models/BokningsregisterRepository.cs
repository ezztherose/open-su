using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities_FrameWork.Models;
using DataLayer_FrameWork.Context;
using DataLayer_FrameWork.Interfaces;

namespace DataLayer_FrameWork.Models
{   
    // Representerar en kombination av UnitofWork och repository mönster för att kunna fråga från en databas
    //  och gruppera ändringar tillsammans tillbaka till arkivet som en enhet. 
    public class BokningsregisterRepository : GenericRepository<Bokningsregister>, IBokningsregisterRepository
    {
        public BokningsregisterRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
