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
using Spire.Pdf.Tables;
using GUI_FrameWork;
using BusinessLayer_FrameWork;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace GUI_Framework_v2
{
    public partial class FakturaFörKöp : Form
    {
        public MarknadsChef MarknadsChef { get; set; }
        public Anställd Anställd { get; set; }
        public FacadeBusiness FacadeBusiness { get; set; }
        public SysAdmin SysAdmin { get; set; }

        internal List<FakturaFörKöpClass> FakturaUtskriv { get; set; }
        public List<Faktura> FakturaList { get; set; }

        public FakturaFörKöp(SysAdmin s, MarknadsChef mc)
        {
            InitializeComponent();
            MarknadsChef = mc;
            SysAdmin = s;
            Anställd = new Anställd();
            FacadeBusiness = new FacadeBusiness();
            FakturaList = new List<Faktura>();
            FakturaUtskriv = new List<FakturaFörKöpClass>();
            skapaLista();
            DatagridFaktura();
            UpdateraGrid();
        }
        // Skapar en lista på alla fakturor 
        private void skapaLista()
        {
            List<Faktura> lista = FacadeBusiness.FacadeFaktura.GetAllFakturor();
            List<FakturaFörKöpClass> temp = new List<FakturaFörKöpClass>();
            FakturaUtskriv.AddRange(temp);
        }

        public void DatagridFaktura()
        {
            FakturaList = FacadeBusiness.FacadeFaktura.GetAllFakturor();

            for (int i = 0; i < FakturaList.Count; i++)
            {
                FakturaUtskriv.Add(new FakturaFörKöpClass()
                {
                    FakturaID = FakturaList[i].FakturaID,
                    Pris = FakturaList[i].Pris,
                    FaktureringsDatum = FakturaList[i].FaktureringsDatum,
                    FörfalloDatum = FakturaList[i].FörfalloDatum,
                    Typ = FakturaList[i].Typ,
                    Status = FakturaList[i].Status,
                });
            }
            UpdateraGrid();
        }

        private void UpdateraGrid()
        {
            gvFKdata.DataSource = null;
            gvFKdata.DataSource = FakturaUtskriv;
        }

        private void FakturaFörKöp_Load(object sender, EventArgs e)
        {

        }
        // Metod som väljer de fakturor som ska skrivas ut. Som sedan skrivs ut till en pdf 
        private void btnskrivutfakturas_Click(object sender, EventArgs e)
        {
            string savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filename = "\\Faktura-FörKöp";
            string endpoint = ".pdf";
            Document doc = new Document(iTextSharp.text.PageSize.A4.Rotate(), 10, 10, 60, 60);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(savePath + filename + endpoint, FileMode.Create));

            doc.Open();

            //Manage the paragraph and the content
            //Paragraph.FirstLineIndent  //allows you to apply a float value to indent the first line
            //Paragraph.IndentationLeft  //allows you to add space to the left hand side
            //Paragraph.IndentationRight //allows you to add space to the right hand side
            //Paragraph.SpacingBefore //adds a specified amount of space above the paragraph
            //Paragraph.SpacingAfter  //adds the specified amount of space after the paragraph

            Paragraph paragraph = new Paragraph();
            paragraph.IndentationLeft = 320f;
            paragraph.PaddingTop = 20f;
            paragraph.SetLeading(1.0f, 3.0f);
            paragraph.SpacingAfter = 10f;
            paragraph.Font.SetFamily("Helvetica");
            paragraph.Font.Size = 20f;
            paragraph.Add("Faktura - För Köp");
            doc.Add(paragraph);

            ////Creating iTextSharp Table from the DataTable data
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable table = new PdfPTable(gvFKdata.Columns.Count);
            table.DefaultCell.Padding = 3;
            table.WidthPercentage = 70;
            table.HorizontalAlignment = Element.ALIGN_CENTER;
            table.DefaultCell.BorderWidth = 1;

            //Add the headers from the DGV to table
            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.BOLD);
            for (int j = 0; j < gvFKdata.Columns.Count; j++)
            {
                PdfPCell pCell = new PdfPCell(new Phrase(gvFKdata.Columns[j].HeaderText, text));
                pCell.BackgroundColor = new iTextSharp.text.BaseColor(Color.Yellow);
                table.AddCell(pCell);

            }

            //Flag the first row as a header
            table.HeaderRows = 1;

            //Add the actual rows from the DGV to the table
            iTextSharp.text.Font text2 = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
            for (int i = 0; i < gvFKdata.Rows.Count; i++)
            {
                for (int k = 0; k < gvFKdata.Columns.Count; k++)
                {
                    if (gvFKdata[k, i].Value != null)
                    {
                        PdfPCell pRows = new PdfPCell(new Phrase(gvFKdata[k, i].Value.ToString(), text2));
                        pRows.BackgroundColor = new iTextSharp.text.BaseColor(Color.White);
                        table.AddCell(pRows);
                    }
                }
            }


            doc.Add(table);
            doc.Close();
        }
        // Tillbaka knapp till startmenyn 
        private void btntillbaka_Click(object sender, EventArgs e)
        {
                frmMarknadsmeny mc = new frmMarknadsmeny(null, MarknadsChef);
                this.Hide();
                mc.Show();
        }
        // Sökknapp som fungerar för att få fram de valda fakturorna 
        private void btnsök_Click(object sender, EventArgs e)
        {

        }

        private void gvFKdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
} 

