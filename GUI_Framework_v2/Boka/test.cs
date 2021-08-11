using BusinessEntities_FrameWork.Models;
using BusinessLayer_FrameWork;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_Framework_v2.Boka
{
    public partial class test : Form
    {
        public FacadeBusiness FacadeBusiness { get; set; }

        public Bokning Bokning { get; set; }

        public Anställd Anställd { get; set; }

        private DateTime start { get; set; }

        private DateTime slut { get; set; }

        public Logi Logi { get; set; }

        public PreBokning PreBokning { get; set; }

        public List<Logi> TillBokning { get; set; }

        public double RabattGUI { get; set; }

        internal PdfKlass PdfKlass { get; set; }

        public MarknadsChef MarknadsChef { get; set; }

        public test(Anställd a, MarknadsChef m)
        {
            InitializeComponent();
            Anställd = a;
            MarknadsChef = m;
            Bokning = new Bokning();
            Logi = new Logi();
            FacadeBusiness = new FacadeBusiness();
            PreSetComboBox();
            UpdatePrivateCustomerGrid();
            UpdateCamping();
        }

        private string _search;
        private double _pris;
        private string _veckonummer;
        private string _antalpersoner;
        public bool rabattBool;
        public double rabatt;
        public double brutto;
        public double netto;
        public double temptotal;
        private int dagar;
        double rabattexklmoms;

        private void UpdatePrivateCustomerGrid()
        {
            dataGridView4.DataSource = null;
            dataGridView4.DataSource = FacadeBusiness.FacadePrivatKund.GetAllPKunder();
            dataGridView4.AutoSize = false;
        }

        private void UpdateCamping()
        {
            //lägg till camping i DB
        }

        private void PreSetComboBox()
        {
            comboBox1.Items.Add("Liten");
            comboBox1.Items.Add("Stor");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Search != null)
            {
                if (FacadeBusiness.FacadePrivatKund.SearchPrivatKund(Search).ToList() != null)
                {
                    dataGridView4.DataSource = null;
                    dataGridView4.DataSource = FacadeBusiness.FacadePrivatKund.SearchPrivatKund(Search).ToList();
                }
                else
                    UpdatePrivateCustomerGrid();
            }
            else
                MessageBox.Show("Det finns ingen sökterm");
        }

        private string Search
        {
            get { return _search; }
            set { _search = value; }
        }

        public double Pris
        {
            get { return _pris; }
            set { _pris = value; }
        }

        public string Veckonummer
        {
            get { return _veckonummer; }
            set { _veckonummer = value; }
        }

        public string AntalPersoner
        {
            get { return _antalpersoner; }
            set { _antalpersoner = value; }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Search = textBox3.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //fixa så man kommer till camping när man går tillbaka från lägg till ny kund
            LäggTillKundPrivat lk = new LäggTillKundPrivat(null, Anställd);
            this.Hide();
            lk.Show();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int testveckoNummer;
            if (textBox2.Text != null && int.TryParse(textBox2.Text, out testveckoNummer))
            {
                _veckonummer = textBox2.Text;
            }
            else
            {
                MessageBox.Show("Fel input i textrutan", "Error");
                textBox2.Text = "";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int testAntalPersoner;
            if (textBox1.Text != null && int.TryParse(textBox1.Text, out testAntalPersoner))
            {
                _antalpersoner = textBox1.Text;
            }
            else
            {
                MessageBox.Show("Fel input i textrutan", "Error");
                textBox1.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Logi> SökLedig = new List<Logi>();
            // Sök
            if (comboBox1.SelectedItem.Equals("Alla"))
            {
                gvFreeLogi.DataSource = null;
                gvFreeLogi.DataSource = FacadeBusiness.FacadeLogi.GetAllLedigaLägenheter(); ;

            }
            else if (comboBox1.SelectedItem.Equals("Stor"))
            {
                gvFreeLogi.DataSource = null;
                gvFreeLogi.DataSource = FacadeBusiness.FacadeLogi.GetTillgängligStor();
            }
            else if (comboBox1.SelectedItem.Equals("Liten"))
            {
                gvFreeLogi.DataSource = null;
                gvFreeLogi.DataSource = FacadeBusiness.FacadeLogi.GetTillgängligLiten();
            }
            else
            {
                MessageBox.Show("Du har inte valt något alternativ");
            }
        }

        private void getlogi()
        {
            Logi = FacadeBusiness.FacadeLogi.HämtaLogi(comboBox1.Text);
        }

        private void TotalPris()
        {
            PrivatKund pk = (PrivatKund)dataGridView4.CurrentRow.DataBoundItem;
            rabattBool = FacadeBusiness.FacadePrivatKund.KontrolleraRabatt(pk);

            if (rabattBool == true)
            {
                TaFramNetto();
                tbMoms.Text = "12%";
                TaFramRabatt();
                UppdateraRabattGUI();
            }
            else
            {
                TaFramNetto();
                tbMoms.Text = "12%";
                TaFramBrutto();
                tbRabatt.Text = "Ingen Rabatt";
            }

            if (checkBox1.Checked == true)
            {
                if (rabattBool == true)
                {
                    rabatt = rabatt + 300;
                    tbtotalpris.Text = rabatt.ToString();
                    tbavbeställningsskydd.Text = "300";
                }
                else
                {
                    brutto = brutto + 300;
                    tbtotalpris.Text = brutto.ToString();
                    tbavbeställningsskydd.Text = "300";
                }
            }
        }

        private void TaFramBrutto()
        {
            tbtotalpris.Text = brutto.ToString();
        }

        private void TaFramNetto()
        {
            tbExklMoms.Text = temptotal.ToString();
        }

        private void TaFramRabatt()
        {
            tbtotalpris.Text = rabatt.ToString();
        }

        private void UppdateraRabattGUI()
        {
            double rPris = brutto * 0.08;
            tbRabatt.Text = rPris.ToString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tbMoms_TextChanged(object sender, EventArgs e)
        {

        }

        private void skapaPreBokning()
        {
            PrivatKund pk = (PrivatKund)dataGridView4.CurrentRow.DataBoundItem;
            rabattBool = FacadeBusiness.FacadePrivatKund.KontrolleraRabatt(pk);
            int d = 7;
            int e = 5;
            int f = 2;

            if (checkBoxVecka.Checked == true)
            {
                dagar = d;
            }
            if (checkBoxHelg.Checked == true)
            {
                dagar = e;
            }
            if (checkBoxDagar.Checked == true)
            {
                dagar = f;
            }
            if (rabattBool == false)
            {
                PreBokning.InCheckningsDatum = DateTime.Now;
                PreBokning.UtCheckningsDatum = DateTime.Now.AddDays(dagar);
                PreBokning.BokningsTyp = (string)comboBox1.SelectedItem;
                PreBokning.BokningsPris = brutto;
                PreBokning.Moms = 0.2;
                PreBokning.Bruttopris = brutto;
                PreBokning.Nettopris = netto;
                PreBokning.Status = false;
                PreBokning.PrivatKund = pk;
                PreBokning.FöretagsKund = null;
            }
            else
            {
                PreBokning.InCheckningsDatum = DateTime.Now;
                PreBokning.UtCheckningsDatum = DateTime.Now.AddDays(dagar);
                PreBokning.BokningsTyp = (string)comboBox1.SelectedItem;
                PreBokning.BokningsPris = rabatt;
                PreBokning.Moms = 0.2;
                PreBokning.Bruttopris = rabatt;
                PreBokning.Nettopris = rabattexklmoms;
                PreBokning.Status = false;
                PreBokning.PrivatKund = pk;
                PreBokning.FöretagsKund = null;
            }
        }

        private void btnTaBort_Click(object sender, EventArgs e)
        {
            if (dataGridView3.CurrentRow != null)
            {
                Logi l = (Logi)dataGridView3.CurrentRow.DataBoundItem;

                tbtotalpris.Text = temptotal.ToString();
                TillBokning.Remove(l);
                TillBokningGUI(l);
            }
            else
                MessageBox.Show("Du har inte valt rad!", "Error");
        }

        private void TillBokningGUI(Logi l)
        {
            PrivatKund pk = (PrivatKund)dataGridView3.CurrentRow.DataBoundItem;
            rabattBool = FacadeBusiness.FacadePrivatKund.KontrolleraRabatt(pk);
            if (rabattBool == false)
            {
                if (TillBokning.Count == 0)
                {
                    dataGridView3.DataSource = null;
                    dataGridView3.DataSource = TillBokning;
                    brutto = 0;
                    netto = 0;
                    temptotal = 0;
                    rabatt = 0;
                    tbExklMoms.Text = temptotal.ToString();
                    tbtotalpris.Text = brutto.ToString();
                }
                else
                {
                    temptotal = temptotal - l.LogiPris;
                    brutto = temptotal * 1.12;

                    dataGridView3.DataSource = null;
                    dataGridView3.DataSource = TillBokning;

                    tbExklMoms.Text = rabattexklmoms.ToString();
                    tbtotalpris.Text = brutto.ToString();
                }
            }
            else
            {
                if (TillBokning.Count == 0)
                {
                    dataGridView3.DataSource = null;
                    dataGridView3.DataSource = TillBokning;
                    brutto = 0;
                    netto = 0;
                    temptotal = 0;
                    rabatt = 0;
                    tbExklMoms.Text = brutto.ToString();
                    tbtotalpris.Text = temptotal.ToString();
                }
                else
                {
                    temptotal = temptotal - l.LogiPris;
                    brutto = temptotal * 1.12;
                    brutto = brutto * 0.92;

                    dataGridView3.DataSource = null;
                    dataGridView3.DataSource = TillBokning;

                    tbExklMoms.Text = temptotal.ToString();
                    tbtotalpris.Text = brutto.ToString();
                    UppdateraRabattGUI();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Faktura faktura = null;
            start = DateTime.Now;
            slut = start.AddMonths(1);
            PrivatKund pk = (PrivatKund)dataGridView4.CurrentRow.DataBoundItem;
            PrivatKund temp = FacadeBusiness.FacadePrivatKund.HämtaPrivatKund(pk.PrivatKundID);
            rabattBool = FacadeBusiness.FacadePrivatKund.KontrolleraRabatt(pk);
            // Kontrollerar kostnaden
            if (temptotal < 12000)
            {
                BokningTillFaktura();
                if (rabattBool == false)
                {
                    faktura = FacadeBusiness.FacadeFaktura.BokningFakturaPrivat(brutto, "Bokning", Bokning, pk, start, slut);
                    skapaBokningsBekräftelse(Bokning.InCheckningsDatum, Bokning.UtCheckningsDatum, brutto, Bokning, pk, rabattBool);
                }
                else if (rabattBool == true)
                {
                    faktura = FacadeBusiness.FacadeFaktura.BokningFakturaPrivat(rabatt, "Bokning", Bokning, pk, start, slut);
                    skapaBokningsBekräftelse(Bokning.InCheckningsDatum, Bokning.UtCheckningsDatum, rabatt, Bokning, pk, rabattBool);
                }
                PdfKlass.FakturaUtskriftPrivat(faktura, pk, null, null, 0, null);
                MessageBox.Show("Bokning skapad");

            }
            else if (temptotal >= 12000)
            {
                double tillBetalning = double.Parse(tbtotalpris.Text);
                skapaPreBokning();
                FacadeBusiness.FacadePreBokning.BokningPrivatPre(tillBetalning, "PreBokning", PreBokning, pk.PrivatKundID, start, slut);
                MessageBox.Show("Bokning för granskning skapad");
            }
        }

        private void BokningTillFaktura()
        {
            int d = 7;
            int e = 5;
            int f = 2;
            int år = int.Parse(textBox4.Text);
            int vecka = int.Parse(textBox2.Text);
            DateTime datum = FacadeBusiness.FacadeBokning.veckaDatum(år, vecka);
            PrivatKund pk = (PrivatKund)dataGridView4.CurrentRow.DataBoundItem;
            rabattBool = FacadeBusiness.FacadePrivatKund.KontrolleraRabatt(pk);

            if (checkBoxVecka.Checked == true)
            {
                dagar = d;
                datum = datum.AddDays(6);
            }
            if (checkBoxHelg.Checked == true)
            {
                dagar = e;
            }
            if (checkBoxDagar.Checked == true)
            {
                dagar = f;
                datum = datum.AddDays(4);
            }

            string lägenhetstyp = comboBox1.Text;

            if (rabattBool == false)
            {
                Bokning.InCheckningsDatum = datum;
                Bokning.UtCheckningsDatum = datum.AddDays(dagar);
                Bokning.BokningsTyp = lägenhetstyp;
                Bokning.BokningsPris = brutto;
                Bokning.Moms = 0.12;
                Bokning.Bruttopris = brutto;
                Bokning.Nettopris = temptotal;
                Bokning.Status = false;
                Bokning.PrivatKund = pk;
            }
            else
            {
                Bokning.InCheckningsDatum = datum;
                Bokning.UtCheckningsDatum = datum.AddDays(dagar);
                Bokning.BokningsTyp = lägenhetstyp;
                Bokning.BokningsPris = rabatt;
                Bokning.Moms = 0.12;
                Bokning.Bruttopris = rabatt;
                Bokning.Nettopris = rabattexklmoms;
                Bokning.Status = false;
                Bokning.PrivatKund = pk;
            }
        }

        public void skapaBokningsBekräftelse(DateTime IncheckningsDatum, DateTime UtcheckningsDatum, double brutto, Bokning Bokning, PrivatKund pk, bool boolRabatt)
        {
            PrivatKund privat = (PrivatKund)dataGridView4.CurrentRow.DataBoundItem;

            List<Logi> temp = FacadeBusiness.FacadeLogi.LogiPåBokningsID(Bokning);


            double mängdRabatt;
            double totalPris = brutto;
            int a = 120;
            int b = 570;
            int c = 510;
            int d = 570;
            double logibrutto;

            string savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filename = "\\Bokningsbekräftelse";
            string endpoint = ".pdf";
            Document doc = new Document(iTextSharp.text.PageSize.A4, 10, 10, 40, 40);

            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(savePath + filename + endpoint, FileMode.Create));
            doc.Open();
            PdfContentByte cb = wri.DirectContent;
            cb.BeginText();
            BaseFont font = BaseFont.CreateFont("c:\\windows\\fonts\\calibrib.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

            Paragraph pgraph1 = new Paragraph("Ski-Center ");

            cb.SetFontAndSize(font, 20);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Ski-Center", 300, 700, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Bokningsbekräftelse", 300, 650, 0);

            Paragraph pgraph2 = new Paragraph("Objekt");
            cb.SetFontAndSize(font, 10);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Objekt", 120, 600, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Ankomst", 250, 600, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Avresa", 380, 600, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Pris", 510, 600, 0);

            for (int i = 0; i < temp.Count; i++)
            {
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, temp[i].LogiTyp, a, b, 0);
                b = b - 30;
            }

            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, IncheckningsDatum.ToString(), 250, 570, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, UtcheckningsDatum.AddDays(dagar).ToString(), 380, 570, 0);
            for (int i = 0; i < temp.Count; i++)
            {
                logibrutto = temp[i].LogiPris;
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, logibrutto.ToString(), c, d, 0);
                d = d - 30;
            }

            if (rabattBool == true)
            {
                mängdRabatt = (brutto * 0.08);
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Rabatt:", 120, d - 30, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, mängdRabatt.ToString(), 510, d - 30, 0);
            }
            else if (rabattBool == false)
            {
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Rabatt:", 120, d - 30, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Ingen rabatt", 510, d - 30, 0);

            }
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "TotalPris:", 120, d - 60, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, totalPris.ToString(), 510, d - 60, 0);

            Paragraph pgraph3 = new Paragraph("Footer");
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Kontakta Ski-Center om du har några frågor kring ditt köp", 100, d - 120, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Telefonnummer: 0123-456 789", 100, d - 140, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Hälsningar Ski-Center", 100, d - 160, 0);

            cb.EndText();
            doc.Close();

        }

        private void SkrivaUtFakturaBokningBt_Click(object sender, EventArgs e)
        {
            string savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filename = "\\Faktura-Privat";
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
            PdfPTable table = new PdfPTable(dataGridView3.Columns.Count);
            table.DefaultCell.Padding = 3;
            table.WidthPercentage = 70;
            table.HorizontalAlignment = Element.ALIGN_CENTER;
            table.DefaultCell.BorderWidth = 1;

            //Add the headers from the DGV to table
            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.BOLD);
            for (int j = 0; j < dataGridView3.Columns.Count; j++)
            {
                PdfPCell pCell = new PdfPCell(new Phrase(dataGridView3.Columns[j].HeaderText, text));
                pCell.BackgroundColor = new iTextSharp.text.BaseColor(Color.Yellow);
                table.AddCell(pCell);

            }

            //Flag the first row as a header
            table.HeaderRows = 1;

            //Add the actual rows from the DGV to the table
            iTextSharp.text.Font text2 = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                for (int k = 0; k < dataGridView3.Columns.Count; k++)
                {
                    if (dataGridView3[k, i].Value != null)
                    {
                        PdfPCell pRows = new PdfPCell(new Phrase(dataGridView3[k, i].Value.ToString(), text2));
                        pRows.BackgroundColor = new iTextSharp.text.BaseColor(Color.White);
                        table.AddCell(pRows);
                    }
                }
            }
        }

        private void SkrivaUtBekräftelseBokningPrivatButon_Click(object sender, EventArgs e)
        {
            string savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filename = "\\Bekräftelse till Privat";
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
            PdfPTable table = new PdfPTable(dataGridView3.Columns.Count);
            table.DefaultCell.Padding = 3;
            table.WidthPercentage = 70;
            table.HorizontalAlignment = Element.ALIGN_CENTER;
            table.DefaultCell.BorderWidth = 1;

            //Add the headers from the DGV to table
            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.BOLD);
            for (int j = 0; j < dataGridView3.Columns.Count; j++)
            {
                PdfPCell pCell = new PdfPCell(new Phrase(dataGridView3.Columns[j].HeaderText, text));
                pCell.BackgroundColor = new iTextSharp.text.BaseColor(Color.Yellow);
                table.AddCell(pCell);

            }

            //Flag the first row as a header
            table.HeaderRows = 1;

            //Add the actual rows from the DGV to the table
            iTextSharp.text.Font text2 = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                for (int k = 0; k < dataGridView3.Columns.Count; k++)
                {
                    if (dataGridView3[k, i].Value != null)
                    {
                        PdfPCell pRows = new PdfPCell(new Phrase(dataGridView3[k, i].Value.ToString(), text2));
                        pRows.BackgroundColor = new iTextSharp.text.BaseColor(Color.White);
                        table.AddCell(pRows);
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmBokning a = new frmBokning(Anställd, MarknadsChef, null);
            this.Hide();
            a.Show();
        }
    }
}
