using BusinessEntities_FrameWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer_FrameWork.Interfaces
{
    public interface IFakturaRepository : IGenericRepository<Faktura>
    {
        public List<Faktura> FakturorFörLogi();
        public Faktura HämtaDelbetalning(string typ, Bokning bokning);    
        public List<Faktura> GetEjUtskrivna();
    }
}
