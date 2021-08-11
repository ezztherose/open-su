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
    public partial class ButikÅterlämning : Form
    {
        public FacadeBusiness FacadeBusiness { get; set; }
        public Anställd Anställd { get; set; }
        public Uthyrning Uthyrning { get; set; }
        public MarknadsChef MarknadsChef { get; set; }
        public Utrustning Utrustning { get; set; }
        public PrivatKund pk { get; set; }
        public List<Utrustning> utrustnings = new List<Utrustning>();
        
        private string _sök;
        public string Sök
        {
            get { return _sök; }
            set { _sök = value; }
        }

        public ButikÅterlämning(Anställd a , MarknadsChef mc)
        {
            InitializeComponent();
            FacadeBusiness = new FacadeBusiness();
            Anställd = new Anställd();
            MarknadsChef = new MarknadsChef();
            Uthyrning = new Uthyrning();
            Utrustning = new Utrustning();
            Anställd = a;
            MarknadsChef = mc;
            LaddaGUI();
            btnÅterlämna.Hide();
        }

        private void LaddaGUI()
        {
            gvÅterlämning.DataSource = null;
            gvÅterlämning.DataSource = FacadeBusiness.FacadePrivatKund.GetAllPKunder();
        }
        private bool LaddaUthyrning()
        {
            if (gvÅterlämning.CurrentRow == null) MessageBox.Show("Det finns inte någon kund att välja", "Error", MessageBoxButtons.OK);

            if (gvÅterlämning.CurrentRow != null)
            {
                utrustnings.Clear();
                pk = (PrivatKund)gvÅterlämning.CurrentRow.DataBoundItem;
                List<Uthyrning> checkList = FacadeBusiness.FacadeUthyrning.GetAllEjReturnerade(pk);
                if (checkList.Count <= 0) MessageBox.Show($"Det finns inga produkter att lämna tillbaka för {pk.PrivatFörnamn} {pk.PrivatEfternamn}", "Inga redskap", MessageBoxButtons.OK);
                else
                {
                    foreach (Uthyrning item in FacadeBusiness.FacadeUthyrning.GetAllEjReturnerade(pk))
                    {
                        utrustnings.AddRange(FacadeBusiness.FacadeUthyrning.GetEjReturneradePK(item.UthyrningsID));
                        gvÅterlämning.DataSource = null;
                        gvÅterlämning.DataSource = utrustnings;
                    }
                    return true;
                }
            }
            else
                MessageBox.Show("Du har valt artikel, gå tillbaka och markera en kund", "Error", MessageBoxButtons.OK);
            return false;
        }

        private void ButikÅterlämning_Load(object sender, EventArgs e)
        {

        }

        private void tbSök_TextChanged(object sender, EventArgs e)
        {
            Sök = tbSök.Text;
        }

        private void btnSök_Click(object sender, EventArgs e)
        {
            ResetButtons();
            if (Sök != null)
            {
                List<PrivatKund> SearchByName = FacadeBusiness.FacadePrivatKund.SearchUthyrningByFullName(Sök);
                bool isEmpty = !SearchByName.Any();
                if (!isEmpty)
                {
                    gvÅterlämning.DataSource = null;
                    gvÅterlämning.DataSource = SearchByName;
                }
                else
                {
                    gvÅterlämning.DataSource = null;
                    List<FöretagsKund> SearchCompany = FacadeBusiness.FacadeFöretagsKund.SearchFöretagsKund(Sök);
                    gvÅterlämning.DataSource = SearchCompany;
                }
            }
            else
                LaddaGUI();
        }

        private void ResetButtons()
        {
            btnSök.BackColor = Color.LightGray;
            btnSök.Text = "Sök";
            btnTillbaka.Show();
        }

        private void btnTillbaka_Click(object sender, EventArgs e)
        {
            if (MarknadsChef != null && Anställd == null)
            {
                frmButikMeny meny = new frmButikMeny(Anställd, MarknadsChef);
                this.Hide();
                meny.Show();
            }
            else if (Anställd != null && MarknadsChef == null)
            {
                frmButikMeny meny = new frmButikMeny(Anställd, MarknadsChef);
                this.Hide();
                meny.Show();
            }
        }

        private void btnÅterlämna_Click(object sender, EventArgs e)
        {
            if (gvÅterlämning.CurrentRow != null)
            {
                Utrustning Utrustning = (Utrustning)gvÅterlämning.CurrentRow.DataBoundItem;
                FacadeBusiness.FacadeUthyrning.UtrustningTillÅterlämning(Utrustning); //Lämnar tillbaka personens valda uthyrning.
                utrustnings.Clear(); // rensar listan för att undvika dubletter
                foreach (Uthyrning item in FacadeBusiness.FacadeUthyrning.GetAllEjReturnerade(pk)) //Kollar personens uthyrningar. 
                {
                    if (item != null) utrustnings.AddRange(FacadeBusiness.FacadeUthyrning.GetEjReturneradePK(item.UthyrningsID));
                    if (utrustnings.Count == 0) FacadeBusiness.FacadeUthyrning.StatusTillgänglig(item);   
                }
                gvÅterlämning.DataSource = null;
                gvÅterlämning.DataSource = utrustnings;
            }
            else
                MessageBox.Show("Du har inte valt kund", "Error", MessageBoxButtons.OK);          
        }

        private void btKund_Click(object sender, EventArgs e)
        {
            bool checker = false;
            checker = LaddaUthyrning();
            if (checker == true)
            {
                btnTillbaka.Hide();
                btnÅterlämna.Show();
                btnSök.Text = "Tillbaka";
                btnSök.BackColor = Color.Green;
            }
        }

        private void tbSök_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter) btnSök_Click(null, null);
        }

        private void gvÅterlämning_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
