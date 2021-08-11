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
using BusinessLayer_FrameWork.Models;
using DataLayer_FrameWork.Context;

namespace GUI_Framework_v2
{
    public partial class Butiksregister : Form
    {
        public FacadeBusiness FacadeBusiness;
        public Anställd Anställd { get; set; }
        public MarknadsChef MarknadsChef { get; set; }
        internal List<ButiksregisterClass> ButikRegisterUtskriv { get; set; }
        public List<Utrustning> UtrustningList { get; set; }
        public Butiksregister(Anställd a, MarknadsChef mc)
        {
            InitializeComponent();
            Anställd = a;
            MarknadsChef = mc;
            FacadeBusiness = new FacadeBusiness();
            UtrustningList = new List<Utrustning>();
            ButikRegisterUtskriv = new List<ButiksregisterClass>();
            DatagridButikRegister();
            VisaProdukter();
            skapaLista();          
        }

        private void skapaLista()
        {
            List<Utrustning> lista = FacadeBusiness.FacadeButiksregister.GetAllProdukter();
            List<ButiksregisterClass> temp = new List<ButiksregisterClass>();
            ButikRegisterUtskriv.AddRange(temp);
        }

        private void Butiksregister_Load(object sender, EventArgs e)
        {
            gvButikregister.AllowUserToAddRows = false;
        }

        private void btntillbaka_Click(object sender, EventArgs e)
        {
            frmButikMeny meny = new frmButikMeny(Anställd, MarknadsChef);
            this.Hide();
            meny.Show();
        }

        private void VisaProdukter()
        {
            gvButikregister.DataSource = null;
            gvButikregister.DataSource = ButikRegisterUtskriv;
        }

        public void DatagridButikRegister()
        {
            UtrustningList = FacadeBusiness.FacadeUtrustning.GetAllProdukter();
            for (int i = 0; i < UtrustningList.Count; i++)
            {
                ButikRegisterUtskriv.Add(new ButiksregisterClass()
                {
                    ArtikelID = UtrustningList[i].ArtikelID,
                    UtrustningSort = UtrustningList[i].UtrustningSort,
                    UtrustningsTyp = UtrustningList[i].UtrustningsTyp,
                    Tillgänglig = UtrustningList[i].Tillgänglig,                   
                });
            }
            VisaProdukter();
        }

        [Obsolete]
        private void btnskrivutregister_Click(object sender, EventArgs e)
        {
            string savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filename = "\\ButiksRegister";
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
            paragraph.Add("Faktura - ButiksRegister");
            doc.Add(paragraph);

            ////Creating iTextSharp Table from the DataTable data
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable table = new PdfPTable(gvButikregister.Columns.Count);
            table.DefaultCell.Padding = 3;
            table.WidthPercentage = 70;
            table.HorizontalAlignment = Element.ALIGN_CENTER;
            table.DefaultCell.BorderWidth = 1;

            //Add the headers from the DGV to table
            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.BOLD);
            for (int j = 0; j < gvButikregister.Columns.Count; j++)
            {
                PdfPCell pCell = new PdfPCell(new Phrase(gvButikregister.Columns[j].HeaderText, text));
                pCell.BackgroundColor = new iTextSharp.text.BaseColor(Color.Green);
                table.AddCell(pCell);

            }   
            //Flag the first row as a header
            table.HeaderRows = 1;

            //Add the actual rows from the DGV to the table
            iTextSharp.text.Font text2 = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
            for (int i = 0; i < gvButikregister.Rows.Count; i++)
            {
                for (int k = 0; k < gvButikregister.Columns.Count; k++)
                {
                    if (gvButikregister[k, i].Value != null)
                    {
                        PdfPCell pRows = new PdfPCell(new Phrase(gvButikregister[k, i].Value.ToString(), text2));
                        pRows.BackgroundColor = new iTextSharp.text.BaseColor(Color.White);
                        table.AddCell(pRows);
                    }
                }
            }            
            doc.Add(table);
            doc.Close();           
        }
    }
}
