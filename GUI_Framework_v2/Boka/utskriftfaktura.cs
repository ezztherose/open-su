using BusinessEntities_FrameWork.Models;
using BusinessLayer_FrameWork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_Framework_v2.Boka
{
    public partial class utskriftfaktura : Form
    {
        public FacadeBusiness FacadeBusiness = new FacadeBusiness();
        public Faktura Faktura { get; set; }
        public Anställd Anställd { get; set; }
        internal PdfKlass PdfKlass { get; set; }
        public utskriftfaktura(Anställd a)
        {
            InitializeComponent();
            FacadeBusiness = new FacadeBusiness();
            LaddaFakturor();
            Faktura = new Faktura();
            PdfKlass = new PdfKlass();
            Anställd = a;
        }

        private void btUtskriftAlla_Click(object sender, EventArgs e)
        {
           
            List<Faktura> list = FacadeBusiness.FacadeFaktura.GetEjUtskrivna();
            for (int i = 0; i < list.Count; i++)
            {

                if (list[i].Företag == null)
                {

                    PdfKlass.FakturaUtskriftPrivat(list[i], list[i].Privat, list[i].Uthyrning);
                }
                else
                {
                    PdfKlass.FakturaUtskriftFöretag(list[i], list[i].Företag);
                }
                    FacadeBusiness.FacadeFaktura.ÄndraStatusFaktura(list[i]);
            }
                    MessageBox.Show("Fakturor utskrivna.");

        }
       
        public void LaddaFakturor()
        {
            gvFakturor.DataSource = null;
            gvFakturor.DataSource = FacadeBusiness.FacadeFaktura.GetEjUtskrivna();
        }

        private void btTillbaka_Click(object sender, EventArgs e)
        {
            //Fixa anställda
            frmBokning fb = new frmBokning(Anställd,null, null);
            this.Hide();
            fb.Show();
        }

        private void btUtskriftEnskild_Click(object sender, EventArgs e)
        {
            List<Faktura> list = FacadeBusiness.FacadeFaktura.GetEjUtskrivna();
            Faktura fk = (Faktura)gvFakturor.CurrentRow.DataBoundItem;
            if (fk.Företag == null)
            {

                if (fk.Typ == "Uthyrning")
                {
                    PdfKlass.FakturaUtskriftPrivat(fk, fk.Privat, fk.Uthyrning);
                     FacadeBusiness.FacadeFaktura.ÄndraStatusFaktura(fk);
                    MessageBox.Show("Faktura utskriven.");
                }
                else
                {
                    PdfKlass.FakturaUtskriftPrivat(fk, fk.Privat, null);
                    FacadeBusiness.FacadeFaktura.ÄndraStatusFaktura(fk);
                    MessageBox.Show("Faktura utskriven.");
                }
            }
            else if (fk.Företag != null) PdfKlass.FakturaUtskriftFöretag(fk, fk.Företag);
        }
    }
}
