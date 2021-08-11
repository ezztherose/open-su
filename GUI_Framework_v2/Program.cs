using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer_FrameWork;
using GUI_Framework_v2;

namespace GUI_Framework_v2
{
    static class Program
    {
        public static FacadeBusiness Facade { get; set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Facade = new FacadeBusiness();
             /*
             * Kommentera bort för att inte resetta databasen
             */
             //Facade.FacadeSysAdmin.ResetDB();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin_2());
        }
    }
}
