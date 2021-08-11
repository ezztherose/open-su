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
    public partial class frmUtskriftBokningsbekräftelse : Form
    {  public SysAdmin Admin { get; set; }
        public MarknadsChef Chef { get; set; }
        public Anställd Anställd { get; set; }
        public FacadeBusiness FacadeBusiness { get; set; }
        public Bokning bokning{ get; set; }
        internal PdfKlass PdfKlass { get; set; }
        public frmUtskriftBokningsbekräftelse(Anställd a, MarknadsChef mc, SysAdmin sys)
        {
            InitializeComponent();
            FacadeBusiness = new FacadeBusiness();
            Admin = sys;
            Chef = mc;
            Anställd = a;
            bokning = new Bokning();
            PdfKlass = new PdfKlass();
            LaddaBokningar();
        }
        public void LaddaBokningar()
        {
            gvBokningsbekräftelser.DataSource = null;
            gvBokningsbekräftelser.DataSource = FacadeBusiness.FacadeBokning.GetEjUtskrivnaBokningsbekräftelser();

        }

        private void btTillbaka_Click(object sender, EventArgs e)
        {
            frmBokning b = new frmBokning(Anställd, Chef, Admin);
            this.Hide();
            b.Show();
        }

        private void btUtskriftAlla_Click(object sender, EventArgs e)
        {
            List<Bokning> list = FacadeBusiness.FacadeBokning.GetEjUtskrivnaBokningsbekräftelser();
            for (int i = 0; i < list.Count; i++)
                if (list[i].FöretagsKund == null && list[i].PrivatKund != null)
                {
                    PdfKlass.skapaBokningsBekräftelsePrivat(list[i]);
                    FacadeBusiness.FacadeBokning.ÄndraStatusBokning(list[i]);
                }
                else if(list[i].FöretagsKund != null && list[i].PrivatKund == null)
                {
                    PdfKlass.skapaBokningsBekräftelseFöretag(list[i]);
                    FacadeBusiness.FacadeBokning.ÄndraStatusBokning(list[i]);
                }
            MessageBox.Show("Bokningsbekräftelser utskrivna");
            LaddaBokningar();
        }

        private void btUtskriftEnskild_Click(object sender, EventArgs e)
        {
            List<Bokning> list = FacadeBusiness.FacadeBokning.GetEjUtskrivnaBokningsbekräftelser();
            Bokning bokning = (Bokning)gvBokningsbekräftelser.CurrentRow.DataBoundItem;
            if (bokning.FöretagsKund == null && bokning.PrivatKund != null) BokingPrivate(bokning);
            if (bokning.FöretagsKund != null && bokning.PrivatKund == null) BokingEnterprise(bokning);
        }

        private void BokingPrivate(Bokning b)
        {
            PdfKlass.skapaBokningsBekräftelsePrivat(b);
            FacadeBusiness.FacadeBokning.ÄndraStatusBokning(b);
            MessageBox.Show("Bokningsbekräftelse utskriven");
            LaddaBokningar();
        }

        private void BokingEnterprise(Bokning b)
        {
            PdfKlass.skapaBokningsBekräftelseFöretag(b);
            FacadeBusiness.FacadeBokning.ÄndraStatusBokning(b);
            MessageBox.Show("Bokningsbekräftelse utskriven");
            LaddaBokningar();
        }
    }
}

