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



namespace GUI_Framework_v2
{
    public partial class frmMarknadsmeny : Form
    {
        public MarknadsChef MarknadsChef { get; set; }
        public SysAdmin SysAdmin { get; set; }
        public Anställd Anställd { get; set; }
        public FacadeBusiness FacadeBusiness { get; set; }

        public frmMarknadsmeny(SysAdmin s, MarknadsChef mc)
        {
            FacadeBusiness = new FacadeBusiness();
            InitializeComponent();
            SignaleraPreBokning();
            SysAdmin = s;
            MarknadsChef = mc;
        }

        private void btnbutik_Click(object sender, EventArgs e)
        {
            frmButikMeny fbm = new frmButikMeny(null, MarknadsChef);
            this.Hide();
            fbm.Show();
        }

        private void btnbokning_Click(object sender, EventArgs e)
        {
            frmBokning fb = new frmBokning(Anställd, MarknadsChef, null);
            this.Hide();
            fb.Show();
        }

        private void btnloggaut_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Är du säker på att logga ut?", "Logga ut", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                frmLogin_2 logg = new frmLogin_2();
                this.Hide();
                logg.Show();
            }   
        }

        private void prebokningmc_Click(object sender, EventArgs e)
        {
            Preliminärbokningar m = new Preliminärbokningar(MarknadsChef);
            this.Hide();
            m.Show();
        }

        private void btnstatistik_Click(object sender, EventArgs e)
        {
            BelStatistik mc = new BelStatistik(MarknadsChef);
            this.Hide();
            mc.Show();
        }

        private void btnregistreraföretagskund_Click(object sender, EventArgs e)
        {
            LäggTillKundFöretag lägg = new LäggTillKundFöretag(MarknadsChef, Anställd);
            Hide();
            lägg.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LäggTillKundPrivat mc = new LäggTillKundPrivat(MarknadsChef , null);
            this.Hide();
            mc.Show();
        }

        private void btnmarknadPrislistor_Click(object sender, EventArgs e)
        {
            Prislistor mc = new Prislistor(null, MarknadsChef);
            this.Hide();
            mc.Show();
        }

        private void btnregister_Click(object sender, EventArgs e)
        {
            frmRegister mc = new frmRegister(MarknadsChef, null);
            this.Hide();
            mc.Show();
        }
        public void SignaleraPreBokning()
        {
            List<PreBokning> list = FacadeBusiness.FacadePreBokning.GetAllPreBokning();
            if (list.Count != 0)
            {
                prebokningmc.BackColor = Color.LightGreen;
            }
            else
                prebokningmc.BackColor = Color.LightGray;
        }

        private void btFaktura_Click(object sender, EventArgs e)
        {
            FakturaFörKöp ffk = new FakturaFörKöp(null, MarknadsChef);
            this.Hide();
            ffk.Show();
        }

        private void btFakturaFörLogi_Click(object sender, EventArgs e)
        {
            FakturaFörLogi ffk = new FakturaFörLogi(null, MarknadsChef);
            this.Hide();
            ffk.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            UppdateraKundFöretag mc = new UppdateraKundFöretag(null, MarknadsChef, null);
            this.Hide();
            mc.Show();
        }
    }
}
