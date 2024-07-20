using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.Enterprise
{
    public class Get1_Empresas
    {
        public int idEmpresa { get; set; }
        public string ruc { get; set; }
        public string rs { get; set; }
        public string direccion { get; set; }
        public bool Activar_Transa_Kardex { get; set; }
        public bool Validar_stock_exportacion { get; set; }
    }
}
