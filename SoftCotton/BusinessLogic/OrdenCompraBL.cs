using SoftCotton.Model.PurchaseOrder;
using SoftCotton.Reports.PurchaseOrder.OrdenCompra;
using SoftCotton.Repository;
using SoftCotton.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.BusinessLogic
{
    public class OrdenCompraBL
    {
        OrdenCompraRepository _ordenCompraRepository;

        public OrdenCompraBL()
        {
            _ordenCompraRepository = new OrdenCompraRepository();
        }



        // ### GET ###
        public List<GetOC1_TipoMoneda> Get1_TipoMoneda()
        {
            return _ordenCompraRepository.Get1_TipoMoneda();
        }
        public List<GetOC2_CondPago> Get2_CondicionPago()
        {
            return _ordenCompraRepository.Get2_CondicionPago();
        }
        //public List<GetOC3_ProvClientes> Get3_ProvClientes(string filtroBusqueda)
        //{
        //    return _ordenCompraRepository.Get3_ProvClientes(filtroBusqueda);
        //}
        public GetOC4_ProductoXCod Get4_ProductoXCod(string codProducto)
        {
            return _ordenCompraRepository.Get4_ProductoXCod(codProducto);
        }
        public List<GetOC5_TipoAprobacion> Get5_TipoAprobaciones()
        {
            return _ordenCompraRepository.Get5_TipoAprobaciones();
        }
        public List<GetOC6_TipoAnulado> Get6_TipoAnulados()
        {
            return _ordenCompraRepository.Get6_TipoAnulados();
        }
        public GetOC7_OCCabXCodigo Get7_OCCabXCodigo(int idEmpresa, int idOC)
        {
            return _ordenCompraRepository.Get7_OCCabXCodigo(idEmpresa, idOC);
        }
        public List<GetOC8_OCDetXCodigo> Get8_OCDetXCodigo(int idEmpresa, int idOC)
        {
            return _ordenCompraRepository.Get8_OCDetXCodigo(idEmpresa, idOC);
        }
        public List<GetOC12_Usuarios> Get12_Usuarios(int idEmpresa)
        {
            return _ordenCompraRepository.Get12_Usuarios(idEmpresa);
        }
        public List<GetOC11_Firmantes> Get11_Firmantes(int idEmpresa)
        {
            return _ordenCompraRepository.Get11_Firmantes(idEmpresa);
        }
        public List<GetOC13_TiposAprobacion> Get13_TiposAprobacion()
        {
            return _ordenCompraRepository.Get13_TiposAprobaciones();
        }
        public List<GetOC14_Observaciones> Get14_Observaciones()
        {
            return _ordenCompraRepository.Get14_Observaciones();
        }
        public GetOC15_FirmanteXNivel Get15_FirmanteXNivel(int idUsuario, int idTipoAprobacion)
        {
            return _ordenCompraRepository.Get15_FirmanteXNivel(idUsuario, idTipoAprobacion);
        }
        public List<GetOC16_Firmantes> Get16_Firmantes(int idEmpresa, int oc)
        {
            return _ordenCompraRepository.Get16_Firmantes(idEmpresa, oc);
        }

        public List<GetOC19_Reporte> Get19_Reporte(string fechaInicio, string fechaFin)
        {
            return _ordenCompraRepository.Get19_Reporte(fechaInicio, fechaFin);
        }


        // ### REPORTE ###
        public OrdenCompraModel RpteOrdenCompra(int idEmpresa, int idOC)
        {
            OrdenCompraModel modelo = new OrdenCompraModel();

            modelo.ocCab = _ordenCompraRepository.Rpte9_OrdenCompraCabecera(idEmpresa, idOC);
            modelo.ocDet = _ordenCompraRepository.Rpte10_OrdenCompraDetalle(idEmpresa, idOC);
            modelo.ocObs = _ordenCompraRepository.Rpte17_OrdenCompraObservacion();
            modelo.ocFirmas = _ordenCompraRepository.Rpte17_OrdenCompraFirmantes(idEmpresa, idOC);
        
            return modelo;
        }

        // ### REPORTE V2 ###
        public OrdenCompraModelV2 RpteOrdenCompraV2(int idEmpresa, int idOC)
        {
            OrdenCompraModelV2 modelo = new OrdenCompraModelV2();

            modelo.ocCab = _ordenCompraRepository.Rpte9_OrdenCompraCabecera(idEmpresa, idOC);
            modelo.ocDet = _ordenCompraRepository.Rpte10_OrdenCompraDetalleV2(idEmpresa, idOC);
            modelo.ocObs = _ordenCompraRepository.Rpte17_OrdenCompraObservacion();
            modelo.ocFirmas = _ordenCompraRepository.Rpte17_OrdenCompraFirmantes(idEmpresa, idOC);

            return modelo;
        }


        // ### SET ###
        public Response SetOC(SetOCParam parametros)
        {
            return _ordenCompraRepository.SetOC(parametros);
        }
        public Response SetOCDetalle(SetOCDetParam parametros)
        {
            return _ordenCompraRepository.SetOCDetalle(parametros);
        }
        public Response SetOCTipoAprobacion(SetOCTipoAprobParam parametros)
        {
            return _ordenCompraRepository.SetOCTipoAprobacion(parametros);
        }
        public Response SetOCTipoAnulado(SetOCTipoAnuladoParam parametros)
        {
            return _ordenCompraRepository.SetOCTipoAnulado(parametros);
        }
        public Response SetOCFirmantes(SetOCFirmantesParam parametros)
        {
            return _ordenCompraRepository.SetOCFirmantes(parametros);
        }
        public Response SetOCObservacion(SetOCObservacionParam parametros)
        {
            return _ordenCompraRepository.SetOCObservacion(parametros);
        }
        public Response SetOCAprobacion(SetOCAprobacionParam parametros)
        {
            return _ordenCompraRepository.SetOCAprobacion(parametros);
        }


    }
}
