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
    public partial class frmSysadminLäggTillPersonal : Form
    {
        public FacadeBusiness FacadeBusiness { get; set; }
        public SysAdmin SysAdmin { get; set; }

        public frmSysadminLäggTillPersonal(SysAdmin sp)
        {
            InitializeComponent();
            FacadeBusiness = new FacadeBusiness();
            SysAdmin = sp;
        }

        private string _användarnamn;
        private string _fnamn;
        private string _enamn;
        private string _lösenord;
        private string _behörighet;
        private string _anställningstyp;

        private void btntillbaka_Click(object sender, EventArgs e)
        {
            frmSysadminpersonal sp = new frmSysadminpersonal(SysAdmin);
            this.Hide();
            sp.Show();
        }

        private void btnläggtillpersonal_Click(object sender, EventArgs e)
        {
            if (Användarnamn != null)
            {
                if (Förnamn != null)
                {
                    if (Efternamn != null)
                    {
                        if (Lösenord != null)
                        {
                            if (Behörighet != null)
                            {
                                if (Anställningstyp != null)
                                {
                                    if (Behörighet == "Sysadmin")
                                    {
                                        FacadeBusiness.FacadeSysAdmin.LäggTillSysAdmin(new SysAdmin()
                                        {
                                            AnvändarNamn = Användarnamn,
                                            SysAdminFörnamn = Förnamn,
                                            SysAdminEfternamn = Efternamn,
                                            Lösenord = Lösenord,
                                            Behörighet = Behörighet,
                                            AnställningsTyp = Anställningstyp,
                                            Bokningar = null,
                                        });
                                    }
                                    else
                                    {
                                        FacadeBusiness.FacadeAnställd.AddAnställd(new Anställd()
                                        {
                                            AnvändarNamn = Användarnamn,
                                            AnställdFörnamn = Förnamn,
                                            AnställdEfternamn = Efternamn,
                                            Lösenord = Lösenord,
                                            Behörighet = Behörighet,
                                            AnställningsTyp = Anställningstyp,
                                            Bokningar = null,
                                            Uthyrningar = null,
                                        });
                                    }
                                    
                                    MessageBox.Show("Anställd tillagd");
                                }
                                else
                                    MessageBox.Show("Varning! Saknas 'lösenord', 'behörighet' eller 'anställdstyp' ");
                            }
                            else
                                MessageBox.Show("Varning! Saknar förnamn' eller 'efternamn'");
                        }
                    }
                }
            }
        }

        private void tbnanvändarnamn_TextChanged(object sender, EventArgs e)
        {
            if (tbnanvändarnamn != null) Användarnamn = tbnanvändarnamn.Text;
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1 != null) Behörighet = comboBox1.Text;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2 != null) Anställningstyp = comboBox2.Text;
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
    }
}
