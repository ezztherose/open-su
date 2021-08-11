using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities_FrameWork.Models;
using BusinessLayer_FrameWork;
using GUI_FrameWork;
using System.IO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data.SqlClient;
using DataLayer_FrameWork.Context;
using System.Windows.Forms;

namespace GUI_Framework_v2
{
    public partial class Fakturaregister : Form
    {
        public MarknadsChef MarknadsChef { get; set; }
        public FacadeBusiness FacadeBusiness { get; set; }
        internal List<FakturaRegisterClass> FakturaRegisterClass { get; set; }

        public Fakturaregister(MarknadsChef mc)
        {
            InitializeComponent();
            MarknadsChef = mc;
            FacadeBusiness = new FacadeBusiness();
            FakturaRegisterClass = new List<FakturaRegisterClass>();
            KonverteraTillUtskrif();
            VisaFakturor();
        }

        private void KonverteraTillUtskrif()
        {
            List<Faktura> TempListaFaktura = FacadeBusiness.FacadeFaktura.GetAllFakturor();
            for (int i = 0; i < TempListaFaktura.Count; i++)
            {
                FakturaRegisterClass.Add(new FakturaRegisterClass()
                {
                    FakturaID = TempListaFaktura[i].FakturaID,
                    Pris = TempListaFaktura[i].Pris,
                    Status = TempListaFaktura[i].Status ? "Betalt" : "Inte betalt",
                    FaktureringsDatum = TempListaFaktura[i].FaktureringsDatum,
                    FörfalloDatum = TempListaFaktura[i].FörfalloDatum
                });
            }
        }

        private void VisaFakturor()
        {
            dgvFakturaRegister.DataSource = null;
            dgvFakturaRegister.DataSource = FakturaRegisterClass;
        }

        private void Fakturaregister_Load(object sender, EventArgs e)
        {

        }
        // Tillbaka knapp som tar en till startsidan
        private void btntillbaka_Click(object sender, EventArgs e)
        {

            frmRegister mc = new frmRegister(MarknadsChef, null);
            this.Hide();
            mc.Show();
        }
        // Metod som skriver ut faktura som görs till en pdf 
        private void btnskrivutregister_Click(object sender, EventArgs e)
        {
            string savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filename = "\\Faktura-Register";
            string endpoint = ".pdf";
            Document doc = new Document(iTextSharp.text.PageSize.A4, 10, 10, 60, 60);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(savePath + filename + endpoint, FileMode.Create));
            doc.Open();

            PdfPTable table = new PdfPTable(dgvFakturaRegister.Columns.Count);

            //Add the headers from the DGV to table
            for (int j = 0; j < dgvFakturaRegister.Columns.Count; j++)
            {
                table.AddCell(new Phrase(dgvFakturaRegister.Columns[j].HeaderText));
            }

            //Flag the first row as a header
            table.HeaderRows = 1;

            //Add the actual rows from the DGV to the able
            for (int i = 0; i < dgvFakturaRegister.Rows.Count; i++)
            {
                for (int k = 0; k < dgvFakturaRegister.Columns.Count; k++)
                {
                    if (dgvFakturaRegister[k, i].Value != null)
                    {
                        table.AddCell(new Phrase(dgvFakturaRegister[k, i].Value.ToString()));
                    }
                }         
            }
            doc.Add(table);
            doc.Close();
        }

        private void dgvFakturaRegister_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
