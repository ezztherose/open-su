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
    public partial class Uthyrningsregister : Form
    {
        public FacadeBusiness FacadeBusiness { get; set; }
        public MarknadsChef MarknadsChef { get; set; }
        public Uthyrningsregister(MarknadsChef mc)
        {
            InitializeComponent();
            MarknadsChef = mc;
            FacadeBusiness = new FacadeBusiness();
            VisaUthyrningar();
        }

        private void Uthyrningsregister_Load(object sender, EventArgs e)
        {

        }

        private void btntillbaka_Click(object sender, EventArgs e)
        {
            frmRegister mc = new frmRegister(MarknadsChef, null);
            this.Hide();
            mc.Show();
        }

        private void VisaUthyrningar()
        {
            gvuthyrningr.DataSource = null;
            var allUtnyrningar = FacadeBusiness.FacadeUthyrning.GetAllUtnyrningar();
            var filteredElements = allUtnyrningar.Select(u => new UthyrningsregisterClass
            {
                UthyrningsID = u.UthyrningsID,
                UthyrningsDatum = u.UthyrningsDatum,
                UthyrningsPris = u.UthyrningsPris,
                AntalDagar = u.AntalDagar,
                Status = u.Status ? "Aterlämnad":"Ej aterlämnad"
            }).ToList();

            gvuthyrningr.AutoGenerateColumns = true;
            gvuthyrningr.DataSource = filteredElements;
            gvuthyrningr.Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnskrivututhyrningsregister_Click(object sender, EventArgs e)
        {
            string savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filename = "\\Uthyrningsregister";
            string endpoint = ".pdf";
            Document doc = new Document(iTextSharp.text.PageSize.A4.Rotate(), 10, 10, 60, 60);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(savePath + filename + endpoint, FileMode.Create));

            doc.Open();

            Paragraph paragraph = new Paragraph();
            paragraph.IndentationLeft = 320f;
            paragraph.PaddingTop = 20f;
            paragraph.SetLeading(1.0f, 3.0f);
            paragraph.SpacingAfter = 10f;
            paragraph.Font.SetFamily("Helvetica");
            paragraph.Font.Size = 20f;
            paragraph.Add("Uthyrningsregister");
            doc.Add(paragraph);

            ////Creating iTextSharp Table from the DataTable data
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);

            PdfPTable table = new PdfPTable(gvuthyrningr.Columns.Count);
            table.DefaultCell.Padding = 3;
            table.WidthPercentage = 70;
            table.HorizontalAlignment = Element.ALIGN_CENTER;
            table.DefaultCell.BorderWidth = 1;

            //Add the headers from the DGV to table
            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.BOLD);
            for (int j = 0; j < gvuthyrningr.Columns.Count; j++)
            {
                PdfPCell pCell = new PdfPCell(new Phrase(gvuthyrningr.Columns[j].HeaderText, text));
                pCell.BackgroundColor = new iTextSharp.text.BaseColor(Color.Yellow);
                table.AddCell(pCell);
            }

            //Flag the first row as a header
            table.HeaderRows = 1;

            //Add the actual rows from the DGV to the table
            iTextSharp.text.Font text2 = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL);
            foreach (DataGridViewRow row in gvuthyrningr.Rows)
            {
                foreach (DataGridViewCell celli in row.Cells)
                {
                    PdfPCell pRows = new PdfPCell(new Phrase(celli.Value?.ToString(), text2));
                    table.AddCell(pRows);
                }
            }
            doc.Add(table);
            doc.Close();
        }
    }
}

