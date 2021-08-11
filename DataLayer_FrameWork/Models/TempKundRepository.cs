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
    public class TempKundRepository : GenericRepository<TempKund>, ITempKundRepository
    {
        public TempKundRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
