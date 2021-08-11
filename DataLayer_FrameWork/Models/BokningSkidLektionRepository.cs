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
    // Representerar en kombination av UnitofWork och repository mönster för att kunna fråga från en databas
    //  och gruppera ändringar tillsammans tillbaka till arkivet som en enhet. 
    public class BokningSkidLektionRepository : GenericRepository<BokningSkidLektion>, IBokningSkidLektionRepository
    {
        public BokningSkidLektionRepository(DatabaseContext context) : base(context)
        {
            
        }
    }
}
