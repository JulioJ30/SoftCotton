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
    public partial class RegistroProgramasView : Form
    {
        MantenimientoBL _mantenimientoBL;
        SetProgramaParam _ProgramaParam;
        public string _codProgramaUpdate;
        public int id;

        public RegistroProgramasView()
        {
            InitializeComponent();

            _mantenimientoBL = new MantenimientoBL();
        }

        private void RegistroProgramaView_Load(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
            txtPrograma.Focus();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
            txtPrograma.Focus();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListado.Columns[e.ColumnIndex].Name.Equals("cbtnEditar"))
            {
                if (Convert.ToBoolean(dgvListado.Rows[e.RowIndex].Cells["estado"].Value))
                {
                    txtPrograma.Text = dgvListado.Rows[e.RowIndex].Cells["programa"].Value.ToString().Trim();
                    id = Convert.ToInt32(dgvListado.Rows[e.RowIndex].Cells["idPrograma"].Value.ToString().Trim());


                }
                else
                {
                    Limpiar();
                }
            }
            //else if (dgvListado.Columns[e.ColumnIndex].Name.Equals("cbtnEliminar"))
            //{
            //    if (Convert.ToBoolean(dgvListado.Rows[e.RowIndex].Cells["cbxActivo"].Value))
            //    {
            //        string codPrograma = dgvListado.Rows[e.RowIndex].Cells["ctxtCodPrograma"].Value.ToString().Trim();
            //        DialogResult pregunta = ResponseMessage.MessageQuestion("¿Desea eliminar el registro permanentemente?");

            //        if (pregunta.Equals(DialogResult.OK))
            //        {
            //            _ProgramaParam = new SetProgramaParam();
            //            _ProgramaParam.opcion = 4; // ELIMINAR 
            //            _ProgramaParam.codPrograma = codPrograma;
            //            _ProgramaParam.usuarioReg = UserApplication.USUARIO;

            //            Procesar(_ProgramaParam);
            //        }
            //    }
            //    else
            //    {
            //        Limpiar();
            //    }
            //}
        }

        private void dgvListado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvListado.Columns[e.ColumnIndex].Name.Equals("estado"))
            {
                DataGridViewRow row = dgvListado.Rows[e.RowIndex];
                bool valorCheck = !Convert.ToBoolean(row.Cells["estado"].Value);
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
                    row.Cells["estado"].Value = valorCheck;

                    _ProgramaParam = new SetProgramaParam();

                    _ProgramaParam.opcion = 3; // INHABILITAR
                    _ProgramaParam.idPrograma =  Convert.ToInt32( row.Cells["idPrograma"].Value.ToString().Trim());
                    //_ProgramaParam.usuarioReg = UserApplication.USUARIO;
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

                if (id != 0)
                {
                    _ProgramaParam.opcion = 2; // ACTUALIZAR
                    _ProgramaParam.idPrograma = id;
                    _ProgramaParam.programa = txtPrograma.Text;
                    _ProgramaParam.idUsuarioCrea = UserApplication.ID_USUARIO; // UserApplication.USUARIO;
                }
                else
                {
                    _ProgramaParam.opcion = 1; // REGISTRAR
                    _ProgramaParam.idPrograma = 0;
                    _ProgramaParam.programa = txtPrograma.Text;
                    _ProgramaParam.idUsuarioCrea = UserApplication.ID_USUARIO; // UserApplication.USUARIO;
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

                dgvListado.Rows[index].Cells["idPrograma"].Value = item.idPrograma;
                dgvListado.Rows[index].Cells["programa"].Value = item.programa;
                //dgvListado.Rows[index].Cells["ctxtFechaReg"].Value = item.fechaReg;
                //dgvListado.Rows[index].Cells["ctxtUsuarioReg"].Value = item.usuarioReg;

                //dgvListado.Rows[index].Cells["pedido"].Value = item.pedido;
                //dgvListado.Rows[index].Cells["estilo"].Value = item.estilo;
                //dgvListado.Rows[index].Cells["nombre"].Value = item.nombre;
                //dgvListado.Rows[index].Cells["codColor"].Value = item.codColor;
                //dgvListado.Rows[index].Cells["color"].Value = item.descripcionColor;


                if (item.estado)
                {
                    dgvListado.Rows[index].Cells["estado"].Value = true;
                    dgvListado.Rows[index].Cells["cbtnEditar"].Style.BackColor = Color.MediumSeaGreen;
                    dgvListado.Rows[index].Cells["cbtnEditar"].Style.SelectionBackColor = Color.MediumSeaGreen;
                    //dgvListado.Rows[index].Cells["cbtnEliminar"].Style.BackColor = Color.LightCoral;
                    //dgvListado.Rows[index].Cells["cbtnEliminar"].Style.SelectionBackColor = Color.LightCoral;
                }
                else
                {
                    dgvListado.Rows[index].Cells["estado"].Value = false;
                    dgvListado.Rows[index].Cells["cbtnEditar"].Style.BackColor = Color.Gray;
                    dgvListado.Rows[index].Cells["cbtnEditar"].Style.SelectionBackColor = Color.Gray;
                    //dgvListado.Rows[index].Cells["cbtnEliminar"].Style.BackColor = Color.Gray;
                    //dgvListado.Rows[index].Cells["cbtnEliminar"].Style.SelectionBackColor = Color.Gray;
                }
            }

            lblCantRegistros.Text = "Cantidad de Registros: " + dgvListado.Rows.Count.ToString();
            dgvListado.ClearSelection();
        }

        private bool ValidarDatos()
        {
            bool validacion = false;

            if (string.IsNullOrEmpty(txtPrograma.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese Programa", "INFORMATION");
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
            txtPrograma.Clear();
            id = 0;

        }

        private void btnBuscarProvDest_Click(object sender, EventArgs e)
        {
            //BuscarColorProductoView frmBusquedaColor = new BuscarColorProductoView();

            //frmBusquedaColor.ShowDialog();
            //codigoColor = frmBusquedaColor.codColor;
            //txtColor.Text = frmBusquedaColor.descripcion;
        }
    }
}
