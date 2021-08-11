using BusinessEntities_FrameWork.Models;
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
    public partial class frmButikMeny : Form
    {
        public Anställd Anställd { get; set; }
        public MarknadsChef MarknadsChef { get; set; }

        public frmButikMeny(Anställd a, MarknadsChef m)
        {
            InitializeComponent();           
            Anställd = a;
            MarknadsChef = m;
            Setknapp();
        }

        private void Setknapp()
        {
            if (Anställd != null)
            {
                btnLoggaUt.Text = "Logga ut";
            }
            else if (MarknadsChef != null)
            {
                btnLoggaUt.Text = "Tillbaka";
            }              
        }

        private void btnSkidskolaPrivat_Click(object sender, EventArgs e)
        {
            ButikSkidskolaPrivat bsp = new ButikSkidskolaPrivat(Anställd, MarknadsChef);
            this.Hide();
            bsp.Show();
        }

        private void btnSkidskolaGrupp_Click(object sender, EventArgs e)
        {
            //ButikSkidskolaGrupp bsg = new ButikSkidskolaGrupp(Anställd, MarknadsChef);
            frmGruppSkidlektion_v2 bsg = new frmGruppSkidlektion_v2(Anställd, MarknadsChef);
            this.Hide();
            bsg.Show();
        }

        private void btnSkiduthyrning_Click(object sender, EventArgs e)
        {
            ButikSkiduthyrning bs = new ButikSkiduthyrning(Anställd, MarknadsChef);
            this.Hide();
            bs.Show();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Butiksregister br = new Butiksregister(Anställd, MarknadsChef);
            this.Hide();
            br.Show();
        }

        private void btnÅterlämning_Click(object sender, EventArgs e)
        {
            ButikÅterlämning bå = new ButikÅterlämning(Anställd, MarknadsChef);
            this.Hide();
            bå.Show();
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
    }
}
