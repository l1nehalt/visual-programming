using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_12
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
           
            SQLitePCL.Batteries.Init();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SupplyForm());
        }
    }
}
