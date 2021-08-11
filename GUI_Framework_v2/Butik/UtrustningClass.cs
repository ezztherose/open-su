using BusinessEntities_FrameWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_Framework_v2.Butik
{
    internal class UtrustningClass
    {
        public Utrustning Utrustning { get; set; }
        public List<Utrustning> PaketLista { get; set; }        // Paket med flera olika saker
        //public List<double> PrisLista { get; set; }             // priset för varje paket
        public List<Utrustning> AllUtrustning { get; set; }     // Den totala 
        public double Pris { get; set; }
        public string Typ { get; set; }

        // Klass för att visa lista på utrustning 
        public UtrustningClass()
        {
            PaketLista = new List<Utrustning>();
            AllUtrustning = new List<Utrustning>();
            Typ = "";
            Pris = new double();
            Utrustning = new Utrustning();
        }

        // Metod för att lägga till utrustning till lista 
        public Utrustning UtrustningTillLista(Utrustning u)
        {
            return u;
        }

        // Metod för att lägga till paketpris 
        public void LäggTillPaketPris(double p)
        {
            Pris = p;
        }

        // Metod för att hämta all specifik utrustning 
        public void HämtaSpecifikUtrustning(Utrustning u)
        {
            AllUtrustning.Add(u);
        }

        // Metod som hämtar en lista på utrustning 
        public void HämtaPaket(List<Utrustning> list)
        {
            AllUtrustning.AddRange(list);
        }
        
        // Metod som tar bort paket 
        public void TaBortPaket(int id)
        {
            PaketLista.RemoveAt(id);
        }
    }
}
