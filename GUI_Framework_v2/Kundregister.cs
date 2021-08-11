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
using System.IO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace GUI_Framework_v2
{
    public partial class Kundregister : Form
    {
        public FacadeBusiness FacadeBusiness { get; set; }
        public MarknadsChef MarknadsChef { get; set; }
        internal List<PrivatKundRegisterClass> PrivatKundRegUtSkriv { get; set; }
        public List<PrivatKund> PrivatKundList { get; set; }

        internal List<FöretagsKundRegisterClass> FöretagKundRegUtSkriv { get; set; }
        public List<FöretagsKund> FöretagKundList { get; set; }
       
        public Kundregister(MarknadsChef mc)
        {
            InitializeComponent();
            MarknadsChef = mc;
            FacadeBusiness = new FacadeBusiness();
            PrivatKundList = new List<PrivatKund>();
            PrivatKundRegUtSkriv = new List<PrivatKundRegisterClass>();
            FöretagKundList = new List<FöretagsKund>();
            FöretagKundRegUtSkriv = new List<FöretagsKundRegisterClass>();       
            DatagridPrivatKund();
            DatagridFöretagKund();
        }

        private void företagskundregistergrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void VisaPrivatKunder()
        {
            gvprivatkundregister.DataSource = null;
            gvprivatkundregister.DataSource = PrivatKundRegUtSkriv;

        }

        private void VisaFöretagsKunder()
        {
            gvföretagskundregister.DataSource = null;
            gvföretagskundregister.DataSource = FöretagKundRegUtSkriv;
        
        }

        private void Kundregister_Load(object sender, EventArgs e)
        {

        }

        private void btntillbaka_Click(object sender, EventArgs e)
        {
            frmRegister mc = new frmRegister(MarknadsChef, null);
            this.Hide();
            mc.Show();
        }

        private void btnskrivutregisterförprivatkund_Click(object sender, EventArgs e)
        {
            string savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filename = "\\Privatkundsregister";
            string endpoint = ".pdf";
            Document doc = new Document(iTextSharp.text.PageSize.A4.Rotate(), 10, 10, 60, 60);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(savePath + filename + endpoint, FileMode.Create));

            doc.Open();

            //Manage the paragraph and the content
            
            Paragraph paragraph = new Paragraph();
            paragraph.IndentationLeft = 320f;
            paragraph.PaddingTop = 20f;
            paragraph.SetLeading(1.0f, 3.0f);
            paragraph.SpacingAfter = 10f;
            paragraph.Font.SetFamily("Helvetica");
            paragraph.Font.Size = 20f;
            paragraph.Add("PrivatKund Register");
            doc.Add(paragraph);

            ////Creating iTextSharp Table from the DataTable data
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable table = new PdfPTable(gvprivatkundregister.Columns.Count);
            table.DefaultCell.Padding = 3;
            table.WidthPercentage = 70;
            table.HorizontalAlignment = Element.ALIGN_CENTER;
            table.DefaultCell.BorderWidth = 1;

            //Add the headers from the DGV to table
            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.BOLD);
            for (int j = 0; j < gvprivatkundregister.Columns.Count; j++)
            {
                PdfPCell pCell = new PdfPCell(new Phrase(gvprivatkundregister.Columns[j].HeaderText, text));
                pCell.BackgroundColor = new iTextSharp.text.BaseColor(Color.Yellow);
                table.AddCell(pCell);

            }

            //Flag the first row as a header
            table.HeaderRows = 1;

            //Add the actual rows from the DGV to the table
            iTextSharp.text.Font text2 = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
            for (int i = 0; i < gvprivatkundregister.Rows.Count; i++)
            {
                for (int k = 0; k < gvprivatkundregister.Columns.Count; k++)
                {
                    if (gvprivatkundregister[k, i].Value != null)
                    {
                        PdfPCell pRows = new PdfPCell(new Phrase(gvprivatkundregister[k, i].Value.ToString(), text2));
                        pRows.BackgroundColor = new iTextSharp.text.BaseColor(Color.White);
                        table.AddCell(pRows);
                    }
                }
            }
            doc.Add(table);
            doc.Close();
        }

        public void DatagridPrivatKund()
        {
            PrivatKundList = FacadeBusiness.FacadePrivatKund.GetAllPKunder();

            for(int i = 0; i < PrivatKundList.Count; i++)
            {
                PrivatKundRegUtSkriv.Add(new PrivatKundRegisterClass()
                {
                    PrivatFörnamn = PrivatKundList[i].PrivatFörnamn,
                    PrivatEfternamn = PrivatKundList[i].PrivatEfternamn,
                    PrivatGatuadress = PrivatKundList[i].PrivatGatuadress,
                    PrivatPostnummer = PrivatKundList[i].PrivatPostnummer,
                    PrivatPostort = PrivatKundList[i].PrivatPostort,
                    PrivatTelefonnummer = PrivatKundList[i].PrivatTelefonnummer,
                    PrivatEpostadress = PrivatKundList[i].PrivatEpostadress,
                });
            }
            VisaPrivatKunder();
        }
        

        private void btnskrivutregisterförföretagskund_Click(object sender, EventArgs e)
        {
            string savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filename = "\\Företagskundsregister";
            string endpoint = ".pdf";
            Document doc = new Document(iTextSharp.text.PageSize.A4.Rotate(), 10, 10, 60, 60);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(savePath + filename + endpoint, FileMode.Create));

            doc.Open();

            //Manage the paragraph and the content

            Paragraph paragraph = new Paragraph();
            paragraph.IndentationLeft = 320f;
            paragraph.PaddingTop = 20f;
            paragraph.SetLeading(1.0f, 3.0f);
            paragraph.SpacingAfter = 10f;
            paragraph.Font.SetFamily("Helvetica");
            paragraph.Font.Size = 20f;
            paragraph.Add("FöretagKund Register");
            doc.Add(paragraph);

            ////Creating iTextSharp Table from the DataTable data
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable table = new PdfPTable(gvföretagskundregister.Columns.Count);
            table.DefaultCell.Padding = 3;
            table.WidthPercentage = 70;
            table.HorizontalAlignment = Element.ALIGN_CENTER;
            table.DefaultCell.BorderWidth = 1;

            //Add the headers from the DGV to table
            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.BOLD);
            for (int j = 0; j < gvföretagskundregister.Columns.Count; j++)
            {
                PdfPCell pCell = new PdfPCell(new Phrase(gvföretagskundregister.Columns[j].HeaderText, text));
                pCell.BackgroundColor = new iTextSharp.text.BaseColor(Color.Yellow);
                table.AddCell(pCell);

            }

            //Flag the first row as a header
            table.HeaderRows = 1;

            //Add the actual rows from the DGV to the table
            iTextSharp.text.Font text2 = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
            for (int i = -1; i < gvföretagskundregister.Rows.Count; i++)
            {
                for (int k = -1; k < gvföretagskundregister.Columns.Count; k++)
                {
                    if (gvföretagskundregister[k, i].Value != null)
                    {
                        PdfPCell pRows = new PdfPCell(new Phrase(gvföretagskundregister[k, i].Value.ToString(), text2));
                        pRows.BackgroundColor = new iTextSharp.text.BaseColor(Color.White);
                        table.AddCell(pRows);
                    }
                }
            }
            doc.Add(table);
            doc.Close();
        }

        public void DatagridFöretagKund()
        {
            FöretagKundList = FacadeBusiness.FacadeFöretagsKund.GetAllFöretagKunder();

            for(int i = 0; i < FöretagKundList.Count; i++)
            {
                FöretagKundRegUtSkriv.Add(new FöretagsKundRegisterClass()
                {
                    
                    Företagsnamn = FöretagKundList[i].Företagsnamn,
                    OrgNummer = FöretagKundList[i].OrgNummer,
                    FöretagTelefonNummer = FöretagKundList[i].FöretagTelefonNummer,
                    FöretagEpostadress = FöretagKundList[i].FöretagEpostadress,
                    Gatuadress = FöretagKundList[i].Gatuadress,
                    FöretagPostnummer = FöretagKundList[i].FöretagPostnummer,
                    FöretagPostort = FöretagKundList[i].FöretagPostort,
                    Faktureringsadress = FöretagKundList[i].Faktureringsadress,
                    FöretagFaktureringPostnummer = FöretagKundList[i].FöretagFaktureringPostnummer,
                    FöretagFaktureringPostort = FöretagKundList[i].FöretagFaktureringPostort,

                });
            }
            VisaFöretagsKunder();
        }
    }    
}
