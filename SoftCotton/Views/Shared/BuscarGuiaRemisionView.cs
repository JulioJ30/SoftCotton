using SoftCotton.BusinessLogic;
using SoftCotton.Model.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SoftCotton.Views.Shared
{
    public partial class BuscarGuiaRemisionView : Form
    {
        CompartidoBL _compartidoBL;

        public int IdEmpresa = 0;
        public string Tipo = "";
        public string Serie = "";
        public string Numero = "";
        public string FechaEmision = "";
        public string DestCodigoPC = "";
        public string RazonSocial = "";
        public int Secuencia = 0;
        public int IdDetOC = 0;
        public int IdSecuenciaOCDet = 0;
        public string CodNivel = "";
        public string CodGrupo = "";
        public string CodTalla = "";
        public string CodColor = "";
        public string CodProducto = "";
        public string Producto = "";
        public string CodUM = "";
        public string TipoMovimiento = "";
        public decimal CantidadIngresada = 0;
        public decimal PesoIngresado = 0;

        public int vpIdEmpresa = 0;
        public string vpSerie = "";
        public string vpNumero = "";

        public BuscarGuiaRemisionView(int pIdEmpresa, string pSerie, string pNumero)
        {
            InitializeComponent();

            vpIdEmpresa = pIdEmpresa;
            vpSerie = pSerie;
            vpNumero = pNumero;

            _compartidoBL = new CompartidoBL();
        }

        private void BuscarGuiaRemisionView_Load(object sender, EventArgs e)
        {
            BuscarGuiaRemision(vpIdEmpresa, vpSerie, vpNumero);
        }

        private void BuscarGuiaRemision(int idEmpresa, string serie, string numero)
        {
            List<GetShared4_BuscarGR> lista = _compartidoBL.Get4_BuscarGR(idEmpresa, serie, numero);

            dgvListado.Rows.Clear();

            foreach (var item in lista)
            {
                int index = dgvListado.Rows.Add();

                dgvListado.Rows[index].Cells["dgvIntIdEmpresa"].Value = item.idEmpresa;
                
                if (item.tipo == "C")
                {
                    dgvListado.Rows[index].Cells["dgvTxtTipo"].Value = "Orden de Compra";
                }
                else if (item.tipo == "S")
                {
                    dgvListado.Rows[index].Cells["dgvTxtTipo"].Value = "Orden de Servicio";
                }
                

                dgvListado.Rows[index].Cells["dgvTxtSerie"].Value = item.serie;
                dgvListado.Rows[index].Cells["dgvTxtNumero"].Value = item.numero;

                dgvListado.Rows[index].Cells["dgvTxtGrTipo"].Value = item.tipo;

                dgvListado.Rows[index].Cells["dgvTxtFechaEmision"].Value = item.fechaEmision;
                dgvListado.Rows[index].Cells["dgvTxtDestCodigoPC"].Value = item.destCodigoPC;
                dgvListado.Rows[index].Cells["dgvTxtRazonSocial"].Value = item.razonSocial;
                dgvListado.Rows[index].Cells["dgvTxtProveedor"].Value = item.destCodigoPC.Trim() + " - " + item.razonSocial.Trim();

                dgvListado.Rows[index].Cells["dgvIntSecuencia"].Value = item.secuencia;
                dgvListado.Rows[index].Cells["dgvIntIdDet"].Value = item.idDet;
                dgvListado.Rows[index].Cells["dgvIntIdSecuenciaDet"].Value = item.idSecuenciaDet;

                dgvListado.Rows[index].Cells["dgvTxtCodNivel"].Value = item.codNivel;
                dgvListado.Rows[index].Cells["dgvTxtCodGrupo"].Value = item.codGrupo;
                dgvListado.Rows[index].Cells["dgvTxtCodTalla"].Value = item.codTalla;
                dgvListado.Rows[index].Cells["dgvTxtCodColor"].Value = item.codColor;
                dgvListado.Rows[index].Cells["dgvTxtCodProducto"].Value = item.codProducto;
                dgvListado.Rows[index].Cells["dgvTxtProducto"].Value = item.producto;
                dgvListado.Rows[index].Cells["dgvTxtCodUM"].Value = item.codUM;

                if (item.tipoMovimiento == "E")
                {
                    dgvListado.Rows[index].Cells["dgvTxtTipoMovimiento"].Value = "ENTRADA";
                }
                else if (item.tipoMovimiento == "S")
                {
                    dgvListado.Rows[index].Cells["dgvTxtTipoMovimiento"].Value = "SALIDA";
                }


                dgvListado.Rows[index].Cells["dgvDecCantidadIngresada"].Value = item.cantidadIngresada;
                dgvListado.Rows[index].Cells["dgvDecPesoIngresado"].Value = item.pesoIngresado;
            }

            if (dgvListado.Rows.Count > 0)
            {
                dgvListado.Focus();
                dgvListado.Rows[0].Selected = true;


                dgvListado.AutoResizeColumns();
                dgvListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }

        private void dgvListado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                if (dgvListado.CurrentRow != null)
                {
                    DataGridViewRow dgr = dgvListado.CurrentRow;

                    IdEmpresa = Convert.ToInt32(dgr.Cells["dgvIntIdEmpresa"].Value);

                    if (IdEmpresa != 0)
                    {
                        Tipo = dgr.Cells["dgvTxtGrTipo"].Value.ToString();
                        Serie = dgr.Cells["dgvTxtSerie"].Value.ToString();
                        Numero = dgr.Cells["dgvTxtNumero"].Value.ToString();
                        FechaEmision = dgr.Cells["dgvTxtFechaEmision"].Value.ToString();
                        DestCodigoPC = dgr.Cells["dgvTxtDestCodigoPC"].Value.ToString();
                        RazonSocial = dgr.Cells["dgvTxtRazonSocial"].Value.ToString();
                        Secuencia = Convert.ToInt32(dgr.Cells["dgvIntSecuencia"].Value);
                        IdDetOC = Convert.ToInt32(dgr.Cells["dgvIntIdDet"].Value);
                        IdSecuenciaOCDet = Convert.ToInt32(dgr.Cells["dgvIntIdSecuenciaDet"].Value);
                        CodNivel = dgr.Cells["dgvTxtCodNivel"].Value.ToString();
                        CodGrupo = dgr.Cells["dgvTxtCodGrupo"].Value.ToString();
                        CodTalla = dgr.Cells["dgvTxtCodTalla"].Value.ToString();
                        CodColor = dgr.Cells["dgvTxtCodColor"].Value.ToString();
                        CodProducto = dgr.Cells["dgvTxtCodProducto"].Value.ToString();
                        Producto = dgr.Cells["dgvTxtProducto"].Value.ToString();
                        CodUM = dgr.Cells["dgvTxtCodUM"].Value.ToString();
                        TipoMovimiento = dgr.Cells["dgvTxtTipoMovimiento"].Value.ToString();
                        CantidadIngresada = Convert.ToDecimal(dgr.Cells["dgvDecCantidadIngresada"].Value);
                        PesoIngresado = Convert.ToDecimal(dgr.Cells["dgvDecPesoIngresado"].Value);
                    }

                    this.Hide();
                }

            }
        }





    }
}
