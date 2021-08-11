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
    public partial class Hyrutrustningslista : Form
    {
        public FacadeBusiness FacadeBusiness { get; set; }
        public SysAdmin SysAdmin { get; set; }
        public MarknadsChef MarknadsChef { get; set; }
        public Utrustning Utrustning { get; set; }

        private string _search;
     
        public Hyrutrustningslista(SysAdmin s, MarknadsChef mc)
        {
            InitializeComponent();
            SysAdmin = s;
            MarknadsChef = mc;
            FacadeBusiness = new FacadeBusiness();
            HämtaUtrustning();
        }

        private void Hyrutrustningslista_Load(object sender, EventArgs e)
        {

        }

        public string Search
        {
            get { return _search; }
            set { _search = value; }
        }

        private void btntillbaka_Click(object sender, EventArgs e)
        {
            frmSysadminMeny s = new frmSysadminMeny(SysAdmin, null);
            this.Hide();
            s.Show();
        }

        private void btnsparahyrinfo_Click(object sender, EventArgs e)
        {

        }

        private void dvhyrdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnsökhyr_Click(object sender, EventArgs e)
        {
            if (Search != null)
            {
                if (FacadeBusiness.FacadeUtrustning.SearchUtrustning(Search).ToList() != null)
                {
                    Utrustning = (Utrustning)dvhyrdata.CurrentRow.DataBoundItem;
                    FacadeBusiness.FacadeUtrustning.SearchUtrustning(Search).ToList();
                }
                else
                HämtaUtrustning();
            }
            else
                MessageBox.Show("Det finns ingen sökterm", "Error ", MessageBoxButtons.OK);
        }

        private void HämtaUtrustning()
        {
            dvhyrdata.DataSource = null;
            dvhyrdata.DataSource = FacadeBusiness.FacadeUtrustning.GetAllProdukter();
        }

        private void tbhyrinfo_TextChanged(object sender, EventArgs e)
        {
            Search = tbhyrinfo.Text;
        }

        private void btntaborthyrdata_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Är du säker på att du vill radera vald rad?", "Ta Bort", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                if (dvhyrdata.SelectedRows != null)
                {
                    Utrustning = (Utrustning)dvhyrdata.CurrentRow.DataBoundItem;
                    FacadeBusiness.FacadeUtrustning.RemoveUtrustning(Utrustning);
                }
            }
            HämtaUtrustning();
        }
    }
}
