
using SoftCotton.Model.PurchaseOrder;
using SoftCotton.Model.ServiceOrder;
using SoftCotton.Reports.ServiceOrder.OrdenServicio;
using SoftCotton.Repository;
using SoftCotton.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SoftCotton.BusinessLogic
{
    public class OrdenServicioBL
    {
        OrdenServicioRepository _ordenServicioRepository;

        public OrdenServicioBL()
        {
            _ordenServicioRepository = new OrdenServicioRepository();
        }



        // ### GET ###
        public List<GetOC1_TipoMoneda> Get1_TipoMoneda()
        {
            return _ordenServicioRepository.Get1_TipoMoneda();
        }
        public List<GetOC2_CondPago> Get2_CondicionPago()
        {
            return _ordenServicioRepository.Get2_CondicionPago();
        }
        //public List<GetOC3_ProvClientes> Get3_ProvClientes(string filtroBusqueda)
        //{
        //    return _ordenServicioRepository.Get3_ProvClientes(filtroBusqueda);
        //}
        public GetOC4_ProductoXCod Get4_ProductoXCod(string codProducto)
        {
            return _ordenServicioRepository.Get4_ProductoXCod(codProducto);
        }


        public List<GetOS5_TipoAprobacion> Get5_TipoAprobaciones()
        {
            return _ordenServicioRepository.Get5_TipoAprobaciones();
        }
        public List<GetOS6_TipoAnulado> Get6_TipoAnulados()
        {
            return _ordenServicioRepository.Get6_TipoAnulados();
        }
        public GetOS7_OSCabXCodigo Get7_OCCabXCodigo(int idEmpresa, int idOC)
        {
            return _ordenServicioRepository.Get7_OCCabXCodigo(idEmpresa, idOC);
        }
        public GetOS7_OSCabXCodigo Get26_OCCabXCodigo(int idEmpresa, int idOrdenSalida)
        {
            return _ordenServicioRepository.Get26_OCCabXCodigo(idEmpresa, idOrdenSalida);
        }

        public GetOS7_OSCabXCodigo Get7_OCCabXCodigoEspecial(int idEmpresa, int idOC)
        {
            return _ordenServicioRepository.Get7_OCCabXCodigoEspecial(idEmpresa, idOC);
        }

        public DataTable Get7_OCDeetXCodigoEspecial(int idEmpresa, int idOC)
        {
            return _ordenServicioRepository.Get7_OCDeetXCodigoEspecial(idEmpresa, idOC);
        }

        public List<GetOS8_OSDetXCodigo> Get8_OSDetXCodigo(int idEmpresa, int idOC)
        {
            return _ordenServicioRepository.Get8_OSDetXCodigo(idEmpresa, idOC);
        }

        public List<GetOS8_OSDetXCodigo> Get27_OSDetXCodigo(int idEmpresa, int idOC)
        {
            return _ordenServicioRepository.Get27_OSDetXCodigo(idEmpresa, idOC);
        }


        public List<GetOC12_Usuarios> Get12_Usuarios(int idEmpresa)
        {
            return _ordenServicioRepository.Get12_Usuarios(idEmpresa);
        }
        public List<GetOS11_Firmantes> Get11_Firmantes(int idEmpresa)
        {
            return _ordenServicioRepository.Get11_Firmantes(idEmpresa);
        }
        public List<GetOC13_TiposAprobacion> Get13_TiposAprobacion()
        {
            return _ordenServicioRepository.Get13_TiposAprobaciones();
        }
        public List<GetOS14_Observaciones> Get14_Observaciones()
        {
            return _ordenServicioRepository.Get14_Observaciones();
        }
        public GetOS15_FirmanteXNivel Get15_FirmanteXNivel(int idUsuario, int idTipoAprobacion)
        {
            return _ordenServicioRepository.Get15_FirmanteXNivel(idUsuario, idTipoAprobacion);
        }
        public List<GetOS16_Firmantes> Get16_Firmantes(int idEmpresa, int oc)
        {
            return _ordenServicioRepository.Get16_Firmantes(idEmpresa, oc);
        }
        public List<GetOS19_Reporte> Get19_Reporte(string fechaInicio, string fechaFin)
        {
            return _ordenServicioRepository.Get19_Reporte(fechaInicio, fechaFin);
        }


        // ### REPORTE ###
        public OrdenServicioModel RpteOrdenServicio(int idEmpresa, int idOC)
        {
            OrdenServicioModel modelo = new OrdenServicioModel();

            modelo.osCab = _ordenServicioRepository.Rpte9_OrdenServicioCabecera(idEmpresa, idOC);
            modelo.osDet = _ordenServicioRepository.Rpte10_OrdenServicioDetalle(idEmpresa, idOC);
            modelo.osObs = _ordenServicioRepository.Rpte17_OrdenServicioObservacion();
            modelo.osFirmas = _ordenServicioRepository.Rpte17_OrdenServicioFirmantes(idEmpresa, idOC);

            return modelo;
        }


        public OrdenServicioModelV2 RpteOrdenServicioV2(int idEmpresa, int idOC)
        {
            OrdenServicioModelV2 modelo = new OrdenServicioModelV2();


            modelo.osCab = _ordenServicioRepository.Rpte9_OrdenServicioCabeceraV2(idEmpresa, idOC);
            modelo.osDet = _ordenServicioRepository.Rpte10_OrdenServicioDetalleV2(idEmpresa, idOC);
            modelo.osObs = _ordenServicioRepository.Rpte17_OrdenServicioObservacion();
            modelo.osFirmas = _ordenServicioRepository.Rpte25_OrdenServicioFirmantes(idEmpresa, idOC);

            return modelo;
        }


        // ### SET ###
        public Response SetOS(SetOSParam parametros)
        {
            return _ordenServicioRepository.SetOS(parametros);
        }

        public Response SetOrdenSalida(SetOSParam parametros, string almacen)
        {
            return _ordenServicioRepository.SetOrdenSalida(parametros, almacen);
        }
        public Response SetOSEspecial(SetOSParam parametros)
        {
            return _ordenServicioRepository.SetOSEspecial(parametros);
        }

        public Response SetOSDetalle(SetOSDetParam parametros)
        {
            return _ordenServicioRepository.SetOSDetalle(parametros);
        }


     
        public Response SetOrdenSalidaDetalle(SetOSDetParam parametros)
        {
            return _ordenServicioRepository.SetOrdenSalidaDetalle(parametros);
        }


        public Response SetOSTipoAprobacion(SetOSTipoAprobParam parametros)
        {
            return _ordenServicioRepository.SetOSTipoAprobacion(parametros);
        }
        public Response SetOSTipoAnulado(SetOSTipoAnuladoParam parametros)
        {
            return _ordenServicioRepository.SetOSTipoAnulado(parametros);
        }
        public Response SetOSFirmantes(SetOSFirmantesParam parametros)
        {
            return _ordenServicioRepository.SetOSFirmantes(parametros);
        }
        public Response SetOSObservacion(SetOSObservacionParam parametros)
        {
            return _ordenServicioRepository.SetOSObservacion(parametros);
        }
        public Response SetOSAprobacion(SetOSAprobacionParam parametros)
        {
            return _ordenServicioRepository.SetOSAprobacion(parametros);
        }

        public Response SetOrdenSalidaAprobacion(SetOSAprobacionParam parametros, string tipoOrden)
        {
            return _ordenServicioRepository.SetOrdenSalidaAprobacion(parametros, tipoOrden);
        }
    }
}
