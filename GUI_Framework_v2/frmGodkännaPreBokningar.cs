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
    public partial class frmGodkännaPreBokningar : Form
    {
        public SysAdmin Admin { get; set; }
        public MarknadsChef Chef { get; set; }
        public Anställd Anställd { get; set; }
        public FacadeBusiness FacadeBusiness { get; set; }
        internal GodkännaPreBokningar GodkännaPreBokningar { get; set; }
        internal List<GodkännaPreBokningar> ListOfBokings { get; set; }
        public List<PreBokning> PreBoknings { get; set; }

        public frmGodkännaPreBokningar(Anställd a, MarknadsChef m, SysAdmin sa)
        {
            InitializeComponent();
            Anställd = a;
            Chef = m;
            Admin = sa;
            FacadeBusiness = new FacadeBusiness();
            GodkännaPreBokningar = new GodkännaPreBokningar();
            ListOfBokings = new List<GodkännaPreBokningar>();
            PreBoknings = new List<PreBokning>();
            btnAll.Hide();
            UpdateGUI();
        }

        #region Egna metoder
        private void UpdateGUI()
        {
            ListOfBokings.Clear();
            GetDataForLsit();
            dgvPreBoknings.DataSource = null;
            dgvPreBoknings.DataSource = ListOfBokings;
        }

        private void GetDataForLsit()
        {
            ListOfBokings = GodkännaPreBokningar.ConvertForGUI();
            if (ListOfBokings == null) ListOfBokings.Add(GodkännaPreBokningar);
        }
        #endregion
        // Tillbaka knapp som tar en till startsidan igen 
        private void btnTillbaka_Click(object sender, EventArgs e)
        {
            if(Anställd != null)
            {
                frmBokning fbm = new frmBokning(Anställd, null, null);
                this.Hide();
                fbm.Show();
            }
            else if(Chef != null)
            {
                frmBokning fbm = new frmBokning(null, Chef, null);
                this.Hide();
                fbm.Show();
            }
        }
        // Knapp för att godkänna preliminärbokningar om bokningar är större än 0 
        // Konverterar preliminära bokningar till godkänd bokning och uppdaterar sedan GUI 
        private void btnBoka_Click(object sender, EventArgs e)
        {
            if (dgvPreBoknings.CurrentRow != null)
            {
                GodkännaPreBokningar gpb = (GodkännaPreBokningar)dgvPreBoknings.CurrentRow.DataBoundItem;
                ConvertGodkändToPre(gpb);
                MessageBox.Show($"Bokning för: {gpb._name} {gpb._seconName} är bokad.", "Godkänd bokning", MessageBoxButtons.OK);
                UpdateGUI();
            }
            else MessageBox.Show("Det finns inte någon preliminärbokning att välja!", "Error!");
        }

        private void ConvertGodkändToPre(GodkännaPreBokningar temp)
        {
            PreBoknings = FacadeBusiness.FacadeBokning.SortPreList();
            
            for (int i = 0; i < PreBoknings.Count; i++)
            {
                if (temp._id == PreBoknings[i].BokningsID)
                {
                    PreBokning preTemp = FacadeBusiness.FacadePreBokning.GetPrebokningToBokning(PreBoknings[i]);
                    FacadeBusiness.FacadeBokning.SingleBoking(preTemp, preTemp.BokningsID);
                }
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            string message;
            message = FacadeBusiness.FacadeBokning.PreToBoking();
            MessageBox.Show(message, "Skapade bokningar", MessageBoxButtons.OK);
        }
    }
}
