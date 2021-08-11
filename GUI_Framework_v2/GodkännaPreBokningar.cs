using BusinessEntities_FrameWork.Models;
using BusinessLayer_FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_Framework_v2
{
    internal class GodkännaPreBokningar
    {
        public int _id { get; set; }
        public string _name { get; set; }
        public string _phone { get; set; }
        public string _seconName { get; set; }

        public List<PreBokning> ListPreBokningar { get; set; }
        public List<GodkännaPreBokningar> ListaGodkända { get; set; }
        public FacadeBusiness FB { get; set; }

        public GodkännaPreBokningar()
        {
            ListPreBokningar = new List<PreBokning>();
            ListaGodkända = new List<GodkännaPreBokningar>();
            FB = new FacadeBusiness();
        }

        public List<GodkännaPreBokningar> ConvertForGUI()
        {
            GetPreBokningar();
            SortListOfPre();
            ConvertPreTo();
            return ListaGodkända;
        }

        private void GetPreBokningar()
        {
            ListPreBokningar = FB.FacadePreBokning.GetAllPreBokning();
            //List<PreBokning> temp = new List<PreBokning>();
            //for (int i = 0; i < ListPreBokningar.Count; i++)
            //{
            //    temp.Add(FB.FacadePreBokning.HittaFöretagsKundTillPreBokning(ListPreBokningar[i]));
            //}
        }

        private void SortListOfPre()
        {
            List<PreBokning> temp = new List<PreBokning>();
            foreach (PreBokning item in ListPreBokningar)
                if (item.Status == true)
                    temp.Add(item);
            ListPreBokningar.Clear();
            ListPreBokningar.AddRange(temp);
        }

        private void ConvertPreTo()
        {
            for (int i = 0; i < ListPreBokningar.Count; i++)
            {
                GodkännaPreBokningar temp = new GodkännaPreBokningar();
                FöretagsKund f = new FöretagsKund();
                PrivatKund p = new PrivatKund();
                temp._id = ListPreBokningar[i].BokningsID;
                if (ListPreBokningar[i].PrivatKund == null)
                {
                    f = FB.FacadePreBokning.HittaFöretagsKundTillPreBokning(ListPreBokningar[i]);
                    if (f != null)
                    {
                        temp._name = f.Företagsnamn;
                        temp._phone = f.FöretagTelefonNummer;
                        temp._seconName = f.RefPerson;
                        ListaGodkända.Add(temp);
                    }
                }
                
                if (ListPreBokningar[i].FöretagsKund == null)
                {
                    p = FB.FacadePreBokning.HittaPrivatKundTillPreBokning(ListPreBokningar[i]);
                    if (p != null)
                    {
                        temp._name = p.PrivatFörnamn;
                        temp._phone = p.PrivatTelefonnummer;
                        temp._seconName = p.PrivatEfternamn;
                        ListaGodkända.Add(temp);
                    }  
                }
            }
        }
    }
}
