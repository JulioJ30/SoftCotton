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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftCotton.Views.Maintenance
{
    public partial class RegistrarAreasAlmacen : Form
    {
        MantenimientoBL _mantenimientoBL = new MantenimientoBL();
        SetAreasAlmacen _Param;
        public RegistrarAreasAlmacen()
        {
            InitializeComponent();
        }

        private void RegistrarAreasAlmacen_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private bool ValidarDatos()
        {
            bool validacion = false;

            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese la descripcion de Almacén", "WARNING");
                txtDescripcion.Focus();
            }
            else
            {
                validacion = true;
            }

            return validacion;
        }

        public void Guardar()
        {
            if (ValidarDatos())
            {
                _Param = new SetAreasAlmacen();

                if (!string.IsNullOrEmpty(txtCodigo.Text))
                {
                    _Param.opcion = 2; // ACTUALIZAR
                    _Param.codigo = txtCodigo.Text;
                    _Param.descripcion = txtDescripcion.Text;
                    _Param.resumida = txtResumida.Text.Trim();
                    _Param.estado = chkEstado.Checked;
                }
                else
                {
                    _Param.opcion = 1; // REGISTRAR
                    _Param.codigo = txtCodigo.Text;
                    _Param.descripcion = txtDescripcion.Text;
                    _Param.resumida = txtResumida.Text.Trim();
                    _Param.estado = chkEstado.Checked;

                }

                Procesar(_Param);
            }
        }

        public void Procesar(SetAreasAlmacen parametro)
        {
            Response responseGeneral = _mantenimientoBL.SetAreasAlmacen(parametro);

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

        public void Limpiar()
        {
            txtCodigo.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtResumida.Text = string.Empty;
            chkEstado.Checked = false;
        }

        public void Listar()
        {
            List<SetAreasAlmacen> listaCeCos =  _mantenimientoBL.GetListarAreasAlmacen(txtFiltro.Text);

            dgvListado.Rows.Clear();

            foreach (var item in listaCeCos)
            {
                int index = dgvListado.Rows.Add();

                dgvListado.Rows[index].Cells["codigo"].Value = item.codigo;
                dgvListado.Rows[index].Cells["descripcion"].Value = item.descripcion;
                dgvListado.Rows[index].Cells["resumida"].Value = item.resumida;

                if (item.estado)
                {
                    dgvListado.Rows[index].Cells["estado"].Value = true;
                    dgvListado.Rows[index].Cells["Editar"].Style.BackColor = Color.MediumSeaGreen;
                    dgvListado.Rows[index].Cells["Editar"].Style.SelectionBackColor = Color.MediumSeaGreen;
                    dgvListado.Rows[index].Cells["Eliminar"].Style.BackColor = Color.LightCoral;
                    dgvListado.Rows[index].Cells["Eliminar"].Style.SelectionBackColor = Color.LightCoral;
                }
                else
                {
                    dgvListado.Rows[index].Cells["estado"].Value = false;
                    dgvListado.Rows[index].Cells["Editar"].Style.BackColor = Color.Gray;
                    dgvListado.Rows[index].Cells["Editar"].Style.SelectionBackColor = Color.Gray;
                    dgvListado.Rows[index].Cells["Eliminar"].Style.BackColor = Color.Gray;
                    dgvListado.Rows[index].Cells["Eliminar"].Style.SelectionBackColor = Color.Gray;
                }
            }

            lblCantRegistros.Text = "Cantidad de Registros: " + dgvListado.Rows.Count.ToString();
            dgvListado.ClearSelection();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListado.Columns[e.ColumnIndex].Name.Equals("Editar"))
            {
                if (Convert.ToBoolean(dgvListado.Rows[e.RowIndex].Cells["estado"].Value))
                {
                    txtCodigo.Text = dgvListado.Rows[e.RowIndex].Cells["codigo"].Value.ToString();
                    txtDescripcion.Text = dgvListado.Rows[e.RowIndex].Cells["descripcion"].Value.ToString();
                    txtResumida.Text = dgvListado.Rows[e.RowIndex].Cells["resumida"].Value.ToString();
                    chkEstado.Checked = Convert.ToBoolean(dgvListado.Rows[e.RowIndex].Cells["estado"].Value.ToString());
                }
                else
                {
                    Limpiar();
                }
            }
            else if (dgvListado.Columns[e.ColumnIndex].Name.Equals("Eliminar"))
            {
                if (Convert.ToBoolean(dgvListado.Rows[e.RowIndex].Cells["estado"].Value))
                {
                    string codCeCo = dgvListado.Rows[e.RowIndex].Cells["codigo"].Value.ToString();
                    DialogResult pregunta = ResponseMessage.MessageQuestion("¿Desea eliminar el registro permanentemente?");

                    if (pregunta.Equals(DialogResult.OK))
                    {
                        _Param = new SetAreasAlmacen();
                        _Param.opcion = 3; // INHABILITAR 
                        _Param.codigo = codCeCo;
                        Procesar(_Param);
                    }
                }
                else
                {
                    Limpiar();
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Listar();
        }
    }
}
