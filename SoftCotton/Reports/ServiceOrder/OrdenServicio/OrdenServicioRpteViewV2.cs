using Microsoft.Reporting.WinForms;
using SoftCotton.BusinessLogic;
using SoftCotton.Util;
using System;
using System.IO;
using System.Windows.Forms;


namespace SoftCotton.Reports.ServiceOrder.OrdenServicio
{
    public partial class OrdenServicioRpteViewV2 : Form
    {
        OrdenServicioModelV2 modelo;
        OrdenServicioBL _ordenServicioBL;
        int _ordenServicio;

        public OrdenServicioRpteViewV2(int ordenServicio)
        {
            InitializeComponent();

            modelo = new OrdenServicioModelV2();
            _ordenServicioBL = new OrdenServicioBL();
            _ordenServicio = ordenServicio;

        }

        private void OrdenServicioRpteViewV2_Load(object sender, EventArgs e)
        {
            ObtenerModelo(Empresa.ID_EMPRESA, _ordenServicio);
            Cursor = Cursors.Default;
        }


        private void ObtenerModelo(int idEmpresa, int idOC)
        {
            modelo = _ordenServicioBL.RpteOrdenServicioV2(idEmpresa, idOC);

            if (modelo.osCab.codigoOS != null && modelo.osCab.codigoOS != "")
            {
                CrearReporte(modelo);
            }
            else
            {
                ResponseMessage.Message("No existe orden de compra", "WARNING");
            }
        }


        private void CrearReporte(OrdenServicioModelV2 pModelo)
        {
            int contador = 1;
            string directorioBase = AppDomain.CurrentDomain.BaseDirectory;

            // 1. Logo Empresa
            string rutaImgEmpresa = string.Format("{0}Resources\\icono-oc.jpg", Path.GetFullPath(Path.Combine(directorioBase, @"..\..\")));
            if (!File.Exists(rutaImgEmpresa))
            {
                rutaImgEmpresa = string.Format("{0}Resources\\icono-oc-default.png", Path.GetFullPath(Path.Combine(directorioBase, @"..\..\")));
            }
            string ImgEmpresaURIAbsoluto = new Uri(rutaImgEmpresa).AbsoluteUri;


            // 2. Firmas
            string primeraFirma = "-";
            string imgFirma1URIAbsoluto = new Uri(string.Format("{0}Resources\\icono-oc-default.png", Path.GetFullPath(Path.Combine(directorioBase, @"..\..\")))).AbsoluteUri;

            string segundaFirma = "-";
            string imgFirma2URIAbsoluto = new Uri(string.Format("{0}Resources\\icono-oc-default.png", Path.GetFullPath(Path.Combine(directorioBase, @"..\..\")))).AbsoluteUri;

            foreach (var itemFirma in pModelo.osFirmas)
            {
                if (itemFirma.nivelAprobacion == 1)
                {
                    primeraFirma = itemFirma.firmante;
                    if (File.Exists(itemFirma.rutaImgFirma))
                    {
                        imgFirma1URIAbsoluto = new Uri(itemFirma.rutaImgFirma).AbsoluteUri;
                    }
                }
                else if (itemFirma.nivelAprobacion == 2)
                {
                    segundaFirma = itemFirma.firmante;
                    if (File.Exists(itemFirma.rutaImgFirma))
                    {
                        imgFirma2URIAbsoluto = new Uri(itemFirma.rutaImgFirma).AbsoluteUri;
                    }
                }
            }


            string observacion1 = "";
            string observacion2 = "";
            string observacion3 = "";
            string observacion4 = "";
            string observacion5 = "";
            string observacion6 = "";
            string observacion7 = "";

            string observacion = "";
            contador = 1;

            foreach (var item in pModelo.osObs)
            {
                if (string.IsNullOrEmpty(item.observacion))
                {
                    observacion = "";
                }
                else
                {
                    observacion = item.observacion;
                }


                if (contador == 1)
                {
                    observacion1 = observacion;
                }
                else if (contador == 2)
                {
                    observacion2 = observacion;
                }
                else if (contador == 3)
                {
                    observacion3 = observacion;
                }
                else if (contador == 4)
                {
                    observacion4 = observacion;
                }
                else if (contador == 5)
                {
                    observacion5 = observacion;
                }
                else if (contador == 6)
                {
                    observacion6 = observacion;
                }
                else if (contador == 7)
                {
                    observacion7 = observacion;
                }

                contador++;
            }


            ReportParameter[] p = new ReportParameter[]
            {
                new ReportParameter("pEmpresaImagePath", ImgEmpresaURIAbsoluto),

                new ReportParameter("pEmpresaRUC", pModelo.osCab.empresaRUC),
                new ReportParameter("pEmpresaDireccion", pModelo.osCab.empresaDireccion),
                new ReportParameter("pCodigoOS","OS - " + pModelo.osCab.codigoOS),
                new ReportParameter("pFechaEmision", pModelo.osCab.fechaEmision),
                new ReportParameter("pFechaEntrega", pModelo.osCab.fechaEntrega),

                new ReportParameter("pProveedorRS",pModelo.osCab.proveedorRS),
                new ReportParameter("pProveedorRUC",pModelo.osCab.proveedorRUC),
                new ReportParameter("pProveedorDireccion",pModelo.osCab.proveedorDireccion),
                new ReportParameter("pContacto",pModelo.osCab.contacto),
                new ReportParameter("pTelefono",pModelo.osCab.telefono),
                new ReportParameter("pEmail",pModelo.osCab.email),

                new ReportParameter("pTipoMoneda",pModelo.osCab.tipoMoneda),
                new ReportParameter("pTipoCompra",pModelo.osCab.tipoCompra),
                new ReportParameter("pFormaPago",pModelo.osCab.formaPago),
                new ReportParameter("pTipoCambio",pModelo.osCab.tipoCambio),

                new ReportParameter("pSubTotal", pModelo.osCab.simbolo + "" + pModelo.osCab.subTotal),
                new ReportParameter("pDescuento", pModelo.osCab.simbolo + "" + pModelo.osCab.descuento),
                new ReportParameter("pBaseImponible", pModelo.osCab.simbolo + "" + pModelo.osCab.baseImponible),
                new ReportParameter("pIGV", pModelo.osCab.simbolo + "" + pModelo.osCab.igv),
                new ReportParameter("pTotal", pModelo.osCab.simbolo + "" + pModelo.osCab.total),

                new ReportParameter("pMontoLetras", pModelo.osCab.montoLetras),
                new ReportParameter("pObservacion", "Observación: " + pModelo.osCab.observacion),

                new ReportParameter("pObservacion1", observacion1),
                new ReportParameter("pObservacion2", observacion2),
                new ReportParameter("pObservacion3", observacion3),
                new ReportParameter("pObservacion4", observacion4),
                new ReportParameter("pObservacion5", observacion5),
                new ReportParameter("pObservacion6", observacion6),
                new ReportParameter("pObservacion7", observacion7),

                new ReportParameter("pPrimeraFirma", primeraFirma),
                new ReportParameter("pPrimeraFirmaImgPath", imgFirma1URIAbsoluto),

                new ReportParameter("pSegundaFirma", segundaFirma),
                new ReportParameter("pSegundaFirmaImgPath", imgFirma2URIAbsoluto),

                new ReportParameter("pPrograma", pModelo.osCab.programa),
                new ReportParameter("pServicio", pModelo.osCab.servicio),

            };


            this.OrdenServicioReportViewer.Visible = true;

            var reportDataSource = new ReportDataSource("dsOrdenServicioDetalle", pModelo.osDet);

            this.OrdenServicioReportViewer.LocalReport.DataSources.Clear();

            this.OrdenServicioReportViewer.LocalReport.DataSources.Add(reportDataSource);
            this.OrdenServicioReportViewer.LocalReport.EnableExternalImages = true;
            this.OrdenServicioReportViewer.LocalReport.SetParameters(p);

            this.OrdenServicioReportViewer.RefreshReport();
        }



        private void OrdenServicioRpteViewV2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cursor = Cursors.Default;
        }
    }
}
