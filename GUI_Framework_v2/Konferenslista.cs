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
    public partial class Konferenslista : Form
    {
        public FacadeBusiness FacadeBusiness { get; set; }
        public SysAdmin SysAdmin { get; set; }
        public Konferens Konferens { get; set; }
        public List<Konferens> konferenslista { get; set; }

        private string _search;

        public Konferenslista(SysAdmin s)
        {
            InitializeComponent();
            FacadeBusiness = new FacadeBusiness();
            SysAdmin = s;
            konferenslista = new List<Konferens>();
            Konferens = new Konferens();
            UpdateGridViewKonferens();
        }

        public string Search
        {
            get { return _search; }
            set { _search = value; }
        }

        private void Konferenslista_Load(object sender, EventArgs e)
        {

        }

        private void btntillbaka_Click(object sender, EventArgs e)
        {
            frmSysadminMeny s = new frmSysadminMeny(SysAdmin, null);
            this.Hide();
            s.Show();
        }

        private void btnsökinfo_Click(object sender, EventArgs e)
        {
            if (Search != null)
            {
                if (FacadeBusiness.FacadeKonferens.SearchKonferens(Search).ToList() != null)
                {
                    konferensgrid.DataSource = null;
                    konferensgrid.DataSource = FacadeBusiness.FacadeKonferens.SearchKonferens(Search).ToList();
                }
                else
                    UpdateGridViewKonferens();
            }
            else
                MessageBox.Show("Det finns ingen sökterm");
        }

        public void UpdateGridViewKonferens()
        {
            konferensgrid.DataSource = null;
            konferensgrid.DataSource = FacadeBusiness.FacadeKonferens.GetAllKonferens();
        }

        private void tblogiinfo_TextChanged(object sender, EventArgs e)
        {
            Search = tblogiinfo.Text;
        }

        private void konferensgrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btntabortkonferensinfo_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Är du säker på att du vill radera vald rad?", "Ta Bort", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                if (konferensgrid.SelectedRows != null)
                {
                    Konferens = (Konferens)konferensgrid.CurrentRow.DataBoundItem;
                    FacadeBusiness.FacadeKonferens.RemoveKonferensInfo(Konferens);
                }
            }
            UpdateGridViewKonferens();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
