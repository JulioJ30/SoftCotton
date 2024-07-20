using SoftCotton.Reports.PurchaseOrder;
using SoftCotton.Reports.PurchaseOrder.OrdenCompra;
using SoftCotton.Views.Configuraciones;
using SoftCotton.Views.Employee;
using SoftCotton.Views.Invoices;
using SoftCotton.Views.Maintenance;
using SoftCotton.Views.PurchaseOrder;
using SoftCotton.Views.ReferralGuide;
using SoftCotton.Views.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SoftCotton
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginView());
            //Application.Run(new ConfiguracionesView());
        }
    }
}
