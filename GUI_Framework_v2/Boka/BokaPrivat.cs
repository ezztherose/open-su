using BusinessEntities_FrameWork.Models;
using BusinessLayer_FrameWork;
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
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace GUI_Framework_v2
{
    public partial class BokaPrivat : Form
    {

        public FacadeBusiness FacadeBusiness = new FacadeBusiness();
        public Anställd Anställd = new Anställd();
        public Bokning Bokning { get; set; }
        private DateTime start { get; set; }
        private DateTime slut { get; set; }
        private PreBokning PreBokning { get; set; }
        public Logi Logi { get; set; }
        public List<Logi> TillBokning { get; set; }
        public double RabattGUI { get; set; }
        internal PdfKlass PdfKlass { get; set; }
        private string _search;
        private string _veckonummer;
        private string _antalPersoner;
        private double _pris;
        private string logityp;
        private string vecka;
        private int dagar;
        public double temptotal;
        private string _år;
        public double brutto;
        public double rabatt;
        double rabattexklmoms;
        public double netto;
        public bool rabattBool;

        public MarknadsChef MarknadsChef = null;

        public BokaPrivat(Anställd a, MarknadsChef m)
        {
            InitializeComponent();
            PreBokning = new PreBokning();
            Bokning = new Bokning();
            FacadeBusiness = new FacadeBusiness();
            Anställd = a;
            MarknadsChef = m;
            TillBokning = new List<Logi>();
            RabattGUI = new double();
            PdfKlass = new PdfKlass();
            PreSetComboBox();
            UpdatePrivatKund();
        }

        private void BokaPrivat_Load(object sender, EventArgs e)
        {

        }

        private void UpdatePrivatKund()
        {
            gvPrivatKund.DataSource = null;
            gvPrivatKund.DataSource = FacadeBusiness.FacadePrivatKund.GetAllPKunder();
            gvPrivatKund.AutoSize = false;
            HidePrivatKunfColums();
        }

        private void HidePrivatKunfColums()
        {
            gvPrivatKund.Columns["PrivatKundID"].Visible = false;
            gvPrivatKund.Columns["PrivatGatuadress"].Visible = false;
            gvPrivatKund.Columns["PrivatPostnummer"].Visible = false;
            gvPrivatKund.Columns["PrivatPostOrt"].Visible = false;
        }

        private void tillbakaknapp_Click(object sender, EventArgs e)
        {
            if (Anställd != null && MarknadsChef == null)
            {
                frmBokning a_s = new frmBokning(Anställd, MarknadsChef, null);
                this.Hide();
                a_s.Show();
            }
            else if (Anställd == null && MarknadsChef != null)
            {
                frmMarknadsmeny a = new frmMarknadsmeny(null, MarknadsChef);
                this.Hide();
                a.Show();
            }
        }

        private void PreSetComboBox()
        {
            comboBoxLägenhetstyp.Items.Add("Liten");
            comboBoxLägenhetstyp.Items.Add("Stor");
        }

        private void btnSökLgh_Click(object sender, EventArgs e)
        {
            List<Logi> SökLedig = new List<Logi>();
            // Sök
            if (comboBoxLägenhetstyp.SelectedItem.Equals("Alla"))
            {
                gvLedigaAlt.DataSource = null;
                gvLedigaAlt.DataSource = FacadeBusiness.FacadeLogi.GetAllLedigaLägenheter(); ;

            }
            else if (comboBoxLägenhetstyp.SelectedItem.Equals("Stor"))
            {
                gvLedigaAlt.DataSource = null;
                gvLedigaAlt.DataSource = FacadeBusiness.FacadeLogi.GetTillgängligStor();
            }
            else if (comboBoxLägenhetstyp.SelectedItem.Equals("Liten"))
            {
                gvLedigaAlt.DataSource = null;
                gvLedigaAlt.DataSource = FacadeBusiness.FacadeLogi.GetTillgängligLiten();
            }
            else
            {
                MessageBox.Show("Du har inte valt något alternativ");
            }
        }

        private void btnBoka_Click(object sender, EventArgs e)
        {
            Faktura faktura = null;
            start = DateTime.Now;
            slut = start.AddMonths(1);
            PrivatKund pk = (PrivatKund)gvPrivatKund.CurrentRow.DataBoundItem;
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
                //PdfKlass.FakturaUtskriftPrivat(faktura, pk, null, null, 0, null);
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

        /// <summary>
        /// SKapar preBokning och lägger till den i PreBokning-tabell
        /// </summary>
        private void skapaPreBokning()
        {
            PrivatKund pk = (PrivatKund)gvPrivatKund.CurrentRow.DataBoundItem;
            rabattBool = FacadeBusiness.FacadePrivatKund.KontrolleraRabatt(pk);
            int d = 7;
            int e = 5;
            int f = 2;

            if (checkBoxVecka.Checked == true) dagar = d;
            if (checkBoxHelg.Checked == true) dagar = e;
            if (checkBoxDagar.Checked == true) dagar = f;
            if (rabattBool == false)
            {
                PreBokning.InCheckningsDatum = DateTime.Now;
                PreBokning.UtCheckningsDatum = DateTime.Now.AddDays(dagar);
                PreBokning.BokningsTyp = (string)comboBoxLägenhetstyp.SelectedItem;
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
                PreBokning.BokningsTyp = (string)comboBoxLägenhetstyp.SelectedItem;
                PreBokning.BokningsPris = rabatt;
                PreBokning.Moms = 0.2;
                PreBokning.Bruttopris = rabatt;
                PreBokning.Nettopris = rabattexklmoms;
                PreBokning.Status = false;
                PreBokning.PrivatKund = pk;
                PreBokning.FöretagsKund = null;
            }
        }

        /// <summary>
        /// SKapar bokning och lägger till den i bokning-tabell
        /// </summary>
        private void BokningTillFaktura()
        {
            int d = 7;
            int e = 5;
            int f = 2;
            int år = int.Parse(tbår.Text);
            int vecka = int.Parse(tbveckonummer.Text);
            DateTime datum = FacadeBusiness.FacadeBokning.veckaDatum(år, vecka);
            PrivatKund pk = (PrivatKund)gvPrivatKund.CurrentRow.DataBoundItem;
            rabattBool = FacadeBusiness.FacadePrivatKund.KontrolleraRabatt(pk);

            if (checkBoxVecka.Checked == true)
            {
                dagar = d;
                datum = datum.AddDays(6);
            }
            if (checkBoxHelg.Checked == true) dagar = e;
            if (checkBoxDagar.Checked == true)
            { 
                dagar = f;
                datum = datum.AddDays(4);
            }

            string lägenhetstyp = comboBoxLägenhetstyp.Text;
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
            PrivatKund privat = (PrivatKund)gvPrivatKund.CurrentRow.DataBoundItem;
            List<Logi> temp = FacadeBusiness.FacadeLogi.LogiPåBokningsID(Bokning);
            double mängdRabatt;
            double totalPris = brutto;
            int a = 120;
            int b = 570;
            int c = 510;
            int d = 570;
            double logibrutto;

            string savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filename = ("\\Bokningsbekräftelse-{0}" + privat.PrivatFörnamn + Bokning.BokningsID);
            string endpoint = ".pdf";
            Document doc = new Document(iTextSharp.text.PageSize.A4, 10, 10, 40, 40);

            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(savePath + filename + endpoint, FileMode.Create, FileAccess.ReadWrite));
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

        private void tbår_TextChanged(object sender, EventArgs e)
        {
            int testÅr;
            if (tbår.Text != null && int.TryParse(tbår.Text, out testÅr))
                _år = tbår.Text;
            else
            {
                MessageBox.Show("Error", "Error");
                tbår.Text = "";
            }
        }

        private void tbveckonummer_TextChanged(object sender, EventArgs e)
        {
            int testveckoNummer;
            if (tbveckonummer.Text != null && int.TryParse(tbveckonummer.Text, out testveckoNummer))
                _veckonummer = tbveckonummer.Text;
            else
            {
                MessageBox.Show("Fel input i textrutan", "Error");
                tbveckonummer.Text = "";
            }

        }

        private void tbantalpersoner_TextChanged(object sender, EventArgs e)
        {
            int testAntalPersoner;
            if (tbantalpersoner.Text != null && int.TryParse(tbantalpersoner.Text, out testAntalPersoner))
                _antalPersoner = tbantalpersoner.Text;
            else
            {
                MessageBox.Show("Fel input i textrutan", "Error");
                tbantalpersoner.Text = "";
            }
        }

        public double Pris
        {
            get { return _pris; }
            set { _pris = value; }
        }

        private void getlogi()
        {
            Logi = FacadeBusiness.FacadeLogi.HämtaLogi(comboBoxLägenhetstyp.Text);
        }

        private void TotalPris()
        {
            PrivatKund pk = (PrivatKund)gvPrivatKund.CurrentRow.DataBoundItem;
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

            if (btavbeställningsskydd.Checked == true)
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

        private void HämtaPrisUthyrning(string logityp, int dagar, int vecka)
        {
            Pris = FacadeBusiness.FacadeLogiPris.GetLogiPris(logityp, dagar, vecka);
            Logi.LogiPris = Pris;
            temptotal = temptotal + Pris;

            netto = temptotal;
            brutto = temptotal * 1.12;
            rabatt = brutto * 0.92;
            rabattexklmoms = temptotal * 0.92;
        }

        private void tbExklMoms_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbtotalpris_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTaBort_Click(object sender, EventArgs e)
        {
            if (gvBokning.CurrentRow != null)
            {
                Logi l = (Logi)gvBokning.CurrentRow.DataBoundItem;

                tbtotalpris.Text = temptotal.ToString();
                TillBokning.Remove(l);
                TillBokningGUI(l);
            }
            else
                MessageBox.Show("Du har inte valt rad!", "Error");
        }

        private void TillBokningGUI(Logi l)
        {
            PrivatKund pk = (PrivatKund)gvPrivatKund.CurrentRow.DataBoundItem;
            rabattBool = FacadeBusiness.FacadePrivatKund.KontrolleraRabatt(pk);
            if (rabattBool == false)
                if (TillBokning.Count == 0)
                {
                    gvBokning.DataSource = null;
                    gvBokning.DataSource = TillBokning;
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

                    gvBokning.DataSource = null;
                    gvBokning.DataSource = TillBokning;

                    tbExklMoms.Text = rabattexklmoms.ToString();
                    tbtotalpris.Text = brutto.ToString();
                }
            else
                if (TillBokning.Count == 0)
                {
                    gvBokning.DataSource = null;
                    gvBokning.DataSource = TillBokning;
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

                    gvBokning.DataSource = null;
                    gvBokning.DataSource = TillBokning;

                    tbExklMoms.Text = temptotal.ToString();
                    tbtotalpris.Text = brutto.ToString();
                    UppdateraRabattGUI();
                }
        }

        private void btnNyKund_Click(object sender, EventArgs e)
        {
            LäggTillKundPrivat lk = new LäggTillKundPrivat(null, Anställd);
            this.Hide();
            lk.Show();
        }

        private void btnVäljKund_Click_1(object sender, EventArgs e)
        {
            if (gvPrivatKund.CurrentRow != null && gvLedigaAlt.CurrentRow != null)
            {
                // Dagar
                if (!checkBoxVecka.Checked && !checkBoxDagar.Checked && !checkBoxHelg.Checked)
                {
                    MessageBox.Show("Du har inte valt antal dagar för bokning");
                }

                // val av kund
                if (!checkBoxVecka.Checked && !checkBoxDagar.Checked && !checkBoxHelg.Checked)
                {
                    MessageBox.Show("Du har inte valt antal dagar för bokning");
                }
                if (comboBoxLägenhetstyp.SelectedItem != null && tbveckonummer.Text != null && tbår != null && checkBoxVecka.Checked || checkBoxDagar.Checked || checkBoxHelg.Checked)
                {
                    getlogi();
                    int a = 7;
                    int b = 5;
                    int c = 2;

                    logityp = (string)comboBoxLägenhetstyp.SelectedItem;
                    vecka = tbveckonummer.Text;
                    if (checkBoxVecka.Checked == true) dagar = a;
                    if (checkBoxDagar.Checked == true) dagar = b;
                    if (checkBoxHelg.Checked == true) dagar = c;

                    TillBokning.Add(Logi);
                    gvBokning.DataSource = null;
                    gvBokning.DataSource = TillBokning;
                    Bokning.LogiTillBokning.Add(Logi);
                    PreBokning.LogiTillBokning.Add(Logi);
                    HämtaPrisUthyrning(logityp, dagar, Convert.ToInt32(vecka));
                    TotalPris();
                }
            }
        }

        private void btnSökKund_Click(object sender, EventArgs e)
        {
            if (Search != null)
            {
                if (FacadeBusiness.FacadePrivatKund.SearchPrivatKund(Search).ToList() != null)
                {
                    gvPrivatKund.DataSource = null;
                    gvPrivatKund.DataSource = FacadeBusiness.FacadePrivatKund.SearchPrivatKund(Search).ToList();
                }
                else
                    UpdateGridViewprivatkund();
            }
            else
                MessageBox.Show("Det finns ingen sökterm");
        }

        private void UpdateGridViewprivatkund()
        {
            gvPrivatKund.DataSource = null;
            gvPrivatKund.DataSource = FacadeBusiness.FacadePrivatKund.GetAllPKunder().ToList();
        }

        private void tbSökKund_TextChanged(object sender, EventArgs e)
        {
            Search = tbSökKund.Text;
        }
        public string Search
        {
            get { return _search; }
            set { _search = value; }
        }

        private void comboBoxLägenhetstyp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (btavbeställningsskydd.Checked)
                AddProtection();
            else if (!btavbeställningsskydd.Checked) 
                SubtractProtection();

        }

        private void AddProtection()
        {
            // Lägger till skyddpriset på totalen med moms
            // Total + skydd 
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
            MessageBox.Show("Checked", "", MessageBoxButtons.OK);
        }

        private void SubtractProtection()
        {
            // Ta bort priset på totalen med mom
            // Total - skydd
            if (rabattBool == true)
            {
                rabatt = rabatt - 300;
                tbtotalpris.Text = rabatt.ToString();
                tbavbeställningsskydd.Text = "";
            }
            else
            {
                brutto = brutto - 300;
                tbtotalpris.Text = brutto.ToString();
                tbavbeställningsskydd.Text = "";
            }
            MessageBox.Show("Unchecked", "", MessageBoxButtons.OK);
        }

        private void tbRabatt_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUppdatera_Click(object sender, EventArgs e)
        {
            UppdateraKundPrivat p = new UppdateraKundPrivat(null, Anställd);
            this.Hide();
            p.Show();
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
            PdfPTable table = new PdfPTable(gvBokning.Columns.Count);
            table.DefaultCell.Padding = 3;
            table.WidthPercentage = 70;
            table.HorizontalAlignment = Element.ALIGN_CENTER;
            table.DefaultCell.BorderWidth = 1;

            //Add the headers from the DGV to table
            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.BOLD);
            for (int j = 0; j < gvBokning.Columns.Count; j++)
            {
                PdfPCell pCell = new PdfPCell(new Phrase(gvBokning.Columns[j].HeaderText, text));
                pCell.BackgroundColor = new iTextSharp.text.BaseColor(Color.Yellow);
                table.AddCell(pCell);

            }

            //Flag the first row as a header
            table.HeaderRows = 1;

            //Add the actual rows from the DGV to the table
            iTextSharp.text.Font text2 = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
            for (int i = 0; i < gvBokning.Rows.Count; i++)
            {
                for (int k = 0; k < gvBokning.Columns.Count; k++)
                {
                    if (gvBokning[k, i].Value != null)
                    {
                        PdfPCell pRows = new PdfPCell(new Phrase(gvBokning[k, i].Value.ToString(), text2));
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
            PdfPTable table = new PdfPTable(gvBokning.Columns.Count);
            table.DefaultCell.Padding = 3;
            table.WidthPercentage = 70;
            table.HorizontalAlignment = Element.ALIGN_CENTER;
            table.DefaultCell.BorderWidth = 1;

            //Add the headers from the DGV to table
            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.BOLD);
            for (int j = 0; j < gvBokning.Columns.Count; j++)
            {
                PdfPCell pCell = new PdfPCell(new Phrase(gvBokning.Columns[j].HeaderText, text));
                pCell.BackgroundColor = new iTextSharp.text.BaseColor(Color.Yellow);
                table.AddCell(pCell);

            }

            //Flag the first row as a header
            table.HeaderRows = 1;

            //Add the actual rows from the DGV to the table
            iTextSharp.text.Font text2 = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
            for (int i = 0; i < gvBokning.Rows.Count; i++)
            {
                for (int k = 0; k < gvBokning.Columns.Count; k++)
                {
                    if (gvBokning[k, i].Value != null)
                    {
                        PdfPCell pRows = new PdfPCell(new Phrase(gvBokning[k, i].Value.ToString(), text2));
                        pRows.BackgroundColor = new iTextSharp.text.BaseColor(Color.White);
                        table.AddCell(pRows);
                    }
                }
            }
        }

        private void gvLedigaAlt_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBoxVecka_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
        
    
