using SoftCotton.BusinessLogic;
using SoftCotton.Model.Maintenance;
using SoftCotton.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SoftCotton.Views.Maintenance
{
    public partial class RegistroProgramaView : Form
    {
        MantenimientoBL _mantenimientoBL;
        SetProgramaParam _ProgramaParam;
        public string _codProgramaUpdate;
        public string codigoColor;

        public RegistroProgramaView()
        {
            InitializeComponent();

            _mantenimientoBL = new MantenimientoBL();
        }

        private void RegistroProgramaView_Load(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
            txtCodPrograma.Focus();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
            txtCodPrograma.Focus();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListado.Columns[e.ColumnIndex].Name.Equals("cbtnEditar"))
            {
                if (Convert.ToBoolean(dgvListado.Rows[e.RowIndex].Cells["cbxActivo"].Value))
                {
                    txtCodPrograma.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtCodPrograma"].Value.ToString().Trim();
                    txtPrograma.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtPrograma"].Value.ToString().Trim();
                    _codProgramaUpdate = dgvListado.Rows[e.RowIndex].Cells["ctxtCodPrograma"].Value.ToString().Trim();


                    txtPedido.Text = dgvListado.Rows[e.RowIndex].Cells["pedido"].Value.ToString().Trim();
                    txtEstilo.Text = dgvListado.Rows[e.RowIndex].Cells["estilo"].Value.ToString().Trim();
                    txtNombre.Text = dgvListado.Rows[e.RowIndex].Cells["nombre"].Value.ToString().Trim();
                    txtColor.Text = dgvListado.Rows[e.RowIndex].Cells["color"].Value.ToString().Trim();
                    codigoColor = dgvListado.Rows[e.RowIndex].Cells["codColor"].Value.ToString().Trim();
                }
                else
                {
                    Limpiar();
                }
            }
            else if (dgvListado.Columns[e.ColumnIndex].Name.Equals("cbtnEliminar"))
            {
                if (Convert.ToBoolean(dgvListado.Rows[e.RowIndex].Cells["cbxActivo"].Value))
                {
                    string codPrograma = dgvListado.Rows[e.RowIndex].Cells["ctxtCodPrograma"].Value.ToString().Trim();
                    DialogResult pregunta = ResponseMessage.MessageQuestion("¿Desea eliminar el registro permanentemente?");

                    if (pregunta.Equals(DialogResult.OK))
                    {
                        _ProgramaParam = new SetProgramaParam();
                        _ProgramaParam.opcion = 4; // ELIMINAR 
                        _ProgramaParam.codPrograma = codPrograma;
                        _ProgramaParam.usuarioReg = UserApplication.USUARIO;

                        Procesar(_ProgramaParam);
                    }
                }
                else
                {
                    Limpiar();
                }
            }
        }

        private void dgvListado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvListado.Columns[e.ColumnIndex].Name.Equals("cbxActivo"))
            {
                DataGridViewRow row = dgvListado.Rows[e.RowIndex];
                bool valorCheck = !Convert.ToBoolean(row.Cells["cbxActivo"].Value);
                string pregunta = "";

                if (valorCheck)
                {
                    pregunta = "¿Desea activar el programa?";
                }
                else
                {
                    pregunta = "¿Desea deshabilitar el programa?";
                }

                DialogResult resultadoPregunta = ResponseMessage.MessageQuestion(pregunta);

                if (resultadoPregunta.Equals(DialogResult.OK))
                {
                    row.Cells["cbxActivo"].Value = valorCheck;

                    _ProgramaParam = new SetProgramaParam();

                    _ProgramaParam.opcion = 3; // INHABILITAR
                    _ProgramaParam.codPrograma = row.Cells["ctxtCodPrograma"].Value.ToString().Trim();
                    _ProgramaParam.usuarioReg = UserApplication.USUARIO;
                    _ProgramaParam.estado = valorCheck;

                    Procesar(_ProgramaParam);
                }
            }

        }


        // ### Funciones ###
        public void Guardar()
        {
            if (ValidarDatos())
            {
                _ProgramaParam = new SetProgramaParam();

                if (!string.IsNullOrEmpty(_codProgramaUpdate))
                {
                    _ProgramaParam.opcion = 2; // ACTUALIZAR
                    _ProgramaParam.codPrograma = txtCodPrograma.Text;
                    _ProgramaParam.codProgamaUpdate = _codProgramaUpdate;
                    _ProgramaParam.nombrePrograma = txtPrograma.Text;
                    _ProgramaParam.pedido = txtPedido.Text.Trim();
                    _ProgramaParam.estilo = txtEstilo.Text.Trim();
                    _ProgramaParam.nombre = txtNombre.Text.Trim();
                    _ProgramaParam.codColor = codigoColor;
                    _ProgramaParam.usuarioReg = UserApplication.USUARIO; // UserApplication.USUARIO;
                }
                else
                {
                    _ProgramaParam.opcion = 1; // REGISTRAR
                    _ProgramaParam.codPrograma = txtCodPrograma.Text;
                    _ProgramaParam.nombrePrograma = txtPrograma.Text;
                    _ProgramaParam.pedido = txtPedido.Text.Trim();
                    _ProgramaParam.estilo = txtEstilo.Text.Trim();
                    _ProgramaParam.nombre = txtNombre.Text.Trim();
                    _ProgramaParam.codColor = codigoColor;
                    _ProgramaParam.usuarioReg = UserApplication.USUARIO; // UserApplication.USUARIO;
                }

                Procesar(_ProgramaParam);
            }
        }

        public void Procesar(SetProgramaParam parametro)
        {
            Response responseGeneral = _mantenimientoBL.SetPrograma(parametro);

            if (responseGeneral.idResponse > 0)
            {
                Limpiar();
                Listar();
            }
            else
            {
                ResponseMessage.Message(responseGeneral.messageResponse, responseGeneral.typeMessage);
            }
        }

        public void Listar()
        {
            List<GetMant34_Programa> listaPrograma = _mantenimientoBL.Get34_Programa();

            dgvListado.Rows.Clear();

            foreach (var item in listaPrograma)
            {
                int index = dgvListado.Rows.Add();

                dgvListado.Rows[index].Cells["ctxtCodPrograma"].Value = item.codPrograma;
                dgvListado.Rows[index].Cells["ctxtPrograma"].Value = item.nombrePrograma;
                dgvListado.Rows[index].Cells["ctxtFechaReg"].Value = item.fechaReg;
                dgvListado.Rows[index].Cells["ctxtUsuarioReg"].Value = item.usuarioReg;

                dgvListado.Rows[index].Cells["pedido"].Value = item.pedido;
                dgvListado.Rows[index].Cells["estilo"].Value = item.estilo;
                dgvListado.Rows[index].Cells["nombre"].Value = item.nombre;
                dgvListado.Rows[index].Cells["codColor"].Value = item.codColor;
                dgvListado.Rows[index].Cells["color"].Value = item.descripcionColor;


                if (item.estado)
                {
                    dgvListado.Rows[index].Cells["cbxActivo"].Value = true;
                    dgvListado.Rows[index].Cells["cbtnEditar"].Style.BackColor = Color.MediumSeaGreen;
                    dgvListado.Rows[index].Cells["cbtnEditar"].Style.SelectionBackColor = Color.MediumSeaGreen;
                    dgvListado.Rows[index].Cells["cbtnEliminar"].Style.BackColor = Color.LightCoral;
                    dgvListado.Rows[index].Cells["cbtnEliminar"].Style.SelectionBackColor = Color.LightCoral;
                }
                else
                {
                    dgvListado.Rows[index].Cells["cbxActivo"].Value = false;
                    dgvListado.Rows[index].Cells["cbtnEditar"].Style.BackColor = Color.Gray;
                    dgvListado.Rows[index].Cells["cbtnEditar"].Style.SelectionBackColor = Color.Gray;
                    dgvListado.Rows[index].Cells["cbtnEliminar"].Style.BackColor = Color.Gray;
                    dgvListado.Rows[index].Cells["cbtnEliminar"].Style.SelectionBackColor = Color.Gray;
                }
            }

            lblCantRegistros.Text = "Cantidad de Registros: " + dgvListado.Rows.Count.ToString();
            dgvListado.ClearSelection();
        }

        private bool ValidarDatos()
        {
            bool validacion = false;

            if (string.IsNullOrEmpty(txtCodPrograma.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese el código de Programa", "INFORMATION");
                txtCodPrograma.Focus();
            }
            else if (string.IsNullOrEmpty(txtPrograma.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese el nombre del Programa", "INFORMATION");
                txtPrograma.Focus();
            }
            else
            {
                validacion = true;
            }

            return validacion;
        }

        public void Limpiar()
        {
            txtCodPrograma.Text = "";
            txtPrograma.Text = "";
            _codProgramaUpdate = "";

            txtPedido.Clear();
            txtColor.Clear();
            txtEstilo.Clear();
            txtNombre.Clear();
        }

        private void btnBuscarProvDest_Click(object sender, EventArgs e)
        {
            BuscarColorProductoView frmBusquedaColor = new BuscarColorProductoView();

            frmBusquedaColor.ShowDialog();
            codigoColor = frmBusquedaColor.codColor;
            txtColor.Text = frmBusquedaColor.descripcion;
        }
    }
}
