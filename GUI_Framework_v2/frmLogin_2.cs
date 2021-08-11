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
    public partial class frmLogin_2 : Form
    {
        private string _användarnamn;
        private string _lösen;

        public Anställd Anställd;
        public SysAdmin SysAdmin;
        public MarknadsChef MarknadsChef;

        public string Lösen
        {
            get { return _lösen; }
            set { _lösen = value; }
        }

        public string AnvändarNamn
        {
            get { return _användarnamn; }
            set { _användarnamn = value; }
        }

        public FacadeBusiness FacadeBusiness { get; set; }

        public frmLogin_2()
        {
            InitializeComponent();
            FacadeBusiness = new FacadeBusiness();
            Anställd = null;
            SysAdmin = null;
            MarknadsChef = null;
        }
        // Metod för inlogg. Kräver användarnamn och lösenord 
        private void btnLoggin_Click(object sender, EventArgs e)
        {
            AnvändarNamn = tbAnvändare.Text;
            Lösen = tbLösen.Text;

            Anställd = FacadeBusiness.FacadeAnställd.LoginAnställd(AnvändarNamn, Lösen);
            SysAdmin = FacadeBusiness.FacadeSysAdmin.LoginSysAdmin(AnvändarNamn, Lösen);
            MarknadsChef = FacadeBusiness.FacadeMarknadsChef.LoginMarknadsChef(AnvändarNamn, Lösen);

            if (Anställd == null && SysAdmin == null && MarknadsChef == null)
            {
                AnvändarNamn = null;
                Lösen = null;
                MessageBox.Show(":/ åtkomst nekad ");
            }
            else if (Anställd != null && Anställd.Behörighet == "Reception")
            {
                frmBokning a_s = new frmBokning(Anställd, MarknadsChef, null);
                this.Hide();
                a_s.Show();
            }
            else if (SysAdmin != null && SysAdmin.Behörighet.Equals("Sysadmin"))
            {
                frmSysadminMeny sa = new frmSysadminMeny(SysAdmin, MarknadsChef);
                this.Hide();
                sa.Show();
            }
            else if (MarknadsChef != null)
            {
                frmMarknadsmeny mc = new frmMarknadsmeny(SysAdmin, MarknadsChef);
                this.Hide();
                mc.Show();
            }
            else if (Anställd != null && Anställd.Behörighet == "Butik")
            {
                frmButikMeny bk = new frmButikMeny(Anställd, MarknadsChef);
                this.Hide();
                bk.Show();
            }
            else if (Anställd != null && Anställd.Behörighet.Equals("Skidlärare"))
            {
                frmSkidlärare sk = new frmSkidlärare(Anställd);
                this.Hide();
                sk.Show();
            }
        }
        // Textruta där man skriver in användarnamn 
        private void tbAnvändare_TextChanged(object sender, EventArgs e)
        {
            AnvändarNamn = tbAnvändare.Text;
        }
        // Textruta där man skriver in lösenord 
        private void tbLösen_TextChanged(object sender, EventArgs e)
        {
            Lösen = tbLösen.Text;
        }

        private void tbLösen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                btnLoggin_Click(null, null);
            }
        }
        // Metod som lämnar applicationen
        private void btnavsluta_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
