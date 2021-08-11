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
    public partial class LäggTillKundFöretag : Form
    {
        public FacadeBusiness FacadeBusiness {get; set;}
        public MarknadsChef MarknadsChef {get; set;}
        public Anställd Anställd {get; set;}
       
        public LäggTillKundFöretag(MarknadsChef mc, Anställd a)
        {
            InitializeComponent();
            MarknadsChef = mc;
            Anställd = a;
            FacadeBusiness = new FacadeBusiness();
        }
       
        private string namn;

        public string Namn
        {
            get { return namn; }
            set { namn = value; }
        }

        private string orgnummer;

        public string Orgnummer
        {
            get { return orgnummer; }
            set { orgnummer = value; }
        }

        private double rabatt;

        public double Rabatt
        {
            get { return rabatt; }
            set { rabatt = value; }
        }

        private string refperson;

        public string Refperson
        {
            get { return refperson; }
            set { refperson = value; }
        }

        private string telefon;

        public string Telefon
        {
            get { return telefon; }
            set { telefon = value; }
        }

        private string epost;

        public string Epost
        {
            get { return epost; }
            set { epost = value; }
        }

        private string adress;

        public string Adress
        {
            get { return adress; }
            set { adress = value; }
        }

        private string postnr;

        public string Postnr
        {
            get { return postnr; }
            set { postnr = value; }
        }

        private string postort;

        public string Postort
        {
            get { return postort; }
            set { postort = value; }
        }

        private string fakturaadress;

        public string Fakturadress
        {
            get { return fakturaadress; }
            set { fakturaadress = value; }
        }

        private string _fakturapostnummer;

        public string FakturaPostnummer
        {
            get { return _fakturapostnummer; }
            set { _fakturapostnummer = value; }
        }

        private string _fakturaort;

        public string FakturaOrt
        {
            get { return _fakturaort; }
            set { _fakturaort = value; }
        }

        private double _kredit;

        public double Kredit
        {
            get { return _kredit; }
            set { _kredit = value; }
        }


        private void LäggTillKundFöretag_Load(object sender, EventArgs e)
        {

        }

        private void btnTillbaka_Click(object sender, EventArgs e)
        {
            if (MarknadsChef != null && Anställd == null)
            {
                frmMarknadsmeny meny = new frmMarknadsmeny(null, MarknadsChef);
                this.Hide();
                meny.Show();
            }
            else if (Anställd != null && MarknadsChef == null)
            {
                Boka.frmKonferens k = new Boka.frmKonferens(Anställd, null);
                this.Hide();
                k.Show();
            }
        }

        private void btnläggtillfkund_Click(object sender, EventArgs e)
        {
            FacadeBusiness.FacadeFöretagsKund.LäggTillKund(new FöretagsKund()
            {
                Företagsnamn = Namn,
                OrgNummer = Orgnummer,
                FöretagRabatt = Rabatt,
                RefPerson = Refperson,
                FöretagTelefonNummer = Telefon,
                FöretagEpostadress = Epost,
                Gatuadress = Adress,
                FöretagPostnummer = Postnr,
                FöretagFaktureringPostort = FakturaOrt,
                Faktureringsadress = Fakturadress,
                FöretagPostort = Postort,
                FöretagFaktureringPostnummer = FakturaPostnummer
            }) ;
            MessageBox.Show("Kund skapad");
        }

        private void tbnamnf_TextChanged(object sender, EventArgs e)
        {
            if (tbnamnf != null) Namn = tbnamnf.Text;
        }

        private void tborgnr_TextChanged(object sender, EventArgs e)
        {
            if (tborgnr != null) Orgnummer = tborgnr.Text;
        }

        private void tbrabatt_TextChanged(object sender, EventArgs e)
        {
            double pris;
            bool isPris = double.TryParse(tbrabatt.Text, out pris);
            if (tbrabatt != null && isPris == true)
                Rabatt = pris;
            else
            { 
                MessageBox.Show("Rabbaten är felaktigt inlagd", "Felaktig input", MessageBoxButtons.OK);
                tbrabatt.Text = "";
            }
        }

        private void tbrepersonf_TextChanged(object sender, EventArgs e)
        {
            if (tbrepersonf != null) Refperson = tbrepersonf.Text;
        }

        private void tbtelefonf_TextChanged(object sender, EventArgs e)
        {
            if (tbtelefonf != null) Telefon = tbtelefonf.Text;
        }

        private void tbepostf_TextChanged(object sender, EventArgs e)
        {
            if (tbepostf != null) Epost = tbepostf.Text;
        }

        private void tbadressf_TextChanged(object sender, EventArgs e)
        {
            if (tbadressf != null) Adress = tbadressf.Text;
        }

        private void tbpostnrf_TextChanged(object sender, EventArgs e)
        {
            if (tbpostnrf != null) Postnr = tbpostnrf.Text;
        }

        private void tbpostortf_TextChanged(object sender, EventArgs e)
        {
            if (tbpostortf != null) Postort = tbpostortf.Text;
        }

        private void tbfakturaf_TextChanged(object sender, EventArgs e)
        {
            if (tbfakturaf != null) Fakturadress = tbfakturaf.Text;
        }

        private void tbfakturapostnr_TextChanged(object sender, EventArgs e)
        {
            if (tbfakturapostnr != null) FakturaPostnummer = tbfakturapostnr.Text;
        }

        private void tbfakturaort_TextChanged(object sender, EventArgs e)
        {
            if (tbfakturaort != null) FakturaOrt = tbfakturaort.Text;
        }

        private void tbKredit_TextChanged(object sender, EventArgs e)
        {
            double kreditgräns;
            bool isPris = double.TryParse(tbKredit.Text, out kreditgräns);
            if (tbKredit != null && isPris == true)
                Kredit = kreditgräns;
            else
            {
                MessageBox.Show("Krediten är felaktigt inlagd", "Felaktig input", MessageBoxButtons.OK);
                tbKredit.Text = "";
            }
        }
    }
}
