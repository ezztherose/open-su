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
    public partial class Logilista : Form
    {
        public FacadeBusiness FacadeBusiness { get; set; }
        public SysAdmin SysAdmin { get; set; }
        public Logi Logi { get; set; }

        private string _search;

        public Logilista(SysAdmin s)
        {
            InitializeComponent();
            SysAdmin = s;
            FacadeBusiness = new FacadeBusiness();
            SetComboBox();
            UpdateLogi();
        }

        private void Logilista_Load(object sender, EventArgs e)
        {

        }

        private void SetComboBox()
        {
            cblogi.Items.Add("Liten");
            cblogi.Items.Add("Stor");
            cblogi.Items.Add("Alla");
            cblogi.Items.Add("Camping");
        }

        private void btntillbaka_Click(object sender, EventArgs e)
        {
            frmSysadminMeny s = new frmSysadminMeny(SysAdmin, null);
            this.Hide();
            s.Show();
        }

        public void UpdateLogi()
        {
            dglogidata.DataSource = null;
            dglogidata.DataSource = FacadeBusiness.FacadeLogi.GetAllLogi();
        }

        private void btntabortlogiinfo_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Är du säker på att du vill radera vald rad?", "Ta Bort", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                if (dglogidata.CurrentRow != null)
                {
                    Logi = (Logi)dglogidata.CurrentRow.DataBoundItem;
                    FacadeBusiness.FacadeLogi.RemoveLogidata(Logi);
                }
                UpdateLogi();
            }
        }

        private void btnsökinfo_Click(object sender, EventArgs e)
        {
            List<Logi> SökLedig = new List<Logi>();
            // Sök
            if (cblogi.SelectedItem.Equals("Alla"))
            {
                dglogidata.DataSource = null;
                dglogidata.DataSource = FacadeBusiness.FacadeLogi.GetAllLedigaLägenheter();
            }
            else if (cblogi.SelectedItem.Equals("Stor"))
            {
                dglogidata.DataSource = null;
                dglogidata.DataSource = FacadeBusiness.FacadeLogi.GetTillgängligStor();
            }
            else if (cblogi.SelectedItem.Equals("Liten"))
            {
                dglogidata.DataSource = null;
                dglogidata.DataSource = FacadeBusiness.FacadeLogi.GetTillgängligLiten();
            }
            else if (cblogi.SelectedItem.Equals("Camping"))
            {
                dglogidata.DataSource = null;
                dglogidata.DataSource = FacadeBusiness.FacadeLogi.GetAllCamping();
            }
            else
                MessageBox.Show("Du har inte valt något alternativ");
        }

        public string Search
        {
            get { return _search; }
            set { _search = value; }
        }

        private void HideColums()
        {
            dglogidata.Columns["LogiID"].Visible = false;
        }

        private void btnsparalogiinfo_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search = (string)cblogi.SelectedItem;
        }
    }
}
