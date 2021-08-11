using BusinessEntities_FrameWork.Models;
using BusinessLayer_FrameWork;
using GUI_Framework_v2.Boka;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_Framework_v2
{
    public partial class frmBokning : Form
    {
        public Anställd  Anställd { get; set; }
        public MarknadsChef MarknadsChef { get; set; }
        public SysAdmin SysAdmin { get; set; }
        public FacadeBusiness FacadeBusiness { get; set; }

        public frmBokning(Anställd a, MarknadsChef mc, SysAdmin s)
        {
            InitializeComponent();
            FacadeBusiness = new FacadeBusiness();
            Anställd = a;
            MarknadsChef = mc;
            SysAdmin = s;
            SetKnapp();
            CheckForPreBokingsToAccept();
        }

        private void SetKnapp()
        {
            if (Anställd != null)
                btnLoggaUt.Text = "Logga ut";
            else if (MarknadsChef != null || SysAdmin != null)
                btnLoggaUt.Text = "Tillbaka";
        }

        private void btnBokaPrivat_Click(object sender, EventArgs e)
        {
            BokaCampingochPrivat c = new BokaCampingochPrivat(Anställd, MarknadsChef);
            this.Hide();
            c.Show();
        }

        private void btnBokaFöretag_Click(object sender, EventArgs e)
        {
            frmKonferens k = new frmKonferens(Anställd, MarknadsChef);
                this.Hide();
            k.Show();
           
        }

        private void btnBokningar_Click(object sender, EventArgs e)
        {
            Bokningar b = new Bokningar(Anställd, MarknadsChef);
            this.Hide();
            b.Show();
        }

        private void btnLoggaUt_Click(object sender, EventArgs e)
        {
            if (Anställd == null && MarknadsChef != null)
            {
                frmMarknadsmeny fm = new frmMarknadsmeny(null, MarknadsChef);
                this.Hide();
                fm.Show();
            }
            else if (Anställd != null && MarknadsChef == null)
            {
                DialogResult dr = MessageBox.Show("Är du säker på att logga ut?", "Logga ut", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    frmLogin_2 logg = new frmLogin_2();
                    this.Hide();
                    logg.Show();
                }
            }
        }

        private void btFakturor_Click(object sender, EventArgs e)
        {
            utskriftfaktura fk = new utskriftfaktura(Anställd);
            this.Hide();
            fk.Show();
        }

        private void btnPreToBoking_Click(object sender, EventArgs e)
        {
            frmGodkännaPreBokningar fgpb = new frmGodkännaPreBokningar(Anställd, MarknadsChef, SysAdmin);
            this.Hide();
            fgpb.Show();
        }

        private void CheckForPreBokingsToAccept()
        {
            List<PreBokning> List = new List<PreBokning>();
            List = FacadeBusiness.FacadeBokning.SortPreList();
            if (List != null && List.Count > 0) SetForBoking();
            if (List == null && List.Count <= 0) btnPreToBoking.BackColor = Color.LightGray;
            
        }

        private void SetForBoking()
        {
            btnPreToBoking.BackColor = Color.Green;
            MessageBox.Show("Den finns bokningar att lägga till", "Skapa bokningar", MessageBoxButtons.OK);
        }

        private void btBokningsbekräftelse_Click(object sender, EventArgs e)
        {
            frmUtskriftBokningsbekräftelse bokningbekräftelse = new frmUtskriftBokningsbekräftelse(Anställd, MarknadsChef, SysAdmin);
            this.Hide();
            bokningbekräftelse.Show();
        }
    }
}
