using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.Security
{
    public class GetAcceso6_PermisosGuia
    {
        public bool permiteEntrada { get; set; }
        public bool permiteSalida { get; set; }
        public bool permiteDevolucion { get; set; }

        // tipoMovimiento: codigo (E / S / D) o descripcion (ENTRADA / SALIDA / DEVOLUCION)
        public bool Permite(string tipoMovimiento)
        {
            switch ((tipoMovimiento ?? "").Trim().ToUpper())
            {
                case "E":
                case "ENTRADA":
                    return permiteEntrada;
                case "S":
                case "SALIDA":
                    return permiteSalida;
                case "D":
                case "DEVOLUCION":
                    return permiteDevolucion;
                default:
                    return true;
            }
        }
    }
}
