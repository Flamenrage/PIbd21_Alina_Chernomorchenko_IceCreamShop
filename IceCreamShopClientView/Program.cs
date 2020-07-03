using IceCreamShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IceCreamShopClientView
{
    static class Program
    {
        public static ClientViewModel Client { set; get; }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApiClient.Connect();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var login = new FormLogin();
            login.ShowDialog();

            if (Client != null)
            {
                Application.Run(new FormMain());
            }
        }
    }
}
