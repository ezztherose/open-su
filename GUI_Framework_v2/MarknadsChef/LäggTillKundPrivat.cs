using BusinessEntities_FrameWork.Models;
using BusinessLayer_FrameWork;
using GUI_Framework_v2.Boka;
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
    public partial class LäggTillKundPrivat : Form
    {
        public MarknadsChef MarknadsChef { get; set; }
        public FacadeBusiness FacadeBusiness { get; set; }
        public Anställd Anställd { get; set; }
        public PrivatKund PrivatKund { get; set; }
        public LäggTillKundPrivat(MarknadsChef mc, Anställd a)
        {
            InitializeComponent();
            FacadeBusiness = new FacadeBusiness();
            MarknadsChef = mc;             
            Anställd = a;
        }

        private void btnTillbaka_Click(object sender, EventArgs e)
        {
            if (MarknadsChef != null && Anställd == null)
            {
                frmMarknadsmeny meny = new frmMarknadsmeny(null, MarknadsChef);
                this.Hide();
                meny.Show();
            }
            else if(Anställd != null && Anställd.Behörighet.Equals("Butik") && MarknadsChef == null)
            {
                ButikSkiduthyrning meny = new ButikSkiduthyrning(Anställd, null);
                this.Hide();
                meny.Show();
            }
            else if (Anställd != null && Anställd.Behörighet.Equals("Reception") && MarknadsChef == null)
            {
                BokaCampingochPrivat bcp = new BokaCampingochPrivat(Anställd, null);
                this.Hide();
                bcp.Show();
            }
        }
     
        private string privatFörnamn;

        public string PrivatFörnamn
        {
            get { return privatFörnamn; }
            set { privatFörnamn = value; }
        }

        private string privatEfternamn;

        public string PrivatEfternamn
        {
            get { return privatEfternamn; }
            set { privatEfternamn = value; }
        }

        private string privatGatuadress;

        public string PrivatGatuadress
        {
            get { return privatGatuadress; }
            set { privatGatuadress = value; }
        }

        private string privatPostnummer;

        public string PrivatPostnummer
        {
            get { return privatPostnummer; }
            set { privatPostnummer = value; }
        }

        private string privatPostort;

        public string PrivatPostort
        {
            get { return privatPostort; }
            set { privatPostort = value; }
        }
        
        private string privatTelefonnummer;

        public string PrivatTelefonnummer
        {
            get { return privatTelefonnummer; }
            set { privatTelefonnummer = value; }
        }

        private string epostAdress;

        public string PrivatEpostadress
        {
            get { return epostAdress; }
            set { epostAdress = value; }
        }

        private void tbnamnp_TextChanged(object sender, EventArgs e)
        {
            if (tbenamnp != null) PrivatFörnamn = tbnamnp.Text;
        }

        private void tbadressp_TextChanged(object sender, EventArgs e)
        {
            if (tbadressp != null)PrivatGatuadress = tbadressp.Text;
        }

        private void tbenamnp_TextChanged(object sender, EventArgs e)
        {
            if (tbenamnp != null) PrivatEfternamn = tbenamnp.Text;
        }

        private void tbpostnrp_TextChanged(object sender, EventArgs e)
        {
            if (tbpostnrp != null) PrivatPostnummer = tbpostnrp.Text;
        }

        private void tbpostortp_TextChanged(object sender, EventArgs e)
        {
            if (tbpostortp != null) PrivatPostort = tbpostortp.Text;
        }

        private void tbtelefonp_TextChanged(object sender, EventArgs e)
        {
            if (tbtelefonp != null) PrivatTelefonnummer = tbtelefonp.Text;
        }

        private void tbepostp_TextChanged(object sender, EventArgs e)
        {
            if (tbepostp != null) PrivatEpostadress = tbepostp.Text;
        }

        private void btnLäggTillpKund_Click_1(object sender, EventArgs e)
        {
            double rabatt = GetDiscount();
            FacadeBusiness.FacadePrivatKund.LäggTillKund(new PrivatKund()
            {
                PrivatFörnamn = PrivatFörnamn,
                PrivatEfternamn = PrivatEfternamn,
                PrivatGatuadress = PrivatGatuadress,
                PrivatPostnummer = PrivatPostnummer,
                PrivatPostort = PrivatPostort,
                PrivatTelefonnummer = PrivatTelefonnummer,
                PrivatEpostadress = PrivatEpostadress,
                Rabatt = rabatt
            });
            MessageBox.Show("Kund skapad");
        }

        private double GetDiscount()
        {
            PrivatKund p = FacadeBusiness.FacadePrivatKund.HämtaPrivatKund(1);
            if (p == null)
            {
                MessageBox.Show("Det finns ingen angiven rabatt för privatkunder.\n" +
                    "Be admin att uppdatera för alla privatkunder", "Saknad rabatt");
                return 0;
            }
            else
                return p.Rabatt;
        }
    }
}
