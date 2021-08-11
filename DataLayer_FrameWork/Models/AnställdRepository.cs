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
    public class AnställdRepository : GenericRepository<Anställd>, IAnställdRepository
    {
        public AnställdRepository(DatabaseContext context) : base(context)
        {

        }

        // Metod för inlogg till anställd som kräver ett användarnamn och lösenord 
        public Anställd Login(string användarnamn, string password)
        {
            return Context.Anställd.Where(x => användarnamn.ToLower() == användarnamn.ToLower() && x.Lösenord.ToString().Equals(password.ToString())).FirstOrDefault();
        }

        // En lista på alla anställda
        // Sök på efternamn för att få fram anställda 
        public List<Anställd> SearchAnställdEfternamn(string search)
        {
            return Context.Anställd.Where(x => x.AnställdEfternamn.ToLower().Contains(search)).ToList();
        }
    }
}
