using BusinessEntities_FrameWork.Models;
using BusinessLayer_FrameWork;
using GUI_FrameWork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using SaveFileDialog = System.Windows.Forms.SaveFileDialog;

namespace GUI_Framework_v2
{
    public partial class BelStatistik : Form
    {
        public FacadeBusiness FacadeBusiness { get; set; }
        public MarknadsChef MarknadsChef { get; set; }
        internal BelStatistikClass BelStatistikClass { get; set; }
        internal List<BelStatistikClass> BokningStatistik { get; set; }

        public BelStatistik(MarknadsChef mc)
        {
            InitializeComponent();
            FacadeBusiness = new FacadeBusiness();
            BokningStatistik = new List<BelStatistikClass>();
            BelStatistikClass = new BelStatistikClass();
            MarknadsChef = mc;
            skapaLista();
            FyllComboBox();
            Uppdateragrid();
        }

        private void Uppdateragrid()
        {
            gvBeStatic.DataSource = null;
            gvBeStatic.DataSource = BokningStatistik;

        }

        private void skapaLista()
        {
            List<Bokning> lista = FacadeBusiness.FacadeBokning.GetAllBokningar();
            List<BelStatistikClass> temp = new List<BelStatistikClass>();
            BokningStatistik.AddRange(temp);
        }

        #region Ifyllnad av gui
        private void FyllComboBox()
        {
            for (int i = 1; i < 53; i++)
            {
                cbStartVecka.Items.Add(i);
                cbSlutVecka.Items.Add(i);
            }
            cbMånad.Items.Add(1);
            cbMånad.Items.Add(2);
            cbMånad.Items.Add(3);
            cbMånad.Items.Add(4);
            cbMånad.Items.Add(5);
            cbMånad.Items.Add(6);
            cbMånad.Items.Add(7);
            cbMånad.Items.Add(8);
            cbMånad.Items.Add(9);
            cbMånad.Items.Add(10);
            cbMånad.Items.Add(11);
            cbMånad.Items.Add(12);

            cbStartMånad.Items.Add(1);
            cbStartMånad.Items.Add(2);
            cbStartMånad.Items.Add(3);
            cbStartMånad.Items.Add(4);
            cbStartMånad.Items.Add(5);
            cbStartMånad.Items.Add(6);
            cbStartMånad.Items.Add(7);
            cbStartMånad.Items.Add(8);
            cbStartMånad.Items.Add(9);
            cbStartMånad.Items.Add(10);
            cbStartMånad.Items.Add(11);
            cbStartMånad.Items.Add(12);

            cbSlutÅr.Items.Add(2019);
            cbSlutÅr.Items.Add(2020);
            cbSlutÅr.Items.Add(2021);
            cbSlutÅr.Items.Add(2022);
            cbSlutÅr.Items.Add(2023);
            cbSlutÅr.Items.Add(2024);
            cbSlutÅr.Items.Add(2019);
            cbSlutÅr.Items.Add(2020);
            cbSlutÅr.Items.Add(2022);
            cbSlutÅr.Items.Add(2023);
            cbSlutÅr.Items.Add(2024);

            cbStartår.Items.Add(2019);
            cbStartår.Items.Add(2020);
            cbStartår.Items.Add(2021);
            cbStartår.Items.Add(2022);
            cbStartår.Items.Add(2023);
            cbStartår.Items.Add(2024);
            cbStartår.Items.Add(2019);
            cbStartår.Items.Add(2020);
            cbStartår.Items.Add(2022);
            cbStartår.Items.Add(2023);
            cbStartår.Items.Add(2024);

            cbLogialternativ.Items.Add("Typ 1 Lägenhet");
            cbLogialternativ.Items.Add("Typ 2 Lägenhet");
            cbLogialternativ.Items.Add("Camping");
        }

        #endregion

        private void BelStatistik_Load(object sender, EventArgs e)
        {

        }

        private void btntillbaka_Click(object sender, EventArgs e)
        {
                frmMarknadsmeny mc = new frmMarknadsmeny(null, MarknadsChef);
                this.Hide();
                mc.Show();
        }

        private void btnExporteraTillExellbt_Click(object sender, EventArgs e)
        {
            //*************************************//
            // creating Excel Application  
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();      
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);         
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            app.Visible = true;  
            worksheet = workbook.Sheets["Blad1"];
            worksheet = workbook.ActiveSheet;
            
            worksheet.Name = "Exported from gridview";
            for (int i = 1; i < gvBeStatic.Columns.Count + 1; i++)
                worksheet.Cells[1, i] = gvBeStatic.Columns[i - 1].HeaderText;


            // storing Each row and column value to excel sheet  
            for (int i = 0; i < gvBeStatic.Rows.Count; i++)
                for (int j = 0; j < gvBeStatic.Columns.Count; j++)
                    worksheet.Cells[i + 2, j + 1] = gvBeStatic.Rows[i].Cells[j].Value.ToString();

            object misValue = System.Reflection.Missing.Value;
        }

        private void btVälj_Click(object sender, EventArgs e)
        {
           
            DatagridStatistik();

        }

        private void rbVecka_CheckedChanged(object sender, EventArgs e)
        {
            if (rbVecka.Checked)
            {
                cbMånad.Hide();
                cbStartVecka.Show();
                cbSlutVecka.Show();
                cbStartMånad.Hide();
            }
        }

        private void rbMånad_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMånad.Checked)
            {
                cbMånad.Show();
                cbStartVecka.Hide();
                cbStartMånad.Show();
                cbSlutVecka.Hide();
            }
        }

        public void DatagridStatistik()
        {
            bool Månad = true;
            int max;
            int frånMånad = 0;
            int tillMånad = 0;

            int frånÅr = int.Parse(cbStartår.Text);
            int start = 0;
            int slut = 0;
            int tillVecka = 0;
            int frånVecka = 0;
            int tillÅr = int.Parse(cbSlutÅr.Text);
            for (int kollaÅr = frånÅr; kollaÅr <= tillÅr; kollaÅr++)
            {
                if (rbMånad.Checked)
                {
                    max = 12;
                    frånMånad = int.Parse(cbStartMånad.Text);
                    tillMånad = int.Parse(cbMånad.Text);
                    start = kollaÅr > frånÅr ? 1 : frånMånad;
                    slut = tillÅr > kollaÅr ? max : tillMånad;
                }
                else if (rbVecka.Checked)
                {
                    max = 52;
                    frånVecka = int.Parse(cbStartVecka.Text);
                    tillVecka = int.Parse(cbSlutVecka.Text);
                    start = kollaÅr > frånÅr ? 1 : frånVecka;
                    slut = tillÅr > kollaÅr ? max : tillVecka;

                }
                // Iterates through months or weeks
                for (int kollaPeriod = start; kollaPeriod <= slut; kollaPeriod++)
                {
                    DateTime startDatum = new DateTime();
                    DateTime slutDatum = new DateTime();
                    int antalDagar = 0;
                    string lägenhetstyp = cbLogialternativ.Text;
                    if (lägenhetstyp == "Typ 1 Lägenhet") lägenhetstyp = "Liten";
                    if (lägenhetstyp == "Typ 2 Lägenhet") lägenhetstyp = "Stor";
                    if (rbMånad.Checked)
                    {
                        startDatum = new DateTime(kollaÅr, kollaPeriod, 1);
                        antalDagar = DateTime.DaysInMonth(kollaÅr, kollaPeriod);
                        slutDatum = new DateTime(kollaÅr, kollaPeriod, antalDagar);

                    }
                    if (rbVecka.Checked && !rbMånad.Checked)
                    {
                        antalDagar = 7;
                        startDatum = FacadeBusiness.FacadeBokning.veckaDatum(kollaÅr, kollaPeriod);
                        slutDatum = startDatum.AddDays(6);
                    }
                    int tillgänglig = FacadeBusiness.FacadeMarknadsChef.TillgängligaLägenheter(startDatum.AddHours(13), slutDatum.AddHours(13), lägenhetstyp);

                    int reserved = FacadeBusiness.FacadeLogi.HämtaLogiPåTyp(lägenhetstyp);
                    reserved = reserved * antalDagar - tillgänglig;

                    BokningStatistik.Add(new BelStatistikClass()
                    {
                        Lägenhetstyp = lägenhetstyp,
                        Tillgängliga = tillgänglig,
                        Reserverade = reserved,
                        Månad = kollaPeriod,
                    });
                    Uppdateragrid();
                }
            }
        }
    }
}
