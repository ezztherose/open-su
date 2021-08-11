using BusinessEntities_FrameWork.Models;
using BusinessLayer_FrameWork;
using GUI_Framework_v2.Butik;
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

namespace GUI_Framework_v2
{
    public partial class ButikSkiduthyrning : Form
    {
      
        private string _search;
        private double _pris;
        public double JacobTest123;
        public double _inkMoms = 1.12;
        public bool paketCheck;
        public List<bool> boollista;
        private string _exkund;

        public FacadeBusiness FacadeBusiness { get; set; }
        internal List<UtrustningClass> UtrustningarLista { get; set; }
        internal UtrustningClass UtrustningClass { get; set; } // behövs denna?
        public PrivatKund PrivatKund { get; set; }
        public Utrustning Utrustning { get; set; }
        public List<Utrustning> TillUtrustning { get; set; }
        public List<Uthyrning> UthyrningarList { get; set; }
        public Faktura TempFaktura { get; set; }
        public Anställd Anställd { get; set; }
        public MarknadsChef MarknadsChef { get; set; }
        public Uthyrning Uthyrning { get; set; }
        public List<Uthyrning> PaketUthyrning { get; set; }
        public Utrustning Utrustning1 { get; set; }
        public Utrustning Utrustning2 { get; set; }
        public Utrustning Utrustning3 { get; set; }
        private DateTime start { get; set; }
        private DateTime slut { get; set; }
        public List<double> Priser { get; set; }
        internal PdfKlass PdfKlass { get; set; }

        public ButikSkiduthyrning(Anställd a, MarknadsChef mc)
        {
            InitializeComponent();
            FacadeBusiness = new FacadeBusiness();
            UtrustningClass = new UtrustningClass();
            UtrustningarLista = new List<UtrustningClass>();
            VisaUthyrningar = new List<Uthyrning>();
            PrivatKund = new PrivatKund();
            TillUtrustning = new List<Utrustning>();
            TempFaktura = new Faktura();
            boollista = new List<bool>();
            Uthyrning = new Uthyrning();
            Utrustning = new Utrustning();
            Utrustning1 = new Utrustning();
            Utrustning2 = new Utrustning();
            Utrustning3 = new Utrustning();
            PdfKlass = new PdfKlass();
            PaketUthyrning = new List<Uthyrning>();
            Anställd = a;
            MarknadsChef = mc;
            Priser = new List<double>();
            UpdatePrivatKunder();
            PreSetEnskildaTillbehör();
            StartCombobox();
            checkboxFaktura.Checked = false;
            checkboxKontant.Checked = false;
            SättVisaUthyrningar();
        }

        private void UpdatePrivatKunder()
        {
            gvkunder.DataSource = null;
            gvkunder.DataSource = FacadeBusiness.FacadePrivatKund.GetAllPKunder().ToList();
        }

        private void StartCombobox()
        {
            cbskidor.Text = "Inget";
            cbPjäxor.Text = "Inget";
            cbSkor.Text = "Inget";
            cbSkoter.Text = "Inget";
            cbSnowboard.Text = "Inget";
            cbStavar.Text = "Inget";
            cbHjälm.Text = "Inget";
            cbDagar.Text = "Inget";
        }

        private void UpdateListaTillbehör()
        {
            gvListaTillbehör.DataSource = null;
            gvListaTillbehör.DataSource = UtrustningarLista;
            GömData();
        }

        #region Backgroundstuff

        private void GömData()
        {
            gvListaTillbehör.Columns["Utrustning"].Visible = false;
            gvListaTillbehör.Columns["Typ"].Visible = true;
            gvListaTillbehör.Columns["Pris"].Visible = true;
        }

        private void PreSetEnskildaTillbehör()
        {
            // Skidor
            cbskidor.Items.Add("Inget");
            cbskidor.Items.Add("Alpint");
            cbskidor.Items.Add("Längd");

            //Hjälmar
            cbHjälm.Items.Add("1");

            // Pjäxor
            cbPjäxor.Items.Add("Inget");
            cbPjäxor.Items.Add("Alpint");
            cbPjäxor.Items.Add("Längd");

            // Stavar
            cbStavar.Items.Add("Inget");
            cbStavar.Items.Add("Alpint");
            cbStavar.Items.Add("Längd");

            // Snowboard
            cbSnowboard.Items.Add("Inget");
            cbSnowboard.Items.Add("Snowboard");

            // Snowboardskor
            cbSkor.Items.Add("Inget");
            cbSkor.Items.Add("Skor");

            // Skoter
            cbSkoter.Items.Add("Ingen");
            cbSkoter.Items.Add("Lynx 50");
            cbSkoter.Items.Add("Yamaha Viking");
            cbSkoter.Items.Add("Nilapulka");

            // Dagar
            cbDagar.Items.Add("1");
            cbDagar.Items.Add("2");
            cbDagar.Items.Add("3");
            cbDagar.Items.Add("4");
            cbDagar.Items.Add("5");
            cbDagar.Items.Add("6");
            cbDagar.Items.Add("7");
        }

        #endregion

        private void ButikSkiduthyrning_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnsökkund_Click(object sender, EventArgs e)
        {
            if (Search != null)
            {
                if (FacadeBusiness.FacadePrivatKund.SearchPrivatKund(Search).ToList() != null)
                {
                    gvkunder.DataSource = null;
                    gvkunder.DataSource = FacadeBusiness.FacadePrivatKund.SearchPrivatKund(Search).ToList();
                }
                else
                    UpdateGridViewprivatkund();
            }
            else
                MessageBox.Show("Det finns ingen sökterm");
        }

        private void UpdateGridViewprivatkund()
        {
            gvkunder.DataSource = null;
            gvkunder.DataSource = FacadeBusiness.FacadePrivatKund.GetAllPKunder().ToList();
        }

        private void tbexisterandekunder_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(tbexisterandekunder.Text, "^[a-zA-Z ]"))
            {
                MessageBox.Show("Error", "Error");
                tbexisterandekunder.Text = "";
            }
            Search = tbexisterandekunder.Text;
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

        private void btLäggTillVara_Click(object sender, EventArgs e)
        {
            if (cbDagar.Text == null || cbDagar.Text == "Inget") MessageBox.Show("Välj antal dagar");
            else
            {
                if (cbskidor.Text != "Inget" || cbskidor.Text == null)
                {
                    if (gvkunder.CurrentRow != null)
                    {
                        HämtaSkidor();
                        if (Utrustning == null) MessageBox.Show("Finns inga tillgängliga skidor");

                        UtrustningClass u = new UtrustningClass();
                        u.Utrustning = Utrustning;
                        u.Typ = "Skidor";
                        UtrustningarLista.Add(u);
                        Uthyrning.UtrustningsTillUthyrning.Add(Utrustning);
                        TestHämtaPriser(cbDagar.Text, "Skidor", cbskidor.Text);
                        cbskidor.Text = "Inget";
                    }
                    else
                        MessageBox.Show("Du har inte valt någon kund");

                }
                else if (cbPjäxor.Text != "Inget" || cbPjäxor.Text == null)
                {
                    if (gvkunder.CurrentRow != null)
                    {
                        HämtaPjäxa();
                        if (Utrustning == null) MessageBox.Show("Finns inga tillgängliga pjäxor");
                        else
                        {
                            UtrustningClass u = new UtrustningClass();
                            u.Utrustning = Utrustning;
                            u.Typ = "Pjäxor";
                            UtrustningarLista.Add(u);
                            Uthyrning.UtrustningsTillUthyrning.Add(Utrustning);
                            TestHämtaPriser(cbDagar.Text, "Pjäxor", cbPjäxor.Text);
                            cbPjäxor.Text = "Inget";
                        }
                    }
                    else
                        MessageBox.Show("Du har inte valt någon kund");
                }
                else if (cbStavar.Text != "Inget" || cbStavar.Text == null)
                {
                    if (gvkunder.CurrentRow != null)
                    {
                        HämtaStavar();
                        if (Utrustning == null) MessageBox.Show("Finns inga tillgängliga stavar");
                        else
                        {
                            UtrustningClass u = new UtrustningClass();
                            u.Utrustning = Utrustning;
                            u.Typ = "Stavar";
                            UtrustningarLista.Add(u);
                            Uthyrning.UtrustningsTillUthyrning.Add(Utrustning);
                            TestHämtaPriser(cbDagar.Text, "Stavar", cbStavar.Text);
                            cbStavar.Text = "Inget";
                        }
                    }
                    else
                        MessageBox.Show("Du har inte valt någon kund");
                }
                else if (cbSkoter.Text != "Inget" || cbSkoter.Text == null)
                {
                    if (gvkunder.CurrentRow != null)
                    {
                        if (Utrustning == null) MessageBox.Show("Finns inga tillgängliga skotrar");
                        int day1 = int.Parse(cbDagar.Text);
                        int day2 = int.Parse(cbDagar.Text);
                        if (day1 == 2 || day2 == 4) MessageBox.Show("Det går inte att boka skoter 2 eller 4 dagar");
                        else if (day1 != 2 || day2 != 4)
                        {
                            HämtaSkoter();
                            UtrustningClass u = new UtrustningClass();
                            u.Utrustning = Utrustning;
                            u.Typ = "Skoter";
                            UtrustningarLista.Add(u);
                            Uthyrning.UtrustningsTillUthyrning.Add(Utrustning);

                            TestHämtaPriser(cbDagar.Text, "Skoter", cbSkoter.Text);
                            cbSkoter.Text = "Inget";
                        }
                        
                    }
                    else
                        MessageBox.Show("Du har inte valt någon kund");
                }
                else if (cbSnowboard.Text != "Inget" || cbSnowboard.Text == null)
                {
                    if (gvkunder.CurrentRow != null)
                    {
                        HämtaSnowboard();
                        if (Utrustning == null) MessageBox.Show("Finns inga tillgängliga skotrar");

                        else
                        {
                            UtrustningClass u = new UtrustningClass();
                            u.Utrustning = Utrustning;
                            u.Typ = "Snowboard";
                            UtrustningarLista.Add(u);
                            Uthyrning.UtrustningsTillUthyrning.Add(Utrustning);
                            TestHämtaPriser(cbDagar.Text, "Snowboard", cbSnowboard.Text);
                            cbSnowboard.Text = "Inget";
                        }
                    }
                    else
                        MessageBox.Show("Du har inte valt någon kund");
                }
                else if (cbSkor.Text != "Inget" || cbSkor.Text == null)
                {
                    if (gvkunder.CurrentRow != null)
                    {
                        HämtaSkor();
                        if (Utrustning == null) MessageBox.Show("Finns inga tillgängliga skor");

                        else
                        {
                            UtrustningClass u = new UtrustningClass();
                            u.Utrustning = Utrustning;
                            u.Typ = "Skor";
                            UtrustningarLista.Add(u);
                            Uthyrning.UtrustningsTillUthyrning.Add(Utrustning);
                            TestHämtaPriser(cbDagar.Text, "Skor", "Skor");
                            cbSkor.Text = "Inget";
                        }
                    }
                    else
                        MessageBox.Show("Du har inte valt någon kund");
                }
                else if (cbHjälm.Text != "Inget" || cbHjälm.Text == null)
                {
                    if (gvkunder.CurrentRow != null)
                    {
                        HämtaHjälm();
                        if (Utrustning == null) MessageBox.Show("Finns inga tillgängliga hjälmar");
                        else
                        {
                            UtrustningClass u = new UtrustningClass();
                            u.Utrustning = Utrustning;
                            u.Typ = "Hjälm";
                            UtrustningarLista.Add(u);
                            Uthyrning.UtrustningsTillUthyrning.Add(Utrustning);
                            TestHämtaPriser(cbDagar.Text, "Hjälm", "Hjälm");
                            cbHjälm.Text = "Inget";
                        }
                        
                    }
                }
                else
                {
                    
                }

                if (checkBoxAlpPaket.Checked)
                {
                    HämtaAlpPaket();
                    gvListaTillbehör.DataSource = null;
                    gvListaTillbehör.DataSource = UtrustningarLista;
                    
                    TestHämtaPriser(cbDagar.Text, "Paket", "Alpint");
                    checkBoxAlpPaket.Checked = false;
                }
                if (checkBoxLängdPaket.Checked) 
                {
                    HämtaLängdPaket();
                    gvListaTillbehör.DataSource = null;
                    gvListaTillbehör.DataSource = TillUtrustning;
                    TestHämtaPriser(cbDagar.Text, "Paket", "Längd");
                    checkBoxLängdPaket.Checked = false;
                }
                if (checkBoxSnowboardPaket.Checked)
                {
                    HämtaSnowPaket();
                    gvListaTillbehör.DataSource = null;
                    gvListaTillbehör.DataSource = TillUtrustning;
                    TestHämtaPriser(cbDagar.Text, "Paket", "Snowboard");
                    checkBoxSnowboardPaket.Checked = false;
                }
            }
            TotalPris();
            UpdateListaTillbehör();
        }

        private void HämtaSkidor()
        {
            Utrustning = FacadeBusiness.FacadeUtrustning.GetSkida(cbskidor.Text);
        }

        private void HämtaSnowPaket()
        {
            UtrustningClass u = new UtrustningClass();
            Utrustning1 = FacadeBusiness.FacadeUtrustning.GetSnowboard("Snowboard");
            Utrustning1.PaketStatus = true;
            u.PaketLista.Add(Utrustning1);
            UtrustningClass.PaketLista.Add(Utrustning1);
            Uthyrning.UtrustningsTillUthyrning.Add(Utrustning1);
            Utrustning2 = FacadeBusiness.FacadeUtrustning.GetSkor("Skor");
            Utrustning2.PaketStatus = true;
            u.PaketLista.Add(Utrustning2);
            Uthyrning.UtrustningsTillUthyrning.Add(Utrustning2);
            UtrustningClass.PaketLista.Add(Utrustning2);
            u.Typ = "Snowboard Paket";
            UtrustningarLista.Add(u);
            
        }

        private void HämtaLängdPaket()
        {
            UtrustningClass u = new UtrustningClass();
            Utrustning1 = FacadeBusiness.FacadeUtrustning.GetPjäxa("Längd");
            Utrustning1.PaketStatus = true;
            Uthyrning.UtrustningsTillUthyrning.Add(Utrustning1);
            u.PaketLista.Add(Utrustning1);
            Utrustning2 = FacadeBusiness.FacadeUtrustning.GetSkida("Längd");
            Utrustning2.PaketStatus = true;
            Uthyrning.UtrustningsTillUthyrning.Add(Utrustning2);
            u.PaketLista.Add(Utrustning2);
            Utrustning3 = FacadeBusiness.FacadeUtrustning.GetStavar("Längd");
            Utrustning3.PaketStatus = true;
            Uthyrning.UtrustningsTillUthyrning.Add(Utrustning3);
            u.PaketLista.Add(Utrustning3);
            u.Typ = "Längd Paket";
            UtrustningarLista.Add(u);
        }

        private void HämtaAlpPaket()
        {
            UtrustningClass u = new UtrustningClass();
            Utrustning1 = FacadeBusiness.FacadeUtrustning.GetPjäxa("Alpint");
            Utrustning1.PaketStatus = true;
            u.PaketLista.Add(Utrustning1);
            UtrustningClass.PaketLista.Add(Utrustning1);
            Uthyrning.UtrustningsTillUthyrning.Add(Utrustning1);
            Utrustning2 = FacadeBusiness.FacadeUtrustning.GetSkida("Alpint");
            Utrustning2.PaketStatus = true;
            u.PaketLista.Add(Utrustning2);
            UtrustningClass.PaketLista.Add(Utrustning2);
            Uthyrning.UtrustningsTillUthyrning.Add(Utrustning2);
            Utrustning3 = FacadeBusiness.FacadeUtrustning.GetStavar("Alpint");
            Utrustning3.PaketStatus = true;
            u.PaketLista.Add(Utrustning3);
            UtrustningClass.PaketLista.Add(Utrustning3);
            Uthyrning.UtrustningsTillUthyrning.Add(Utrustning3);
            u.Typ = "Alpint Paket";
            UtrustningarLista.Add(u);
        }

        private void HämtaStavar()
        {
            Utrustning = FacadeBusiness.FacadeUtrustning.GetStavar(cbStavar.Text);
        }

        private void HämtaPjäxa()
        {
            Utrustning = FacadeBusiness.FacadeUtrustning.GetPjäxa(cbPjäxor.Text);
        }

        private void HämtaSkoter()
        {
            Utrustning = FacadeBusiness.FacadeUtrustning.GetSkoter(cbSkoter.Text);
        }

        private void HämtaSnowboard()
        {
            Utrustning = FacadeBusiness.FacadeUtrustning.GetSnowboard(cbSnowboard.Text);
        }

        private void HämtaSkor()
        {
            Utrustning = FacadeBusiness.FacadeUtrustning.GetSkor(cbSkor.Text);
        }

        private void HämtaHjälm()
        {
            Utrustning = FacadeBusiness.FacadeUtrustning.GetHjälm(null);
        }

        private void TestHämtaPriser(string dagar, string sort, string typ)
        {
            double p = FacadeBusiness.FacadeHyrpris.GetUtrustningsHyrpris(dagar, sort, typ);
            UtrustningarLista[UtrustningarLista.Count - 1].Pris = p;
            Priser.Add(p);
            if (sort == "Paket")
            {
                paketCheck = true;
                boollista.Add(paketCheck);
                
            }
            else if(sort != "Paket")
            {
                paketCheck = false;
                boollista.Add(paketCheck);
            }
        }

        private void TotalPris()
        {
            Pris = 0;
            for (int i = 0; i < UtrustningarLista.Count; i++)
            {
                Pris += Priser[i];
            }
            PrisUI();
        }

        private void PrisUI()
        {
            tbprisexklmoms.Text = Pris.ToString();
            tbmoms.Text = "12%";
            double d = Pris;
            tbprisinklmoms.Text = (d * 1.12).ToString();
        }

        private void btnsparabokning_Click(object sender, EventArgs e)
        {
            {
                if (gvkunder.CurrentRow != null)
                {
                    
                    if (checkboxKontant.Checked == true && checkboxFaktura.Checked == true)
                    {
                        MessageBox.Show("Du kan endast välja ett betalsätt");
                    }
                    else if (checkboxKontant.Checked == true && checkboxFaktura.Checked == false)
                    {
                        MessageBox.Show($"Betalining kontant: {tbprisinklmoms.Text} inkuderat moms");
                        FakturaTillUthyrning();
                        PrivatKund pk = (PrivatKund)gvkunder.CurrentRow.DataBoundItem;
                        
                        Uthyrning u = new Uthyrning();
                        for (int i = 0; i < UtrustningarLista.Count; i++)
                        {
                            if (UtrustningarLista[i].Utrustning != null)
                            {
                                u.UtrustningsTillUthyrning.Add(UtrustningarLista[i].Utrustning);
                                Uthyrning.UtrustningsTillUthyrning.ToList().AddRange(u.UtrustningsTillUthyrning.ToList());
                            }
                            else if (UtrustningarLista[i].PaketLista != null)
                            {
                                List<Utrustning> tempUt = new List<Utrustning>();
                                tempUt.AddRange(UtrustningarLista[i].PaketLista);
                                Uthyrning.UtrustningsTillUthyrning.ToList().AddRange(tempUt);
                            }

                        }
                        u = Uthyrning;
                        u.Faktura = null;
                        u.UthyrningsPris = Pris * _inkMoms;
                        u.Status = false;
                        FacadeBusiness.FacadeUthyrning.SparaKontantUthyrning(u);
                        MessageBox.Show("Bokning skapad");
                    }
                    else if (checkboxKontant.Checked == false && checkboxFaktura.Checked == true)
                    {
                        FakturaTillUthyrning();
                        start = DateTime.Now;
                        slut = start.AddMonths(1);

                        PrivatKund pk = (PrivatKund)gvkunder.CurrentRow.DataBoundItem;
                        PrivatKund = pk;
                        Uthyrning u = new Uthyrning();

                        for (int i = 0; i < UtrustningarLista.Count; i++)
                        {
                            if (UtrustningarLista[i].Utrustning != null)
                            {
                                u.UtrustningsTillUthyrning.Add(UtrustningarLista[i].Utrustning);
                                Uthyrning.UtrustningsTillUthyrning.ToList().AddRange(u.UtrustningsTillUthyrning.ToList());
                            }
                            else if (UtrustningarLista[i].PaketLista != null)
                            {
                                List<Utrustning> tempUt = new List<Utrustning>();
                                tempUt.AddRange(UtrustningarLista[i].PaketLista);
                                Uthyrning.UtrustningsTillUthyrning.ToList().AddRange(tempUt);
                                
                            }

                        }
                        u = Uthyrning;
                        u.UthyrningsPris = Pris * _inkMoms;
                        u.Status = false;
                        Faktura temp = FacadeBusiness.FacadeFaktura.UthyrningsFakturaPrivat(Pris, "Uthyrning", u, pk, start, slut);
                        MessageBox.Show("Bokning skapad");
                        TempFaktura = temp;
                    }
                  
                    if (checkboxFaktura.Checked == true || checkboxKontant.Checked == true) UthyrningsBlankett(Uthyrning, PrivatKund);
                }
                Uthyrning.UthyrningsPris = 0;
                Pris = 0;

                ClearAfterBooking();
            }
        }

        private void ClearAfterBooking()
        {
            
            
            tbprisexklmoms.Text = "";
            tbprisinklmoms.Text = "";
            tbmoms.Text = "";
            gvListaTillbehör.DataSource = null;
            cbDagar.SelectedIndex = -1;
            checkBoxAlpPaket.Checked = false;
            checkboxFaktura.Checked = false;
            checkboxKontant.Checked = false;
            checkBoxLängdPaket.Checked = false;
            checkBoxSnowboardPaket.Checked = false;

            frmButikMeny bm = new frmButikMeny(Anställd, MarknadsChef);
            this.Hide();
            bm.Show();


        }

        private void FakturaTillUthyrning()
        {
            Uthyrning.UthyrningsDatum = DateTime.Now;
            Uthyrning.AntalDagar = int.Parse(cbDagar.Text);
        }

        private void btntabortobjekt_Click(object sender, EventArgs e)
        {
           
            if (gvListaTillbehör.CurrentRow != null)
            {
                UtrustningClass = (UtrustningClass)gvListaTillbehör.CurrentRow.DataBoundItem;
                //for (int i = 0; i < Priser.Count; i++)
                //{
                //    if (UtrustningClass.Utrustning.ArtikelID == UtrustningarLista[i].Utrustning.ArtikelID)
                //    {
                //        UtrustningarLista.RemoveAt(i);
                //        //UtrustningarLista.Remove(UtrustningClass);
                //        Pris = Pris - UtrustningClass.Pris;
                //        //Pris = Pris - UtrustningarLista[i].Pris;
                //    }
                //}
                Pris = Pris - UtrustningClass.Pris;
                UtrustningarLista.Remove(UtrustningClass);
                PrisUI();
                UpdateListaTillbehör();
                KontrolleraBorttagningPris();
            }
            else if (gvListaTillbehör == null || gvListaTillbehör.CurrentRow == null)
                MessageBox.Show("Det går inte att ta genomföra borttagning i en tom lista", "Tom lista", MessageBoxButtons.OK);
 
        }

        private void KontrolleraBorttagningPris()
        {
            if (UtrustningarLista == null || UtrustningarLista.Count == 0)
                Priser.Clear();
        }

        private void btntillbaka_Click(object sender, EventArgs e)
        {
            frmButikMeny bm = new frmButikMeny(Anställd, MarknadsChef);
            this.Hide();
            bm.Show();
        }
        public void UthyrningsBlankett(Uthyrning Uthyrning, PrivatKund pk)
        {
            List<Utrustning> temp = FacadeBusiness.FacadeUtrustning.UtrustningPåUthyrningsID(Uthyrning);

            int a = 120;
            int b = 560;
            DateTime frånDatum;
            DateTime tillDatum;
            frånDatum = Uthyrning.UthyrningsDatum;
            tillDatum = frånDatum.AddDays(Uthyrning.AntalDagar);
            //int c = 510;
            int d = 580;

            string savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filename = ("\\Uthyrningsblankett " + pk.PrivatFörnamn + " ID " + Uthyrning.UthyrningsID) ;
            string endpoint = ".pdf";
            Document doc = new Document(iTextSharp.text.PageSize.A4, 10, 10, 40, 40);

            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(savePath + filename + endpoint, FileMode.Create, FileAccess.ReadWrite));
            doc.Open();
            PdfContentByte cb = wri.DirectContent;
            cb.BeginText();
            BaseFont font = BaseFont.CreateFont("c:\\windows\\fonts\\calibrib.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

            Paragraph pgraph1 = new Paragraph("Ski-Center ");

            //VÄNSTER = KOLUMN Y, HÖGER = RAD X. (Y,X)

            cb.SetFontAndSize(font, 20);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Ski-Center", 300, 700, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Uthyrningsblankett", 300, 650, 0);

            cb.SetFontAndSize(font, 15);
            
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER,"Uthyrnings ID: " +  Uthyrning.UthyrningsID.ToString(), 300, 620, 0);

            Paragraph pgraph2 = new Paragraph("Objekt");
            if (checkboxFaktura.Checked == true)
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER,"Kundnamn: "+ pk.PrivatFörnamn + " " + pk.PrivatEfternamn + " " + pk.PrivatKundID, 120, b + 60, 0);



            for (int i = 0; i < temp.Count; i++)
            {
                
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Objekt", 120,d, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Från", 300, d, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Till", 480, d, 0);

                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "ID: " + temp[i].ArtikelID  + ". " +  temp[i].UtrustningSort.ToString() + " , " + temp[i].UtrustningsTyp.ToString(), a, b, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, frånDatum.ToString(), 300, b, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, tillDatum.ToString(), 480, b, 0);
                b = b - 60;
                d = d - 60;                
            }

            cb.EndText();
            doc.Close();
        }

        private void gvUthyrning_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /*
         * ------------------------------
         * För att hantera uthyrningarna
         * ------------------------------
         */
        public List<Uthyrning> VisaUthyrningar { get; set; }

        private string _uthyrning;

        public string SökUthyrning
        {
            get { return _uthyrning; }
            set { _uthyrning = value; }
        }

        private void SättVisaUthyrningar()
        {
            VisaUthyrningar = FacadeBusiness.FacadeUthyrning.GetAllUtnyrningar();
        }

        private void btnsök_Click(object sender, EventArgs e)
        {
            if (SökUthyrning != "" || SökUthyrning != null) FacadeBusiness.FacadeUthyrning.SökEfterUthyrning(SökUthyrning);
        }

        private void btnnykund_Click(object sender, EventArgs e)
        {
            LäggTillKundPrivat lkp = new LäggTillKundPrivat(MarknadsChef, Anställd);
            this.Hide();
            lkp.Show();
        }

        private void checkboxKontant_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbHjälm_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
