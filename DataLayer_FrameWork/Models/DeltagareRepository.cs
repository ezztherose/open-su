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
    public class DeltagareRepository : GenericRepository<Deltagare>, IDeltagareRepository
    {
        public DeltagareRepository(DatabaseContext context) : base(context)
        {

           
        }

        // En lista på deltagare i privatskidlektion 
        // Man hittar deltagaren efter deras ID 
        public List<Deltagare> HämtaDeltagarePåId(int id)
        {
            return Context.Deltagare.Where(x => x.Privatskidlektion.PrivatskidlektionsID == id).ToList();
        }
    }
}
