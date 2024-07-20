using SoftCotton.BusinessLogic;
using SoftCotton.Model.Security;
using SoftCotton.Util;
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
    public partial class RegistroModuloView : Form
    {
        SeguridadBL _seguridadBL;
        SetModuloParam _moduloParam;

        public RegistroModuloView()
        {
            InitializeComponent();
            _seguridadBL = new SeguridadBL();

        }


        private void RegistroModuloView_Load(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
            txtModulo.Focus();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
            txtModulo.Focus();
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
                    lblIdModulo.Text = dgvListado.Rows[e.RowIndex].Cells["cIntModulo"].Value.ToString();
                    txtModulo.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtModulo"].Value.ToString();
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
                    int idModulo = Convert.ToInt32(dgvListado.Rows[e.RowIndex].Cells["cIntModulo"].Value.ToString());
                    DialogResult pregunta = ResponseMessage.MessageQuestion("¿Desea eliminar el registro permanentemente?");

                    if (pregunta.Equals(DialogResult.OK))
                    {
                        SetSubModuloParam subModuloParam = new SetSubModuloParam();
                        subModuloParam.opcion = 5; // ELIMINAR SUBMODULO X MODULO
                        subModuloParam.idModulo = idModulo;
                        Response respuesta = _seguridadBL.SetSubModulo(subModuloParam);

                        if (respuesta.idResponse > 0)
                        {
                            _moduloParam = new SetModuloParam();
                            _moduloParam.opcion = 4; // ELIMINAR 
                            _moduloParam.idModulo = idModulo;
                            _moduloParam.usuarioReg = UserApplication.USUARIO;

                            Procesar(_moduloParam);
                        }
                        else
                        {
                            ResponseMessage.Message(respuesta.messageResponse, respuesta.typeMessage);
                        }
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
                    pregunta = "¿Desea activar usuario?";
                }
                else
                {
                    pregunta = "¿Desea deshabilitar el usuario?";
                }

                DialogResult resultadoPregunta = ResponseMessage.MessageQuestion(pregunta);

                if (resultadoPregunta.Equals(DialogResult.OK))
                {
                    row.Cells["cbxActivo"].Value = valorCheck;

                    _moduloParam = new SetModuloParam();

                    _moduloParam.opcion = 3; // INHABILITAR
                    _moduloParam.idModulo = Convert.ToInt32(row.Cells["cIntModulo"].Value);
                    _moduloParam.usuarioReg = "JMORAN";
                    _moduloParam.estado = valorCheck;

                    Procesar(_moduloParam);
                }
            }
        }



        // #####   FUNCIONES   #####
        public void Guardar()
        {
            if (ValidarDatos())
            {
                _moduloParam = new SetModuloParam();

                if (Convert.ToInt32(lblIdModulo.Text) > 0)
                {
                    _moduloParam.opcion = 2; // ACTUALIZAR
                    _moduloParam.idModulo = Convert.ToInt32(lblIdModulo.Text);
                    _moduloParam.modulo = txtModulo.Text.Trim();
                    _moduloParam.usuarioReg = "JMORAN"; // UserApplication.USUARIO;
                }
                else
                {
                    _moduloParam.opcion = 1; // REGISTRAR
                    _moduloParam.idModulo = 0;
                    _moduloParam.modulo = txtModulo.Text.Trim();
                    _moduloParam.usuarioReg = "JMORAN"; // UserApplication.USUARIO;
                }

                Procesar(_moduloParam);
            }
        }

        public void Procesar(SetModuloParam parametro)
        {
            Response responseGeneral = _seguridadBL.SetModulo(parametro);

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
            List<GetMant2_Modulos> listaModulos = _seguridadBL.GetMant2_Modulos();

            dgvListado.Rows.Clear();

            foreach (var item in listaModulos)
            {
                int index = dgvListado.Rows.Add();

                dgvListado.Rows[index].Cells["cIntModulo"].Value = item.id;
                dgvListado.Rows[index].Cells["ctxtModulo"].Value = item.modulo;
                dgvListado.Rows[index].Cells["ctxtFechaReg"].Value = item.fechaReg;
                dgvListado.Rows[index].Cells["ctxtUsuarioReg"].Value = item.usuarioReg;

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

            if (string.IsNullOrEmpty(txtModulo.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese el nombre de módulo", "INFORMATION");
                txtModulo.Focus();
            }
            else
            {
                validacion = true;
            }
                
            return validacion;
        }

        public void Limpiar()
        {
            lblIdModulo.Text = "0";
            txtModulo.Text = "";
        }


    }
}
