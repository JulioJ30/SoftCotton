using SoftCotton.BusinessLogic;
using SoftCotton.Model.Kardex;
using SoftCotton.Model.Maintenance;
using SoftCotton.Util;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SoftCotton.Views.Kardex
{
    public partial class CuadreKardexView : Form
    {
        KardexBL _kardexBL;
        MantenimientoBL _mantenimientoBL;
        CuadreKardexParam _cuadreParam;

        public CuadreKardexView()
        {
            InitializeComponent();

            _kardexBL = new KardexBL();
            _mantenimientoBL = new MantenimientoBL();
        }

        private void CuadreKardexView_Load(object sender, EventArgs e)
        {
            ListarNivelCBX();
            ListarTipoAjusteCBX();
            Limpiar();
            Listar();
        }

        public void ListarNivelCBX()
        {
            List<GetMant16_NivelCBX> cbxNivelList = _mantenimientoBL.Get16_NivelCBX();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = cbxNivelList;

            cbxNivel.DisplayMember = "nivel";
            cbxNivel.ValueMember = "codNivel";
            cbxNivel.DataSource = bindingSource.DataSource;
        }

        public void ListarTipoAjusteCBX()
        {
            List<TipoAjusteItem> lista = new List<TipoAjusteItem>
            {
                new TipoAjusteItem { codigo = "E", descripcion = "SUMAR" },
                new TipoAjusteItem { codigo = "S", descripcion = "RESTAR" }
            };
            var bindingSource = new BindingSource();
            bindingSource.DataSource = lista;

            cbxTipoAjuste.DisplayMember = "descripcion";
            cbxTipoAjuste.ValueMember = "codigo";
            cbxTipoAjuste.DataSource = bindingSource.DataSource;
            cbxTipoAjuste.SelectedIndex = -1;
        }

        private class TipoAjusteItem
        {
            public string codigo { get; set; }
            public string descripcion { get; set; }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        public void Guardar()
        {
            if (!ValidarDatos())
            {
                return;
            }

            _cuadreParam = new CuadreKardexParam();
            _cuadreParam.opcion = 1; // REGISTRAR
            _cuadreParam.codNivel = cbxNivel.SelectedValue.ToString();
            _cuadreParam.codGrupo = txtGrupo.Text.Trim();
            _cuadreParam.codTalla = txtTalla.Text.Trim();
            _cuadreParam.codColor = txtColor.Text.Trim();
            _cuadreParam.tipoAjuste = cbxTipoAjuste.SelectedValue.ToString();
            _cuadreParam.cantidad = decimal.Parse(txtCantidad.Text.Trim());
            _cuadreParam.fechaMovimiento = dtpFechaMovimiento.Value.ToString("yyyyMMdd");
            _cuadreParam.usuarioReg = UserApplication.USUARIO;

            Procesar(_cuadreParam);
        }

        public void Procesar(CuadreKardexParam parametro)
        {
            Response response = _kardexBL.SetCuadreKardex(parametro);

            if (response.idResponse > 0)
            {
                Limpiar();
                Listar();
            }

            ResponseMessage.Message(response.messageResponse, response.typeMessage);
        }

        public void Listar()
        {
            List<GetCuadreKardex> lista = _kardexBL.GetListCuadreKardex();

            dgvListado.Rows.Clear();

            foreach (var item in lista)
            {
                int index = dgvListado.Rows.Add();

                dgvListado.Rows[index].Cells["ctxtIdCuadre"].Value = item.idCuadre;
                dgvListado.Rows[index].Cells["ctxtCodigo"].Value = item.codNivel + "." + item.codGrupo + "." + item.codTalla + "." + item.codColor;
                dgvListado.Rows[index].Cells["ctxtArticulo"].Value = item.grupo + " - " + item.color;
                dgvListado.Rows[index].Cells["ctxtTipoAjuste"].Value = item.tipoAjusteDescripcion;
                dgvListado.Rows[index].Cells["ctxtCantidad"].Value = item.cantidad;
                dgvListado.Rows[index].Cells["ctxtFechaMovimiento"].Value = item.fechaMovimiento.ToString("dd/MM/yyyy");
                dgvListado.Rows[index].Cells["ctxtUsuarioReg"].Value = item.usuarioReg;
                dgvListado.Rows[index].Cells["ctxtFechaReg"].Value = item.fechaReg;
            }

            lblCantRegistros.Text = "Cantidad de Registros: " + dgvListado.Rows.Count.ToString();
            dgvListado.ClearSelection();
        }

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (dgvListado.Columns[e.ColumnIndex].Name.Equals("cbtnEliminar"))
            {
                int idCuadre = Convert.ToInt32(dgvListado.Rows[e.RowIndex].Cells["ctxtIdCuadre"].Value);
                DialogResult pregunta = ResponseMessage.MessageQuestion("¿Desea eliminar este cuadre permanentemente?");

                if (pregunta.Equals(DialogResult.OK))
                {
                    _cuadreParam = new CuadreKardexParam();
                    _cuadreParam.opcion = 4; // ELIMINAR
                    _cuadreParam.idCuadre = idCuadre;
                    _cuadreParam.usuarioReg = UserApplication.USUARIO;

                    Procesar(_cuadreParam);
                }
            }
        }

        private bool ValidarDatos()
        {
            if (cbxNivel.SelectedValue == null)
            {
                ResponseMessage.Message("Seleccione el nivel/categoría", "INFORMATION");
                cbxNivel.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtGrupo.Text.Trim()))
            {
                ResponseMessage.Message("Ingrese el código de grupo del producto", "INFORMATION");
                txtGrupo.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtTalla.Text.Trim()))
            {
                ResponseMessage.Message("Ingrese el código de talla del producto", "INFORMATION");
                txtTalla.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtColor.Text.Trim()))
            {
                ResponseMessage.Message("Ingrese el código de color del producto", "INFORMATION");
                txtColor.Focus();
                return false;
            }

            if (cbxTipoAjuste.SelectedValue == null)
            {
                ResponseMessage.Message("Seleccione el tipo de ajuste (Sumar/Restar)", "INFORMATION");
                cbxTipoAjuste.Focus();
                return false;
            }

            decimal cantidad;
            if (!decimal.TryParse(txtCantidad.Text.Trim(), out cantidad) || cantidad <= 0)
            {
                ResponseMessage.Message("Ingrese una cantidad válida, mayor a cero", "INFORMATION");
                txtCantidad.Focus();
                return false;
            }

            return true;
        }

        public void Limpiar()
        {
            txtGrupo.Text = "";
            txtTalla.Text = "";
            txtColor.Text = "";
            txtCantidad.Text = "";
            cbxTipoAjuste.SelectedIndex = -1;
            dtpFechaMovimiento.Value = DateTime.Now;
        }
    }
}
