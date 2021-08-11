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
using BusinessLayer_FrameWork;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;


namespace GUI_Framework_v2.Boka
{
    public partial class frmKonferens : Form
    {
        public Anställd Anställd = new Anställd();
        public MarknadsChef MarknadsChef = new MarknadsChef();
        private string _veckonummer;
        internal PdfKlass PdfKlass { get; set; }
        public FacadeBusiness FacadeBusiness = new FacadeBusiness();
        public Bokning Bokning { get; set; }
        private DateTime start { get; set; }
        private DateTime slut { get; set; }
        private PreBokning PreBokning { get; set; }
        private string _search;
        public FöretagsKund FöretagsKund { get; set; }
        public Faktura Faktura { get; set; }
        
        internal List<BokaKonferensLogi> BokingList { get; set; }
        internal BokaKonferensLogi bokningLogiKonferens {get;set;}
        public List<Logi> LogiList { get; set; }
        public List<Konferens> KonferensList { get; set; }

        public DateTime datum;
        public bool rabattBool;
        public double temptotal;
        public double brutto;
        public double rabatt;
        public double netto;
        public double rPris;
        private string _antalPersoner;
        private double _pris;
        private string vecka;
        private int dagar;
        private double totprice;
        public DateTime datumFaktura;

        /*
         * NYA PRISVARIABLER
         * -----------------
         * Beskrivning:
         * - _netto: priset innan pålägg av skatt
         * - _brutto: _nettopriset med pålägg av skatten
         * - _rabatt: _brutto med avdrag av företagsrabatten
         * - _decimalDiscount: är decimalforma av företagsrabatten
         */
        private double _netto;
        private double _brutto;
        private double _rabatt;
        private double _decimalDiscount;
        private double _protection = 300;
        private double _moms; 
       

        public frmKonferens(Anställd a, MarknadsChef mc)
        {
            InitializeComponent();
            Faktura = new Faktura();
            PdfKlass = new PdfKlass();
            PreBokning = new PreBokning();
            Bokning = new Bokning();
            FacadeBusiness = new FacadeBusiness();
            BokingList = new List<BokaKonferensLogi>();
            LogiList = new List<Logi>();
            KonferensList = new List<Konferens>();
            
            Anställd = a;
            MarknadsChef = mc;
            UpdateFöretagsKund();
            LaddaKonferensInnehåll();

        }

        private void LaddaKonferensInnehåll()
        {
            label13.Hide();
            label8.Hide();
            label9.Hide();
            comboTimmar.Hide();
            comboVecka.Hide();
            cbDygn.Hide();

            for (int i = 1; i < 24; i++)
                comboTimmar.Items.Add(i);

            for (int i = 1; i < 53; i++)
                comboVecka.Items.Add(i);

            for (int i = 1; i < 7; i++)
                cbDygn.Items.Add(i);

            cbtypav.Items.Add("Stor");
            cbtypav.Items.Add("Liten");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Anställd != null && MarknadsChef == null)
            {
                frmBokning a_s = new frmBokning(Anställd, null, null);
                this.Hide();
                a_s.Show();
            }
            else if (Anställd == null && MarknadsChef != null)
            {
                frmBokning a_s = new frmBokning(null, MarknadsChef, null);
                this.Hide();
                a_s.Show();
            }
        }

        private void cbkonferens_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void tbantalpersoner_TextChanged(object sender, EventArgs e)
        {
            int testVeckoNummer;
            if (tbveckor.Text != null && int.TryParse(tbveckor.Text, out testVeckoNummer)) 
                _veckonummer = tbveckor.Text;
            else
            {
                MessageBox.Show("Fel input i textrutan", "Error");
                tbveckor.Text = "";
            }
        }

        private void btväljk_Click(object sender, EventArgs e)
        {
            BokaKonferensLogi bokningLogiKonferens = new BokaKonferensLogi();

            datum = dateTimePicker1.Value;
            if (dgfkund.CurrentRow != null && dgkonferens.CurrentRow != null)
            {
                GetDatumKonferens();
                Konferens konferens = new Konferens();
                konferens = (Konferens)dgkonferens.CurrentRow.DataBoundItem;
                if (konferens.KonferensTyp == "KonferensLiten") konferensTyp = "KonferensLiten";
                if (konferens.KonferensTyp == "KonferensStor") konferensTyp = "KonferensStor";

                HämtaKonferensPris();
                FöretagsKund = (FöretagsKund)dgfkund.CurrentRow.DataBoundItem;
                if (!checkBox2vecka.Checked && !checkBoxdygn.Checked && !cbTimmar.Checked && comboTimmar.SelectedItem == null && comboVecka.SelectedItem == null && cbDygn.SelectedItem == null)
                {
                    MessageBox.Show("Du har inte valt tid för bokning av konferens");
                }
                vecka = FacadeBusiness.FacadeBokning.GetVecka(datum).ToString();

                konferens.KonferensTyp = konferensTyp;
                konferens.Vecka = int.Parse(vecka);
                konferens.Pris = konferensPris;
                konferens.Start = dateTimePicker1.Value;
                konferens = GetKonferenseDate(konferens);
                KonferensList.Add(konferens);

                // Dispalay i gridview
                bokningLogiKonferens.Typ = konferens.KonferensTyp;
                bokningLogiKonferens.Vecka = vecka;
                bokningLogiKonferens.Pris = konferensPris;
                bokningLogiKonferens.Id = konferens.KonferensID;
                BokingList.Add(bokningLogiKonferens);
            }
            UpdateShoppingList();
            CalculateNetto();
            CalcualteCompanyDiscount(FöretagsKund);
            UpdateEndPrice();
        }

        private Konferens GetKonferenseDate(Konferens k)
        {
            int vecka = 0;
            int timmar = 0;
            int år = DateTime.Now.Year;
            if (comboTimmar.SelectedItem != null) timmar = int.Parse(comboTimmar.SelectedItem.ToString());
            if (comboVecka.SelectedItem != null) vecka = int.Parse(comboVecka.SelectedItem.ToString());

            datum = FacadeBusiness.FacadeBokning.veckaDatum(år, vecka);
            if (checkBox2vecka.Checked == true)
            {
                dagar = 0;
                datum = _fråndatum;
                _tillDatum = _fråndatum.AddDays(antalVeckor * 7);
            }
            if (checkBoxdygn.Checked == true)
            {
                antalDygn = int.Parse(cbDygn.Text);
                datum = _fråndatum;
                _tillDatum = _fråndatum.AddDays(antalDygn);
            }
            if (cbTimmar.Checked == true)
            {
                dagar = 0;
                antalTimmar = int.Parse(comboTimmar.Text);
                _tillDatum = _fråndatum.AddHours(antalTimmar);
            }
            k.Slut = _tillDatum;
            return k;
        }

        private void tbtotalpris_TextChanged(object sender, EventArgs e)
        {
            
        }

        /*
         * Innehåller:
         * - TaBort
         * - Räkna om pris
         * - Reset av BokningList
         * --------------------------------------------
         */
        #region Tabort och räkna om
        private void bttabort_Click(object sender, EventArgs e)
        {
            if (dgsummabok.CurrentRow == null) MessageBox.Show("Ingen vara är vald", "Ingen vara", MessageBoxButtons.OK);
            FöretagsKund tempKund = new FöretagsKund();
            tempKund = (FöretagsKund)dgfkund.CurrentRow.DataBoundItem;
            if (tempKund == null) MessageBox.Show("Kunden är inte vald", "Saknar kund", MessageBoxButtons.OK);
            if (dgsummabok.CurrentRow != null)
            {
                BokaKonferensLogi bkl = new BokaKonferensLogi();
                bkl = (BokaKonferensLogi)dgsummabok.CurrentRow.DataBoundItem;
                if (bkl.Typ == "KonferensStor" || bkl.Typ == "KonferensLiten")
                    for (int i = 0; i < KonferensList.Count; i++)
                        if (bkl.Typ == KonferensList[i].KonferensTyp && bkl.Id == KonferensList[i].KonferensID)
                        {
                            List<Konferens> temp = new List<Konferens>();
                            temp.AddRange(FacadeBusiness.FacadeFöretagsKund.RemoveKonferensFromList(KonferensList, KonferensList[i]));
                            KonferensList.Clear();
                            KonferensList.AddRange(temp);
                            SetPriceList();
                        }

                if (bkl.Typ == "Stor" || bkl.Typ == "Liten")
                    for (int i = 0; i < LogiList.Count; i++)
                        if (bkl.Typ == LogiList[i].LogiTyp && bkl.Id == LogiList[i].LogiID)
                        {
                            List<Logi> temp = new List<Logi>();
                            temp.AddRange(FacadeBusiness.FacadeFöretagsKund.RemoveLogiFromList(LogiList, LogiList[i]));
                            LogiList.Clear();
                            LogiList.AddRange(temp);
                            SetPriceList();
                        }
            }
            SetPriceList();
            UpdateShoppingList();
            SetPrice(tempKund);
            //CheckForProtection();
            UpdateEndPrice();
        }


        private void SetPrice(FöretagsKund f)
        {
            _netto = 0;
            _netto = FacadeBusiness.FacadeFöretagsKund.RecalcualtePrice(LogiList, KonferensList);
            _brutto = FacadeBusiness.FacadeFöretagsKund.GetTaxOnPrice(_netto);
            _decimalDiscount = FacadeBusiness.FacadeFöretagsKund.GetCompanyDiscount(f);
            _rabatt = FacadeBusiness.FacadeFöretagsKund.CalculateDiscount(_brutto, _decimalDiscount);
        }


        #endregion

        /// <summary>
        /// private void SetPriceList()
        /// ---------------------------
        /// Converts konferensList & Logilist to BokaKonferensLogi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetPriceList()
        {
            BokingList.Clear();
            for (int i = 0; i < KonferensList.Count; i++)
            {
                BokaKonferensLogi temp = new BokaKonferensLogi();
                temp.Id = KonferensList[i].KonferensID;
                temp.Typ = KonferensList[i].KonferensTyp;
                temp.Vecka = KonferensList[i].Vecka.ToString();
                temp.Pris = KonferensList[i].Pris;
                BokingList.Add(temp);
            }

            for (int i = 0; i < LogiList.Count; i++)
            {
                BokaKonferensLogi temp = new BokaKonferensLogi();
                temp.Id = LogiList[i].LogiID;
                temp.Typ = LogiList[i].LogiTyp;
                temp.Vecka = LogiList[i].Vecka.ToString();
                temp.Pris = LogiList[i].LogiPris;
                BokingList.Add(temp);
            }
            UpdateShoppingList();
        }

        /// <summary>
        /// CalculateNetto()
        /// ----------------
        /// Recalcualtaes the netto price after adding any new item to price list
        /// </summary>
        private void CalculateNetto()
        {
            _netto = 0;
            _rabatt = 0;
            if (checkBox1.Checked) _rabatt += 300;
            for (int i = 0; i < BokingList.Count; i++)
                _netto += BokingList[i].Pris;
            CalcualteBrutto();
        }

        private void CalcualteBrutto()
        {
            _brutto = 0;
            _brutto = FacadeBusiness.FacadeFöretagsKund.GetTaxOnPrice(_netto);
        }

        private void CalcualteCompanyDiscount(FöretagsKund f)
        {
            _decimalDiscount = 0;
            _decimalDiscount = FacadeBusiness.FacadeFöretagsKund.GetCompanyDiscount(f);
            _rabatt += FacadeBusiness.FacadeFöretagsKund.CalculateDiscount(_brutto, _decimalDiscount);
            
           
            
            //if (checkBox1.Checked)
            //{
            //    _rabatt += 300;
            //    _brutto += 300;
            //}
        }

        #region Innehåller uppdatering av totalprier till GUI
        private void UpdateShoppingList()
        {
            dgsummabok.DataSource = null;
            dgsummabok.DataSource = BokingList;
        }

        private void ClearPriceBoxes()
        {
            // Empty textboxed
            tbExklMoms.Text = "";
            tbMoms.Text = "";
            tbRabatt.Text = "";
            tbtotalpris.Text = "";
        }

        private void UpdateEndPrice()
        {
            double tax;
            ClearPriceBoxes();
            FöretagsKund fk = (FöretagsKund)dgfkund.CurrentRow.DataBoundItem;
            rabattBool = FacadeBusiness.FacadeFöretagsKund.KontrolleraRabatt(fk);
            tax = FacadeBusiness.FacadeFöretagsKund.GetTax(_netto);
            tbMoms.Text = tax.ToString();
            tbExklMoms.Text = _netto.ToString();
            tbRabatt.Text = _rabatt.ToString();
            if (rabattBool == false && !checkBox1.Checked)
            {
            tbtotalpris.Text = _brutto.ToString();
            }
            else if (rabattBool == true && checkBox1.Checked)
            {
                tbtotalpris.Text = _rabatt.ToString();

            }
           


        }
        #endregion

        private void btnSökkonferen_Click(object sender, EventArgs e)
        {
            if (cbkonferens.SelectedItem != null)
            {
                List<Konferens> SökLedig = new List<Konferens>();
                if (cbkonferens.SelectedItem.Equals("Alla"))
                {
                    dgkonferens.DataSource = null;
                    dgkonferens.DataSource = FacadeBusiness.FacadeKonferens.GetAllKonferens();
                }
                else if (cbkonferens.SelectedItem.Equals("Stor"))
                {
                    dgkonferens.DataSource = null;
                    dgkonferens.DataSource = FacadeBusiness.FacadeKonferens.GetKonferensStor();
                }
                else if (cbkonferens.SelectedItem.Equals("Liten"))
                {
                    dgkonferens.DataSource = null;
                    dgkonferens.DataSource = FacadeBusiness.FacadeKonferens.GetKonferensLiten();
                }
            }
            else
                MessageBox.Show("Du har inte valt något alternativ");
        }

        private void ClearAfterBooking()
        {
            //rensar ifylld information efter bokning
            dglogi.DataSource = null;
            dgkonferens.DataSource = null;
            dgsummabok.DataSource = null;
            cbkonferens.Text = "";
            tbtotalpris.Text = "";
            cbDygn.Text = "";
            tbantal.Text = "";
            comboTimmar.SelectedIndex = -1;
            textBox1.Text = "";
            cbtypav.SelectedIndex = -1;
            tbveckor.Text = "";
            tbdeltagare.Text = "";
            checkBox1.Checked = false;
            checkBox2vecka.Checked = false;
            checkBoxDagar.Checked = false;
            checkBoxdygn.Checked = false;
            checkBoxHelg.Checked = false;
            checkBoxVecka.Checked = false;
            tbExklMoms.Text = "";
            tbMoms.Text = "";
            tbRabatt.Text = "";
            tbtotalpris.Text = "";
            tbavbeställningsskydd.Text = "";
            textBox1.Text = "";
        }

        private void btboka_Click(object sender, EventArgs e)
        {
            if (KonferensList == null)
                MessageBox.Show("Det finns inga val", "Tom lista", MessageBoxButtons.OK);
            else
            {
                MakeBoking();
                BokingList.Clear();
            }
                
        }

        private void MakeBoking()
        {
            start = DateTime.Now;
            slut = start.AddMonths(1);
            FöretagsKund fk = (FöretagsKund)dgfkund.CurrentRow.DataBoundItem;
            FöretagsKund temp = FacadeBusiness.FacadeFöretagsKund.HämtaFöretagsKund(fk.FöretagKundID);
            rabattBool = FacadeBusiness.FacadeFöretagsKund.KontrolleraRabatt(fk);
            MoveLogiToBoking();
            MoveKonfToBoking();
            // Kontrollerar kostnaden
            if (_netto < fk.Kreditgräns)
            {
                BokningTillFaktura();
                if (rabattBool == false)
                {
                    FacadeBusiness.FacadeFaktura.BokningFakturaFöretag(_brutto, "Bokning", Bokning, fk, start, slut);
                    MessageBox.Show("Bokning skapad");
                    ClearAfterBooking();
                }
                else if (rabattBool == true)
                {
                    FacadeBusiness.FacadeFaktura.BokningFakturaFöretag(_rabatt, "Bokning", Bokning, fk, start, slut);
                    MessageBox.Show("Bokning skapad");
                    ClearAfterBooking();
                }
            }
            else if (_netto >= fk.Kreditgräns)
            {
                double tillBetalning = 0;
                if (tbtotalpris.Text != "") tillBetalning = double.Parse(tbtotalpris.Text);
                if (tbRabatt.Text != "" && tbtotalpris.Text == "") tillBetalning = double.Parse(tbRabatt.Text);
                PreBokning tempPre = skapaPreBokning();
                MoveItemsToPreList(tempPre);
                FacadeBusiness.FacadePreBokning.BokningFöretagPre(tillBetalning, "PreBokning", tempPre, fk.FöretagKundID, start, slut);
                MessageBox.Show("Bokning för granskning skapad");
                ClearAfterBooking();
                FacadeBusiness.FacadePreBokning.SparaPreBokning();
            }
        }



        private void MoveItemsToPreList(PreBokning pre)
        {
            if (LogiList.Count > 0 && LogiList != null)
                for (int i = 0; i < LogiList.Count; i++)
                    pre.LogiTillBokning.Add(LogiList[i]);
            if (KonferensList.Count > 0 && KonferensList != null)
                for (int i = 0; i < KonferensList.Count; i++)
                    pre.KonferensTillBokning.Add(KonferensList[i]);
        }


        private void MoveLogiToBoking()
        {
            if (LogiList.Count > 0 && LogiList != null)
                for (int i = 0; i < LogiList.Count; i++)
                    Bokning.LogiTillBokning.Add(LogiList[i]);
        }

        private void MoveKonfToBoking()
        {
            if (KonferensList.Count > 0 && KonferensList != null)
                for (int i = 0; i < KonferensList.Count; i++)
                    Bokning.Konferenser.Add(KonferensList[i]);
        }

        public string Search
        {
            get { return _search; }
            set { _search = value; }
        }
        public double Pris
        {
            get { return _pris; }
            set { _pris = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Search != null)
            {
                if (FacadeBusiness.FacadeFöretagsKund.SearchFöretagsKund(Search).ToList() != null)
                {
                    dgfkund.DataSource = null;
                    dgfkund.DataSource = FacadeBusiness.FacadeFöretagsKund.SearchFöretagsKund(Search).ToList();
                }
               else
                  UpdateFöretagsKund();
            }
            else
                MessageBox.Show("Det finns ingen sökterm");
        }

        private void UpdateFöretagsKund()
        {
            dgfkund.DataSource = null;
            dgfkund.DataSource = FacadeBusiness.FacadeFöretagsKund.GetAllFöretagKunder();
            dgfkund.AutoSize = false;
        }

        private void dgkonferens_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private PreBokning skapaPreBokning()
        {
            // Variabler för logi
            int d = 7;
            int e = 5;
            int f = 2;

            // Variabler för konferens
            int konferensVal = 0;

            // Kontroll för logi
            if (checkBoxVecka.Checked == true) dagar = d;
            if (checkBoxHelg.Checked == true) dagar = f;
            if (checkBoxDagar.Checked == true) dagar = e;

            // kontroll för konferens
            if (comboVecka.SelectedItem != null) konferensVal = int.Parse(comboVecka.SelectedItem.ToString());
            if (comboTimmar.SelectedItem != null) konferensVal = int.Parse(comboTimmar.SelectedItem.ToString());
            if (cbDygn.SelectedItem != null) konferensVal = int.Parse(cbDygn.SelectedItem.ToString());

            FöretagsKund fk = new FöretagsKund();
            fk = (FöretagsKund)dgfkund.CurrentRow.DataBoundItem;
            PreBokning temp = new PreBokning();
            temp.InCheckningsDatum = DateTime.Now;
            temp.UtCheckningsDatum = DateTime.Now.AddDays(dagar);
            
            _moms = _netto * 0.12;
            temp.Bruttopris = _brutto;
            temp.Nettopris = _netto;
            temp.Status = false;
            temp.FöretagsKund = fk;
            temp.PrivatKund = null;
            temp.BokningsTyp = "PreBokning";
            if (fk.FöretagRabatt > 0)
            {
                temp.BokningsPris = _rabatt;
                temp.Rabatt = temp.BokningsPris * (fk.FöretagRabatt / 100);
            }
            else if (fk.FöretagRabatt == 0)
            {
                temp.BokningsPris = _brutto;
            }
            if (checkBox1.Checked)
            {
                temp.Avbeställningsskydd = true;
            }

            temp.Moms = (temp.BokningsPris * 0.12);
            return temp;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            LäggTillKundFöretag a = new LäggTillKundFöretag(null, Anställd);
            this.Hide();
            a.Show();
        }

        private void dglogi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public DateTime _fråndatum;
        private int _veckaKonferens;
        private int antalTimmar;
        private int antalDygn;
        private int antalVeckor;
        private string konferensTyp;
        private string tidTyp;
        private double konferensPris;
        private double tempPris;
        public DateTime _tillDatum;

        private void button3_Click(object sender, EventArgs e)
        {
            start = DateTime.Now;
            slut = DateTime.Now.AddMonths(1);
            Bokning b = new Bokning();
            FöretagsKund fk = (FöretagsKund)dgfkund.CurrentRow.DataBoundItem;
            if (fk != null)
            {
                FacadeBusiness.FacadeBokning.BokaKonferens(_fråndatum, _tillDatum, konferensTyp, konferensPris, fk, b);
               // remove tax calculation, enter netto price
                Faktura faktura = FacadeBusiness.FacadeFaktura.FakturaKonferens((konferensPris), "Konferens", b, fk, start, slut);
                Faktura = faktura;
                MessageBox.Show("Ångrat bokning");
            }
        }

        private void tbantal_TextChanged(object sender, EventArgs e)
        {
            int testAntalPersoner;
            if (tbantal.Text != null && int.TryParse(tbantal.Text, out testAntalPersoner)) _antalPersoner = tbantal.Text;
        }

        private void BokningTillFaktura()
        {
            int d = 7;
            int e = 5;
            int f = 2;
            //Alternativ på hur många dagar man vill boka, ovan är för konferens, nedan för logi
            int g = 1;
            int h = 7;
            int i = 5;

            int vecka = 0;
            int timmar = 0;
            int år = 0;

            år = DateTime.Now.Year;

            if (comboTimmar.SelectedItem != null) timmar = int.Parse(comboTimmar.SelectedItem.ToString());
            if (comboVecka.SelectedItem != null) vecka = int.Parse(comboVecka.SelectedItem.ToString());

            if (tbveckor.Text == null || tbveckor.Text.Equals(""))
            {
                GetDatumKonferens();
                vecka = _veckaKonferens;
                // Kolla över så att den väljer rätt vecka från dtpLogi
                //if (LogiList.Count > 0)
                //{
                //    år = dtpLogi.Value.Year;
                //}
                //else
                år = dateTimePicker1.Value.Year;
                DateTime datumFaktura = FacadeBusiness.FacadeBokning.veckaDatum(år, vecka);
            }
            else if(tbveckor.Text != null || tbveckor.Text.Equals(""))
            {
                vecka = int.Parse(tbveckor.Text);
                år = DateTime.Now.Year;
                DateTime datumFaktura = FacadeBusiness.FacadeBokning.veckaDatum(år, vecka);
            }
            FöretagsKund fk = (FöretagsKund)dgfkund.CurrentRow.DataBoundItem;
            rabattBool = FacadeBusiness.FacadeFöretagsKund.KontrolleraRabatt(fk);

            if (checkBox2vecka.Checked == true)
            {
                dagar = 0;
                datum = _fråndatum;
                _tillDatum = _fråndatum.AddDays(antalVeckor * 7);
            }
            if (checkBoxdygn.Checked == true)
            {
                antalDygn = int.Parse(cbDygn.Text);
                datum = _fråndatum;
                _tillDatum = _fråndatum.AddDays(antalDygn);
            }
            if (cbTimmar.Checked == true)
            {
                dagar = 0;
                antalTimmar = int.Parse(comboTimmar.Text);
                _tillDatum = _fråndatum.AddHours(antalTimmar);
            }
            // första för konferens andra för logi
            if (checkBoxVecka.Checked == true)
            {
                dagar = h;
                 datum = FacadeBusiness.FacadeBokning.veckaDatum(år, vecka);
                _tillDatum = datum.AddDays(dagar);
            }
            if (checkBoxDagar.Checked ==true)
            {
                 datum = FacadeBusiness.FacadeBokning.veckaDatum(år, vecka);
                dagar = g;
                _tillDatum = datum.AddDays(dagar);
            }
            if (checkBoxHelg.Checked == true)
            {
                datum = FacadeBusiness.FacadeBokning.veckaDatum(år, vecka);
                dagar = i;
                _tillDatum = datum.AddDays(dagar);
            }

            string lägenhetstyp = cbtypav.Text;

            if (rabattBool == false)
            {
                Bokning.InCheckningsDatum = datum;
                Bokning.UtCheckningsDatum = _tillDatum;
                Bokning.BokningsTyp = lägenhetstyp;
                Bokning.BokningsPris = _brutto;
                Bokning.Bruttopris = _brutto;
                Bokning.Nettopris = _netto;
                Bokning.Status = false;
                Bokning.FöretagsKund = fk;
                Bokning.BokningsTyp = "Bokning";
                if (checkBox1.Checked)
                {
                    Bokning.Avbeställningsskydd = true;
                    Bokning.BokningsPris += 300;
                }
                Bokning.Moms = (Bokning.BokningsPris * 0.12);
            }
            else
            {
                Bokning.InCheckningsDatum = datum;
                Bokning.UtCheckningsDatum = datum.AddDays(dagar);
                Bokning.BokningsTyp = lägenhetstyp;
                Bokning.BokningsPris = _rabatt;
                Bokning.Bruttopris = _brutto;
                Bokning.Nettopris = _netto;
                Bokning.Status = false;
                Bokning.FöretagsKund = fk;
                Bokning.Rabatt = _rabatt * (fk.FöretagRabatt / 100);
                if (checkBox1.Checked)
                {
                    Bokning.Avbeställningsskydd = true;
                    Bokning.BokningsPris += 300;
                }
                Bokning.Moms = (Bokning.BokningsPris * 0.12);
                Bokning.BokningsTyp = "Bokning";
            }
        }
        

        private void button3_Click_1(object sender, EventArgs e)
        {
         
        }

        public void BokningsBekräftelseFöretag(Bokning bokning)
        {

            List<Logi> temp = FacadeBusiness.FacadeLogi.LogiPåBokningsID(Bokning);
            List<Konferens> konferens = FacadeBusiness.FacadeKonferens.KonferensPåBokningsID(Bokning);
            double totalPris = brutto;

            int a = 120;
            int b = 570;
            int c = 510;
            int d = 570;

            string savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filename = ("\\Bokningsbekräftelse-Företag " + Bokning.FöretagsKund.Företagsnamn + " " + Bokning.BokningsID) ;
            string endpoint = ".pdf";
            Document doc = new Document(iTextSharp.text.PageSize.A4, 10, 10, 40, 40);

            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(savePath + filename + endpoint, FileMode.Create));
            doc.Open();
            PdfContentByte cb = wri.DirectContent;
            cb.BeginText();
            BaseFont font = BaseFont.CreateFont("c:\\windows\\fonts\\calibrib.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

            Paragraph pgraph1 = new Paragraph("Ski-Center ");

            //VÄNSTER = KOLUMN Y, HÖGER = RAD X. (Y,X)

            cb.SetFontAndSize(font, 20);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Ski-Center", 300, 700, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Bokningsbekräftelse", 300, 650, 0);

            Paragraph pgraph2 = new Paragraph("Objekt");
            cb.SetFontAndSize(font, 10);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Objekt", 120, 600, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Ankomst", 250, 600, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Avresa", 380, 600, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Pris", 510, 600, 0);

            if (temp != null)
            {
                for (int i = 0; i < temp.Count; i++)
                {
                    cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, temp[i].LogiTyp, a, b, 0);
                    b = b - 30;
                }
            }
            if (konferens != null)
            {
                for (int i = 0; i < konferens.Count; i++)
                {
                    cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, konferens[i].KonferensTyp, a, b, 0);
                    b = b - 30;
                }
            }
          

            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, Bokning.InCheckningsDatum.ToString(), 250, 570, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, Bokning.UtCheckningsDatum.AddDays(dagar).ToString(), 380, 570, 0);
            for (int i = 0; i < temp.Count; i++)
            {
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, temp[i].LogiPris.ToString(), c, d, 0);
                d = d - 30;
            }

            double moms = totalPris * 0.12;

            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Moms:", 120, d - 50, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, moms.ToString(), 510, d - 50, 0);

            if (checkBox1.Checked)
            {
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "AvbeställningSkydd:", 120, d - 70, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "300Kr", 510, d - 70, 0);
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

        private void cbtypav_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Search = textBox1.Text;
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            List<Logi> SökLedig = new List<Logi>();
            if (cbtypav.SelectedItem != null)
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
            else
                    MessageBox.Show("Du har inte valt något alternativ");

        }

        private void checkBox2vecka_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2vecka.Checked)
            {
                cbTimmar.Checked = false;
                checkBoxdygn.Checked = false;
                comboVecka.Show();
                label8.Show();
                label13.Hide();
                label9.Hide();
                comboTimmar.Hide();
                cbDygn.Hide();
                cbDygn.SelectedIndex = -1;
                comboTimmar.SelectedIndex = -1;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxdygn.Checked)
            {
                cbTimmar.Checked = false;
                checkBox2vecka.Checked = false;
                comboVecka.Hide();
                label8.Hide();
                label13.Hide();
                label9.Show();
                comboTimmar.Hide();
                cbDygn.Show();
                comboVecka.SelectedIndex = -1;
                comboTimmar.SelectedIndex = -1;
            }
        }

        private void cbTimmar_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTimmar.Checked)
            {
                checkBoxdygn.Checked = false;
                checkBox2vecka.Checked = false;
                comboVecka.Hide();
                label8.Hide();
                label13.Show();
                label9.Hide();
                comboTimmar.Show();
                cbDygn.Hide();
                cbDygn.SelectedIndex = -1;
                comboTimmar.SelectedIndex = -1;
            }
        }

        private void btväljl_Click(object sender, EventArgs e)
        {

            BokaKonferensLogi bokningLogiKonferens = new BokaKonferensLogi();
            if (!checkBoxVecka.Checked && !checkBoxDagar.Checked && !checkBoxHelg.Checked) MessageBox.Show("Du har inte valt antal dagar för bokning");

            if (cbtypav != null && tbveckor.Text != null &&  checkBoxVecka.Checked || checkBoxDagar.Checked || checkBoxHelg.Checked)
            {
                int tempvar = 0;
                string logiType = "";
                int veckaTemp = 0;

                Logi logi = new Logi();
                logi = (Logi)dglogi.CurrentRow.DataBoundItem;
                FöretagsKund = (FöretagsKund)dgfkund.CurrentRow.DataBoundItem;
                // Tar fram rätt dagar
                if (checkBoxVecka.Checked)
                    tempvar = 7;
                else if (checkBoxDagar.Checked)
                    tempvar = 5;
                else if (checkBoxHelg.Checked)
                    tempvar = 2;

                // Tar fram typen
                if (cbtypav.Text == "Stor")
                    logiType = "Stor";
                else if (cbtypav.Text == "Liten")
                    logiType = "Liten";

                veckaTemp = int.Parse(tbveckor.Text);
                double pris = FacadeBusiness.FacadeLogiPris.GetLogiPris(logi.LogiTyp, tempvar, veckaTemp);

                logi.LogiPris = pris;
                logi.LogiTyp = logiType;
                logi.Vecka = veckaTemp;
                logi.Dagar = tempvar;
                LogiList.Add(logi);

                bokningLogiKonferens.Typ = logi.LogiTyp;
                bokningLogiKonferens.Vecka = veckaTemp.ToString();
                bokningLogiKonferens.Pris = pris;
                bokningLogiKonferens.Id = logi.LogiID;
                BokingList.Add(bokningLogiKonferens);
            }
            UpdateShoppingList();
            CalculateNetto();
            CalcualteCompanyDiscount(FöretagsKund);
            UpdateEndPrice();
        }

        public void HämtaKonferensPris()
        {
            int testtid = 1;
            double test;
            tempPris = 0;
            BokaKonferensLogi bokaKonferensLogi = new BokaKonferensLogi();
            //Konferens vecka
            if (cbDygn.SelectedIndex <= -1 && comboVecka.SelectedIndex > -1 && comboTimmar.SelectedIndex <= -1)
            {
                tidTyp = "Vecka";
                antalVeckor = int.Parse(comboVecka.Text);
                tempPris = FacadeBusiness.FacadeKonferens.GetPrisKonferens(konferensTyp, tidTyp, _veckaKonferens);
                while (testtid < antalVeckor)
                {
                    _veckaKonferens++;
                    test = FacadeBusiness.FacadeKonferens.GetPrisKonferens(konferensTyp, tidTyp, _veckaKonferens);
                    tempPris = tempPris + test;
                    testtid++;
                }
                konferensPris = 0;
                konferensPris = tempPris;
            }
            if (cbDygn.SelectedIndex > -1 && comboVecka.SelectedIndex <= -1 && comboTimmar.SelectedIndex <= -1)
            {
                DateTime tempDatum = dateTimePicker1.Value;
                testtid = 1;
                test = 0;
                int tempVecka;
                tidTyp = "Dygn";
                antalDygn = int.Parse(cbDygn.Text);
                tempPris = FacadeBusiness.FacadeKonferens.GetPrisKonferens(konferensTyp, tidTyp, _veckaKonferens);
                while (testtid < antalDygn)
                {
                    tempDatum = tempDatum.AddDays(1);
                    tempVecka = FacadeBusiness.FacadeBokning.GetVecka(tempDatum);
                    test = FacadeBusiness.FacadeKonferens.GetPrisKonferens(konferensTyp, tidTyp, tempVecka);
                    tempPris = tempPris + test;
                    testtid++;
                }
                konferensPris = 0;
                konferensPris = tempPris;
            }
            if (cbDygn.SelectedIndex <= -1 && comboVecka.SelectedIndex <= -1 && comboTimmar.SelectedIndex > -1)
            {
                testtid = 1;
                test = 0;
                int tempVecka;
                DateTime tempDatum = dateTimePicker1.Value;
                antalTimmar = int.Parse(comboTimmar.Text);
                tidTyp = "Tim";
                tempPris = FacadeBusiness.FacadeKonferens.GetPrisKonferens(konferensTyp, tidTyp, _veckaKonferens);
                while (testtid < antalTimmar)
                {
                    tempDatum = tempDatum.AddHours(1);
                    tempVecka = FacadeBusiness.FacadeBokning.GetVecka(tempDatum);
                    test = FacadeBusiness.FacadeKonferens.GetPrisKonferens(konferensTyp, tidTyp, tempVecka);
                    tempPris = tempPris + test;
                    testtid++;
                }
                konferensPris = 0;
                konferensPris = tempPris;
            }
           
        }
        public void GetDatumKonferens()
        {
            _fråndatum = dateTimePicker1.Value;
            _veckaKonferens = FacadeBusiness.FacadeBokning.GetVecka(_fråndatum);
        }

        #region Hantering för avbeställningsskydd

        private void AddProtection()
        {
            if (rabattBool == true)
            {
                _rabatt = _rabatt + 300;
                tbtotalpris.Text = _rabatt.ToString();
                tbavbeställningsskydd.Text = "300";
            }
            else if (rabattBool != true)
            {
                _brutto = _brutto + 300;
                tbtotalpris.Text = _brutto.ToString();
                tbavbeställningsskydd.Text = "300";
            }
            UpdateEndPrice();           
        }

        private void RemoveProtection()
        {
            if (rabattBool == true)
            {
                _rabatt -= 300;
                tbtotalpris.Text = _rabatt.ToString();
                tbavbeställningsskydd.Text = "";
            }
            else if (rabattBool != true)
            {
                _brutto = _brutto - 300;
                tbtotalpris.Text = _brutto.ToString();
                tbavbeställningsskydd.Text = "";
            }
            UpdateEndPrice();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) AddProtection();
            if (!checkBox1.Checked) RemoveProtection();
        }

        #endregion

        private void frmKonferens_Load(object sender, EventArgs e)
        {

        }

        private void tbdeltagare_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgfkund_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}