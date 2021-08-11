using BusinessEntities_FrameWork.Models;
using BusinessLayer_FrameWork;
//using GUI_FrameWork;
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
    public partial class UppdateraKundFöretag : Form
    {
        private string _search;

        public FacadeBusiness FacadeBusiness { get; set; }
        public SysAdmin SysAdmin { get; set; }
        public MarknadsChef MarknadsChef { get; set; }
        public FöretagsKund FöretagsKund { get; set; }
        public Anställd Anställd { get; set; }

        public string företagsnamn;
        public string organisationsnummer;
        public string företagepost;
        public string företagtelefon;
        public string företagadress;
        public string företagpostnr;
        public string företagpostort;
        public string fakturaadress;
        public string refperson;
        public double rabatt;
        public int id;
        private string fakturapostnummer;
        private string fakturapostort;
        private string _kreditgräns;
        private double _credit;

        public UppdateraKundFöretag(SysAdmin s, MarknadsChef mc, Anställd a)
        {
            InitializeComponent();
            SysAdmin = s;
            MarknadsChef = mc;
            Anställd = a;
            FacadeBusiness = new FacadeBusiness();
            UppdateraGridView();
        }

        private void UppdateraKundFöretag_Load(object sender, EventArgs e)
        {

        }

        private void UppdateraGridView()
        {
            gvfkund.DataSource = null;
            gvfkund.DataSource = FacadeBusiness.FacadeFöretagsKund.GetAllFöretagKunder();
        }

        private void btntillbaka_Click(object sender, EventArgs e)
        {
            if (SysAdmin != null && MarknadsChef == null && Anställd == null)
            {
                frmSysadminMeny s = new frmSysadminMeny(SysAdmin, null);
                this.Hide();
                s.Show();
            }
            else if (MarknadsChef != null && SysAdmin == null && Anställd == null)
            {
                frmMarknadsmeny mc = new frmMarknadsmeny(null, MarknadsChef);
                this.Hide();
                mc.Show();
            }
        }

        private void btnsökfkund_Click(object sender, EventArgs e)
        {
            if (Search != null)
            {
                if (FacadeBusiness.FacadeFöretagsKund.SearchFöretagsKund(Search).ToList() != null)
                {
                    gvfkund.DataSource = null;
                    gvfkund.DataSource = FacadeBusiness.FacadeFöretagsKund.SearchFöretagsKund(Search).ToList();
                }
                else
                    UppdateraGridView();
            }
            else
                MessageBox.Show("Det finns ingen sökterm");
        }

        private void Tbsökföretagskund_TextChanged(object sender, EventArgs e)
        {
            Search = Tbsökföretagskund.Text;
        }

        public string Search
        {
            get { return _search; }
            set { _search = value; }
        }

        private void btnuppdaterafkund_Click(object sender, EventArgs e)
        {
            FöretagsKund fk = (FöretagsKund)gvfkund.CurrentRow.DataBoundItem;
            FöretagsKund = fk;
            if (företagsnamn != null) FöretagsKund.Företagsnamn = företagsnamn;

            if (organisationsnummer != null) FöretagsKund.OrgNummer = organisationsnummer;

            if (företagepost != null) FöretagsKund.FöretagEpostadress = företagepost;

            if (företagtelefon != null) FöretagsKund.FöretagTelefonNummer = företagtelefon;
            
            if (företagadress != null) FöretagsKund.Gatuadress = företagadress;
            
            if (företagpostnr != null) FöretagsKund.FöretagPostnummer = företagpostnr;
            
            if (företagpostort != null) FöretagsKund.FöretagPostort = företagpostort;
            
            if (fakturaadress != null) FöretagsKund.Faktureringsadress = fakturaadress;
            
            if (refperson != null) FöretagsKund.RefPerson = refperson;
            
            if (!rabatt.Equals(null)) FöretagsKund.FöretagRabatt = rabatt;
            
            if (fakturapostnummer != null) FöretagsKund.FöretagFaktureringPostnummer = fakturapostnummer;
            
            if (fakturapostort != null) FöretagsKund.FöretagFaktureringPostort = fakturapostort;

            if (_credit != null) FöretagsKund.Kreditgräns = _credit;

            FacadeBusiness.FacadeFöretagsKund.UppdateraFöretagsKund(FöretagsKund, FöretagsKund.FöretagKundID);
            MessageBox.Show("Kunduppgifter uppdaterade");
            UppdateraGridView();
        }

        private void gvfkund_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gvfkund_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gvfkund.SelectedRows.Count > 0)
            {
                FöretagsKund = (FöretagsKund)gvfkund.SelectedRows[0].DataBoundItem;
                Tbfkund.Text = FöretagsKund.Företagsnamn;
                tborgnummer.Text = FöretagsKund.OrgNummer;
                tbepost.Text = FöretagsKund.FöretagEpostadress;
                tbtelefon.Text = FöretagsKund.FöretagTelefonNummer;
                tbfakturaadress.Text = FöretagsKund.Gatuadress;
                tbpostnr.Text = FöretagsKund.FöretagPostnummer;
                tbpostort.Text = FöretagsKund.FöretagPostort;
                tbfakturaadress.Text = FöretagsKund.Faktureringsadress;
                tbrefperson.Text = FöretagsKund.RefPerson;
                tbadress.Text = FöretagsKund.Gatuadress;
                tbrabatt.Text = FöretagsKund.FöretagRabatt.ToString();
                tbfakturapnr.Text = FöretagsKund.FöretagFaktureringPostnummer;
                tbfakturaort.Text = FöretagsKund.FöretagFaktureringPostort;
                tbKreditgräns.Text = FöretagsKund.Kreditgräns.ToString();
            }
        }

        private void tbfakturapnr_TextChanged(object sender, EventArgs e)
        {
            if (tbfakturapnr.Text != null)
            {
                fakturapostnummer = tbfakturapnr.Text;
            }
        }

        private void btntabort_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Är du säker på att du vill radera vald kund?", "Ta Bort", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                if (gvfkund.SelectedRows != null)
                {
                    FöretagsKund = (FöretagsKund)gvfkund.CurrentRow.DataBoundItem;
                    FacadeBusiness.FacadeFöretagsKund.RemoveFöretagsKund(FöretagsKund);
                }
                UppdateraGridView();
            }
        }

        private void tbrabatt_TextChanged(object sender, EventArgs e)
        {
            double temp;
            if (tbrabatt.Text != null && double.TryParse(tbrabatt.Text, out temp))
                rabatt = double.Parse(tbrabatt.Text);
            else
            {
                MessageBox.Show("Fel input i textrutan", "Error");
                tbrabatt.Text = "";
            }
        }

        private void Tbfkund_TextChanged(object sender, EventArgs e)
        {
            if (Tbfkund.Text != null) företagsnamn = Tbfkund.Text;
        }

        private void tborgnummer_TextChanged(object sender, EventArgs e)
        {
            if (tborgnummer.Text != null) organisationsnummer = tborgnummer.Text;
        }

        private void tbepost_TextChanged(object sender, EventArgs e)
        {
            if (tbepost.Text != null) företagepost = tbepost.Text;
        }

        private void tbtelefon_TextChanged(object sender, EventArgs e)
        {
            if (tbtelefon.Text != null) företagtelefon = tbtelefon.Text;
        }

        private void tbadress_TextChanged(object sender, EventArgs e)
        {
            if (tbadress.Text != null) företagadress = tbadress.Text;
        }

        private void tbpostnr_TextChanged(object sender, EventArgs e)
        {
            if (tbpostnr.Text != null) företagpostnr = tbpostnr.Text;
        }

        private void tbpostort_TextChanged(object sender, EventArgs e)
        {
            if (tbpostort.Text != null) företagpostort = tbpostort.Text;
        }

        private void tbfakturaadress_TextChanged(object sender, EventArgs e)
        {
            if (tbfakturaadress.Text != null) fakturaadress = tbfakturaadress.Text;
        }

        private void tbrefperson_TextChanged(object sender, EventArgs e)
        {
            if (tbrefperson.Text != null) refperson = tbrefperson.Text;
        }

        private void tbfakturaort_TextChanged(object sender, EventArgs e)
        {
            if (tbfakturaort.Text != null) fakturapostort = tbfakturaort.Text;
        }

        private void tbKreditgräns_TextChanged(object sender, EventArgs e)
        {
            double temp;
            if (tbKreditgräns.Text != null && double.TryParse(tbKreditgräns.Text, out temp)) _credit = temp;
        }
    }
}
