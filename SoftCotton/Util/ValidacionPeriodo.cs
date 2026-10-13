using SoftCotton.BusinessLogic;
using System;
using System.Windows.Forms;

namespace SoftCotton.Util
{
    /// <summary>
    /// Reglas de cierre de periodo para los formularios de OC, OS, orden de salida, guias y facturas.
    /// Los procedimientos aplican la misma regla en la base; esto solo avisa antes de llamarlos.
    /// El usuario ADMIN no se valida.
    /// </summary>
    public static class ValidacionPeriodo
    {
        public const string MensajeCerrado = "El periodo se encuentra cerrado. No se puede registrar, modificar ni eliminar documentos de este periodo.";

        public static bool EsAdmin
        {
            get { return UserApplication.USUARIO == "ADMIN"; }
        }

        /// <summary>
        /// Guardar un documento. Nuevo (fechaOriginal null): el periodo de la fecha debe existir y estar abierto.
        /// Existente: ni la fecha guardada ni la nueva pueden estar en un periodo cerrado.
        /// </summary>
        public static bool PermiteGuardar(DateTime? fechaOriginal, DateTime fechaNueva)
        {
            if (EsAdmin)
            {
                return true;
            }

            if (fechaOriginal == null)
            {
                Response response = new GuiaRemisionBL().SetValidarPeriodo(fechaNueva);

                if (response.idResponse == 1)
                {
                    ResponseMessage.Message(response.messageResponse, response.typeMessage);
                    return false;
                }

                return true;
            }

            return PermiteModificar(fechaOriginal) && PermiteModificar(fechaNueva);
        }

        /// <summary>
        /// Modificar, anular o eliminar (cabecera o detalle) un documento con la fecha indicada.
        /// Un documento aun no guardado (fecha null) siempre se permite.
        /// </summary>
        public static bool PermiteModificar(DateTime? fecha)
        {
            if (EsAdmin || !EstaCerrado(fecha))
            {
                return true;
            }

            ResponseMessage.Message(MensajeCerrado, "WARNING");
            return false;
        }

        /// <summary>
        /// Al abrir un documento existente (o limpiar el formulario con fecha null): agrega o quita
        /// del titulo del formulario la marca de periodo cerrado.
        /// </summary>
        public static void IndicarEnTitulo(Form formulario, DateTime? fecha)
        {
            string titulo = formulario.Text.Replace(SufijoTitulo, "");

            if (!EsAdmin && EstaCerrado(fecha))
            {
                titulo += SufijoTitulo;
            }

            formulario.Text = titulo;
        }

        private const string SufijoTitulo = " - PERIODO CERRADO (solo consulta)";

        private static bool EstaCerrado(DateTime? fecha)
        {
            return fecha != null && new GuiaRemisionBL().GetPeriodoCerrado(fecha.Value).idResponse == 1;
        }
    }
}
