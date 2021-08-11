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
    public partial class frmSysadminMeny : Form
    {
        public FacadeBusiness FacadeBusiness { get; set; }
        public SysAdmin SysAdmin { get; set; }
        public MarknadsChef MarknadsChef { get; set; }

        public frmSysadminMeny(SysAdmin s, MarknadsChef mc)
        {
            InitializeComponent();
            FacadeBusiness = new FacadeBusiness();
            MarknadsChef = mc;
            SysAdmin = s;
        }

        private void btnpersonal_Click(object sender, EventArgs e)
        {
            frmSysadminpersonal s = new frmSysadminpersonal(SysAdmin);
            this.Hide();
            s.Show();
        }

        private void btnuppdaterakund_Click(object sender, EventArgs e)
        {
            UppdateraKundPrivat sa = new UppdateraKundPrivat(SysAdmin, null);
            this.Hide();
            sa.Show();
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

        private void uppdaterafkundsysadmin_Click(object sender, EventArgs e)
        {
            UppdateraKundFöretag sa = new UppdateraKundFöretag(SysAdmin, null, null);
            this.Hide();
            sa.Show();
        }

        private void btnhyrpriser_Click(object sender, EventArgs e)
        {
            frmHyrpris_2 s = new frmHyrpris_2(SysAdmin, MarknadsChef);
            this.Hide();
            s.Show();
        }

        private void btnhyrutrustningslista_Click(object sender, EventArgs e)
        {
            Hyrutrustningslista s = new Hyrutrustningslista(SysAdmin, null);
            this.Hide();
            s.Show();
        }

        private void btnkonferenspris_Click(object sender, EventArgs e)
        {
            frmKonferensPris_2 s = new frmKonferensPris_2(SysAdmin, MarknadsChef);
            this.Hide();
            s.Show();
        }

        private void btnkonferenslista_Click(object sender, EventArgs e)
        {
            Konferenslista s = new Konferenslista(SysAdmin);
            this.Hide();
            s.Show();
        }

        private void btnlogipriser_Click(object sender, EventArgs e)
        {
            frmLogipris_2 s = new frmLogipris_2(SysAdmin, MarknadsChef);
            this.Hide();
            s.Show();
        }

        private void btnlogilista_Click(object sender, EventArgs e)
        {
            Logilista s = new Logilista(SysAdmin);
            this.Hide();
            s.Show();
        }

        private void btnPrivateDiscount_Click(object sender, EventArgs e)
        {
            frmUppdateraPrivatRabatt frmP = new frmUppdateraPrivatRabatt(SysAdmin);
            this.Hide();
            frmP.Show();
        }

        private void btnNewGroupLessons_Click(object sender, EventArgs e)
        {
            FacadeBusiness.FacadeGruppskidlektion.CreateLessonsForNewWeek();
            MessageBox.Show("Veckans grupplektioner tillagda", "Succé", MessageBoxButtons.OK);
        }
    }
}
