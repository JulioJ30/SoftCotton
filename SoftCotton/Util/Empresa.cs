using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Util
{
    public static class Empresa
    {
        public static int ID_EMPRESA { get; set; }
        public static string RUC { get; set; }
        public static string RS { get; set; }

        public static bool Activar_Transa_Kardex { get; set; }
        public static bool Validar_stock_exportacion { get; set; }

    }
}
