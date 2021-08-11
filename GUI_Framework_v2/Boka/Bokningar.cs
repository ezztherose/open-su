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
    public partial class Bokningar : Form
    {
        public Anställd Anställd { get; set; }
        public MarknadsChef MarknadsChef { get; set; }
        public FacadeBusiness FacadeBusiness { get; set; }
        internal List<BokningarClass> BokningUtskriv { get; set; }
        public List<Bokning> BokningList { get; set; }

        private string _search;

        public Bokningar(Anställd a, MarknadsChef mc)
        {
            InitializeComponent();
            Anställd = a;
            MarknadsChef = mc;
            FacadeBusiness = new FacadeBusiness();
            BokningList = new List<Bokning>();
            BokningUtskriv = new List<BokningarClass>();
            skapaLista();
            DatagridBokning();
        }

        private void skapaLista()
        {
            List<Bokning> lista = FacadeBusiness.FacadeBokning.GetAllBokningar();
            List<BokningarClass> temp = new List<BokningarClass>();
            BokningUtskriv.AddRange(temp);
        }

        [Obsolete]
        private void btnskrivutb_Click(object sender, EventArgs e)
        {
            string savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filename = "\\Faktura-Bokningar";
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
            paragraph.Add("Faktura - Bokningar");
            doc.Add(paragraph);

            ////Creating iTextSharp Table from the DataTable data
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable table = new PdfPTable(gvBokningar.Columns.Count);
            table.DefaultCell.Padding = 3;
            table.WidthPercentage = 70;
            table.HorizontalAlignment = Element.ALIGN_CENTER;
            table.DefaultCell.BorderWidth = 1;

            //Add the headers from the DGV to table
            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.BOLD);
            for (int j = 0; j < gvBokningar.Columns.Count; j++)
            {
                PdfPCell pCell = new PdfPCell(new Phrase(gvBokningar.Columns[j].HeaderText, text));
                pCell.BackgroundColor = new iTextSharp.text.BaseColor(Color.Yellow);
                table.AddCell(pCell);
            }

            //Flag the first row as a header
            table.HeaderRows = 1;

            //Add the actual rows from the DGV to the table
            iTextSharp.text.Font text2 = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
            for (int i = 0; i < gvBokningar.Rows.Count; i++)
            {
                for (int k = 0; k < gvBokningar.Columns.Count; k++)
                {
                    if (gvBokningar[k, i].Value != null)
                    {
                        PdfPCell pRows = new PdfPCell(new Phrase(gvBokningar[k, i].Value.ToString(), text2));
                        pRows.BackgroundColor = new iTextSharp.text.BaseColor(Color.White);
                        table.AddCell(pRows);
                    }
                }
            }
            doc.Add(table);
            doc.Close();
        }

        private void Bokningar_Load(object sender, EventArgs e)
        {

        }

        public string Search
        {
            get { return _search; }
            set { _search = value; }
        }

        private void VisaBokningar()
        {         
            gvBokningar.DataSource = null;
            gvBokningar.DataSource = BokningUtskriv;
           
        }

        private void btntillbaka_Click(object sender, EventArgs e)
        {
            if (MarknadsChef == null && Anställd != null)
            {
                frmBokning fb = new frmBokning(Anställd, MarknadsChef, null);
                this.Hide();
                fb.Show();
            }
            else if (MarknadsChef != null && Anställd == null)
            {
                frmRegister mc = new frmRegister(MarknadsChef, null);
                this.Hide();
                mc.Show();
            }
        }

        private void tbSökBokningar_TextChanged(object sender, EventArgs e)
        {
            Search = tbSökBokningar.Text;
        }

        private void btnsökb_Click(object sender, EventArgs e)
        {
            if (Search != null)
                if (FacadeBusiness.FacadeBokning.SearchBokning(Search).ToList() != null)
                {
                    gvBokningar.DataSource = null;
                    gvBokningar.DataSource = FacadeBusiness.FacadeBokning.SearchBokning(Search).ToList();
                }
                else
                    VisaBokningar();
            else
                MessageBox.Show("Det finns ingen sökterm");
        }

        public void DatagridBokning()
        {          
            BokningList = FacadeBusiness.FacadeBokning.GetAllBokningar();
            for (int i = 0; i < BokningList.Count; i++)
            {
                BokningUtskriv.Add(new BokningarClass()
                {
                    BokningsID = BokningList[i].BokningsID,
                    InCheckningsDatum = BokningList[i].InCheckningsDatum,
                    UtCheckningsDatum = BokningList[i].UtCheckningsDatum,
                    BokningsTyp = BokningList[i].BokningsTyp,
                    BokningsPris = BokningList[i].BokningsPris,
                    Moms = BokningList[i].Moms,
                });
            }           
            VisaBokningar();
        }

        private void gvBokningar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
