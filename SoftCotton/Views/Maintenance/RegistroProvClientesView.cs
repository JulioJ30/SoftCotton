using ClosedXML.Excel;
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
    public partial class RegistroProvClientesView : Form
    {
        MantenimientoBL _mantenimientoBL;
        SetProvClientesParam _provClientesParam;
        List<GetMant12_ProvClientes> listaProvClientes;

        public RegistroProvClientesView()
        {
            InitializeComponent();

            _mantenimientoBL = new MantenimientoBL();
            listaProvClientes = new List<GetMant12_ProvClientes>();
        }
        private void RegistroProvClientesView_Load(object sender, EventArgs e)
        {
            Listar();
            ListarTipoDocumentoCBX();
            ListarTipoRelEmpresaCBX();
            Limpiar();

            List<GetUbigeos> departamentos = new List<GetUbigeos>();
            departamentos = _mantenimientoBL.GetUbigeos(44).ToList();
            cboDepartamento.DataSource = departamentos;
            cboDepartamento.ValueMember = "iddepartamento";
            cboDepartamento.DisplayMember = "departamento";


            UserApplication.USUARIO = "JMORAN";

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
            cbxTipoDocumento.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

            List<GetMant12_ProvClientesRpte> listaProvClientesRpte = new List<GetMant12_ProvClientesRpte>();

            if (listaProvClientes.Count > 0)
            {

                foreach (var item in listaProvClientes)
                {
                    listaProvClientesRpte.Add(new GetMant12_ProvClientesRpte()
                    {
                        codigo = item.codigo,
                        codTipoDoc = item.codTipoDoc,
                        tipoDocCorta = item.tipoDocCorta,
                        razonSocial = item.razonSocial,
                        nombre1 = item.nombre1,
                        nombre2 = item.nombre2,
                        apellido1 = item.apellido1,
                        apellido2 = item.apellido2,
                        codTipoPC = item.codTipoPC,
                        tipo = item.tipo,
                        telefono = item.telefono,
                        direccion = item.direccion,
                        contacto = item.contacto,
                        email = item.email
                    });
                }

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.InitialDirectory = @"C:\";
                sfd.Title = "Guardar Archivo Como";
                sfd.Filter = "Excel |*.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(sfd.FileName))
                    {
                        ExcelReportTitulo[] arrayTitulo = new ExcelReportTitulo[14];

                        arrayTitulo[0] = new ExcelReportTitulo() { titulo = "Codigo", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
                        arrayTitulo[1] = new ExcelReportTitulo() { titulo = "Cod. Tipo Documento", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
                        arrayTitulo[2] = new ExcelReportTitulo() { titulo = "Tipo Documento", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
                        arrayTitulo[3] = new ExcelReportTitulo() { titulo = "Razon Social", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
                        arrayTitulo[4] = new ExcelReportTitulo() { titulo = "Primer Nombre", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
                        arrayTitulo[5] = new ExcelReportTitulo() { titulo = "Segundo Nombre", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
                        arrayTitulo[6] = new ExcelReportTitulo() { titulo = "Primer Apellido", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
                        arrayTitulo[7] = new ExcelReportTitulo() { titulo = "Segundo Apellido", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
                        arrayTitulo[8] = new ExcelReportTitulo() { titulo = "Cod. Tipo", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
                        arrayTitulo[9] = new ExcelReportTitulo() { titulo = "Tipo", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
                        arrayTitulo[10] = new ExcelReportTitulo() { titulo = "Telefono", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
                        arrayTitulo[11] = new ExcelReportTitulo() { titulo = "Dirección", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
                        arrayTitulo[12] = new ExcelReportTitulo() { titulo = "Contacto", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
                        arrayTitulo[13] = new ExcelReportTitulo() { titulo = "Email", backgroundColor = XLColor.LightBlue, foreColor = XLColor.Black };
                        
                        ExcelReport.GetExcelReport<GetMant12_ProvClientesRpte>(sfd.FileName, arrayTitulo, listaProvClientesRpte);

                        ResponseMessage.Message("Reporte Exportado", "INFORMATION");
                    }
                }

            }
        }



        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListado.Columns[e.ColumnIndex].Name.Equals("cbtnEditar"))
            {
                if (Convert.ToBoolean(dgvListado.Rows[e.RowIndex].Cells["cbxActivo"].Value))
                {
                    lblCodigo.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtCodigo"].Value.ToString().Trim();
                    txtCodigo.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtCodigo"].Value.ToString().Trim();
                    cbxTipoDocumento.SelectedValue = dgvListado.Rows[e.RowIndex].Cells["ctxtCodTipoDoc"].Value.ToString().Trim();
                    txtRazonSocial.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtRazonSocial"].Value.ToString().Trim();
                    txtPrimerNombre.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtNombre1"].Value.ToString().Trim();
                    txtSegundoNombre.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtNombre2"].Value.ToString().Trim();
                    txtPrimerApellido.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtApellido1"].Value.ToString().Trim();
                    txtSegundoApellido.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtApellido2"].Value.ToString().Trim();
                    cbxTipoPC.SelectedValue = dgvListado.Rows[e.RowIndex].Cells["ctxtCodTipoPC"].Value.ToString().Trim();
                    txtTelefono.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtTelefono"].Value.ToString().Trim();
                    txtDireccion.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtDireccion"].Value.ToString().Trim();
                    txtContacto.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtContacto"].Value.ToString().Trim();
                    txtEmail.Text = dgvListado.Rows[e.RowIndex].Cells["ctxtEmail"].Value.ToString().Trim();

                    // DATA
                    string iddepartamento   = dgvListado.Rows[e.RowIndex].Cells["iddepartamento"].Value.ToString().Trim();
                    string idprovincia      = dgvListado.Rows[e.RowIndex].Cells["idprovincia"].Value.ToString().Trim();
                    string iddistrito       = dgvListado.Rows[e.RowIndex].Cells["iddistrito"].Value.ToString().Trim();


                    // DEPARTMAMENTO
                    cboDepartamento.SelectedValue = iddepartamento;


                    // PROVINCIA
                    List<GetUbigeos> provincias = new List<GetUbigeos>();
                    string filtro = iddepartamento;
                    provincias = _mantenimientoBL.GetUbigeos(45, filtro).ToList();
                    cboProvincia.DataSource = provincias;
                    cboProvincia.ValueMember = "idprovincia";
                    cboProvincia.DisplayMember = "provincia";
                    cboProvincia.SelectedValue = idprovincia;

                    // DISTRITOS
                    List<GetUbigeos> distritos = new List<GetUbigeos>();
                    string filtro2 = idprovincia;
                    distritos = _mantenimientoBL.GetUbigeos(46, filtro2).ToList();
                    cboDistrito.DataSource = distritos;
                    cboDistrito.ValueMember = "iddistrito";
                    cboDistrito.DisplayMember = "distrito";
                    cboDistrito.SelectedValue = iddistrito;


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
                    string codigo = dgvListado.Rows[e.RowIndex].Cells["ctxtCodigo"].Value.ToString();
                    DialogResult pregunta = ResponseMessage.MessageQuestion("¿Desea eliminar el registro permanentemente?");

                    if (pregunta.Equals(DialogResult.OK))
                    {
                        _provClientesParam = new SetProvClientesParam();
                        _provClientesParam.opcion = 4; // ELIMINAR 
                        _provClientesParam.codigo = codigo;
                        _provClientesParam.usuarioReg = UserApplication.USUARIO;

                        Procesar(_provClientesParam);
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

                    _provClientesParam = new SetProvClientesParam();

                    _provClientesParam.opcion = 3; // INHABILITAR
                    _provClientesParam.codTipoDoc = row.Cells["ctxtCodTipoDoc"].Value.ToString();
                    _provClientesParam.usuarioReg = UserApplication.USUARIO;
                    _provClientesParam.estado = valorCheck;

                    Procesar(_provClientesParam);
                }
            }
        }




        // ### Funciones ###
        public void ListarTipoDocumentoCBX()
        {
            List<GetMant13_TipoDoc> cbxTipoDocList = _mantenimientoBL.GetMant13_TipoDoc();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = cbxTipoDocList;

            cbxTipoDocumento.DisplayMember = "tipoDocCorta";
            cbxTipoDocumento.ValueMember = "codTipoDoc";
            cbxTipoDocumento.DataSource = bindingSource.DataSource;
        }

        public void ListarTipoRelEmpresaCBX()
        {
            List<GetMant14_RelEmpresas> cbxRelEmpresaList = _mantenimientoBL.GetMant14_RelEmpresas();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = cbxRelEmpresaList;

            cbxTipoPC.DisplayMember = "tipo";
            cbxTipoPC.ValueMember = "codTipoPC";
            cbxTipoPC.DataSource = bindingSource.DataSource;
        }




        public void Guardar()
        {
            if (ValidarDatos())
            {
                _provClientesParam = new SetProvClientesParam();

                if (!string.IsNullOrEmpty(lblCodigo.Text))
                {
                    _provClientesParam.opcion = 2; // ACTUALIZAR 

                    _provClientesParam.codigo = lblCodigo.Text;
                    _provClientesParam.codigoUpdate = txtCodigo.Text;
                    _provClientesParam.codTipoDoc = cbxTipoDocumento.SelectedValue.ToString();
                    _provClientesParam.razonSocial = txtRazonSocial.Text.Trim();
                    _provClientesParam.nombre1 = txtPrimerNombre.Text.Trim();
                    _provClientesParam.nombre2 = txtSegundoNombre.Text.Trim();
                    _provClientesParam.apellido1 = txtPrimerApellido.Text.Trim();
                    _provClientesParam.apellido2 = txtSegundoApellido.Text.Trim();
                    _provClientesParam.codTipoPC = cbxTipoPC.SelectedValue.ToString();
                    _provClientesParam.telefono = txtTelefono.Text;
                    _provClientesParam.direccion = txtDireccion.Text;
                    _provClientesParam.contacto = txtContacto.Text;
                    _provClientesParam.email = txtEmail.Text;
                    _provClientesParam.iddistrito = cboDistrito.SelectedValue.ToString();


                    _provClientesParam.usuarioReg = UserApplication.USUARIO; // UserApplication.USUARIO;
                }
                else
                {
                    _provClientesParam.opcion = 1; // REGISTRAR

                    _provClientesParam.codigo = txtCodigo.Text;
                    _provClientesParam.codTipoDoc = cbxTipoDocumento.SelectedValue.ToString();
                    _provClientesParam.razonSocial = txtRazonSocial.Text.Trim();
                    _provClientesParam.nombre1 = txtPrimerNombre.Text.Trim();
                    _provClientesParam.nombre2 = txtSegundoNombre.Text.Trim();
                    _provClientesParam.apellido1 = txtPrimerApellido.Text.Trim();
                    _provClientesParam.apellido2 = txtSegundoApellido.Text.Trim();
                    _provClientesParam.codTipoPC = cbxTipoPC.SelectedValue.ToString();
                    _provClientesParam.telefono = txtTelefono.Text;
                    _provClientesParam.direccion = txtDireccion.Text;
                    _provClientesParam.contacto = txtContacto.Text;
                    _provClientesParam.email = txtEmail.Text;
                    _provClientesParam.iddistrito = cboDistrito.SelectedValue.ToString();


                    _provClientesParam.usuarioReg = UserApplication.USUARIO; // UserApplication.USUARIO;
                }

                Procesar(_provClientesParam);
            }
        }

        public void Procesar(SetProvClientesParam parametro)
        {
            Response responseGeneral = _mantenimientoBL.SetProvClientes(parametro);

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
            listaProvClientes = _mantenimientoBL.GetMant12_ProvClientes();

            dgvListado.Rows.Clear();

            foreach (var item in listaProvClientes)
            {
                int index = dgvListado.Rows.Add();

                dgvListado.Rows[index].Cells["ctxtCodigo"].Value = item.codigo;
                dgvListado.Rows[index].Cells["ctxtCodTipoDoc"].Value = item.codTipoDoc;
                dgvListado.Rows[index].Cells["ctxtTipoDocCorta"].Value = item.tipoDocCorta;
                dgvListado.Rows[index].Cells["ctxtRazonSocial"].Value = item.razonSocial;
                dgvListado.Rows[index].Cells["ctxtNombre1"].Value = item.nombre1;
                dgvListado.Rows[index].Cells["ctxtNombre2"].Value = item.nombre2;
                dgvListado.Rows[index].Cells["ctxtApellido1"].Value = item.apellido1;
                dgvListado.Rows[index].Cells["ctxtApellido2"].Value = item.apellido2;
                dgvListado.Rows[index].Cells["ctxtCodTipoPC"].Value = item.codTipoPC;
                dgvListado.Rows[index].Cells["ctxtTipo"].Value = item.tipo;
                dgvListado.Rows[index].Cells["ctxtTelefono"].Value = item.telefono;
                dgvListado.Rows[index].Cells["ctxtDireccion"].Value = item.direccion;

                dgvListado.Rows[index].Cells["ctxtFechaReg"].Value = item.fechaReg;
                dgvListado.Rows[index].Cells["ctxtUsuarioReg"].Value = item.usuarioReg;

                dgvListado.Rows[index].Cells["ctxtContacto"].Value = item.contacto;
                dgvListado.Rows[index].Cells["ctxtEmail"].Value = item.email;

                dgvListado.Rows[index].Cells["iddistrito"].Value = item.iddistrito;
                dgvListado.Rows[index].Cells["distrito"].Value = item.distrito;
                dgvListado.Rows[index].Cells["idprovincia"].Value = item.idprovincia;
                dgvListado.Rows[index].Cells["provincia"].Value = item.provincia;
                dgvListado.Rows[index].Cells["iddepartamento"].Value = item.iddepartamento;
                dgvListado.Rows[index].Cells["departamento"].Value = item.departamento;


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

            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese el código", "INFORMATION");
                txtCodigo.Focus();
            }
            else if (cbxTipoDocumento.SelectedValue.ToString().Trim() == "00")
            {
                validacion = false;

                ResponseMessage.Message("Seleccione el tipo de Documento", "INFORMATION");
                cbxTipoDocumento.Focus();
            }
            else if (string.IsNullOrEmpty(txtRazonSocial.Text))
            {
                validacion = false;

                ResponseMessage.Message("Ingrese la Razón Social", "INFORMATION");
                txtRazonSocial.Focus();
            }
            else if (cbxTipoPC.SelectedValue.ToString().Trim() == "0")
            {
                validacion = false;

                ResponseMessage.Message("Seleccione el Tipo - (Tipo de Relación con la Empresa)", "INFORMATION");
                cbxTipoPC.Focus();
            }
            else
            {
                validacion = true;
            }

            return validacion;
        }

        public void Limpiar()
        {
            txtCodigo.Text = "";
            cbxTipoDocumento.SelectedValue = "00";
            txtRazonSocial.Text = "";
            txtPrimerNombre.Text = "";
            txtSegundoNombre.Text = "";
            txtPrimerApellido.Text = "";
            txtSegundoApellido.Text = "";
            cbxTipoPC.SelectedValue = "0";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtContacto.Text = "";
            txtEmail.Text = "";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cboDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

        private void cboDepartamento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            List<GetUbigeos> provincias = new List<GetUbigeos>();
            string filtro = cboDepartamento.SelectedValue.ToString();
            provincias = _mantenimientoBL.GetUbigeos(45, filtro).ToList();
            cboProvincia.DataSource = provincias;
            cboProvincia.ValueMember = "idprovincia";
            cboProvincia.DisplayMember = "provincia";
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void cboProvincia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            List<GetUbigeos> distritos = new List<GetUbigeos>();
            string filtro = cboProvincia.SelectedValue.ToString();
            distritos = _mantenimientoBL.GetUbigeos(46, filtro).ToList();
            cboDistrito.DataSource = distritos;
            cboDistrito.ValueMember = "iddistrito";
            cboDistrito.DisplayMember = "distrito";
        }
    }
}
