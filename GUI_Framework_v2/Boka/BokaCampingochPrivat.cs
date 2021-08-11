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
    public partial class BokaCampingochPrivat : Form
    {
        public FacadeBusiness FacadeBusiness { get; set; }

        public Anställd Anställd { get; set; }

        public Bokning Bokning { get; set; }

        public Logi Logi { get; set; }

        public List<Logi> TillBokning { get; set; }
        public List<Logi> Campinglista { get; set; }

        public MarknadsChef MarknadsChef { get; set; }

        private DateTime start { get; set; }
        private DateTime slut { get; set; }
        private PreBokning PreBokning { get; set; }
        public double RabattGUI { get; set; }
        internal PdfKlass PdfKlass { get; set; }

        private string _search;
        private double _pris;
        private string logityp;
        private string vecka;
        private int dagar;

        public bool rabattBool;

        // ---- Nya variabler för att räkna ut priset
        // RÖR EJ!!!!
        private double _brutto;
        private double _netto;
        private double _rabatt;
        // ---------------------------------------

        public BokaCampingochPrivat(Anställd a, MarknadsChef m)
        {
            InitializeComponent();
            Anställd = a;
            FacadeBusiness = new FacadeBusiness();
            PreBokning = new PreBokning();
            Bokning = new Bokning();
            Anställd = a;
            MarknadsChef = m;
            TillBokning = new List<Logi>();
            Campinglista = new List<Logi>();
            RabattGUI = new double();
            PdfKlass = new PdfKlass();
            HideGroupBox();
            PreSetComboBox();
            UpdatePrivatKund();
        }

        #region Fylla i GUI
        private void tbkund_TextChanged(object sender, EventArgs e)
        {
            Search = tbkund.Text;
        }

        private void HideGroupBox()
        {
            groupBox2.Visible = false;
            groupBox13.Visible = false;
        }

        private void UpdatePrivatKund()
        {
            dgkund.DataSource = null;
            dgkund.DataSource = FacadeBusiness.FacadePrivatKund.GetAllPKunder();
            dgkund.AutoSize = false;
            HidePrivatKunfColums();
        }

        private void HidePrivatKunfColums()
        {
            dgkund.Columns["PrivatKundID"].Visible = false;
            dgkund.Columns["PrivatGatuadress"].Visible = false;
            dgkund.Columns["PrivatPostnummer"].Visible = false;
            dgkund.Columns["PrivatPostOrt"].Visible = false;
        }

        private void PreSetComboBox()
        {
            cbtypav.Items.Add("Liten");
            cbtypav.Items.Add("Stor");
            cbtypav.Items.Add("Camping");
        }
        #endregion

        private void btsöktid_Click(object sender, EventArgs e)
        {
            //söker efter kunder
            if (Search != null)
            {
                if (FacadeBusiness.FacadePrivatKund.SearchPrivatKund(Search).ToList() != null)
                {
                    dgkund.DataSource = null;
                    dgkund.DataSource = FacadeBusiness.FacadePrivatKund.SearchPrivatKund(Search).ToList();
                }
                else
                    UpdateGridViewprivatkund();
            }
            else
                MessageBox.Show("Det finns ingen sökterm");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LäggTillKundPrivat lk = new LäggTillKundPrivat(MarknadsChef, Anställd);
            this.Hide();
            lk.Show();
        }

        private void UpdateGridViewprivatkund()
        {
            dgkund.DataSource = null;
            dgkund.DataSource = FacadeBusiness.FacadePrivatKund.GetAllPKunder().ToList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbtypav_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbtypav.SelectedItem == "Camping")
            {
                groupBox13.Visible = false;
                groupBox2.Visible = true;
            }

            else if (cbtypav.SelectedItem != "Camping")
            {
                groupBox13.Visible = true;
                groupBox2.Visible = false;
            }

            else if (cbtypav.SelectedItem == null)
            {
                groupBox13.Visible = false;
                groupBox2.Visible = false;
            }
        }

        private void tbantalpers_TextChanged(object sender, EventArgs e)
        {

        }

        private void btsök_Click(object sender, EventArgs e)
        {
            List<Logi> SökLedig = new List<Logi>();
            // Söker efter valda tiderna
            if (cbtypav.SelectedItem.Equals("Alla"))
            {
                dglogi.DataSource = null;
                dglogi.DataSource = FacadeBusiness.FacadeLogi.GetAllLedigaLägenheter();
            }
            else if (cbtypav.SelectedItem.Equals("Stor"))
            {
                dglogi.DataSource = null;
                dglogi.DataSource = FacadeBusiness.FacadeLogi.GetTillgängligStor();
            }
            else if (cbtypav.SelectedItem.Equals("Liten"))
            {
                dglogi.DataSource = null;
                dglogi.DataSource = FacadeBusiness.FacadeLogi.GetTillgängligLiten();
            }
            else if (cbtypav.SelectedItem.Equals("Camping"))
            {
                dglogi.DataSource = null;
                dglogi.DataSource = FacadeBusiness.FacadeLogi.GetAllCamping();
            }
            else
                MessageBox.Show("Du har inte valt något alternativ");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                AddProtection();
            else if (!checkBox1.Checked)
                SubtractProtection();
        }

        private void AddProtection()
        {
            // Lägger till skyddpriset på totalen med moms
            // Total + skydd 
            if (rabattBool == true)
            {
                _rabatt = _rabatt + 300;
                tbtotalpris.Text = _rabatt.ToString();
                tbavbeställningsskydd.Text = "300";
            }
            else
            {
                _brutto = _brutto + 300;
                tbtotalpris.Text = _brutto.ToString();
                tbavbeställningsskydd.Text = "300";
            }
        }

        private void SubtractProtection()
        {
            // Ta bort priset på totalen med mom
            // Total - skydd
            if (rabattBool == true)
            {
                _rabatt = _rabatt - 300;
                tbtotalpris.Text = _rabatt.ToString();
                tbavbeställningsskydd.Text = "";
            }
            else
            {
                _brutto = _brutto - 300;
                tbtotalpris.Text = _brutto.ToString();
                tbavbeställningsskydd.Text = "";
            }

            if (TillBokning.Count <= 0)
            {
                _rabatt = 0;
                _brutto = 0;
                tbtotalpris.Text = _brutto.ToString();
                tbtotalpris.Text = _rabatt.ToString();
            }
        }

        private void bttabort_Click(object sender, EventArgs e)
        {
            // tar bort de som ligger i bokningen ifall man skulle ångra sig eller lägga in fel
            if (dgsumbok.CurrentRow != null)
            {
                Logi l = new Logi();
                l = (Logi)dgsumbok.CurrentRow.DataBoundItem;
                tbtotalpris.Text = _brutto.ToString();
                TillBokning.Remove(l);
                Bokning.LogiTillBokning.Remove(l);
                CheckPrice();
            }
            else
                MessageBox.Show("Du har inte valt rad!", "Error");
        }

        private void CheckPrice()
        {
            PrivatKund pk = (PrivatKund)dgkund.CurrentRow.DataBoundItem;
            rabattBool = FacadeBusiness.FacadePrivatKund.KontrolleraRabatt(pk);

            if (TillBokning.Count == 0)
            {
                dgsumbok.DataSource = null;
                dgsumbok.DataSource = TillBokning;
                _brutto = 0;
                _netto = 0;
                _rabatt = 0;
                tbExklMoms.Text = _netto.ToString();
                tbtotalpris.Text = _brutto.ToString();
                if (checkBox1.Checked)
                    AddProtection();
            }

            if (rabattBool == false)
            {
                CalculatePrice();
                dgsumbok.DataSource = null;
                dgsumbok.DataSource = TillBokning;
                if (checkBox1.Checked) _brutto += 300;
                tbExklMoms.Text = _netto.ToString();
                tbtotalpris.Text = _brutto.ToString();
            }
            else if (rabattBool == true)
            {
                CalculatePrice();
                PrivatKund temp = new PrivatKund();
                if (dgkund.CurrentRow != null)
                    temp = (PrivatKund)dgkund.CurrentRow.DataBoundItem;
                double discount = ConvertDiscount(temp.Rabatt);
                CountDiscount(pk);
                dgsumbok.DataSource = null;
                dgsumbok.DataSource = TillBokning;
                if (checkBox1.Checked) _rabatt += 300;
                tbExklMoms.Text = _netto.ToString();
                tbtotalpris.Text = _rabatt.ToString();
                UppdateraRabattGUI(temp);
            }
        }

        private void CalculatePrice()
        {
            _brutto = 0;
            _netto = 0;
            _rabatt = 0;

            for (int i = 0; i < TillBokning.Count; i++)
                _netto += TillBokning[i].LogiPris;

            _brutto = _netto;
            _brutto *= 1.12;
            _rabatt = _brutto;
        }

   

        private void tbExklMoms_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbMoms_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbRabatt_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbavbeställningsskydd_TextChanged(object sender, EventArgs e)
        {

        }


        private void bttillbaka_Click(object sender, EventArgs e)
        {
            if (Anställd != null && MarknadsChef == null)
            {
                frmBokning a_s = new frmBokning(Anställd, MarknadsChef, null);
                this.Hide();
                a_s.Show();
            }
            else if (Anställd == null && MarknadsChef != null)
            {
                frmBokning a = new frmBokning(null, MarknadsChef, null);
                this.Hide();
                a.Show();
            }
        }

        private void btboka_Click(object sender, EventArgs e)
        {
            Faktura faktura = null;
            start = DateTime.Now;
            slut = start.AddMonths(1);
            PrivatKund pk = (PrivatKund)dgkund.CurrentRow.DataBoundItem;
            PrivatKund temp = FacadeBusiness.FacadePrivatKund.HämtaPrivatKund(pk.PrivatKundID);
            rabattBool = FacadeBusiness.FacadePrivatKund.KontrolleraRabatt(pk);
            // Kontrollerar kostnaden
            if (_brutto < 12000)
            {
                BokningTillFaktura();
                if (rabattBool == false)
                {
                    faktura = FacadeBusiness.FacadeFaktura.BokningFakturaPrivat(_brutto, "Bokning", Bokning, pk, start, slut);
                }
                else if (rabattBool == true)
                {
                    faktura = FacadeBusiness.FacadeFaktura.BokningFakturaPrivat(_rabatt, "Bokning", Bokning, pk, start, slut);
                }
                MessageBox.Show("Bokning skapad");
                ClearAfterBooking();
                
            }
            else if (_brutto >= 12000)
            {
                double tillBetalning = double.Parse(tbtotalpris.Text);
                skapaPreBokning();
                FacadeBusiness.FacadePreBokning.BokningPrivatPre(tillBetalning, "PreBokning", PreBokning, pk.PrivatKundID, start, slut);
                MessageBox.Show("Bokning för granskning skapad");
                ClearAfterBooking();
            }

            
        }

        private void ClearAfterBooking()
        {
            //rensar text och gridviews efter registrering
            _rabatt = 0;
            _brutto = 0;
            _netto = 0;
            
            
            dglogi.DataSource = null;
            dgsumbok.DataSource = null;
            cbtypav.SelectedIndex = -1;
            textBox1.Text = "";
            textBox2.Text = "";
            tbantalpers.Text = "";
            tbExklMoms.Text = "";
            tbMoms.Text = "";
            tbRabatt.Text = "";
            tbtotalpris.Text = "";
            tbavbeställningsskydd.Text = "";
            checkBox1.Checked = false;
            TillBokning.Clear();
            Bokning = null;
            Bokning = new Bokning();
        }

        private void skapaPreBokning()
        {
            PrivatKund pk = (PrivatKund)dgkund.CurrentRow.DataBoundItem;
            rabattBool = FacadeBusiness.FacadePrivatKund.KontrolleraRabatt(pk);
            int d = 7;
            int e = 5;
            int f = 2;

            //Alternativ på hur många dagar man vill boka, ovan är för Logi, nedan för camping
            int g = 1;
            int h = 7;

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
            if (checkBox2vecka.Checked == true)
            {
                dagar = h;
            }
            if (checkBox4.Checked == true)
            {
                dagar = h;
            }
            if (rabattBool == false)
            {
                PreBokning.InCheckningsDatum = DateTime.Now;
                PreBokning.UtCheckningsDatum = DateTime.Now.AddDays(dagar);
                PreBokning.BokningsTyp = (string)cbtypav.SelectedItem;
                PreBokning.BokningsPris = _brutto;
                PreBokning.Bruttopris = _brutto;
                PreBokning.Nettopris = _netto;
                PreBokning.Status = false;
                PreBokning.PrivatKund = pk;
                PreBokning.FöretagsKund = null;
                if (checkBox1.Checked)
                {
                    PreBokning.Avbeställningsskydd = true;
                }
                PreBokning.Moms = (PreBokning.BokningsPris * 0.12);
            }
            else
            {
                PreBokning.InCheckningsDatum = DateTime.Now;
                PreBokning.UtCheckningsDatum = DateTime.Now.AddDays(dagar);
                PreBokning.BokningsTyp = (string)cbtypav.SelectedItem;
                PreBokning.BokningsPris = _rabatt;
                PreBokning.Bruttopris = _rabatt;
                PreBokning.Nettopris = _netto;
                PreBokning.Status = false;
                PreBokning.PrivatKund = pk;
                PreBokning.FöretagsKund = null;
                PreBokning.Rabatt = _rabatt * (pk.Rabatt / 100);
                if (checkBox1.Checked)
                {
                    PreBokning.Avbeställningsskydd = true;
                }
                PreBokning.Moms = (PreBokning.BokningsPris * 0.12);
            }
        }

        private void BokningTillFaktura()
        {
            int d = 7;
            int e = 5;
            int f = 2;
            //Alternativ på hur många dagar man vill boka, ovan är för Logi, nedan för camping
            int g = 1;
            int h = 7;
            int år = int.Parse(textBox1.Text);
            int vecka = int.Parse(textBox2.Text);
            DateTime datum = FacadeBusiness.FacadeBokning.veckaDatum(år, vecka);
            PrivatKund pk = (PrivatKund)dgkund.CurrentRow.DataBoundItem;
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
            if (checkBox2vecka.Checked == true)
            {
                dagar = h;
                datum = datum.AddDays(6);
            }
            if (checkBox4.Checked == true)
            {
                dagar = g;
            }

            string lägenhetstyp = cbtypav.Text;

            if (rabattBool == false)
            {
                Bokning.InCheckningsDatum = datum;
                Bokning.UtCheckningsDatum = datum.AddDays(dagar);
                Bokning.BokningsTyp = lägenhetstyp;
                Bokning.BokningsPris = _brutto;
                Bokning.Bruttopris = _brutto;
                Bokning.Nettopris = _netto;
                Bokning.Status = false;
                Bokning.PrivatKund = pk;

                if (checkBox1.Checked)
                {
                Bokning.Avbeställningsskydd = true;
                
                }
                Bokning.Moms = (Bokning.BokningsPris * 0.12);
            }
            else
            {
                Bokning.InCheckningsDatum = datum;
                Bokning.UtCheckningsDatum = datum.AddDays(dagar);
                Bokning.BokningsTyp = lägenhetstyp;
                Bokning.BokningsPris = _rabatt;
                Bokning.Bruttopris = _rabatt;
                Bokning.Nettopris = _netto;
                Bokning.Status = false;
                Bokning.PrivatKund = pk;
                Bokning.Rabatt = _rabatt * (pk.Rabatt/100);
                if (checkBox1.Checked) Bokning.Avbeställningsskydd = true;
                Bokning.Moms = (Bokning.BokningsPris * 0.12);
            }
        }

        public void skapaBokningsBekräftelse(DateTime IncheckningsDatum, DateTime UtcheckningsDatum, double brutto, Bokning Bokning, PrivatKund pk, bool boolRabatt)
        {
            PrivatKund privat = (PrivatKund)dgkund.CurrentRow.DataBoundItem;
            List<Logi> temp = FacadeBusiness.FacadeLogi.LogiPåBokningsID(Bokning);
            
            double mängdRabatt;
            double totalPris = brutto;
            int a = 120;
            int b = 570;
            int c = 510;
            int d = 570;
            double logibrutto;

            string savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filename = ("\\Bokningsbekräftelse" + privat.PrivatFörnamn + " " + Bokning.BokningsID);
            string endpoint = ".pdf";
            Document doc = new Document(iTextSharp.text.PageSize.A4, 10, 10, 40, 40);

            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(savePath + filename + endpoint, FileMode.Create, FileAccess.ReadWrite));
            doc.Open();
            PdfContentByte cb = wri.DirectContent;
            cb.BeginText();
            BaseFont font = BaseFont.CreateFont("c:\\windows\\fonts\\calibrib.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

            Paragraph pgraph1 = new Paragraph("Ski-Center ");
            cb.SetFontAndSize(font, 20);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Ski-Center", 300, 750, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Bokningsbekräftelse", 300, 700, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "ID: " + pk.PrivatKundID + " Namn: " + pk.PrivatFörnamn + " " + pk.PrivatEfternamn, 300, 650, 0);


            Paragraph pgraph2 = new Paragraph("Objekt");
            cb.SetFontAndSize(font, 10);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Id", 60, 600, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Objekt", 120, 600, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Ankomst", 250, 600, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Avresa", 380, 600, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Pris", 510, 600, 0);

            for (int i = 0; i < temp.Count; i++)
            {
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, temp[i].LogiID.ToString(), 60, b, 0);
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
            double moms = totalPris * 0.12;

            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Moms:", 120, d - 50, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, moms.ToString(), 510, d - 50, 0);

            if(checkBox1.Checked)
            {
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "AvbeställningSkydd:", 120, d - 70, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "300Kr", 510, d - 70, 0);
            }

            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "TotalPris:", 120, d - 90, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, totalPris.ToString(), 510, d - 90, 0);

            Paragraph pgraph3 = new Paragraph("Footer");
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Kontakta Ski-Center om du har några frågor kring ditt köp", 100, d - 120, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Telefonnummer: 0123-456 789", 100, d - 140, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Hälsningar Ski-Center", 100, d - 160, 0);

            cb.EndText();
            doc.Close();

        }

        private void TotalPris()
        {
            PrivatKund pk = new PrivatKund();
            pk = (PrivatKund)dgkund.CurrentRow.DataBoundItem;
            rabattBool = FacadeBusiness.FacadePrivatKund.KontrolleraRabatt(pk);

            if (rabattBool == true)
            {
                CountDiscount(pk);
                TaFramNetto();
                tbMoms.Text = "12%";
                TaFramRabatt();
                UppdateraRabattGUI(pk);
            }
            else
            {
                TaFramNetto();
                tbMoms.Text = "12%";
                TaFramBrutto();
                tbRabatt.Text = "Ingen Rabatt";
            }
        }

        private void CountDiscount(PrivatKund p)
        {
            double discountTemp = p.Rabatt;
            discountTemp = (100 - discountTemp) / 100;
            _rabatt *= discountTemp;
        }

        private void TaFramBrutto()
        {
            tbtotalpris.Text = _brutto.ToString();
        }

        private void TaFramNetto()
        {
            tbExklMoms.Text = _netto.ToString();
        }

        private void TaFramRabatt()
        {
            tbtotalpris.Text = "HEJ";
            tbtotalpris.Text = _rabatt.ToString();
        }

        private void UppdateraRabattGUI(PrivatKund p)
        {
            double rPris = p.Rabatt;
            tbRabatt.Text = rPris.ToString();
        }

        private void HämtaPrisUthyrning(string logityp, int dagar, int vecka)
        {
            Pris = FacadeBusiness.FacadeLogiPris.GetLogiPris(logityp, dagar, vecka);
            Logi.LogiPris = Pris;
            _netto += Pris;
            CorrectingPrice();
        }

        private void CorrectingPrice()
        {
            _brutto = 0;
            _brutto = _netto;
            _brutto *= 1.12;
            _rabatt = _brutto;
        }

        public double Pris
        {
            get { return _pris; }
            set { _pris = value; }
        }

        private double ConvertDiscount(double toConvert)
        {
            double d = toConvert / 100;
            return d + 1;
        }

        public string Search
        {
            get { return _search; }
            set { _search = value; }
        }

        private void getlogi()
        {
            Logi = FacadeBusiness.FacadeLogi.HämtaLogi(cbtypav.Text);
        }

        private void btvälj_Click(object sender, EventArgs e)
        {
            if (dgkund.CurrentRow != null && dglogi.CurrentRow != null)
            {
                // Dagar
                if (!checkBoxVecka.Checked && !checkBoxDagar.Checked && !checkBoxHelg.Checked && !checkBox4.Checked && !checkBox2vecka.Checked)
                {
                    MessageBox.Show("Du har inte valt antal dagar för bokning");
                }

                // val av kund
                if (!checkBoxVecka.Checked && !checkBoxDagar.Checked && !checkBoxHelg.Checked && !checkBox4.Checked && !checkBox2vecka.Checked)
                {
                    MessageBox.Show("Du har inte valt antal dagar för bokning");
                }
                if (cbtypav.SelectedItem != null && textBox2.Text != null && textBox1 != null && checkBoxVecka.Checked || checkBoxDagar.Checked || checkBoxHelg.Checked || checkBox4.Checked || checkBox2vecka.Checked)
                {
                    getlogi();
                    int a = 7;
                    int b = 5;
                    int c = 2;
                    int veckacamping = 7;
                    int dygncamping = 1;

                    logityp = (string)cbtypav.SelectedItem;
                    vecka = textBox2.Text;
                    if (checkBoxVecka.Checked == true)
                    {
                        dagar = a;
                    }
                    if (checkBoxDagar.Checked == true)
                    {
                        dagar = b;
                    }
                    if (checkBoxHelg.Checked == true)
                    {
                        dagar = c;
                    }
                    if (checkBox2vecka.Checked == true)
                    {
                        dagar = veckacamping;
                    }
                    if (checkBox4.Checked == true)
                    {
                        dagar = dygncamping;
                    }

                    // Tilldelar nya login i listan värden för att kunna hämta pris
                    Logi.LogiTyp = cbtypav.Text;
                    string typish = cbtypav.Text;
                    Logi.LogiTyp = typish;
                    Logi.Dagar = dagar;
                    Logi.Vecka = Convert.ToInt32(vecka);

                    TillBokning.Add(Logi);
                    dgsumbok.DataSource = null;
                    dgsumbok.DataSource = TillBokning;
                    Bokning.LogiTillBokning.Add(Logi);
                    PreBokning.LogiTillBokning.Add(Logi);
                    HämtaPrisUthyrning(logityp, dagar, Convert.ToInt32(vecka));
                    TotalPris();
                }
            }
        }

        private void dgkund_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
  
