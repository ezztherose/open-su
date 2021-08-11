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
    public partial class frmLogipris_2 : Form
    {
        public FacadeBusiness FacadeBusiness { get; set; }
        public SysAdmin SysAdmin { get; set; }
        public MarknadsChef MarknadsChef { get; set; }
        public LogiPris LogiPris { get; set; }
        public double Pris { get; set; }

        public frmLogipris_2(SysAdmin s, MarknadsChef mc)
        {
            InitializeComponent();
            LogiPris = new LogiPris();
            FacadeBusiness = new FacadeBusiness();
            SysAdmin = s;        
            MarknadsChef = mc;
            UpdateGrid();
        }

        private void UpdateGrid()
        {
            gvlogipris.DataSource = null;
            gvlogipris.DataSource = FacadeBusiness.FacadeLogiPris.HämtaLogiPris().ToList();
        }

        private void btnändra_Click(object sender, EventArgs e)
        {
            LogiPris lp = (LogiPris)gvlogipris.CurrentRow.DataBoundItem;
            LogiPris = lp;
            LogiPris.Pris = Pris;
            FacadeBusiness.FacadeLogiPris.UppdateraLogiPris(LogiPris, LogiPris.LogiPrisID);
            UpdateGrid();
            tbLogiPris.Text = "";
            MessageBox.Show("Logi pris är  uppdaterad!");
        }

        private void dglogipris_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            gvlogipris.Columns["LogiprisID"].Visible = true;
            gvlogipris.Columns["LogiTyp"].Visible = true;
            gvlogipris.Columns["Vecka"].Visible = true;
            gvlogipris.Columns["Dagar"].Visible = true;
            gvlogipris.Columns["Pris"].Visible = true;
        }

        private void btntillbaka_Click(object sender, EventArgs e)
        {
            if (SysAdmin != null && MarknadsChef == null)
            {
                frmSysadminMeny s = new frmSysadminMeny(SysAdmin, null);
                this.Hide();
                s.Show();
            }
            else if (MarknadsChef != null && SysAdmin == null)
            {
                Prislistor mc = new Prislistor(null, MarknadsChef);
                this.Hide();
                mc.Show();
            }
        }

        private void tbLogiPris_TextChanged(object sender, EventArgs e)
        {
            if (tbLogiPris.TextLength > 0)
            {
                Pris = Convert.ToDouble(tbLogiPris.Text);
            }
            else if (tbLogiPris.TextLength == 0)
                tbLogiPris.Text = "";
            else
                MessageBox.Show("", "", MessageBoxButtons.OK);
        }
    }
}
