using BusinessEntities_FrameWork.Models;
using BusinessLayer_FrameWork;
using GUI_Framework_v2.Skidskola;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GUI_Framework_v2
{
    public partial class frmSkidlärare : Form
    {
        public Anställd Anställd { get; set; }
        public FacadeBusiness FacadeBusiness { get; set; }
        public Gruppskidlektion Gruppskidlektion { get; set; }
        internal List<SkidskolaKlass> Gruppdeltagare { get; set; }
        internal SkidskolaKlass SkidskolaKlass { get; set; }
        public List<Gruppskidlektion> Grupplektioner { get; set; }
        public List<Deltagare> DeltagareGrupp { get; set; }
        public Privatskidlektion Privatskidlektion { get; set; }
        internal List<privatskidskolaklass> GruppDeltagarePrivat { get; set; }
        private Privatskidlektion privatID;

        public string Färg { get; set; }
        public int Dagar { get; set; }
        public frmSkidlärare(Anställd a)
        {
            GruppDeltagarePrivat = new List<privatskidskolaklass>();
            InitializeComponent();
            Anställd = a;
            FacadeBusiness = new FacadeBusiness();
            Gruppskidlektion = new Gruppskidlektion();
            Privatskidlektion = new Privatskidlektion();
            Gruppdeltagare = new List<SkidskolaKlass>();
            SkidskolaKlass = new SkidskolaKlass();
            Grupplektioner = new List<Gruppskidlektion>();
            DeltagareGrupp = new List<Deltagare>();
            privatID = new Privatskidlektion();
            skapaLista();
            PreSetComboBox();
            Hämtaprivatlektioner();
        }

        private void skapaLista()
        {
            List<Gruppskidlektion> lista = FacadeBusiness.FacadeGruppskidlektion.GetAllGrupplektioner();
            List<SkidskolaKlass> temp = new List<SkidskolaKlass>();
            Gruppdeltagare.AddRange(temp);
        }

        private void PreSetComboBox()
        {
            comboBox1.Items.Add("Grön");
            comboBox1.Items.Add("Blå");
            comboBox1.Items.Add("Röd");
            comboBox1.Items.Add("Svart");
            cbDagar.Items.Add(3);
            cbDagar.Items.Add(5);
            btVälj.Hide();
            btnskrivutlärare.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnskrivutlärare_Click(object sender, EventArgs e)
        {
           
            string savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filename = $"\\Skidlärare {comboBox1.Text} {cbDagar.Text}";
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
            paragraph.Add("Grupplektion");
            doc.Add(paragraph);

            //Creating iTextSharp Table from the DataTable data
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable table = new PdfPTable(gvgrupplektioner.Columns.Count);

            //Add the headers from the DGV to table
            for (int j = 0; j < gvgrupplektioner.Columns.Count; j++)
            {
                table.AddCell(new Phrase(gvgrupplektioner.Columns[j].HeaderText));
            }

            //Flag the first row as a header
            table.HeaderRows = 1;

            //Add the actual rows from the DGV to the table
            for (int i = 0; i < gvgrupplektioner.Rows.Count; i++)
                for (int k = 0; k < gvgrupplektioner.Columns.Count; k++)
                    if (gvgrupplektioner[k, i].Value != null) table.AddCell(new Phrase(gvgrupplektioner[k, i].Value.ToString()));

            doc.Add(table);
            MessageBox.Show("Utskrift klar");
            doc.Close();
            btnskrivutlärare.Hide();
        }

        private void gvskidlärare_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnTillbaka_Click(object sender, EventArgs e)
        {
            frmLogin_2 logg = new frmLogin_2();
            this.Hide();
            logg.Show();
        }

        private void btSök_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null && cbDagar.SelectedItem == null)
                MessageBox.Show("Du måste välja färg och antal dagar", "Error", MessageBoxButtons.OK);

            else if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Du måste välja färg", "Error", MessageBoxButtons.OK);
                return;
            }
            else if(cbDagar.SelectedItem == null)
            {
                MessageBox.Show("Du måste välja antal dagar", "Error", MessageBoxButtons.OK);
                return;
            }
            else
            {
                Färg = comboBox1.Text;
                Dagar = int.Parse(cbDagar.Text);
                SearchForLesson();
                btVälj.Show();
            }
        }

        private void SearchForLesson()
        {
            if (comboBox1.SelectedItem.Equals(Färg) && cbDagar.SelectedItem.Equals(Dagar))
            {
                Grupplektioner.Clear();
                Grupplektioner = FacadeBusiness.FacadeGruppskidlektion.SearchGruppskidlektion(Färg, Dagar);
                gvgrupplektioner.DataSource = null;
                gvgrupplektioner.DataSource = Grupplektioner;
            }
            else
                MessageBox.Show("Fel i sökningen", "Error", MessageBoxButtons.OK);
        }

        private void Hämtaprivatlektioner()
        {
            gvPrivatlektioner.DataSource = null;
            gvPrivatlektioner.DataSource = FacadeBusiness.FacadePrivatLektion.HämtaAllPrivatLektioner();
        }

        // används inte -- ta bort?
        private void HämtaGruppDeltagare() 
        {
            Gruppskidlektion gs = (Gruppskidlektion)gvgrupplektioner.CurrentRow.DataBoundItem;
            List<Deltagare> deltagares = FacadeBusiness.FacadeDeltagare.HämtaDeltagarePåId(gs.GruppskidlektionsID);

            for (int i = 0; i < deltagares.Count; i++)
            {
                //Gruppdeltagare.Add(new Gruppskidlektion()
                //{
                //    //GruppDeltagare = (string)Gruppdeltagare[i].Deltagare,
                //    //Lärare = Anställd.AnställdFörnamn + " " + Anställd.AnställdEfternamn,
                //    //Tid = gs.Tid,
                //});
            }
            gvgrupplektioner.DataSource = null;
            gvgrupplektioner.DataSource = GruppDeltagarePrivat;
        }

        private void HämtaPrivatDeltagare()
        {
            Privatskidlektion pl = (Privatskidlektion)gvPrivatlektioner.CurrentRow.DataBoundItem;
            List<Deltagare> deltagares = FacadeBusiness.FacadeDeltagare.HämtaDeltagarePåId(pl.PrivatskidlektionsID);
            privatID = pl;
            for (int i = 0; i < deltagares.Count; i++)
            {
                GruppDeltagarePrivat.Add(new privatskidskolaklass()
                {
                    Deltagare = (string)deltagares[i].DeltagarFörnamn,
                    Lärare = Anställd.AnställdFörnamn + " " + Anställd.AnställdEfternamn,
                    Tid = pl.Tid,
                }) ;
            }
            gvPrivatlektioner.DataSource = null;
            gvPrivatlektioner.DataSource = GruppDeltagarePrivat;
        }

        private void btSökPrivat_Click(object sender, EventArgs e)
        {
            if (gvPrivatlektioner.Rows.Count > 0) 
                HämtaPrivatDeltagare();
            else
                MessageBox.Show("Du har inte valt någon lektion \neller så finns det inga lektioner att välja.", "Tom sökning", MessageBoxButtons.OK);
        }

        private void btSkrivUtPrivat_Click(object sender, EventArgs e)
        {
            gvPrivatlektioner.DataSource = null;
            gvPrivatlektioner.DataSource = GruppDeltagarePrivat;
            if (gvPrivatlektioner.DataSource == GruppDeltagarePrivat)
            {
                string savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string filename = $"\\Skidlärare {privatID.PrivatskidlektionsID}";
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
                paragraph.Add("Privatlektion");
                doc.Add(paragraph);

                //Creating iTextSharp Table from the DataTable data
                BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
                PdfPTable table = new PdfPTable(gvPrivatlektioner.Columns.Count);

                //Add the headers from the DGV to table

                for (int j = 0; j < gvPrivatlektioner.Columns.Count; j++)
                {
                    table.AddCell(new Phrase(gvPrivatlektioner.Columns[j].HeaderText));
                }

                //Flag the first row as a header
                table.HeaderRows = 1;

                //Add the actual rows from the DGV to the table
                for (int i = 0; i < gvPrivatlektioner.Rows.Count; i++)
                {
                    for (int k = 0; k < gvPrivatlektioner.Columns.Count; k++)
                    {
                        if (gvPrivatlektioner[k, i].Value != null)
                        {
                            table.AddCell(new Phrase(gvPrivatlektioner[k, i].Value.ToString()));
                        }
                    }
                }
                doc.Add(table);
                MessageBox.Show("Utskrift klar");
                doc.Close();
            }
            else
                MessageBox.Show("Ingen lektion vald");
        }

        private void btVälj_Click(object sender, EventArgs e)
        {
            if (gvgrupplektioner.CurrentRow != null)
            {
                Gruppskidlektion gl = (Gruppskidlektion)gvgrupplektioner.CurrentRow.DataBoundItem;
                List<Deltagare> deltagarelista = FacadeBusiness.FacadeGruppskidlektion.GetDeltagare(gl.GruppskidlektionsID);
                Gruppdeltagare.Clear();
                for (int i = 0; i < deltagarelista.Count; i++)
                {
                    Gruppdeltagare.Add(new SkidskolaKlass()
                    {
                        Deltagare = (string)deltagarelista[i].DeltagarFörnamn,
                        Anställd = Anställd.AnställdFörnamn + " " + Anställd.AnställdEfternamn,
                        Färg = comboBox1.Text
                    });
                }
                gvgrupplektioner.DataSource = null;
                gvgrupplektioner.DataSource = Gruppdeltagare;
                btnskrivutlärare.Show();
                btVälj.Hide();
            }
            else
                MessageBox.Show("Finns inga deltagare", "Error", MessageBoxButtons.OK);
        }

        private void btTillbakaPrivat_Click(object sender, EventArgs e)
        {
            if (Anställd != null)
            {
                frmLogin_2 li = new frmLogin_2();
                this.Hide();
                li.Show();
            }
        }

        private void gvPrivatlektioner_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = "";
            cbDagar.SelectedItem = "";
            gvgrupplektioner.DataSource = null;
            Grupplektioner.Clear();
            Gruppdeltagare.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GruppDeltagarePrivat.Clear();
            Hämtaprivatlektioner();
        }
    }
}