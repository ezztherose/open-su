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
    public partial class frmRegister : Form
    {
        public MarknadsChef MarknadsChef { get; set; }
        public Anställd Anställd { get; set; }
        public frmRegister(MarknadsChef mc, Anställd a)
        {
            InitializeComponent();
            MarknadsChef = mc;
            Anställd = a;
        }

        private void btnkundregister_Click(object sender, EventArgs e)
        {
            Kundregister mc = new Kundregister(MarknadsChef);
            this.Hide();
            mc.Show();
        }

        private void btnuthyrningsregister_Click(object sender, EventArgs e)
        {
            Uthyrningsregister mc = new Uthyrningsregister(MarknadsChef);
            this.Hide();
            mc.Show();
        }

        private void btnfakturaregister_Click(object sender, EventArgs e)
        {
            Fakturaregister mc = new Fakturaregister(MarknadsChef);
            this.Hide();
            mc.Show();
        }

        private void btnbokningsregister_Click(object sender, EventArgs e)
        {
            Bokningar mc = new Bokningar(null, MarknadsChef);
            this.Hide();
            mc.Show();
        }

        private void btntillbaka_Click(object sender, EventArgs e)
        {
            frmMarknadsmeny mc = new frmMarknadsmeny(null, MarknadsChef);
            this.Hide();
            mc.Show();
        }
    }
}
