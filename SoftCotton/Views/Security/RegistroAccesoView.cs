using SoftCotton.BusinessLogic;
using SoftCotton.Model.Security;
using SoftCotton.Util;
using SoftCotton.Views.ReferralGuide;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SoftCotton.Views.Security
{
    public partial class RegistroAccesoView : Form
    {
        SeguridadBL _seguridadBL;
        SetAccesoParam _accesoParam;

        public RegistroAccesoView()
        {
            InitializeComponent();
            _seguridadBL = new SeguridadBL();
            _accesoParam = new SetAccesoParam();
        }

        private void RegistroAccesoView_Load(object sender, EventArgs e)
        {
            ListarUsuarios();
            Limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                _accesoParam = new SetAccesoParam();

                foreach (DataGridViewRow itemRow in dgvListado.Rows)
                {
                    _accesoParam.idUsuario = Convert.ToInt32(lblIdUsuario.Text);
                    _accesoParam.idSubModulo = Convert.ToInt32(itemRow.Cells["cIntIdSubModulo"].Value);
                    _accesoParam.activo = Convert.ToBoolean(itemRow.Cells["ccbxActivo"].Value);
                    _accesoParam.usuarioReg = UserApplication.USUARIO;

                    // PERMISOS DE MOVIMIENTO (solo formularios de guias, el resto se mantiene en true)
                    _accesoParam.permiteEntrada = ObtenerPermiso(itemRow, "ccbxEntrada");
                    _accesoParam.permiteSalida = ObtenerPermiso(itemRow, "ccbxSalida");
                    _accesoParam.permiteDevolucion = ObtenerPermiso(itemRow, "ccbxDevolucion");

                    Procesar(_accesoParam);
                }

                Listar(Convert.ToInt32(lblIdUsuario.Text));
            }
        }


        private void dgvListadoUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvListadoUsuarios.Columns[e.ColumnIndex].Name.Equals("cbxSeleccionar"))
            {
                foreach (DataGridViewRow rowItem in dgvListadoUsuarios.Rows)
                {
                    if (rowItem.Index == e.RowIndex)
                    {
                        rowItem.Cells["cbxSeleccionar"].Value = !Convert.ToBoolean(rowItem.Cells["cbxSeleccionar"].Value);

                        if (Convert.ToBoolean(rowItem.Cells["cbxSeleccionar"].Value))
                        {
                            lblIdUsuario.Text = rowItem.Cells["ctxtIdUsuario"].Value.ToString();
                            lblUsuarioSeleccionado.Text = rowItem.Cells["ctxtUsuario"].Value.ToString();

                            Listar(Convert.ToInt32(lblIdUsuario.Text));
                        }
                        else
                        {
                            lblIdUsuario.Text = "0";
                            lblUsuarioSeleccionado.Text = "";

                            dgvListado.Rows.Clear();
                        }
                    }
                    else
                    {
                        rowItem.Cells["cbxSeleccionar"].Value = false;
                    }
                }
            }
            else
            {
                lblIdUsuario.Text = "0";
                lblUsuarioSeleccionado.Text = "";
            }
        }

        private void dgvListado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            DataGridViewRow row = dgvListado.Rows[e.RowIndex];
            string columna = dgvListado.Columns[e.ColumnIndex].Name;

            if (columna.Equals("ccbxEntrada") || columna.Equals("ccbxSalida") || columna.Equals("ccbxDevolucion"))
            {
                // Solo se marca si el permiso aplica al formulario de la fila
                if (row.Cells[columna] is DataGridViewCheckBoxCell)
                {
                    row.Cells[columna].Value = !Convert.ToBoolean(row.Cells[columna].Value);
                }
            }
            else
            {
                row.Cells["ccbxActivo"].Value = !Convert.ToBoolean(row.Cells["ccbxActivo"].Value);
            }
        }




        // ####  FUNCIONES  ####

        public void Procesar(SetAccesoParam parametro)
        {
            Response responseGeneral = _seguridadBL.SetAcceso(parametro);

            if (responseGeneral.idResponse == 0)
            {
                ResponseMessage.Message(responseGeneral.messageResponse, responseGeneral.typeMessage);
            }
        }


        public void ListarUsuarios()
        {
            List<GetMant5_Usuarios> listaUsuarios = _seguridadBL.GetMant5_Usuarios();
            dgvListadoUsuarios.Rows.Clear();

            foreach (var item in listaUsuarios)
            {
                int index = dgvListadoUsuarios.Rows.Add();

                dgvListadoUsuarios.Rows[index].Cells["cbxSeleccionar"].Value = false;
                dgvListadoUsuarios.Rows[index].Cells["ctxtIdUsuario"].Value = item.idUsuario;
                dgvListadoUsuarios.Rows[index].Cells["ctxtUsuario"].Value = item.colaborador;
            }
            dgvListadoUsuarios.ClearSelection();
        }

        public void Listar(int idUsuario)
        {
            List<GetAcceso5_Accesos> listaAccesos = _seguridadBL.GetAcceso5_Accesos(idUsuario);
            dgvListado.Rows.Clear();

            foreach (var item in listaAccesos)
            {
                int index = dgvListado.Rows.Add();

                dgvListado.Rows[index].Cells["cIntIdModulo"].Value = item.idModulo;
                dgvListado.Rows[index].Cells["ctxtModulo"].Value = item.modulo;
                dgvListado.Rows[index].Cells["cIntIdSubModulo"].Value = item.idSubModulo;
                dgvListado.Rows[index].Cells["ctxtSubModulo"].Value = item.submodulo;
                dgvListado.Rows[index].Cells["ctxtRutaForm"].Value = item.rutaForm;

                if (item.activo)
                {
                    dgvListado.Rows[index].DefaultCellStyle.BackColor = Color.FromArgb(171, 235, 198);
                }
                else
                {
                    dgvListado.Rows[index].DefaultCellStyle.BackColor = Color.White;
                }

                dgvListado.Rows[index].Cells["ccbxActivo"].Value = item.activo;

                MostrarPermiso(dgvListado.Rows[index], "ccbxEntrada", item.permiteEntrada, AplicaPermiso(item.rutaForm, "ccbxEntrada"));
                MostrarPermiso(dgvListado.Rows[index], "ccbxSalida", item.permiteSalida, AplicaPermiso(item.rutaForm, "ccbxSalida"));
                MostrarPermiso(dgvListado.Rows[index], "ccbxDevolucion", item.permiteDevolucion, AplicaPermiso(item.rutaForm, "ccbxDevolucion"));
            }
            dgvListado.ClearSelection();
        }

        // Guia normal: Entrada / Salida / Devolucion. Guia de exportacion: siempre es salida.
        private bool AplicaPermiso(string rutaForm, string columna)
        {
            string formulario = "SoftCotton." + rutaForm.Trim();

            if (formulario.Equals(typeof(RegistroGuiaRemisionView).FullName))
            {
                return true;
            }

            if (formulario.Equals(typeof(RegistroGuiaRemisionExportacionView).FullName))
            {
                return columna.Equals("ccbxSalida");
            }

            return false;
        }

        private void MostrarPermiso(DataGridViewRow row, string columna, bool valor, bool aplica)
        {
            if (aplica)
            {
                row.Cells[columna].Value = valor;
            }
            else
            {
                // El permiso no aplica al formulario: se deja la celda en blanco
                row.Cells[columna] = new DataGridViewTextBoxCell();
                row.Cells[columna].Value = "";
            }
        }

        private bool ObtenerPermiso(DataGridViewRow row, string columna)
        {
            if (row.Cells[columna] is DataGridViewCheckBoxCell)
            {
                return Convert.ToBoolean(row.Cells[columna].Value);
            }

            return true;
        }

        public bool ValidarDatos()
        {
            bool respuestaValidacion = false;
            bool existeSeleccionUsuario = false;

            // 1. Validar si se selecciono Usuario
            foreach (DataGridViewRow rowUsuario in dgvListadoUsuarios.Rows)
            {
                bool usuarioActivo = Convert.ToBoolean(rowUsuario.Cells["cbxSeleccionar"].Value);
                if (usuarioActivo)
                {
                    existeSeleccionUsuario = true;
                }
            }


            if (!existeSeleccionUsuario)
            {
                ResponseMessage.Message("Seleccione un usuario", "INFORMATION");
                respuestaValidacion = false;
            }
            else if (Convert.ToInt32(lblIdUsuario.Text) == 0)
            {
                ResponseMessage.Message("Seleccione un usuario", "INFORMATION");
                respuestaValidacion = false;
            }
            else if (dgvListado.Rows.Count == 0)
            {
                ResponseMessage.Message("No existe submódulos para brindar acceso", "INFORMATION");
                respuestaValidacion = false;
            }
            else
            {
                respuestaValidacion = true;
            }

            return respuestaValidacion;
        }


        public void Limpiar()
        {
            lblIdUsuario.Text = "0";
            lblUsuarioSeleccionado.Text = "";

            foreach (DataGridViewRow rowItem in dgvListadoUsuarios.Rows)
            {
                rowItem.Cells["cbxSeleccionar"].Value = false;
            }

            dgvListadoUsuarios.ClearSelection();

            dgvListado.Rows.Clear();
        }

    }
}
