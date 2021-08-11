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
    public partial class frmUppdateraPrivatRabatt : Form
    {
        public List<PrivatKund> Privatkunder { get; set; }
        public FacadeBusiness FB { get; set; }
        public double rabatt;
        public SysAdmin Admin { get; set; }

        public frmUppdateraPrivatRabatt(SysAdmin a)
        {
            InitializeComponent();
            Admin = a;
            FB = new FacadeBusiness();

            Privatkunder = FB.FacadePrivatKund.GetAllPKunder();
        }

        private void frmTillbaka_Click(object sender, EventArgs e)
        {
            frmSysadminMeny frmM = new frmSysadminMeny(Admin, null);
            this.Hide();
            frmM.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Privatkunder.Count; i++)
            {
                Privatkunder[i].Rabatt = double.Parse(tbRabatt.Text);
                FB.FacadePrivatKund.UppdateraPrivatkund(Privatkunder[i], Privatkunder[i].PrivatKundID);
            }
            MessageBox.Show($"Rabatter för privatkunderna är uppdaterat till {rabatt}%", "Fungerande uppdatering", MessageBoxButtons.OK);
        }

        private void tbRabatt_TextChanged(object sender, EventArgs e)
        {
            double temp;
            if (double.TryParse(tbRabatt.Text, out temp))
            {
                if (temp > 100 || temp < 0)
                {
                    MessageBox.Show("Rabatten måste vara inom intervallet 0 - 100", "Fel på rabattintervall");
                    tbRabatt.Text = "";
                }
                else 
                    rabatt = temp;
            }
            else if (tbRabatt.Text != null) tbRabatt.Text = "";
            else
            {
                MessageBox.Show("Fel input i textrutan", "Error");
                tbRabatt.Text = "";
            }
        }
    }
}
