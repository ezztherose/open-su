using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities_FrameWork.Models;
using DataLayer_FrameWork.Context;
using DataLayer_FrameWork.Interfaces;

namespace DataLayer_FrameWork.Models
{
    public class PrivatLektionRepository : GenericRepository<Privatskidlektion>,  IPrivatLektionRepository
    {
        public PrivatLektionRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
