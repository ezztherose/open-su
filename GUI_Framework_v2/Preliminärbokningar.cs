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
    public partial class Preliminärbokningar : Form
    {
        internal PdfKlass PdfKlass { get; set; }
        public MarknadsChef MarknadsChef { get; set; }
        public FacadeBusiness FacadeBusiness = new FacadeBusiness();
        public List<PreBokning> Prebokningar;
        public PreBokning pre { get; set; }
        public PrivatKund pk { get; set; }
        public FöretagsKund fk { get; set; }
        public Faktura Faktura = new Faktura();
        public Bokning bk = new Bokning();

        private string search;

        public Preliminärbokningar(MarknadsChef m)
        {
            InitializeComponent();         
            MarknadsChef = m;
            pk = new PrivatKund();
            fk = new FöretagsKund();
            PdfKlass = new PdfKlass();
            FacadeBusiness = new FacadeBusiness();
            pre = new PreBokning();
            Prebokningar = new List<PreBokning>();
            UpdateDataGrid();
        }

        private void UpdateDataGrid()
        {
            Prebokningar.Clear();
            CheckForAcceptedPreBokings();
            gvpbokning.DataSource = null;
            gvpbokning.DataSource = Prebokningar;
        }

        private void CheckForAcceptedPreBokings()
        {
            Prebokningar.Clear();
            List<PreBokning> temp = FacadeBusiness.FacadePreBokning.GetAllPreBokning();
            List<PreBokning> preTemp = new List<PreBokning>();
            foreach (PreBokning item in temp)
                if (item.Status == false) preTemp.Add(item);
            Prebokningar.AddRange(preTemp);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Avslå bokning, är du säker?", "Avslå bokning", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                if (gvpbokning.CurrentRow != null)
                {
                    pre = (PreBokning)gvpbokning.CurrentRow.DataBoundItem;
                    FacadeBusiness.FacadePreBokning.AvslåPreBokning(pre);
                }
            }
            UpdateDataGrid();           
        }

        private void Preliminärbokningar_Load(object sender, EventArgs e)
        {

        }

        private void btntillbaka_Click(object sender, EventArgs e)
        {
            frmMarknadsmeny m = new frmMarknadsmeny(null, MarknadsChef);
            this.Hide();
            m.Show();
        }

        private void btngodkändbokning_Click(object sender, EventArgs e)
        {
            if (gvpbokning.CurrentRow != null)
            {
                // Status på godkänd prebokning == 1
                // Status på avslagen prebokning == 0
                pre = (PreBokning)gvpbokning.CurrentRow.DataBoundItem;
                pk = FacadeBusiness.FacadePreBokning.HittaPrivatKundTillPreBokning(pre);
                fk = FacadeBusiness.FacadePreBokning.HittaFöretagsKundTillPreBokning(pre);
                
                if (pk != null)
                {
                    pre.Status = true;
                    FacadeBusiness.FacadePreBokning.UpdatePreBoking(pre, pre.BokningsID);
                }
                else
                {
                    pre.Status = true;
                    FacadeBusiness.FacadePreBokning.UpdatePreBoking(pre, pre.BokningsID);
                }              
            }
            UpdateDataGrid();
        }

        private void btnsök_Click(object sender, EventArgs e)
        {
            if (Search != null)
            {
                if (FacadeBusiness.FacadePreBokning.SearchPreBokning(Search).ToList() != null)
                {
                    gvpbokning.DataSource = null;
                    gvpbokning.DataSource = FacadeBusiness.FacadePreBokning.SearchPreBokning(Search).ToList();
                }
                else
                    UpdateDataGrid();
            }
            else
                MessageBox.Show("Det finns ingen sökterm!");
        }
        public string Search
        {
            get { return search; }
            set { search = value; }
        }

        private void tbpreliminärbokningar_TextChanged(object sender, EventArgs e)
        {
            Search = tbpreliminärbokningar.Text;
        }
    }
}
