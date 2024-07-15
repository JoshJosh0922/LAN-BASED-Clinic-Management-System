using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Inventory());
            //Application.Run(new List());
            //Application.Run(new Batch());
            //Application.Run(new ListAddProduct());
            //Application.Run(new ListEdit());
        }
    }
}
