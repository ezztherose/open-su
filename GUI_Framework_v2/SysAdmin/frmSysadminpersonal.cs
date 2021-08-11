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
    public partial class frmSysadminpersonal : Form
    {
        public FacadeBusiness FacadeBusiness { get; set; }
        public SysAdmin SysAdmin { get; set; }
        public Anställd Anställd { get; set; }

        public string _search;
        private string _användarnamn;
        private string _fnamn;
        private string _enamn;
        private string _lösenord;
        private string _behörighet;
        private string _anställningstyp;

        public frmSysadminpersonal(SysAdmin s)
        {
            InitializeComponent();
            FacadeBusiness = new FacadeBusiness();
            SysAdmin = s;
            Anställd = new Anställd();
            UpdatePersonal();
            PreSetComboBox();
        }

        private void btntillbaka_Click(object sender, EventArgs e)
        {
            frmSysadminMeny sa = new frmSysadminMeny(SysAdmin, null);
            this.Hide();
            sa.Show();
        }

        private void btnuppdateraanställd_Click(object sender, EventArgs e)
        {
            Anställd a = (Anställd)gvpersonaldata.CurrentRow.DataBoundItem;
            Anställd = a;
            if (Användarnamn != null) Anställd.AnvändarNamn = Användarnamn;
            if (Förnamn != null) Anställd.AnställdFörnamn = Förnamn;
            if (Efternamn != null) Anställd.AnställdEfternamn = Efternamn;
            if (Lösenord != null) Anställd.Lösenord = Lösenord;
            if (Behörighet != null) Anställd.Behörighet = Behörighet;
            if (Anställningstyp != null) Anställd.AnställningsTyp = Anställningstyp;
            FacadeBusiness.FacadeAnställd.UppdateraAnställd(Anställd, Anställd.AnställningsID);
            MessageBox.Show("Personal Uppdaterad!");
            UpdatePersonal();
        }

        private void UpdatePersonal()
        {
            gvpersonaldata.DataSource = null;
            gvpersonaldata.DataSource = FacadeBusiness.FacadeAnställd.GetAllAnställd();
        }

        private void btntabortpersonal_Click(object sender, EventArgs e)
        {
            if (gvpersonaldata.CurrentRow != null)
            {
                Anställd = (Anställd)gvpersonaldata.CurrentRow.DataBoundItem;
                FacadeBusiness.FacadeAnställd.RemovePersonal(Anställd);
            }
            UpdatePersonal();
        }

        public string Användarnamn
        {
            get { return _användarnamn; }
            set { _användarnamn = value; }
        }

        public string Förnamn
        {
            get { return _fnamn; }
            set { _fnamn = value; }
        }

        public string Efternamn
        {
            get { return _enamn; }
            set { _enamn = value; }
        }

        public string Lösenord
        {
            get { return _lösenord; }
            set { _lösenord = value; }
        }

        public string Behörighet
        {
            get { return _behörighet; }
            set { _behörighet = value; }
        }

        public string Anställningstyp
        {
            get { return _anställningstyp; }
            set { _anställningstyp = value; }
        }

        public string Search
        {
            get { return _search; }
            set { _search = value; }
        }

        private void btnsökupdatepersonal_Click(object sender, EventArgs e)
        {
            if (Search != null)
            {
                if (FacadeBusiness.FacadeAnställd.SearchAnställdEfternamn(Search).ToList() != null)
                {
                    gvpersonaldata.DataSource = null;
                    gvpersonaldata.DataSource = FacadeBusiness.FacadeAnställd.SearchAnställdEfternamn(Search).ToList();
                }
                else
                    UpdatePersonal();
            }
            else
                MessageBox.Show("Det finns ingen sökterm");
        }

        private void dvpersonaldata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gvpersonaldata.CurrentRow != null)
                if (gvpersonaldata.SelectedRows.Count > 0)
                {
                    Anställd = (Anställd)gvpersonaldata.CurrentRow.DataBoundItem;
                    tbanvändarnamn.Text = Anställd.AnvändarNamn;
                    tbförnamn.Text = Anställd.AnställdFörnamn;
                    tbefternamn.Text = Anställd.AnställdEfternamn;
                    tblösenord.Text = Anställd.Lösenord;
                    cbbehörig.Text = Anställd.Behörighet;
                    cbanställdstyp.Text = Anställd.AnställningsTyp.ToString();
                }
        }

        private void tbanvändarnamn_TextChanged(object sender, EventArgs e)
        {
            if (tbanvändarnamn != null) Användarnamn = tbanvändarnamn.Text;
        }

        private void tbförnamn_TextChanged(object sender, EventArgs e)
        {
            if (tbförnamn != null) Förnamn = tbförnamn.Text;
        }

        private void tbefternamn_TextChanged(object sender, EventArgs e)
        {
            if (tbefternamn != null) Efternamn = tbefternamn.Text;
        }

        private void tblösenord_TextChanged(object sender, EventArgs e)
        {
            if (tblösenord != null) Lösenord = tblösenord.Text;
        }

        private void btnläggtillpersonal_Click(object sender, EventArgs e)
        {
            frmSysadminLäggTillPersonal slp = new frmSysadminLäggTillPersonal(SysAdmin);
            this.Hide();
            slp.Show();
        }

        private void tbpersonal_TextChanged(object sender, EventArgs e)
        {
            Search = tbpersonal.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbehörig != null) _behörighet = comboBox1.Text;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbanställdstyp != null) _anställningstyp = comboBox2.Text;
        }

        private void PreSetComboBox()
        {

        }

        private void gvpersonaldata_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gvpersonaldata.SelectedRows.Count > 0)
            {
                Anställd = (Anställd)gvpersonaldata.SelectedRows[0].DataBoundItem;
                tbanvändarnamn.Text = Anställd.AnvändarNamn;
                tbförnamn.Text = Anställd.AnställdFörnamn;
                tbefternamn.Text = Anställd.AnställdEfternamn;
                tblösenord.Text = Anställd.Lösenord;
                cbbehörig.Text = Anställd.Behörighet;
                cbanställdstyp.Text = Anställd.AnställningsTyp;
            }
        }
    }
}
