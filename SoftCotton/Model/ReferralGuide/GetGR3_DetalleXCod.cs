using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.ReferralGuide
{
    public class GetGR3_DetalleXCod
    {
        public string tipo { get; set; }
        public int idEmpresa { get; set; }
        public string serie { get; set; }
        public string numero { get; set; }
        public int secuencia { get; set; }

        public int idEmpresaDet { get; set; }
        public string codigo { get; set; }
        public string razonSocial { get; set; }

        public int idDet { get; set; }
        public int secuenciaDet { get; set; }
        public string codigoProducto { get; set; }
        public string producto { get; set; }
        public string codCuenta { get; set; }
        public decimal cantidadOC { get; set; }
        public decimal cantidadOCsaldo { get; set; }
        public string codUM { get; set; }
        public string OP { get; set; }

        public decimal precioUnitario { get; set; }
        public decimal total { get; set; }
        public string tipoMovimiento { get; set; }

        public double cantidadIngresada { get; set; }
        public decimal pesoIngresado { get; set; }
        
        public string numeroPartida { get; set; }

        public string ruc { get; set; }
        public string descripcionUM { get; set; }
        public string descripcion { get; set; }
        public string codUmDam { get; set; }

        public decimal cantidadIngresoTotal { get; set; }
        public decimal cantidadSalidaTotal { get; set; }
        public decimal cantidadSaldo { get; set; }

        public int idOrden { get; set; }
    }
}
