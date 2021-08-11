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
    public partial class frmKonferensPris_2 : Form
    {
        public FacadeBusiness FacadeBusiness { get; set; }
        public SysAdmin SysAdmin { get; set; }
        public MarknadsChef MarknadsChef { get; set; }
        public KonferensPris KonferensPris { get; set; }
        private double Pris;

        public frmKonferensPris_2(SysAdmin s, MarknadsChef mc)
        {
            InitializeComponent();
            SysAdmin = s;
            MarknadsChef = mc;
            FacadeBusiness = new FacadeBusiness();
            UpdateDataGrid();
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

        private void UpdateDataGrid()
        {
            gvkonferenspris.DataSource = null;
            gvkonferenspris.DataSource = FacadeBusiness.FacadeKonferensPris.HämtaKonferensPris().ToList();
        }

        private void btnändra_Click(object sender, EventArgs e)
        {
            KonferensPris kp = (KonferensPris)gvkonferenspris.CurrentRow.DataBoundItem;
            KonferensPris = kp;
            KonferensPris.Pris = Pris;
            FacadeBusiness.FacadeKonferensPris.UppdateraKonferensPris(KonferensPris, KonferensPris.KonferensPrisID);
            tbkonferenspris.Text = "";
            UpdateDataGrid();
            MessageBox.Show("Uppdaterad!");
        }
        // Metod som visar konferenspriset. Konferenspris måste vara större än 0 
        private void tbkonferenspris_TextChanged(object sender, EventArgs e)
        {
            if (tbkonferenspris.TextLength > 0)
            {
                Pris = Convert.ToDouble(tbkonferenspris.Text);
            }
            else if (tbkonferenspris.TextLength == 0)
                tbkonferenspris.Text = "";
            else
                MessageBox.Show("", "", MessageBoxButtons.OK);
        }

        private void dgkonferenspris_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            gvkonferenspris.Columns["KonferensPrisID"].Visible = true;
            gvkonferenspris.Columns["Antal dagar"].Visible = true;
            gvkonferenspris.Columns["Konferens typ"].Visible = true;
            gvkonferenspris.Columns["Vecka"].Visible = true;
            gvkonferenspris.Columns["Timmar"].Visible = true;
            gvkonferenspris.Columns["Pris"].Visible = true;
        }
    }
}
