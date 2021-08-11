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
    public partial class UppdateraKundPrivat : Form
    {
        private string _search;
        public FacadeBusiness FacadeBusiness { get; set; }
        public SysAdmin SysAdmin { get; set; }
        public PrivatKund PrivatKund { get; set; }
        public Anställd Anställd { get; set; }

        public UppdateraKundPrivat(SysAdmin s, Anställd a)
        {
            InitializeComponent();          
            SysAdmin = s;
            Anställd = a;
            FacadeBusiness = new FacadeBusiness();
            UppdateraGridView();
        }

        public string fnamn;
        public string enamn;
        public string epost;
        public string telefon;
        public string adress;
        public string postnummer;
        public string postort;

        private void UppdateraKundPrivat_Load(object sender, EventArgs e)
        {

        }

        private void UppdateraGridView()
        {
            gvpkund.DataSource = null;
            gvpkund.DataSource = FacadeBusiness.FacadePrivatKund.GetAllPKunder();
        }

        private void btntillbaka_Click(object sender, EventArgs e)
        {
            if (SysAdmin != null && Anställd == null)
            {
                frmSysadminMeny s = new frmSysadminMeny(SysAdmin, null);
                this.Hide();
                s.Show();
            }
            else if (Anställd != null && SysAdmin == null)
            {
                BokaPrivat a = new BokaPrivat(Anställd, null);
                this.Hide();
                a.Show();
            }
        }

        private void btnuppdatera_Click(object sender, EventArgs e)
        {
            PrivatKund pk = (PrivatKund)gvpkund.CurrentRow.DataBoundItem;
            PrivatKund = pk;
            if (fnamn != null)
            {
                PrivatKund.PrivatFörnamn = fnamn;
            }
            if (enamn != null)
            {
                PrivatKund.PrivatEfternamn = enamn;
            }
            if (epost != null)
            {
                PrivatKund.PrivatEpostadress = epost;
            }
            if (adress != null)
            {
                PrivatKund.PrivatGatuadress = adress;
            }
            if (postnummer != null)
            {
                PrivatKund.PrivatPostnummer = postnummer;
            }
            if (postort != null)
            {
                PrivatKund.PrivatPostort = postort;
            }
            if (tbtelefon != null)
            {
                PrivatKund.PrivatTelefonnummer = tbtelefon.Text;
            }

            FacadeBusiness.FacadePrivatKund.UppdateraPrivatkund(PrivatKund, PrivatKund.PrivatKundID);
            MessageBox.Show("Kunduppgifter uppdaterade");
            UppdateraGridView();
        }

        private void btnsökpkund_Click(object sender, EventArgs e)
        {
            if (Search != null)
            {
                if (FacadeBusiness.FacadePrivatKund.SearchPrivatKund(Search).ToList() != null)
                {
                    gvpkund.DataSource = null;
                    gvpkund.DataSource = FacadeBusiness.FacadePrivatKund.SearchPrivatKund(Search).ToList();
                }
                else
                    UppdateraGridView();
            }
            else
                MessageBox.Show("Det finns ingen sökterm");
        }

        private void Tbsökkund_TextChanged(object sender, EventArgs e)
        {
            Search = Tbsökkund.Text;
        }

        public string Search
        {
            get { return _search; }
            set { _search = value; }
        }

        private void dvpkund_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gvpkund.SelectedRows.Count > 0)
            {
                PrivatKund = (PrivatKund)gvpkund.SelectedRows[0].DataBoundItem;
                tbkund.Text = PrivatKund.PrivatFörnamn;
                tbefternamn.Text = PrivatKund.PrivatEfternamn;
                tbepost.Text = PrivatKund.PrivatEpostadress;
                tbtelefon.Text = PrivatKund.PrivatTelefonnummer;
                tbadress.Text = PrivatKund.PrivatGatuadress;
                tbpostadress.Text = PrivatKund.PrivatPostnummer;
                tbpostort.Text = PrivatKund.PrivatPostort;
            }
        }

        private void tbkund_TextChanged(object sender, EventArgs e)
        {
            if (tbkund.Text != null)
            {
                fnamn = tbkund.Text;
            }
        }

        private void tbefternamn_TextChanged(object sender, EventArgs e)
        {
            if (tbefternamn.Text != null)
            {
                enamn = tbefternamn.Text;
            }
        }

        private void tbepost_TextChanged(object sender, EventArgs e)
        {
            if (tbepost.Text != null)
            {
                epost = tbepost.Text;
            }
        }

        private void tbtelefon_TextChanged(object sender, EventArgs e)
        {
            if (tbtelefon.Text != null)
            {
                telefon = tbtelefon.Text;
            }
        }

        private void tbadress_TextChanged(object sender, EventArgs e)
        {
            if (tbadress.Text != null)
            {
                adress = tbadress.Text;
            }
        }

        private void tbpostadress_TextChanged(object sender, EventArgs e)
        {
            if (tbpostadress.Text != null)
            {
                postnummer = tbpostadress.Text;
            }
        }

        private void tbpostort_TextChanged(object sender, EventArgs e)
        {
            if (tbpostort.Text != null)
            {
                postort = tbpostort.Text;
            }
        }

        private void gvpkund_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gvpkund.SelectedRows.Count > 0)
            {
                PrivatKund = (PrivatKund)gvpkund.SelectedRows[0].DataBoundItem;
                tbkund.Text = PrivatKund.PrivatFörnamn;
                tbefternamn.Text = PrivatKund.PrivatEfternamn;
                tbepost.Text = PrivatKund.PrivatEpostadress;
                tbtelefon.Text = PrivatKund.PrivatTelefonnummer;
                tbadress.Text = PrivatKund.PrivatGatuadress;
                tbpostadress.Text = PrivatKund.PrivatPostnummer;
                tbpostort.Text = PrivatKund.PrivatPostort;
            }
        }

        private void btntabort_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Är du säker på att du vill radera vald kund?", "Ta Bort", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                if (gvpkund.SelectedRows != null)
                {
                   PrivatKund = (PrivatKund)gvpkund.CurrentRow.DataBoundItem;
                   FacadeBusiness.FacadePrivatKund.RemovePrivatkund(PrivatKund);
                }
                UppdateraGridView();
            }
        }
    }
}
