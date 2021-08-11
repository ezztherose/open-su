using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities_FrameWork.Models;

namespace DataLayer_FrameWork.Interfaces
{
    public interface IPreBokningRepository : IGenericRepository<PreBokning>
    {
        public void TestaLogiTaBortKey(PreBokning pre);
        List<PreBokning> SearchPreBokning(string pre);
        public PrivatKund GetSpecifikPrivatKund(PreBokning pre);
        public PreBokning GetPreBokningMedPrivatkund(PreBokning pre);
        public PreBokning GetPreBokningMedFöretagsKund(PreBokning pre);
        public PreBokning GetPrebokningToBokning(PreBokning pre);
        public PreBokning GetPreWithOwner(PreBokning pre);
    }
}
