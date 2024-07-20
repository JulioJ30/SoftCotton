using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SoftCotton.BusinessLogic;
using SoftCotton.Model.Maintenance;
using SoftCotton.Util;


namespace SoftCotton.Views.Maintenance
{
    public partial class RegistroPedidosView : Form
    {
        MantenimientoBL _mantenimientoBL;
        SetPedidosParam _pedidoParam;
        SetPedidosColorParam _pedidoColorParam;

        public int idPedidoParam = 0;
        public int idPedidoColorParam = 0;
        public int idEstiloParam = 0;
        public int idProgramaParam = 0;
        public string codColorParam = "";




        public RegistroPedidosView()
        {
            InitializeComponent();
            _mantenimientoBL = new MantenimientoBL();

        }

        private void RegistroPedidosView_Load(object sender, EventArgs e)
        {
            Listar();

        }

        public void Limpiar(bool limpiarvariablepedido = true)
        {
            txtPedido.Clear();
            txtEstilo.Clear();
            txtPrograma.Clear();
            txtColor.Clear();

            if (limpiarvariablepedido)
            {
                idPedidoParam = 0;
                lblPedido.Text = "Pedido:";
                ListarPedidosColor(0);
                dgvPedidos.ClearSelection();
            }
            idPedidoColorParam = 0;
            idEstiloParam = 0;
            idProgramaParam = 0;


        }


        public void Guardar()
        {
            if (ValidarDatos())
            {
                _pedidoParam = new SetPedidosParam();

                if (idPedidoParam != 0)
                {
                    _pedidoParam.opcion = 2; // ACTUALIZAR
                    _pedidoParam.idpedido = idPedidoParam; // ACTUALIZAR
                    _pedidoParam.idestilo = idEstiloParam;
                    _pedidoParam.idprograma = idProgramaParam;
                    _pedidoParam.idusuariocrea = UserApplication.ID_USUARIO; // UserApplication.USUARIO;
                    _pedidoParam.pedido = txtPedido.Text.Trim(); // UserApplication.USUARIO;

                }
                else
                {
                    _pedidoParam.opcion = 1; // REGISTRAR
                    _pedidoParam.idestilo = idEstiloParam;
                    _pedidoParam.idprograma = idProgramaParam;
                    _pedidoParam.idusuariocrea = UserApplication.ID_USUARIO; // UserApplication.USUARIO;
                    _pedidoParam.pedido = txtPedido.Text.Trim();
                }

                Procesar(_pedidoParam);
            }
        }


        public void GuardarPedidoColor()
        {
            if (ValidarDatosPedidosColor())
            {
                _pedidoColorParam = new SetPedidosColorParam();

                if (idPedidoColorParam != 0)
                {
                    _pedidoColorParam.opcion = 2; // ACTUALIZAR
                    _pedidoColorParam.idpedido = idPedidoParam; // ACTUALIZAR
                    _pedidoColorParam.idpedidocolor = idPedidoColorParam;
                    _pedidoColorParam.codcolor = codColorParam;
                    _pedidoColorParam.idusuariocrea = UserApplication.ID_USUARIO; // UserApplication.USUARIO;

                }
                else
                {
                    _pedidoColorParam.opcion = 1; // REGISTRAR
                    _pedidoColorParam.idpedido = idPedidoParam; // ACTUALIZAR
                    _pedidoColorParam.codcolor = codColorParam;
                    _pedidoColorParam.idusuariocrea = UserApplication.ID_USUARIO; // UserApplication.USUARIO;
                }

                ProcesarPedidoColor(_pedidoColorParam);
            }
        }


        private bool ValidarDatos()
        {
            bool validacion = false;

            if (string.IsNullOrEmpty(txtPedido.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese Pedido", "INFORMATION");
                txtPrograma.Focus();
            }else if (string.IsNullOrEmpty(txtPrograma.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese Programa", "INFORMATION");
                txtPrograma.Focus();
            }
            else if (string.IsNullOrEmpty(txtEstilo.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese Estilo", "INFORMATION");
                txtPrograma.Focus();
            }

            else
            {
                validacion = true;
            }

            return validacion;
        }


        private bool ValidarDatosPedidosColor()
        {
            bool validacion = false;

            if (string.IsNullOrEmpty(txtColor.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese Color", "WARNING");
                txtColor.Focus();
            }

            else
            {
                validacion = true;
            }

            return validacion;
        }



        public void Procesar(SetPedidosParam parametro)
        {
            Response responseGeneral = _mantenimientoBL.setPedidosMantenimiento(parametro);

            if (responseGeneral.idResponse > 0)
            {
                Limpiar(true);
                Listar();
            }
            else
            {
                ResponseMessage.Message(responseGeneral.messageResponse, responseGeneral.typeMessage);
            }
        }

        public void ProcesarPedidoColor(SetPedidosColorParam parametro)
        {
            Response responseGeneral = _mantenimientoBL.setPedidosColorMantenimiento(parametro);

            if (responseGeneral.idResponse > 0)
            {
                ListarPedidosColor(idPedidoParam);
                Limpiar(false);
            }
            else
            {
                ResponseMessage.Message(responseGeneral.messageResponse, responseGeneral.typeMessage);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void Listar()
        {
            List<GetMant55_Pedidos> listaPedidos = _mantenimientoBL.GetPedidos().ToList();

            dgvPedidos.Rows.Clear();

            foreach (var item in listaPedidos)
            {
                int index = dgvPedidos.Rows.Add();

                dgvPedidos.Rows[index].Cells["idPedido"].Value = item.idPedido;
                dgvPedidos.Rows[index].Cells["idEstilo"].Value = item.idEstilo;
                dgvPedidos.Rows[index].Cells["idPrograma"].Value = item.idPrograma;
                dgvPedidos.Rows[index].Cells["idUsuarioCrea"].Value = item.idUsuarioCrea;
                dgvPedidos.Rows[index].Cells["pedido"].Value = item.pedido;
                dgvPedidos.Rows[index].Cells["fechaCrea"].Value = item.fechaCrea;
                dgvPedidos.Rows[index].Cells["estilo"].Value = item.estilo;
                dgvPedidos.Rows[index].Cells["programa"].Value = item.programa;



                if (item.estado)
                {
                    dgvPedidos.Rows[index].Cells["estado"].Value = true;
                    dgvPedidos.Rows[index].Cells["cbtnEditar"].Style.BackColor = Color.MediumSeaGreen;
                    dgvPedidos.Rows[index].Cells["cbtnEditar"].Style.SelectionBackColor = Color.MediumSeaGreen;
                }
                else
                {
                    dgvPedidos.Rows[index].Cells["estado"].Value = false;
                    dgvPedidos.Rows[index].Cells["cbtnEditar"].Style.BackColor = Color.Gray;
                    dgvPedidos.Rows[index].Cells["cbtnEditar"].Style.SelectionBackColor = Color.Gray;
                }
            }

            //lblCantRegistros.Text = "Cantidad de Registros: " + dgvListado.Rows.Count.ToString();
            dgvPedidos.ClearSelection();
        }

        private void btnBuscarProgramas_Click(object sender, EventArgs e)
        {
            BuscarProgramasView frm = new BuscarProgramasView();
            frm.ShowDialog();
            idProgramaParam = frm.idProgramaParam;
            txtPrograma.Text = frm.programaParam;
        }

        private void btnBuscarEstilos_Click(object sender, EventArgs e)
        {
            BuscarEstilosView frm = new BuscarEstilosView();
            frm.ShowDialog();
            idEstiloParam = frm.idEstiloParam;
            txtEstilo.Text = frm.estiloParam;
        }

        private void dgvPedidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            //idPedidoParam = Convert.ToInt32(dgvPedidos.Rows[e.RowIndex].Cells["idPedido"].Value.ToString());
            //lblPedido.Text = "Pedido: " + dgvPedidos.Rows[e.RowIndex].Cells["pedido"].Value.ToString();
            //ListarPedidosColor(idPedidoParam);

            // EDITAR
            if (dgvPedidos.Columns[e.ColumnIndex].Name.Equals("cbtnEditar"))
            {
                if (Convert.ToBoolean(dgvPedidos.Rows[e.RowIndex].Cells["estado"].Value))
                {
                    idPedidoParam = Convert.ToInt32(dgvPedidos.Rows[e.RowIndex].Cells["idPedido"].Value.ToString().Trim());
                    txtPedido.Text = dgvPedidos.Rows[e.RowIndex].Cells["pedido"].Value.ToString().Trim();
                    txtPrograma.Text = dgvPedidos.Rows[e.RowIndex].Cells["programa"].Value.ToString().Trim();
                    txtEstilo.Text = dgvPedidos.Rows[e.RowIndex].Cells["estilo"].Value.ToString().Trim();
                    idProgramaParam = Convert.ToInt32(dgvPedidos.Rows[e.RowIndex].Cells["idPrograma"].Value.ToString().Trim());
                    idEstiloParam = Convert.ToInt32(dgvPedidos.Rows[e.RowIndex].Cells["idEstilo"].Value.ToString().Trim());
                }
                
            }

            //VER 
            if (dgvPedidos.Columns[e.ColumnIndex].Name.Equals("cbtnVer"))
            {

                idPedidoParam = Convert.ToInt32(dgvPedidos.Rows[e.RowIndex].Cells["idPedido"].Value.ToString());
                lblPedido.Text = "Pedido: " + dgvPedidos.Rows[e.RowIndex].Cells["pedido"].Value.ToString();
                ListarPedidosColor(idPedidoParam);
            }
        }


        private void ListarPedidosColor(int idPedido)
        {
            List<GetMant56_PedidosColor> listaPedidosColor = _mantenimientoBL.GetPedidosColor(idPedido).ToList();

            dgvPedidosColor.Rows.Clear();

            foreach (var item in listaPedidosColor)
            {
                int index = dgvPedidosColor.Rows.Add();

                dgvPedidosColor.Rows[index].Cells["idPedidoColor"].Value = item.idPedidoColor;
                dgvPedidosColor.Rows[index].Cells["codColor"].Value = item.codColor;
                dgvPedidosColor.Rows[index].Cells["color"].Value = item.color;


                if (item.estado)
                {
                    dgvPedidosColor.Rows[index].Cells["estadoColor"].Value = true;
                    //dgvPedidos.Rows[index].Cells["cbtnEditar"].Style.BackColor = Color.MediumSeaGreen;
                    //dgvPedidos.Rows[index].Cells["cbtnEditar"].Style.SelectionBackColor = Color.MediumSeaGreen;
                }
                else
                {
                    dgvPedidosColor.Rows[index].Cells["estadoColor"].Value = false;
                    //dgvPedidos.Rows[index].Cells["cbtnEditar"].Style.BackColor = Color.Gray;
                    //dgvPedidos.Rows[index].Cells["cbtnEditar"].Style.SelectionBackColor = Color.Gray;
                }
            }

            //lblCantRegistros.Text = "Cantidad de Registros: " + dgvListado.Rows.Count.ToString();
            dgvPedidosColor.ClearSelection();
        }

        private void btnBuscarColor_Click(object sender, EventArgs e)
        {

            if (lblPedido.Text != "Pedido:")
            {
                BuscarColorProductoView frm = new BuscarColorProductoView();
                frm.ShowDialog();
                codColorParam = frm.codColor;
                txtColor.Text = frm.descripcion.Trim();

            }else
            {
                ResponseMessage.Message("Seleccione un pedido primero","WARNING");

            }



        }

        private void btnAgregarColor_Click(object sender, EventArgs e)
        {
            GuardarPedidoColor();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar(true);
            //dgvPedidosColor.
            txtPedido.Focus();
        }

        private void dgvPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvPedidos.Columns[e.ColumnIndex].Name.Equals("estado"))
            {
                DataGridViewRow row = dgvPedidos.Rows[e.RowIndex];
                bool valorCheck = !Convert.ToBoolean(row.Cells["estado"].Value);
                string pregunta = "";

                if (valorCheck)
                {
                    pregunta = "¿Desea activar el pedido?";
                }
                else
                {
                    pregunta = "¿Desea deshabilitar el pedido?";
                }

                DialogResult resultadoPregunta = ResponseMessage.MessageQuestion(pregunta);

                if (resultadoPregunta.Equals(DialogResult.OK))
                {
                    row.Cells["estado"].Value = valorCheck;

                    //_TallaParam = new SetTallaParam();

                    //_TallaParam.opcion = 3; // INHABILITAR
                    //_TallaParam.codTalla = row.Cells["ctxtCodTalla"].Value.ToString();
                    //_TallaParam.usuarioReg = UserApplication.USUARIO;
                    //_TallaParam.estado = valorCheck;
                    _pedidoParam = new SetPedidosParam();
                    _pedidoParam.opcion = 3; // ACTUALIZAR
                    _pedidoParam.estado = valorCheck;
                    _pedidoParam.idpedido = Convert.ToInt32( row.Cells["idPedido"].Value.ToString());
                    Procesar(_pedidoParam);
                }
            }
        }
    }
}
