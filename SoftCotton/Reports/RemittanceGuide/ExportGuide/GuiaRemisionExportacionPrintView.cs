using Microsoft.Reporting.WinForms;
using SoftCotton.BusinessLogic;
using SoftCotton.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SoftCotton.Reports.RemittanceGuide.ExportGuide
{
    public partial class GuiaRemisionExportacionPrintView : Form
    {
        GuiaRemisionExportacionModel modelo;
        GuiaRemisionExportacionBL _guiaRemisionBL;
        
        string _ruc;
        string _serie;
        string _numero;

        public GuiaRemisionExportacionPrintView(string ruc, string serie, string numero)
        {
            InitializeComponent();

            modelo = new GuiaRemisionExportacionModel();
            _guiaRemisionBL = new GuiaRemisionExportacionBL();

            _ruc = ruc;
            _serie = serie;
            _numero = numero;
            
        }

        private void GuiaRemisionExportacionPrintView_Load(object sender, EventArgs e)
        {
            ObtenerModelo(Empresa.ID_EMPRESA, _ruc, _serie, _numero);
            Cursor = Cursors.Default;
        }

        private void ObtenerModelo(int idEmpresa, string ruc, string serie, string numero)
        {
            modelo = _guiaRemisionBL.RpteGuiaRemisionExportacion(idEmpresa, serie, numero, ruc);

            CrearReporte(modelo);
        }

        private void CrearReporte(GuiaRemisionExportacionModel pModelo)
        {
            string directorioBase = AppDomain.CurrentDomain.BaseDirectory;
            decimal total_cantidad = 0;

            string m1 = "";
            string m2 = "";
            string m3 = "";
            string m4 = "";
            string m5 = "";
            string m6 = "";
            string m7 = "";
            string m8 = "";
            string m9 = "";
            string m10 = "";
            string m11 = "";
            string m12 = "";
            string m13 = "";
            
            // 1. Logo Empresa
            string rutaImgEmpresa = string.Format("{0}Resources\\icono-oc.jpg", Path.GetFullPath(Path.Combine(directorioBase, @"..\..\")));
            if (!File.Exists(rutaImgEmpresa))
            {
                rutaImgEmpresa = string.Format("{0}Resources\\icono-oc-default.png", Path.GetFullPath(Path.Combine(directorioBase, @"..\..\")));
            }
            string ImgEmpresaURIAbsoluto = new Uri(rutaImgEmpresa).AbsoluteUri;

            foreach (var det in pModelo.greDet)
            {
                total_cantidad += det.cantidadIngresada;
            }

            if (pModelo.greCab.idMotivoTraslado == 1)
            {
                m1 = "X";
            }
            else if (pModelo.greCab.idMotivoTraslado == 2)
            {
                m2 = "X";
            }
            else if (pModelo.greCab.idMotivoTraslado == 3)
            {
                m3 = "X";
            }
            else if (pModelo.greCab.idMotivoTraslado == 4)
            {
                m4 = "X";
            }
            else if (pModelo.greCab.idMotivoTraslado == 5)
            {
                m5 = "X";
            }
            else if (pModelo.greCab.idMotivoTraslado == 6)
            {
                m6 = "X";
            }
            else if (pModelo.greCab.idMotivoTraslado == 7)
            {
                m7 = "X";
            }
            else if (pModelo.greCab.idMotivoTraslado == 8)
            {
                m8 = "X";
            }
            //else if (pModelo.greCab.idMotivoTraslado == 9)
            //{
            //    m9 = "X";
            //}
            //else if (pModelo.greCab.idMotivoTraslado == 10)
            //{
            //    m10 = "X";
            //}
            //else if (pModelo.greCab.idMotivoTraslado == 11)
            //{
            //    m11 = "X";
            //}
            //else if (pModelo.greCab.idMotivoTraslado == 12)
            //{
            //    m12 = "X";
            //}
            //else if (pModelo.greCab.idMotivoTraslado == 13)
            //{
            //    m13 = "X";
            //}


            ReportParameter[] p = new ReportParameter[]
            {
                new ReportParameter("pEmpresaImagePath", ImgEmpresaURIAbsoluto),

                new ReportParameter("pRUC", pModelo.greCab.ruc.ToString().Trim()),
                new ReportParameter("pSerie", pModelo.greCab.serie.ToString().Trim()),
                new ReportParameter("pNumero", pModelo.greCab.numero.ToString().Trim()),
                new ReportParameter("pFechaEmision", pModelo.greCab.fechaEmision.ToString().Trim()),
                new ReportParameter("pPuntoPartida", pModelo.greCab.puntoPartida.ToString().Trim()),
                new ReportParameter("pPuntoLlegada", pModelo.greCab.puntoLlegada.ToString().Trim()),
                new ReportParameter("pFechaInicioTraslado", pModelo.greCab.fechaInicioTraslado.ToString().Trim()),
                new ReportParameter("pRSDestinatario", pModelo.greCab.destRS.ToString().Trim()),

                new ReportParameter("pRUCDestinatario", pModelo.greCab.destCodigoPC.ToString().Trim()),

                new ReportParameter("pMarcaPlaca", pModelo.greCab.transMarca.ToString().Trim()),

                new ReportParameter("pConstanciaInscripcion", pModelo.greCab.constanciaInscripcion.ToString().Trim()),
                new ReportParameter("pLicenciaConducir", pModelo.greCab.numeroLicenciaConducir.ToString().Trim()),

                new ReportParameter("pNombreTransporte", pModelo.greCab.transRS.ToString().Trim()),
                new ReportParameter("pRUCTransporte", pModelo.greCab.transCodigoPC.ToString().Trim()),

                new ReportParameter("pTotalCantidad", total_cantidad.ToString().Trim()),
                new ReportParameter("pPrecinto", pModelo.greCab.precinto.ToString().Trim()),
                new ReportParameter("pNumeroContenedor", pModelo.greCab.numero_contenedor.ToString().Trim()),
                new ReportParameter("pPrecintoAduana", pModelo.greCab.precinto_aduana.ToString().Trim()),
                new ReportParameter("pPrecintoLinea", pModelo.greCab.precinto_linea.ToString().Trim()),

                new ReportParameter("pTotal", pModelo.greCab.total.ToString().Trim() + " " + pModelo.greCab.total_um.ToString().Trim()),
                new ReportParameter("pGrossWeight", pModelo.greCab.gross_weight.ToString().Trim() + " " + pModelo.greCab.gross_weight_um.ToString().Trim()),
                new ReportParameter("pNetWeight", pModelo.greCab.net_weight.ToString().Trim() + " " + pModelo.greCab.net_weight_um.ToString().Trim()),

                new ReportParameter("pMotivo1", m1),
                new ReportParameter("pMotivo2", m2),
                new ReportParameter("pMotivo3", m3),
                new ReportParameter("pMotivo4", m4),
                new ReportParameter("pMotivo5", m5),
                new ReportParameter("pMotivo6", m6),
                new ReportParameter("pMotivo7", m7),
                new ReportParameter("pMotivo8", m8),
                new ReportParameter("pMotivo9", m9),
                new ReportParameter("pMotivo10", m10),
                new ReportParameter("pMotivo11", m11),
                new ReportParameter("pMotivo12", m12),
                new ReportParameter("pMotivo13", m13),
                
            };


            this.guiaRemisionReportViewer.Visible = true;

            var reportDataSource = new ReportDataSource("dsGuiaRemisionExportacion", pModelo.greDet);

            this.guiaRemisionReportViewer.LocalReport.DataSources.Clear();
            this.guiaRemisionReportViewer.LocalReport.DataSources.Add(reportDataSource);

            this.guiaRemisionReportViewer.LocalReport.EnableExternalImages = true;
            this.guiaRemisionReportViewer.LocalReport.SetParameters(p);

            this.guiaRemisionReportViewer.RefreshReport();
        }

        private void GuiaRemisionExportacionPrintView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cursor = Cursors.Default;
        }
    }
}
