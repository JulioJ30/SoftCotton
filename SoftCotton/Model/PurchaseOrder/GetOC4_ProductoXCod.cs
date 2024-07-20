using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.PurchaseOrder
{
    public class GetOC4_ProductoXCod
    {
        public string codFamilia { get; set; }
        public string codProducto { get; set; }
        public string codTalla { get; set; }
        public string codColor { get; set; }
        public string color { get; set; }
        public string producto { get; set; }
        public string codUM { get; set; }

        public GetOC4_ProductoXCod()
        {
            codFamilia = "";
            codProducto = "";
            codTalla = "";
            codColor = "";
            color = "";
            producto = "";
            codUM = "";
        }
    }
}
