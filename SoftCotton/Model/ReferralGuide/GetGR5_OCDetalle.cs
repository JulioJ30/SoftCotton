using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.ReferralGuide
{
    public class GetGR5_OCDetalle
    {
        public string tipo { get; set; }

        public int idEmpresa { get; set; }

        public int id { get; set; }

        public int secuencia { get; set; }

        public string codNivel { get; set; }

        public string codGrupo { get; set; }

        public string codTalla { get; set; }

        public string codColor { get; set; }

        public string codProductoGeneral { get; set; }

        public string producto { get; set; }

        public string codCuenta { get; set; }

        public string descripcionCta { get; set; }

        public decimal cantidad { get; set; }

        public string codUM { get; set; }

        public decimal precioUnitario { get; set; }

        public decimal total { get; set; }

        public string codigoPC { get; set; }

        public string razonSocial { get; set; }

        public decimal cantidadSaldo { get; set; }

        public int tienegrfact { get; set; }

        public decimal cantidadEntrada { get; set; }

        public decimal cantidadSalida { get; set; }
    }


    public class GetGR5_OCDetalleDevolver
    {
        public string tipoOrdenId { get; set; }
        public string tipoOrden { get; set; }


        public int idEmpresa { get; set; }
        public int secuencia { get; set; }

        public string codigoPc { get; set; }
        public string proveedor { get; set; }



        public string codNivel { get; set; }

        public string codGrupo { get; set; }

        public string codTalla { get; set; }

        public string codColor { get; set; }

        public string codProductoGeneral { get; set; }

        public string producto { get; set; }

        public string codCuenta { get; set; }

        public string descripcionCta { get; set; }

        public decimal cantidad { get; set; }


        public decimal cantidadIngreso { get; set; }
        public decimal cantidadSalida { get; set; }
        public decimal cantidadSaldo { get; set; }
        public string codUM { get; set; }
        public decimal precioUnitario { get; set; }
        public decimal total { get; set; }


    }

}
