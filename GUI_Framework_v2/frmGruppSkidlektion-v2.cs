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

namespace GUI_Framework_v2
{
    public partial class frmGruppSkidlektion_v2 : Form
    {
        private string _participantFullName;
        public string ParticipantFirstName { get; set; }
        public string ParticipantLastName { get; set; }
        private int _sendDays;
        private string _sendColor;
        private double _totPrice;
        private double _tax = 12; // kontrollera momsen
        private double _priceWithTax;
        private string _searchName;

        public double PriceWithTax
        {
            get { return _priceWithTax; }
            set { _priceWithTax = value; }
        }


        public double TotalPrice
        {
            get { return _totPrice; }
            set { _totPrice = value; }
        }


        public Anställd Anställd { get; set; }
        public MarknadsChef MarknadsChef { get; set; }
        public Gruppskidlektion Gruppskidlektion { get; set; }
        public Deltagare Deltagare { get; set; }
        public PrivatKund PrivatKund { get; set; }
        public List<Deltagare> Deltagarlista { get; set; }
        public List<PrivatKund> PrivatKunder { get; set; }
        public FacadeBusiness FacadeBusiness { get; set; }

        public frmGruppSkidlektion_v2(Anställd a, MarknadsChef m)
        {
            InitializeComponent();
            Anställd = a;
            MarknadsChef = m;
            FacadeBusiness = new FacadeBusiness();
            Gruppskidlektion = new Gruppskidlektion();
            Deltagare = new Deltagare();
            PrivatKund = new PrivatKund();
            PrivatKund = new PrivatKund();
            Deltagarlista = new List<Deltagare>();
            PrivatKunder = new List<PrivatKund>();
            SetComboBox();

        }

        private void SetComboBox()
        {
            comboBoxColor.Text = "";
            comboBoxDays.Text = "";
        }

        private void UIRefresh()
        {
            gvParticipant.DataSource = null;
            gvParticipant.DataSource = Deltagarlista;
            gvParticipant.Columns[0].Visible = false;
            gvParticipant.Columns[3].Visible = false;
            gvParticipant.Columns[4].Visible = false;
            tbName.Text = "";
        }

        private void SplitParticipantName()
        {
            string[] splitWord;
            splitWord = _participantFullName.Split(' ');
            ParticipantFirstName = splitWord[0];

            if (splitWord.Length > 1 && splitWord[1] == "")
                ParticipantLastName = "";
            else if (splitWord.Length > 1)
                ParticipantLastName = splitWord[1];
        }

        private void tbAddParticipant_Click(object sender, EventArgs e)
        {
            if (tbName.Text == "" || tbName.Text == null) return;
            if (comboBoxDays.SelectedItem != null || comboBoxDays.Text != "")
            {
                if (comboBoxColor.SelectedItem != null || comboBoxColor.Text != "")
                {
                    if (tbParticipantName.Text != null || tbParticipantName.Text != "")
                    {
                        if (ParticipantLastName != "")
                        {
                            SplitParticipantName();
                            Deltagarlista.Add(CreatNewParticipand());
                            UIRefresh();
                            TotalPrice += FacadeBusiness.FacadeGruppskidlektion.GetParticipandPrice(_sendDays, _sendColor);
                            GetPriceWithTax();
                            RefreshPriceOutput();
                        }
                        else
                            MessageBox.Show("Du måste fylla i för- och efternamn", "Efternamn saknas", MessageBoxButtons.OK);
                    }
                }
                else
                    MessageBox.Show("Du har inte valt färg", "Färg saknas", MessageBoxButtons.OK);
            }
            else
                MessageBox.Show("Du har inte gjort något val av dagar", "Dagar saknas", MessageBoxButtons.OK);
        }

        private double CalculateTax()
        {
            double tax = _tax;
            tax = tax / 100;
            tax++;
            return tax;
        }

        private void GetPriceWithTax()
        {
            double tax = CalculateTax();
            PriceWithTax = TotalPrice * tax;
        }

        private void RefreshPriceOutput()
        {
            tbTax.Text = _tax.ToString();
            tbPriceNoTax.Text = TotalPrice.ToString();
            tbPriceWithTax.Text = PriceWithTax.ToString();
        }

        private Deltagare CreatNewParticipand()
        {
            Deltagare temp = new Deltagare();
            temp.DeltagarFörnamn = ParticipantFirstName;
            temp.DeltagarEfternamn = ParticipantLastName;
            return temp;
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            _participantFullName = tbName.Text;
        }

        private void tbRemoveParticipant_Click(object sender, EventArgs e)
        {
            if (gvParticipant.CurrentRow != null)
            {
                Deltagare d = (Deltagare)gvParticipant.CurrentRow.DataBoundItem;
                Deltagarlista.Remove(d);
                UIRefresh();
                ReductPrice();
            }
        }

        private void ReductPrice()
        {
            double tempPrice = FacadeBusiness.FacadeGruppskidlektion.GetParticipandPrice(_sendDays, _sendColor);
            TotalPrice -= tempPrice;
            GetPriceWithTax();
            RefreshPriceOutput();
        }

        private void btnGenerateBoking_Click(object sender, EventArgs e)
        {
            if (cbCash.Checked && !cbInvoice.Checked)
            {
                RegisterToLesson();
                MessageBox.Show($"Totalbeloppet: {PriceWithTax}", "Totalbelopp", MessageBoxButtons.OK);
                ClearAfterBooking();
            }
            else if (!cbCash.Checked && cbInvoice.Checked)
            {
                RegisterToLesson();
                if (gvRegCustomer.CurrentRow != null)
                {
                    PrivatKund p = (PrivatKund)gvRegCustomer.CurrentRow.DataBoundItem;
                    string message = FacadeBusiness.FacadeGruppskidlektion.GenerateInvoice(p, null, PriceWithTax);
                    MessageBox.Show($"{message}. Bokningen tillhör {p.PrivatFörnamn} {p.PrivatEfternamn}", "Bekräftelse", MessageBoxButtons.OK);
                    ClearAfterBooking();
                }
            }
        }

        private void ClearAfterBooking()
        {
            tbName.Text = "";
            cbCash.Checked = false;
            tbCashName.Text = "";
            gvRegCustomer.DataSource = null;
            gvParticipant.DataSource = null;
            tbTax.Text = "";
            tbPriceWithTax.Text = "";
            tbPriceNoTax.Text = "";
            ParticipantFirstName = "";
            ParticipantLastName = " ";
            Deltagarlista.Clear();
            TotalPrice = 0;
        }

        private void RegisterToLesson()
        {
            string message = FacadeBusiness.FacadeGruppskidlektion.RegisterToLesson(Deltagarlista, _sendColor, _sendDays);
            MessageBox.Show(message, "Meddelande", MessageBoxButtons.OK);
        }

        private void comboBoxDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            _sendDays = int.Parse(comboBoxDays.Text);
        }

        private void comboBoxColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            _sendColor = comboBoxColor.Text;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            
            if (Anställd != null && MarknadsChef == null)
            {
                frmButikMeny bm = new frmButikMeny(Anställd, null);
                this.Hide();
                bm.Show();
            }
            else if (Anställd == null && MarknadsChef != null)
            {
                frmButikMeny mm = new frmButikMeny(null, MarknadsChef);
                this.Hide();
                mm.Show();
            }
            else
            {
                MessageBox.Show("Fel inträffade. Vänligen logga in igen för att fortsätta...", "Fel", MessageBoxButtons.OK);
                frmLogin_2 lo = new frmLogin_2();
                this.Hide();
                lo.Show();
            }
        }

        private void cbCash_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCash.Checked)
            {
                btnSearchCustomer.Hide();
                cbInvoice.Hide();
                tbParticipantName.Hide();
            }
            else if (!cbCash.Checked)
            {
                btnSearchCustomer.Show();
                cbInvoice.Show();
                tbParticipantName.Show();
            }
        }

        private void cbInvoice_CheckedChanged(object sender, EventArgs e)
        {
            if (cbInvoice.Checked)
            {
                cbCash.Hide();
                tbCashName.Hide();
                lbReciverCash.Hide();
                GetPrivateCustomer();
            }
            else if (!cbInvoice.Checked)
            {
                lbReciverCash.Show();
                cbCash.Show();
                tbCashName.Show();
                gvRegCustomer.DataSource = null;
            }
        }

        private void GetPrivateCustomer()
        {
            PrivatKunder = FacadeBusiness.FacadePrivatKund.GetAllPKunder();
            gvRegCustomer.DataSource = null;
            gvRegCustomer.DataSource = PrivatKunder;
        }

        private void SearchForRegCustomer()
        {
            if (_searchName == "")
            {
                if (_searchName.Any(x => char.IsWhiteSpace(x)))
                    PrivatKunder = FacadeBusiness.FacadeGruppskidlektion.SearchCustomer(_searchName);
                else

                    MessageBox.Show($"Namet är felinmatat: {_searchName}", "Fel", MessageBoxButtons.OK);
            }
            ShowSearchResults();
        }

        private void ShowSearchResults()
        {
            gvRegCustomer.DataSource = null;
            gvRegCustomer.DataSource = PrivatKunder;
        }

        private void tbParticipantName_TextChanged(object sender, EventArgs e)
        {
            _searchName = tbParticipantName.Text;
        }

        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            SearchForRegCustomer();
        }
    }
}
