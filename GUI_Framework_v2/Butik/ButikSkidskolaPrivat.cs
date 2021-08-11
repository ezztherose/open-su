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
    public partial class ButikSkidskolaPrivat : Form
    {
        private int _fastAntal = 1;
        public FacadeBusiness FacadeBusiness { get; set; }
        public List<PrivatKund> PrivataKunderLista { get; set; }
        public PrivatKund pk { get; set; }
        public Deltagare Deltagare { get; set; }
        public List<Deltagare> ListaDeltagare { get; set; }
        public List<SkidLektion> SkidLektion { get; set; }
        public Privatskidlektion Privatskidlektion { get; set; }
        public Anställd Anställd { get; set; }
        public MarknadsChef MarknadsChef { get; set; }
        public Faktura Faktura { get; set; }
        internal PdfKlass PdfKlass { get; set; }
        private string _sökOrd;
        private string _delatagareNamn;
        private string _förnamn;
        private string _efternamn;
        private double _pris;
        DateTime start;
        DateTime slut;
        public string typ;
        public int antalTimmar;

        public string Efternamn
        {
            get { return _efternamn; }
            set { _efternamn = value; }
        }

        public string Förnamn
        {
            get { return _förnamn; }
            set { _förnamn = value; }
        }

        public string DeltagarNamn
        {
            get { return _delatagareNamn; }
            set { _delatagareNamn = value; }
        }

        public string SökOrd
        {
            get { return _sökOrd; }
            set { _sökOrd = value; }
        }

        public double Pris
        {
            get { return _pris; }
            set { _pris = value; }
        }

        public ButikSkidskolaPrivat(Anställd a, MarknadsChef m)
        {
            InitializeComponent();
            FacadeBusiness = new FacadeBusiness();
            PrivataKunderLista = new List<PrivatKund>();
            pk = new PrivatKund();
            Anställd = a;
            MarknadsChef = m;
            Deltagare = new Deltagare();
            PdfKlass = new PdfKlass();
            SkidLektion = new List<SkidLektion>();
            Privatskidlektion = new Privatskidlektion();
            ListaDeltagare = new List<Deltagare>();
            Faktura = new Faktura();
            StartaGUIParametrar();
        }

        private void StartaGUIParametrar()
        {
            UppdateraRegistreradeDeltagare();
            presetCheckbox();
        }

        private void presetCheckbox()
        {
            cbDag.Items.Add("Måndag");
            cbDag.Items.Add("Tisdag");
            cbDag.Items.Add("Onsdag");
            cbDag.Items.Add("Torsdag");
            cbDag.Items.Add("Fredag");

            cbTid.Items.Add("1");
            cbTid.Items.Add("2");
            cbTid.Items.Add("3");
            cbTid.Items.Add("4");
        }
        private void setPris()
        {
            if (cbTid.SelectedItem != null)
            {
                double Pris = 375;
                Pris = (Pris * int.Parse(cbTid.SelectedItem.ToString()));
                Pris = Pris * ListaDeltagare.Count; 
                tbPris.Text = Pris.ToString();

            }
            else
                MessageBox.Show("Välj antal timmar för lektion");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        /*
         * Button4 är knappen "välj till lektion"
         */
        private void button4_Click(object sender, EventArgs e)
        {
            //// Kontrollerar storleken på listan (max 2 deltagare)
            if (ListaDeltagare.Count <= _fastAntal)
            {
                if (tbsökregistreradebokningar.Text != null || tbsökregistreradebokningar.Text != "" 
                    && gvSökDelatager.CurrentRow.DataBoundItem != null)
                {
                    Deltagare temp = new Deltagare();
                    PrivatKund p = new PrivatKund();
                    p = (PrivatKund)gvSökDelatager.CurrentRow.DataBoundItem;
                    temp.DeltagarEfternamn = p.PrivatEfternamn;
                    temp.DeltagarFörnamn = p.PrivatFörnamn;
                    ListaDeltagare.Add(temp);
                    UppdateraTillLektion();
                }

                //&& gvSökDelatager.CurrentRow != null
                //kontrollera om det är en privatkund eller en utanstående kund
                else if (Förnamn == "" || Förnamn == null && Efternamn == "" || Efternamn == null) // För registrerade/boende
                {
                    Deltagare.DeltagarFörnamn = pk.PrivatFörnamn;
                    Deltagare.DeltagarEfternamn = pk.PrivatEfternamn;
                    Deltagare temp = new Deltagare();
                    temp.DeltagarEfternamn = Deltagare.DeltagarEfternamn;
                    temp.DeltagarFörnamn = Deltagare.DeltagarFörnamn;
                    ListaDeltagare.Add(temp);
                    UppdateraTillLektion();
                }
                else
                {
                    Deltagare temp = new Deltagare();
                    temp.DeltagarEfternamn = Efternamn;
                    temp.DeltagarFörnamn = Förnamn;
                    ListaDeltagare.Add(temp);
                    UppdateraTillLektion();
                }
            }
            else
                MessageBox.Show("Det finns inte plats på denna lektion", "Full lektion", MessageBoxButtons.OK);
        }

        private void ButikSkidskolaPrivat_Load(object sender, EventArgs e)
        {

        }

        private void tbsökregistreradebokningar_TextChanged(object sender, EventArgs e)
        {
            SökOrd = tbsökregistreradebokningar.Text;
        }

        private void btnsök_Click(object sender, EventArgs e)
        {
            if (SökOrd != null)
            {
                if (FacadeBusiness.FacadePrivatKund.SearchPrivatKund(SökOrd).ToList() != null)
                {
                    gvSökDelatager.DataSource = null;
                    gvSökDelatager.DataSource = FacadeBusiness.FacadePrivatKund.SearchPrivatKund(SökOrd).ToList();

                    pk = (PrivatKund)gvSökDelatager.CurrentRow.DataBoundItem;
                    PrivataKunderLista.Add(pk);
                }
                else
                    UppdateraRegistreradeDeltagare();
            }
            else
                MessageBox.Show("Det finns ingen sökterm");
            //if (tbsökregistreradebokningar.Text != null && tbsökregistreradebokningar.Text != "")
            //{
            //    pk = (PrivatKund)gvSökDelatager.CurrentRow.DataBoundItem;
            //    PrivataKunderLista.Add(pk);
            //    UppdateraRegistreradeDeltagare();

            //    //PrivatKundTillDeltagare();
            //}
            //else
            //    MessageBox.Show("Sökterm saknas", "Invalid", MessageBoxButtons.OK);
        }

        private void PrivatKundTillDeltagare()
        {
            Deltagare.DeltagarFörnamn = pk.PrivatFörnamn;
            Deltagare.DeltagarEfternamn = pk.PrivatEfternamn;
            DeltagarNamn = $"{Deltagare.DeltagarFörnamn} {Deltagare.DeltagarEfternamn}";
        }

        private void UppdateraTillLektion()
        {
            tbFörnamn.Text = "";
            tbEfternamn.Text = "";
            gvPrivatSkidlektion.DataSource = null;
            gvPrivatSkidlektion.DataSource = ListaDeltagare;
        }

        private void UppdateraRegistreradeDeltagare()
        {
            gvSökDelatager.DataSource = null;
            gvSökDelatager.DataSource = FacadeBusiness.FacadePrivatKund.GetAllPKunder();
            gvSökDelatager.ClearSelection();
        }

        private void btnregistrera_Click(object sender, EventArgs e)
        {
            antalTimmar = int.Parse(cbTid.Text);
            bool kontroll, tid, betalning;
            kontroll = KontrolleraDag();
            int antalDeltagare = ListaDeltagare.Count();
            if (kontroll == true)
            {
                tid = KontrolleraTid();
                if (tid == true)
                {
                    betalning = KontrolleraBetalsätt();
                    if (betalning == true)
                    {
                        if (Privatskidlektion.PrivatDeltagare.Count < 3)
                        {
                            foreach (Deltagare deltagare in ListaDeltagare)
                            {
                                Privatskidlektion.PrivatDeltagare.Add(deltagare);
                            }
                            FacadeBusiness.FacadePrivatLektion.RegistreraLektion(Privatskidlektion, Pris, int.Parse(cbTid.Text));
                            if (cbFaktura.Checked && !cbKontant.Checked)
                            {
                                pk = (PrivatKund)gvSökDelatager.CurrentRow.DataBoundItem;

                                Faktura faktura = FacadeBusiness.FacadeFaktura.SkidlektionFakturaprivat(start, slut, pk, typ, antalTimmar, antalDeltagare);
                            }
                            else if (cbKontant.Checked && !cbFaktura.Checked)
                            {
                                MessageBox.Show($"Priset blir {tbPris.Text} SEK.", "Succé", MessageBoxButtons.OK);
                            }
                            MessageBox.Show("Privatlektionen är registrerad", "Registrera", MessageBoxButtons.OK);
                            RensaUppEfterRegistrering();                      
                        }
                    }
                }
            }
        }

        private void RensaUppEfterRegistrering()
        {
            Privatskidlektion.PrivatDeltagare.Clear();
            tbFörnamn.Text = "";
            tbEfternamn.Text = "";
            gvPrivatSkidlektion.DataSource = null;
            ListaDeltagare.Clear();
            tbPris.Text = "0";
            cbDag.SelectedIndex = -1;
            cbTid.SelectedIndex = -1;
            pk = null;
        }

        private bool KontrolleraDag()
        {
            if (cbDag.SelectedItem != null && !cbDag.SelectedItem.ToString().Equals(""))
                return true;
            else
                MessageBox.Show("Du har inte valt dag", "Dag saknas", MessageBoxButtons.OK);
            return false;
        }

        private bool KontrolleraTid()
        {
            if (cbTid.SelectedItem != null && !cbTid.SelectedItem.ToString().Equals(""))
                return true;
            else
                MessageBox.Show("Tid har inte angetts", "Tid saknas", MessageBoxButtons.OK);
            return false;
        }

        private bool KontrolleraBetalsätt()
        {
            if (!cbFaktura.Checked && !cbKontant.Checked)
            {
                MessageBox.Show("Du måste välja ett betalsätt", "Error", MessageBoxButtons.OK);
                return false;
            }
            else if (cbFaktura.Checked && cbKontant.Checked)
            {
                MessageBox.Show("Du kan endast välja ett betalsätt", "Error", MessageBoxButtons.OK);
                return false;
            }
            else if (cbFaktura.Checked || cbKontant.Checked)
                return true;
            else
                return false;
        }

        private void cbTid_SelectedIndexChanged(object sender, EventArgs e)
        {
            setPris();            
        }

        private void btntabortdeltagare_Click(object sender, EventArgs e)
        {
            //kraschar om man trucker en gång för mycket lägg in felghanteirng
            if (gvPrivatSkidlektion.SelectedRows != null)
            {
                Deltagare = (Deltagare)gvPrivatSkidlektion.CurrentRow.DataBoundItem;

                ListaDeltagare.Remove(Deltagare);
                UppdateraTillLektion();
            }
        }

        private void btnVäljPrivatKund_Click(object sender, EventArgs e)
        {
            if (gvSökDelatager.SelectedRows != null)
            {
                pk = (PrivatKund)gvSökDelatager.CurrentRow.DataBoundItem;
                PrivataKunderLista.Add(pk);
                PrivatKundTillDeltagare();
            }
            else
                MessageBox.Show("Du har inte valt en kund", "Saknar val", MessageBoxButtons.OK);
        }

        private void tbFörnamn_TextChanged(object sender, EventArgs e)
        {
            if (tbFörnamn.Text == null)
                Förnamn = "";
            else
                Förnamn = tbFörnamn.Text;
        }

        private void tbEfternamn_TextChanged(object sender, EventArgs e)
        {
            Efternamn = tbEfternamn.Text;
        }

        private void btnLäggTillEjBokadDeltagare_Click(object sender, EventArgs e)
        {
            if (tbEfternamn.Text == null && tbFörnamn.Text == null) MessageBox.Show("Du måste skriva förnamn och efternamn!", "Error");
            if (ListaDeltagare.Count <= _fastAntal)
            {
                if (!tbFörnamn.Text.Equals("") && !tbEfternamn.Text.Equals(""))
                {
                    Deltagare temp = new Deltagare();
                    temp.DeltagarEfternamn = Efternamn;
                    temp.DeltagarFörnamn = Förnamn;
                    ListaDeltagare.Add(temp);
                    UppdateraTillLektion();
                }
            }
            else
                MessageBox.Show("Max antal deltagare", "Error", MessageBoxButtons.OK);
        }                

        private void btntillbaka_Click(object sender, EventArgs e)
        {
            if (Anställd != null && MarknadsChef == null)
            {
                frmButikMeny bm = new frmButikMeny(Anställd, MarknadsChef);
                this.Hide();
                bm.Show();
            }
            else if (Anställd == null && MarknadsChef != null)
            {
                frmButikMeny bm = new frmButikMeny(null, MarknadsChef);
                this.Hide();
                bm.Show();
            }          
        }

        private void cbDag_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btntillutskrift_Click(object sender, EventArgs e)
        {
            string savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filename = "\\Privat skidlektionsbokningar";
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
            PdfPTable table = new PdfPTable(gvPrivatSkidlektion.Columns.Count);
            table.DefaultCell.Padding = 3;
            table.WidthPercentage = 70;
            table.HorizontalAlignment = Element.ALIGN_CENTER;
            table.DefaultCell.BorderWidth = 1;



            //Add the headers from the DGV to table
            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.BOLD);
            for (int j = 0; j < gvPrivatSkidlektion.Columns.Count; j++)
            {
                PdfPCell pCell = new PdfPCell(new Phrase(gvPrivatSkidlektion.Columns[j].HeaderText, text));
                pCell.BackgroundColor = new iTextSharp.text.BaseColor(Color.Yellow);
                table.AddCell(pCell);

            }

            //Flag the first row as a header
            table.HeaderRows = 1;

            //Add the actual rows from the DGV to the table
            iTextSharp.text.Font text2 = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
            for (int i = 0; i < gvPrivatSkidlektion.Rows.Count; i++)
            {
                for (int k = 0; k < gvPrivatSkidlektion.Columns.Count; k++)
                {
                    if (gvPrivatSkidlektion[k, i].Value != null)
                    {
                        PdfPCell pRows = new PdfPCell(new Phrase(gvPrivatSkidlektion[k, i].Value.ToString(), text2));
                        pRows.BackgroundColor = new iTextSharp.text.BaseColor(Color.White);
                        table.AddCell(pRows);
                    }
                }
            }
            doc.Add(table);
            doc.Close();

        }

        private void cbKontant_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tbPris_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

