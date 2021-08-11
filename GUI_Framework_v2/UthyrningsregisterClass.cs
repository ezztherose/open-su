using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_Framework_v2
{    // Klass för register av uthyrning 
    internal class UthyrningsregisterClass 
    {
        public int UthyrningsID { get; set; }
        public DateTime UthyrningsDatum { get; set; }
        public double UthyrningsPris { get; set; }
        public int AntalDagar { get; set; }
        public string Status { get; set; }
    }
}
