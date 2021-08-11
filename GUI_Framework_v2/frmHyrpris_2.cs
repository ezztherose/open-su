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
    public partial class frmHyrpris_2 : Form
    {
        public FacadeBusiness FacadeBusiness { get; set; }
        public SysAdmin SysAdmin { get; set; }
        public MarknadsChef MarknadsChef { get; set; }
        public Hyrpris Hyrpris { get; set; }

        private double pris;

        public frmHyrpris_2(SysAdmin s, MarknadsChef mc)
        {
            InitializeComponent();
            SysAdmin = s;
            MarknadsChef = mc;
            FacadeBusiness = new FacadeBusiness();
            UpdateGrid();
        }
        // Tillbaka knapp som tar en till startsidan
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
        // Metod som ändrar hyrpriset 
        private void btnändra_Click(object sender, EventArgs e)
        {
            Hyrpris h = (Hyrpris)dghyrpris.CurrentRow.DataBoundItem;
            Hyrpris = h;
            Hyrpris.Pris = pris;
            FacadeBusiness.FacadeHyrpris.UppdateraHyrpris(Hyrpris, Hyrpris.HyrPirsID);
            tbHyrpris.Text = "";
            UpdateGrid();
            MessageBox.Show("Uppdaterad!");
        }

        private void UpdateGrid()
        {
            dghyrpris.DataSource = null;
            dghyrpris.DataSource = FacadeBusiness.FacadeHyrpris.HämtaAllaHyrpris().ToList();
        }
        // Ändra i hyrpris genom att välja ett hyrpris som är större än 0 
        private void tbHyrpris_TextChanged(object sender, EventArgs e)
        {
            if (tbHyrpris.TextLength > 0)
            {
                pris = Convert.ToDouble(tbHyrpris.Text);
            }
            else if (tbHyrpris.TextLength == 0)
                tbHyrpris.Text = "";
            else
                MessageBox.Show("", "", MessageBoxButtons.OK);              
        }
        // Metoden väljer ett hyrpris som konverterar det gamla priset till det nya priset 
        private void dghyrpris_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dghyrpris.SelectedRows.Count > 0)
            {
                Hyrpris = (Hyrpris)dghyrpris.SelectedRows[0].DataBoundItem;
                tbHyrpris.Text = Convert.ToString(Hyrpris.Pris);
            }
        }
    }
}
