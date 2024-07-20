using SoftCotton.BusinessLogic;
using SoftCotton.Model.ReferralGuide;
using SoftCotton.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SoftCotton.Views.ReferralGuide
{
    public partial class BuscarOCGRView : Form
    {
        GuiaRemisionBL _guiaRemisionBL;

        public int _idEmpresa = 0;
        public int _codigo = 0;
        public int secuencia = 0;
        public string codNivel = "";
        public string codGrupo = "";
        public string codTalla = "";
        public string codColor = "";
        public string codProductoGeneral = "";
        public string producto = "";
        public string codCuenta = "";
        public string descripcionCta = "";
        public decimal cantidad = 0;
        public string codUM = "";
        public decimal precioUnitario = 0;
        public decimal total = 0;
        public string codigoPC = "";
        public string proveedor = "";
        public decimal cantidadSaldo = 0;
        public string _tipoOrden = "";
        public string _tipoOrdenID = "";
        public decimal cantidadIngreso = 0;
        public decimal cantidadSalida = 0;
        

        public int countMostrarFormulario = 1;

        public BuscarOCGRView(int idEmpresa, int codigoOrden, string tipoOrdenID, string titulo)
        {
            InitializeComponent();

            this.Text = titulo;

            _idEmpresa = idEmpresa;
            _codigo = codigoOrden;
            _tipoOrden = "";
            _tipoOrdenID = tipoOrdenID;

            secuencia = 0;
            codNivel = "";
            codGrupo = "";
            codTalla = "";
            codColor = "";
            codProductoGeneral = "";
            producto = "";
            cantidad = 0;
            codUM = "";
            precioUnitario = 0;
            total = 0;
            codigoPC = "";
            proveedor = "";

            cantidadIngreso = 0;
            cantidadSalida = 0;

            _guiaRemisionBL = new GuiaRemisionBL();


            //Empresa.ID_EMPRESA = 1;
        }

        private void BuscarOCGRView_Load(object sender, EventArgs e)
        {

            BuscarOrdenCompra(_idEmpresa, _codigo, _tipoOrdenID);
        }

        private void BuscarOCGRView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Hide();
            }
        }

        private void BuscarOrdenCompra(int _idEmpresa, int idOC, string tipoOrden)
        {
            List<GetGR5_OCDetalle> listaOCDetalle = _guiaRemisionBL.Get5_OCDetalle(_idEmpresa, idOC, tipoOrden);
            dgvOrdenCompra.Rows.Clear();
            decimal saldo = default(decimal);
            foreach (GetGR5_OCDetalle item in listaOCDetalle)
            {
                int index = dgvOrdenCompra.Rows.Add();
                dgvOrdenCompra.Rows[index].Cells["dgvTxtTipoId"].Value = item.tipo;
                if (item.tipo == "C")
                {
                    dgvOrdenCompra.Rows[index].Cells["dgvTxtTipo"].Value = "Orden de Compra";
                }
                else if (item.tipo == "S")
                {
                    dgvOrdenCompra.Rows[index].Cells["dgvTxtTipo"].Value = "Orden de Servicio";
                }
                else if (item.tipo == "E")
                {
                    dgvOrdenCompra.Rows[index].Cells["dgvTxtTipo"].Value = "Orden de Pedido";
                }
                else if (item.tipo == "P")
                {
                    dgvOrdenCompra.Rows[index].Cells["dgvTxtTipo"].Value = "Orden de Produccion";
                }



                dgvOrdenCompra.Rows[index].Cells["dgvIntIdEmpresa"].Value = item.idEmpresa;
                dgvOrdenCompra.Rows[index].Cells["dgvIntId"].Value = item.id;
                dgvOrdenCompra.Rows[index].Cells["dgvTxtCodPC"].Value = item.codigoPC;
                dgvOrdenCompra.Rows[index].Cells["dgvTxtPC"].Value = item.codigoPC + " - " + item.razonSocial;
                dgvOrdenCompra.Rows[index].Cells["dgvIntSecuencia"].Value = item.secuencia;
                dgvOrdenCompra.Rows[index].Cells["dgvTxtCodNivel"].Value = item.codNivel;
                dgvOrdenCompra.Rows[index].Cells["dgvTxtCodGrupo"].Value = item.codGrupo;
                dgvOrdenCompra.Rows[index].Cells["dgvTxtCodTalla"].Value = item.codTalla;
                dgvOrdenCompra.Rows[index].Cells["dgvTxtCodColor"].Value = item.codColor;
                dgvOrdenCompra.Rows[index].Cells["dgvCodigoProducto"].Value = item.codProductoGeneral;
                dgvOrdenCompra.Rows[index].Cells["dgvTxtProducto"].Value = item.producto;
                dgvOrdenCompra.Rows[index].Cells["dgvCodCuenta"].Value = item.codCuenta;
                dgvOrdenCompra.Rows[index].Cells["dgvDescripcionCta"].Value = item.descripcionCta;
                dgvOrdenCompra.Rows[index].Cells["dgvIntCantidad"].Value = item.cantidad;
                dgvOrdenCompra.Rows[index].Cells["dgvTxtCodUM"].Value = item.codUM;
                dgvOrdenCompra.Rows[index].Cells["dgvDecPrecioUnitario"].Value = item.precioUnitario;
                dgvOrdenCompra.Rows[index].Cells["dgvDecTotal"].Value = item.total;
                dgvOrdenCompra.Rows[index].Cells["dgvDecCantidadEntrada"].Value = item.cantidadEntrada;
                dgvOrdenCompra.Rows[index].Cells["dgvDecCantidadSalida"].Value = item.cantidadSalida;
                saldo = item.cantidadEntrada + item.cantidadSalida;
                if (saldo == 0)
                {
                    dgvOrdenCompra.Rows[index].DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else if (saldo > 0)
                {
                    dgvOrdenCompra.Rows[index].DefaultCellStyle.BackColor = Color.Yellow;
                }
                else if (saldo < 0)
                {
                    dgvOrdenCompra.Rows[index].DefaultCellStyle.BackColor = Color.LightCoral;
                }
                else if (item.cantidadEntrada == 0 && item.cantidadSalida == 0)
                {
                    dgvOrdenCompra.Rows[index].DefaultCellStyle.BackColor = Color.White;
                }
                dgvOrdenCompra.Rows[index].Cells["dgvIntCantidadSaldo"].Value = saldo;
            }

            if (dgvOrdenCompra.Rows.Count > 0)
            {
                dgvOrdenCompra.Focus();
                dgvOrdenCompra.Rows[0].Selected = true;
            }
        }

        private void dgvOrdenCompra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                if (dgvOrdenCompra.CurrentRow != null)
                {
                    DataGridViewRow dgr = dgvOrdenCompra.CurrentRow;
                    _tipoOrdenID = dgr.Cells["dgvTxtTipoId"].Value.ToString().Trim();
                    _tipoOrden = dgr.Cells["dgvTxtTipo"].Value.ToString().Trim();
                    _idEmpresa = Convert.ToInt32(dgr.Cells["dgvIntIdEmpresa"].Value);
                    codigoPC = dgr.Cells["dgvTxtCodPC"].Value.ToString().Trim();
                    proveedor = dgr.Cells["dgvTxtPC"].Value.ToString().Trim();
                    secuencia = Convert.ToInt32(dgr.Cells["dgvIntSecuencia"].Value);
                    codNivel = dgr.Cells["dgvTxtCodNivel"].Value.ToString().Trim();
                    codGrupo = dgr.Cells["dgvTxtCodGrupo"].Value.ToString().Trim();
                    codTalla = dgr.Cells["dgvTxtCodTalla"].Value.ToString().Trim();
                    codColor = dgr.Cells["dgvTxtCodColor"].Value.ToString().Trim();
                    codProductoGeneral = dgr.Cells["dgvCodigoProducto"].Value.ToString().Trim();
                    producto = dgr.Cells["dgvTxtProducto"].Value.ToString().Trim();
                    codCuenta = dgr.Cells["dgvCodCuenta"].Value.ToString().Trim();
                    descripcionCta = dgr.Cells["dgvDescripcionCta"].Value.ToString().Trim();
                    cantidad = Convert.ToDecimal(dgr.Cells["dgvIntCantidad"].Value);

                    cantidadIngreso = Convert.ToDecimal(dgr.Cells["dgvDecCantidadEntrada"].Value);
                    cantidadSalida = Convert.ToDecimal(dgr.Cells["dgvDecCantidadSalida"].Value);

                    cantidadSaldo = Convert.ToDecimal(dgr.Cells["dgvDecCantidadEntrada"].Value) + Convert.ToDecimal(dgr.Cells["dgvDecCantidadSalida"].Value);
                    codUM = dgr.Cells["dgvTxtCodUM"].Value.ToString().Trim();
                    precioUnitario = Convert.ToDecimal(dgr.Cells["dgvDecPrecioUnitario"].Value);
                    total = Convert.ToDecimal(dgr.Cells["dgvDecTotal"].Value);
                    VariableGeneral._sEnter = true;
                    Hide();
                }
            }
        }

      

    }
}
