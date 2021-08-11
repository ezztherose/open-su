using BusinessEntities_FrameWork.Models;
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
    public partial class Prislistor : Form
    {
        public SysAdmin SysAdmin { get; set; }
        public MarknadsChef MarknadsChef { get; set; }
        public Prislistor(SysAdmin s, MarknadsChef mc)
        {
            InitializeComponent();
            SysAdmin = new SysAdmin();
            MarknadsChef = mc;
            SysAdmin = s;
        }

        private void Prislistor_Load(object sender, EventArgs e)
        {

        }

        private void btnlogipriser_Click(object sender, EventArgs e)
        {
            frmLogipris_2 mc = new frmLogipris_2(SysAdmin, MarknadsChef);
            this.Hide();
            mc.Show();
        }

        private void btnhyrpriser_Click(object sender, EventArgs e)
        {
            frmHyrpris_2 mc = new frmHyrpris_2(SysAdmin, MarknadsChef);
            this.Hide();
            mc.Show();
        }

        private void btnkonferenspriser_Click(object sender, EventArgs e)
        {
            frmKonferensPris_2 mc = new frmKonferensPris_2(SysAdmin, MarknadsChef);
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
