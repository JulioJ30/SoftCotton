using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SoftCotton.Model.Maintenance;
using SoftCotton.BusinessLogic;
using SoftCotton.Util;
using System.Data;
using System;
using excel = Microsoft.Office.Interop.Excel;

namespace SoftCotton.Views.Maintenance
{
    public partial class RegistroCatalogoNubefactView : Form
    {
        MantenimientoBL _mantenimientoBL;
        int inicio = 1;
        int final = 0;
        int totalmostrar = 150;
        int pagindice = 0;
        bool cargado = false;


        public RegistroCatalogoNubefactView()
        {
            InitializeComponent();

            _mantenimientoBL = new MantenimientoBL();


        }

        private void RegistroCatalogoNubefactView_Load(object sender, EventArgs e)
        {



            // UNIDAD MEDIDA
            DataGridViewComboBoxColumn comboboxColumn = dgvLista.Columns["codUm"] as DataGridViewComboBoxColumn;
            List<GetMant19_UMCBX> unidadesMed = _mantenimientoBL.Get19_UMCBX();

            comboboxColumn.DataSource = unidadesMed;
            comboboxColumn.DisplayMember = "descripcion";
            comboboxColumn.ValueMember = "codUM";

            // CATEGORIAS
            DataGridViewComboBoxColumn comboboxColumn_ca = dgvLista.Columns["idCategoria"] as DataGridViewComboBoxColumn;
            List<GetMant43_Categorias> categori = _mantenimientoBL.GetMant43_Categorias();

            comboboxColumn_ca.DataSource = categori;
            comboboxColumn_ca.DisplayMember = "descripcionCategoria";
            comboboxColumn_ca.ValueMember = "idCategoria";

            // CARGAMOS DATAGRID
            final = totalmostrar;
            Listar();

            cargado = true;
        }

        public void Listar()
        {

            string filtro = txtFiltro.Text.Trim();
            List<GetMant42_CatalogoNubeFact> lista = _mantenimientoBL.GetMant42_CatalogoNubeFact(inicio,final,filtro);
            //dgvLista.DataSource = lista;
            dgvLista.Rows.Clear();
            int total = 0;
            foreach (var item in lista)
            {
                int index = dgvLista.Rows.Add();

                total = item.total;
                dgvLista.Rows[index].Cells["codigoInterno"].Value               = item.codigoInterno;
                dgvLista.Rows[index].Cells["idCategoria"].Value                 = item.idCategoria;
                dgvLista.Rows[index].Cells["codUm"].Value                       = item.codUm;
                dgvLista.Rows[index].Cells["codMoneda"].Value                   = item.codMoneda;
                dgvLista.Rows[index].Cells["descripcionCatalogo"].Value         = item.descripcionCatalogo;
                dgvLista.Rows[index].Cells["ventaValorUnitarioSinIgv"].Value    = item.ventaValorUnitarioSinIgv;
                dgvLista.Rows[index].Cells["ventaPrecioUnitarioIgv"].Value      = item.ventaPrecioUnitarioIgv;
                dgvLista.Rows[index].Cells["compraValorUnitarioSinIgv"].Value   = item.compraValorUnitarioSinIgv;
                dgvLista.Rows[index].Cells["compraPrecioUnitarioIgv"].Value     = item.compraPrecioUnitarioIgv;
                dgvLista.Rows[index].Cells["destacado"].Value                   = item.destacado;
                dgvLista.Rows[index].Cells["tipoAfectacionIgv"].Value           = item.tipoAfectacionIgv;
                dgvLista.Rows[index].Cells["codProductoSunat"].Value            = item.codProductoSunat;
                dgvLista.Rows[index].Cells["stockActualDisponible"].Value       = item.stockActualDisponible;

            }

            txtnumero.Text = total.ToString();
            dgvLista.ClearSelection();

            int cantidad = total / totalmostrar;
            cboPaginacion.Items.Clear();

            if (cantidad % totalmostrar > 0)
            {
                cantidad++;
            }
            txtde.Text = cantidad.ToString();
            cboPaginacion.Items.Clear();
            for (int x = 1; x <= cantidad; x++)
            {
                cboPaginacion.Items.Add(x.ToString());
            }


            if (pagindice > 0)
            {
                cboPaginacion.SelectedIndex = pagindice;

            }

        }

        private void btnCargarArchivo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Cargar Excel";


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                excel.Application xlApp = new excel.Application();
                excel.Workbook xlWorkbook = xlApp.Workbooks.Open(filePath);
                excel._Worksheet xlWorksheet = (excel._Worksheet)xlWorkbook.Sheets[1];
                excel.Range xlRange = xlWorksheet.UsedRange;

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;


                List<GetMant42_CatalogoNubeFact> detalle = new List<GetMant42_CatalogoNubeFact>();

                // CARGAMOS DATA EN LISTA
                for (int x = 2; x < rowCount; x++)
                {

                    string cellCodigoInterno             = "A" + x.ToString();
                    string cellDescripcion               = "B" + x.ToString();
                    string celldaUnidadMedida            = "C" + x.ToString();
                    string cellMoneda                    = "D" + x.ToString();
                    string cellVentaValorUnitario        = "E" + x.ToString();
                    string cellVentaPrecioUnitarioIGV    = "F" + x.ToString();
                    string cellCompraValorUnitario       = "G" + x.ToString();
                    string cellCompraPrecioUnitarioIGV   = "H" + x.ToString();
                    string cellDestacado                 = "I" + x.ToString();
                    string cellTipoAfectacion            = "J" + x.ToString();
                    string cellIdCategoria               = "K" + x.ToString();
                    string cellCodigoProductoSunat       = "M" + x.ToString();
                    string cellStockActualDisponible     = "N" + x.ToString();

                    excel.Range cCodigoInterno              = xlWorksheet.Range[cellCodigoInterno];
                    excel.Range cDescripcion                = xlWorksheet.Range[cellDescripcion];
                    excel.Range cUnidadMedida               = xlWorksheet.Range[celldaUnidadMedida];
                    excel.Range cMoneda                     = xlWorksheet.Range[cellMoneda];
                    excel.Range cVentaValorUnitario         = xlWorksheet.Range[cellVentaValorUnitario];
                    excel.Range cVentaPrecioUnitarioIGV     = xlWorksheet.Range[cellVentaPrecioUnitarioIGV];
                    excel.Range cCompraValorUnitario        = xlWorksheet.Range[cellCompraValorUnitario];
                    excel.Range cCompraPrecioUnitarioIGV    = xlWorksheet.Range[cellCompraPrecioUnitarioIGV];
                    excel.Range cDestacado                  = xlWorksheet.Range[cellDestacado];
                    excel.Range cTipoAfectacion             = xlWorksheet.Range[cellTipoAfectacion];
                    excel.Range cIdCategoria                = xlWorksheet.Range[cellIdCategoria];
                    excel.Range cCodigoProductoSUNAT        = xlWorksheet.Range[cellCodigoProductoSunat];
                    excel.Range cStockActualDisponible      = xlWorksheet.Range[cellStockActualDisponible];


                    if (cCodigoInterno.Value != null)
                    {

                        //GetMant42_CatalogoNubeFact item = new GetMant42_CatalogoNubeFact();

                        SetCalagoNumbeFactParam item = new SetCalagoNumbeFactParam();
                        item.opcion = 1;
                        item.codigoInterno          = cCodigoInterno.Value.ToString().Trim();
                        item.descripcionCatalogo    = cDescripcion.Value.ToString().Trim();
                        item.codUm                  = cUnidadMedida.Value.ToString().Trim();
                        item.codMoneda              = cMoneda.Value.ToString().Trim();

                        if (cVentaValorUnitario.Value != null)
                        {
                            item.ventaValorUnitarioSinIgv = Convert.ToDecimal(cVentaValorUnitario.Value.ToString().Trim());
                        }else
                        {
                            item.ventaValorUnitarioSinIgv = null;
                        }

                        if (cVentaPrecioUnitarioIGV.Value != null)
                        {
                            item.ventaPrecioUnitarioIgv = Convert.ToDecimal(cVentaPrecioUnitarioIGV.Value.ToString().Trim());
                        }
                        else
                        {
                            item.ventaPrecioUnitarioIgv = null;
                        }

                        if (cCompraValorUnitario.Value != null)
                        {
                            item.compraValorUnitarioSinIgv = Convert.ToDecimal(cCompraValorUnitario.Value.ToString().Trim());
                        }else
                        {
                            item.compraValorUnitarioSinIgv = null;
                        }

                        if (cCompraPrecioUnitarioIGV.Value != null)
                        {
                            item.compraPrecioUnitarioIgv = Convert.ToDecimal(cCompraPrecioUnitarioIGV.Value.ToString().Trim());
                        }else
                        {
                            item.compraPrecioUnitarioIgv = null;
                        }

                        item.destacado = cDestacado.Value.ToString().Trim();
                        item.tipoAfectacionIgv = cTipoAfectacion.Value.ToString().Trim();
                        if (cIdCategoria.Value != null)
                        {
                            if (cIdCategoria.Value.ToString().Trim() != "-")
                            {
                                item.idCategoria = Convert.ToInt32(cIdCategoria.Value.ToString().Trim());
                            }
                            else
                            {
                                item.idCategoria = null;
                            }
                            //item.idCategoria =  ? Convert.ToInt32(cIdCategoria.Value.ToString().Trim()) : null;
                        }else
                        {
                            item.idCategoria = null;
                        }
                        item.codProductoSunat = cCodigoProductoSUNAT.Value != null ? cCodigoProductoSUNAT.Value.ToString().Trim() : "";
                        item.stockActualDisponible = Convert.ToDecimal(cStockActualDisponible.Value.ToString().Trim());

                        // REALIZAMOS REGISTROS
                        _mantenimientoBL.SetCatalogoNubeFact(item);

                        //detalle.Add(item);
                    }
                }

                // TRAEMOS DATOS DE NUEVO
                Listar();
                // REGISTRAMOS DETALLE
                //string siu = "siu";

                // ASIGANMOS DATA DE LISTA A DATAGRID
                //foreach (var item in detalle)
                //{
                //    int index = dgvGRDetalle.Rows.Add();


                //    dgvGRDetalle.Rows[index].Cells["codigoProducto"].Value = item.codigoProducto;
                //    dgvGRDetalle.Rows[index].Cells["dgvTxtProducto"].Value = item.descripcion;
                //    dgvGRDetalle.Rows[index].Cells["dgvDecCantidad"].Value = item.cantidadIngresada;
                //    dgvGRDetalle.Rows[index].Cells["dgvTxtUnidadMedida"].Value = item.codUM;
                //    dgvGRDetalle.Rows[index].Cells["Secuencia"].Value = item.secuencia;
                //}

            }
        }

        private void dgvLista_RowLeave(object sender, DataGridViewCellEventArgs e)
        {

            int index = e.RowIndex;

            SetCalagoNumbeFactParam item = new SetCalagoNumbeFactParam();

            // CODIGO INTERNO
            if (dgvLista.Rows[index].Cells["codigoInterno"].Value != null)
                item.codigoInterno = dgvLista.Rows[index].Cells["codigoInterno"].Value.ToString().Trim();
            else
                item.codigoInterno = null;

            // ID CATEGORIA
            if (dgvLista.Rows[index].Cells["idCategoria"].Value != null)
                item.idCategoria = Convert.ToInt32(dgvLista.Rows[index].Cells["idCategoria"].Value.ToString().Trim());
            else
                item.idCategoria = null;

            // COD UM
            if (dgvLista.Rows[index].Cells["codUm"].Value != null)
                item.codUm = dgvLista.Rows[index].Cells["codUm"].Value.ToString().Trim();
            else
                item.codUm = null;

            // COD MONEDA
            if (dgvLista.Rows[index].Cells["codMoneda"].Value != null)
                item.codMoneda = dgvLista.Rows[index].Cells["codMoneda"].Value.ToString().Trim();
            else
                item.codMoneda = null;

            // DESCRIPCION CATALOGO
            if (dgvLista.Rows[index].Cells["descripcionCatalogo"].Value != null)
                item.descripcionCatalogo = dgvLista.Rows[index].Cells["descripcionCatalogo"].Value.ToString().Trim();
            else
                item.descripcionCatalogo = null;

            // DESCRIPCION CATALOGO
            if (dgvLista.Rows[index].Cells["ventaValorUnitarioSinIgv"].Value != null)
                item.ventaValorUnitarioSinIgv = Convert.ToDecimal(dgvLista.Rows[index].Cells["ventaValorUnitarioSinIgv"].Value.ToString().Trim());
            else
                item.ventaValorUnitarioSinIgv = null;

            // DESCRIPCION CATALOGO
            if (dgvLista.Rows[index].Cells["ventaPrecioUnitarioIgv"].Value != null)
                item.ventaPrecioUnitarioIgv = Convert.ToDecimal(dgvLista.Rows[index].Cells["ventaPrecioUnitarioIgv"].Value.ToString().Trim());
            else
                item.ventaPrecioUnitarioIgv = null;

            // DESCRIPCION CATALOGO
            if (dgvLista.Rows[index].Cells["compraValorUnitarioSinIgv"].Value != null)
                item.compraValorUnitarioSinIgv = Convert.ToDecimal(dgvLista.Rows[index].Cells["compraValorUnitarioSinIgv"].Value.ToString().Trim());
            else
                item.compraValorUnitarioSinIgv = null;

            // DESCRIPCION CATALOGO
            if (dgvLista.Rows[index].Cells["compraPrecioUnitarioIgv"].Value != null)
                item.compraPrecioUnitarioIgv = Convert.ToDecimal(dgvLista.Rows[index].Cells["compraPrecioUnitarioIgv"].Value.ToString().Trim());
            else
                item.compraPrecioUnitarioIgv = null;

            // DESCRIPCION CATALOGO
            if (dgvLista.Rows[index].Cells["destacado"].Value != null)
                item.destacado = dgvLista.Rows[index].Cells["destacado"].Value.ToString().Trim();
            else
                item.destacado = null;

            // DESCRIPCION CATALOGO
            if (dgvLista.Rows[index].Cells["tipoAfectacionIgv"].Value != null)
                item.tipoAfectacionIgv = dgvLista.Rows[index].Cells["tipoAfectacionIgv"].Value.ToString().Trim();
            else
                item.tipoAfectacionIgv = null;

            // DESCRIPCION CATALOGO
            if (dgvLista.Rows[index].Cells["codProductoSunat"].Value != null)
                item.codProductoSunat = dgvLista.Rows[index].Cells["codProductoSunat"].Value.ToString().Trim();
            else
                item.codProductoSunat = null;

            // DESCRIPCION CATALOGO
            if (dgvLista.Rows[index].Cells["stockActualDisponible"].Value != null)
                item.stockActualDisponible = Convert.ToDecimal(dgvLista.Rows[index].Cells["stockActualDisponible"].Value.ToString().Trim());
            else
                item.stockActualDisponible = 0;

            bool validacionMensaje = true;


            if (item.codigoInterno == null)
            {
                ResponseMessage.Message("El codigo interno no puede set nulo","WARNING");
                validacionMensaje = false;
            }

            if (validacionMensaje)
            {
                item.opcion = 1;

                if (item.idCategoria == 0)
                {
                    item.idCategoria = null;
                }

                var response =   _mantenimientoBL.SetCatalogoNubeFact(item);
                if (response.idResponse == 0)
                {
                    ResponseMessage.Message(response.messageResponse, response.typeMessage);
                }
            }

            //MessageBox.Show(indice.ToString());
        }

        private void cboPaginacion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int pagina = Convert.ToInt32(cboPaginacion.Text);
            pagindice = pagina - 1;
            inicio = (pagina - 1) * totalmostrar + 1;
            final = pagina * totalmostrar;
            Listar();
        }

        private void cboPaginacion_SelectedIndexChanged(object sender, EventArgs e)
        {

            //if (cargado)
            //{
            //    int pagina = Convert.ToInt32(cboPaginacion.Text);
            //    pagindice = pagina - 1;
            //    inicio = (pagina - 1) * totalmostrar + 1;
            //    final = pagina * totalmostrar;
            //    Listar();
            //}
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Listar();
        }
    }
}
