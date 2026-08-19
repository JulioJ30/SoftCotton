using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.Model.ServiceOrder
{
    /// <summary>
    /// Representa una fila de la grilla de adjuntos en pantalla. Antes de guardar la OS,
    /// idAdjunto queda en 0 y el archivo viaja en memoria (contenido); recien al guardar la
    /// cabecera de la OS se sube a BD y se completa idAdjunto (ver Guardado).
    /// </summary>
    public class AdjuntoOSItem
    {
        public int idAdjunto { get; set; }
        public string nombreArchivo { get; set; }
        public string extension { get; set; }
        public byte[] contenido { get; set; }
        public decimal tamanioKB { get; set; }
        public string usuarioReg { get; set; }
        public string fechaReg { get; set; }

        public bool Guardado
        {
            get { return idAdjunto > 0; }
        }

        public AdjuntoOSItem()
        {
            idAdjunto = 0;
            nombreArchivo = "";
            extension = "";
            contenido = null;
            tamanioKB = 0;
            usuarioReg = "";
            fechaReg = "";
        }
    }
}
