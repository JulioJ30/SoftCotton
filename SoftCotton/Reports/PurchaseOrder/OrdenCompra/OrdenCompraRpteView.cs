using Microsoft.Reporting.WinForms;
using SoftCotton.BusinessLogic;
using SoftCotton.Util;
using System;
using System.IO;
using System.Windows.Forms;

namespace SoftCotton.Reports.PurchaseOrder.OrdenCompra
{
    public partial class OrdenCompraRpteView : Form
    {
        OrdenCompraModel modelo;
        OrdenCompraBL _ordenCompraBL;
        int _ordenCompra;

        public OrdenCompraRpteView(int ordenCompra)
        {
            InitializeComponent();

            modelo = new OrdenCompraModel();
            _ordenCompraBL = new OrdenCompraBL();
            _ordenCompra = ordenCompra;
        }

        private void OrdenCompraRpteView_Load(object sender, EventArgs e)
        {
            ObtenerModelo(Empresa.ID_EMPRESA, _ordenCompra);

            Cursor = Cursors.Default;
        }


        private void ObtenerModelo(int idEmpresa, int idOC)
        {
            modelo = _ordenCompraBL.RpteOrdenCompra(idEmpresa, idOC);

            if (modelo.ocCab.codigoOC != null && modelo.ocCab.codigoOC != "")
            {
                CrearReporte(modelo);
            }
            else
            {
                ResponseMessage.Message("No existe orden de compra", "WARNING");
            }
        }

        private void CrearReporte(OrdenCompraModel pModelo)
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

            foreach (var itemFirma in pModelo.ocFirmas)
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

            foreach (var item in pModelo.ocObs)
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

                new ReportParameter("pEmpresaRUC", pModelo.ocCab.empresaRUC),
                new ReportParameter("pEmpresaDireccion", pModelo.ocCab.empresaDireccion),
                new ReportParameter("pCodigoOC","OC - " + pModelo.ocCab.codigoOC),
                new ReportParameter("pFechaEmision", pModelo.ocCab.fechaEmision),
                new ReportParameter("pFechaEntrega", pModelo.ocCab.fechaEntrega),

                new ReportParameter("pProveedorRS",pModelo.ocCab.proveedorRS),
                new ReportParameter("pProveedorRUC",pModelo.ocCab.proveedorRUC),
                new ReportParameter("pProveedorDireccion",pModelo.ocCab.proveedorDireccion),
                new ReportParameter("pContacto",pModelo.ocCab.contacto),
                new ReportParameter("pTelefono",pModelo.ocCab.telefono),
                new ReportParameter("pEmail",pModelo.ocCab.email),
                
                new ReportParameter("pTipoMoneda",pModelo.ocCab.tipoMoneda),
                new ReportParameter("pTipoCompra",pModelo.ocCab.tipoCompra),
                new ReportParameter("pFormaPago",pModelo.ocCab.formaPago),
                new ReportParameter("pTipoCambio",pModelo.ocCab.tipoCambio),

                new ReportParameter("pSubTotal", pModelo.ocCab.simbolo + "" + pModelo.ocCab.subTotal),
                new ReportParameter("pDescuento", pModelo.ocCab.simbolo + "" + pModelo.ocCab.descuento),
                new ReportParameter("pBaseImponible", pModelo.ocCab.simbolo + "" + pModelo.ocCab.baseImponible),
                new ReportParameter("pIGV", pModelo.ocCab.simbolo + "" + pModelo.ocCab.igv),
                new ReportParameter("pTotal", pModelo.ocCab.simbolo + "" + pModelo.ocCab.total),

                new ReportParameter("pMontoLetras",pModelo.ocCab.montoLetras),
                new ReportParameter("pObservacion","Observación: " + pModelo.ocCab.observacion),
                
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
                new ReportParameter("pPrograma", pModelo.ocCab.programa)

            };


            foreach (var det in pModelo.ocDet)
            {
                if (det.obs1.Trim() == "" && det.obs2.Trim() == "" && det.obs3.Trim() == "" && det.obs4.Trim() == "" && det.obs5.Trim() == "")
                {
                    det.producto = det.producto;


                }
                else if (det.obs1.Trim() != "" && det.obs2.Trim() == "" && det.obs3.Trim() == "" && det.obs4.Trim() == "" && det.obs5.Trim() == "")
                {
                    det.producto = det.producto + Environment.NewLine + det.obs1;
                }
                else if (det.obs1.Trim() == "" && det.obs2.Trim() != "" && det.obs3.Trim() == "" && det.obs4.Trim() == "" && det.obs5.Trim() == "")
                {
                    det.producto = det.producto + Environment.NewLine + det.obs2;
                }
                else if (det.obs1.Trim() == "" && det.obs2.Trim() == "" && det.obs3.Trim() != "" && det.obs4.Trim() == "" && det.obs5.Trim() == "")
                {
                    det.producto = det.producto + Environment.NewLine + det.obs3;
                }
                else if (det.obs1.Trim() == "" && det.obs2.Trim() == "" && det.obs3.Trim() == "" && det.obs4.Trim() != "" && det.obs5.Trim() == "")
                {
                    det.producto = det.producto + Environment.NewLine + det.obs4;
                }
                else if (det.obs1.Trim() == "" && det.obs2.Trim() == "" && det.obs3.Trim() == "" && det.obs4.Trim() == "" && det.obs5.Trim() != "")
                {
                    det.producto = det.producto + Environment.NewLine + det.obs5;




                }
                else if (det.obs1.Trim() != "" && det.obs2.Trim() != "" && det.obs3.Trim() == "" && det.obs4.Trim() == "" && det.obs5.Trim() == "")
                {
                    det.producto = det.producto + Environment.NewLine + det.obs1 + Environment.NewLine + det.obs2;
                }
                else if (det.obs1.Trim() == "" && det.obs2.Trim() != "" && det.obs3.Trim() != "" && det.obs4.Trim() == "" && det.obs5.Trim() == "")
                {
                    det.producto = det.producto + Environment.NewLine + det.obs2 + Environment.NewLine + det.obs3;
                }
                else if (det.obs1.Trim() == "" && det.obs2.Trim() == "" && det.obs3.Trim() != "" && det.obs4.Trim() != "" && det.obs5.Trim() == "")
                {
                    det.producto = det.producto + Environment.NewLine + det.obs3 + Environment.NewLine + det.obs4;
                }
                else if (det.obs1.Trim() == "" && det.obs2.Trim() == "" && det.obs3.Trim() == "" && det.obs4.Trim() != "" && det.obs5.Trim() != "")
                {
                    det.producto = det.producto + Environment.NewLine + det.obs4 + Environment.NewLine + det.obs5;



                }
                else if (det.obs1.Trim() != "" && det.obs2.Trim() == "" && det.obs3.Trim() != "" && det.obs4.Trim() == "" && det.obs5.Trim() == "")
                {
                    det.producto = det.producto + Environment.NewLine + det.obs1 + Environment.NewLine + det.obs3;
                }
                else if (det.obs1.Trim() != "" && det.obs2.Trim() == "" && det.obs3.Trim() == "" && det.obs4.Trim() != "" && det.obs5.Trim() == "")
                {
                    det.producto = det.producto + Environment.NewLine + det.obs1 + Environment.NewLine + det.obs4;
                }
                else if (det.obs1.Trim() != "" && det.obs2.Trim() == "" && det.obs3.Trim() == "" && det.obs4.Trim() == "" && det.obs5.Trim() != "")
                {
                    det.producto = det.producto + Environment.NewLine + det.obs1 + Environment.NewLine + det.obs5;



                }
                else if (det.obs1.Trim() == "" && det.obs2.Trim() != "" && det.obs3.Trim() == "" && det.obs4.Trim() != "" && det.obs5.Trim() == "")
                {
                    det.producto = det.producto + Environment.NewLine + det.obs2 + Environment.NewLine + det.obs4;
                }
                else if (det.obs1.Trim() == "" && det.obs2.Trim() != "" && det.obs3.Trim() == "" && det.obs4.Trim() == "" && det.obs5.Trim() != "")
                {
                    det.producto = det.producto + Environment.NewLine + det.obs2 + Environment.NewLine + det.obs5;



                }
                else if (det.obs1.Trim() == "" && det.obs2.Trim() == "" && det.obs3.Trim() != "" && det.obs4.Trim() == "" && det.obs5.Trim() != "")
                {
                    det.producto = det.producto + Environment.NewLine + det.obs3 + Environment.NewLine + det.obs5;



                }
                else if (det.obs1.Trim() != "" && det.obs2.Trim() != "" && det.obs3.Trim() != "" && det.obs4.Trim() == "" && det.obs5.Trim() == "")
                {
                    det.producto = det.producto + Environment.NewLine + det.obs1 + Environment.NewLine + det.obs2 + Environment.NewLine + det.obs3;
                }
                else if (det.obs1.Trim() == "" && det.obs2.Trim() != "" && det.obs3.Trim() != "" && det.obs4.Trim() != "" && det.obs5.Trim() == "")
                {
                    det.producto = det.producto + Environment.NewLine + det.obs2 + Environment.NewLine + det.obs3 + Environment.NewLine + det.obs4;
                }
                else if (det.obs1.Trim() == "" && det.obs2.Trim() == "" && det.obs3.Trim() != "" && det.obs4.Trim() != "" && det.obs5.Trim() != "")
                {
                    det.producto = det.producto + Environment.NewLine + det.obs3 + Environment.NewLine + det.obs4 + Environment.NewLine + det.obs5;



                }
                else if (det.obs1.Trim() != "" && det.obs2.Trim() != "" && det.obs3.Trim() != "" && det.obs4.Trim() != "" && det.obs5.Trim() == "")
                {
                    det.producto = det.producto + Environment.NewLine + det.obs1 + Environment.NewLine + det.obs2 + Environment.NewLine + det.obs3 + Environment.NewLine + det.obs4;
                }
                else if (det.obs1.Trim() == "" && det.obs2.Trim() != "" && det.obs3.Trim() != "" && det.obs4.Trim() != "" && det.obs5.Trim() != "")
                {
                    det.producto = det.producto + Environment.NewLine + det.obs2 + Environment.NewLine + det.obs3 + Environment.NewLine + det.obs4 + Environment.NewLine + det.obs5;



                }
                else if (det.obs1.Trim() != "" && det.obs2.Trim() != "" && det.obs3.Trim() != "" && det.obs4.Trim() != "" && det.obs5.Trim() != "")
                {
                    det.producto = det.producto + Environment.NewLine
                                     + det.obs1 + Environment.NewLine
                                     + det.obs2 + Environment.NewLine
                                     + det.obs3 + Environment.NewLine
                                     + det.obs4 + Environment.NewLine
                                     + det.obs5;
                }


            }

            this.OrdenCompraReportViewer.Visible = true;
            
            var reportDataSource = new ReportDataSource("dsOrdenCompraDetalle", pModelo.ocDet);

            this.OrdenCompraReportViewer.LocalReport.DataSources.Clear();

            this.OrdenCompraReportViewer.LocalReport.DataSources.Add(reportDataSource);
            this.OrdenCompraReportViewer.LocalReport.EnableExternalImages = true;
            this.OrdenCompraReportViewer.LocalReport.SetParameters(p);
            this.OrdenCompraReportViewer.RefreshReport();
        }

        private void OrdenCompraRpteView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cursor = Cursors.Default;
        }
    }
}
