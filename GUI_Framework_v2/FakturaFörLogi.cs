using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessEntities_FrameWork.Models;
using BusinessLayer_FrameWork;
using GUI_FrameWork;

using System.IO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data.SqlClient;
using DataLayer_FrameWork.Context;

namespace GUI_Framework_v2
{
    public partial class FakturaFörLogi : Form
    {
        public MarknadsChef MarknadsChef { get; set; }
        public Anställd Anställd { get; set; }
        public FacadeBusiness FacadeBusiness { get; set; }
        public List<Faktura> Fakturor { get; set; }
        public SysAdmin SysAdmin { get; set; }
        internal List <FakturaFörLogiClass> FakturaFörlogiLista { get; set;}

        public FakturaFörLogi(SysAdmin s, MarknadsChef mc)
        {
            InitializeComponent();
            Anställd = new Anställd();
            FacadeBusiness = new FacadeBusiness();
            Fakturor = new List<Faktura>();
            FakturaFörlogiLista = new List<FakturaFörLogiClass>();
            SysAdmin = s;
            MarknadsChef = mc;
            LogiTillUtskrift();
            UpdateraGrid();
        }

        private void UpdateraGrid()
        {
            gvfldata.DataSource = null;
            gvfldata.DataSource = FakturaFörlogiLista;
        }

        private void FakturaFörLogi_Load(object sender, EventArgs e)
        {

        }

        private void btnskrivutf_Click(object sender, EventArgs e)
        {
            string savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filename = "\\Faktura-Logi";
            string endpoint = ".pdf";
            Document doc = new Document(iTextSharp.text.PageSize.A4, 20, 20, 40, 40);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(savePath + filename + endpoint, FileMode.Create));
            doc.Open();

            PdfPTable table = new PdfPTable(gvfldata.Columns.Count);

            //Add the headers from the DGV to table
            for (int j = 0; j < gvfldata.Columns.Count; j++)
            {
                table.AddCell(new Phrase(gvfldata.Columns[j].HeaderText));
            }

            //Flag the first row as a header
            table.HeaderRows = 1;

            //Add the actual rows from the DGV to the able
            for (int i = 0; i < gvfldata.Rows.Count; i++)
            {
                for (int k = 0; k < gvfldata.Columns.Count; k++)
                {
                    if (gvfldata[k, i].Value != null)
                    {
                        table.AddCell(new Phrase(gvfldata[k, i].Value.ToString()));
                    }
                }
            }
            doc.Add(table);
            doc.Close();
        }

        private void gvfldata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btntillbaka_Click(object sender, EventArgs e)
        {
            frmMarknadsmeny mc = new frmMarknadsmeny(null, MarknadsChef);
            this.Hide();
            mc.Show();
        }
        // Metod som skriver ut fakturor för logi 
        // Skapar en lista på alla temporära fakturor som innehåller allt i FakturaFörlogiLista
        private void LogiTillUtskrift ()
        {
            List<Faktura> Templista = FacadeBusiness.FacadeFaktura.FakturorTillLog();
            for (int i = 0; i < Templista.Count; i++)
            {
                FakturaFörlogiLista.Add(new FakturaFörLogiClass()
                {
                    FakturaID = Templista[i].FakturaID,
                    Pris = Templista[i].Pris,
                    FaktureringsDatum = Templista[i].FaktureringsDatum,
                    FörfalloDatum = Templista[i].FörfalloDatum,
                    Typ = Templista[i].Typ,
                    Status = Templista[i].Status,

                });
            }
        }

        private void btnsök_Click(object sender, EventArgs e)
        {

        }
    }
}

        

