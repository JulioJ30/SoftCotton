using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SoftCotton.Util
{
    public static class ResponseMessage
    {
        /// <summary>
        /// Mensaje modal personalizado
        /// </summary>
        /// <param name="mensaje">mensaje</param>
        /// <param name="tipo">INFORMATION, WARNING, ERROR</param>
        public static void Message (string mensaje, string tipo)
        {
            if (tipo.Trim() == "INFORMATION")
            {
                MessageBox.Show(mensaje, "SoftCotton", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (tipo.Trim() == "WARNING")
            {
                MessageBox.Show(mensaje, "SoftCotton", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (tipo.Trim() == "ERROR")
            {
                MessageBox.Show(mensaje, "SoftCotton", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public static DialogResult MessageQuestion (string mensaje)
        {
            DialogResult result = MessageBox.Show(mensaje, "SoftCotton", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            return result;
        }


    }
}
