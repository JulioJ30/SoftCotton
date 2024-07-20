using SoftCotton.Model.ReferralGuide;
using SoftCotton.Repository;
using SoftCotton.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.BusinessLogic
{
    public class GuiaRemisionBL
    {
        GuiaRemisionRepository _guiaRemisionRepository;

        public GuiaRemisionBL()
        {
            _guiaRemisionRepository = new GuiaRemisionRepository();
        }

        // ### GET ###
        public List<GetGR1_Motivo> Get1_Motivo()
        {
            return _guiaRemisionRepository.Get1_Motivo();
        }
        public GetGR2_CabeceraXCod Get2_CabeceraXCod(int idEmpresa, string serie, string numero, string tipoorden)
        {
            return _guiaRemisionRepository.Get2_CabeceraXCod(idEmpresa, serie, numero, tipoorden);
        }
        public List<GetGR3_DetalleXCod> Get3_DetalleXCod(int idEmpresa, string serie, string numero, string tipoOrden)
        {
            return _guiaRemisionRepository.Get3_DetalleXCod(idEmpresa, serie, numero, tipoOrden);
        }
        public List<GetGR4_TipoCptes> Get4_TipoCptes()
        {
            return _guiaRemisionRepository.Get4_TipoCptes();
        }
        public List<GetGR5_OCDetalle> Get5_OCDetalle(int idEmpresa, int idOC, string tipoOrden)
        {
            return _guiaRemisionRepository.Get5_OCDetalle(idEmpresa, idOC, tipoOrden);
        }   
        public List<GetGR6_RpteGROC> Get6_RpteGROC(string fechaInicio, string fechaFin, string codigoProducto)
        {
            return _guiaRemisionRepository.Get6_RpteGROC(fechaInicio, fechaFin, codigoProducto);
        }
        public List<GetGR7_CierrePeriodo> GetGR7_CierrePeriodo()
        {
            return _guiaRemisionRepository.GetGR7_CierrePeriodo();
        }

        public List<GetGR9_DetalleSalidaIngreso> GetGRDetalleSalidaIngreso(int idoc, string tipomovimiento, int secuencia, string tipoorden)
        {
            return _guiaRemisionRepository.GetGRDetalleSalidaIngreso(idoc, tipomovimiento, secuencia, tipoorden);
        }


        // ### SET ###
        public Response SetGRCabecera(SetGRCabParam parametros)
        {
            return _guiaRemisionRepository.SetGRCabecera(parametros);
        }
        public Response SetGRDetalle(SetGRDetParam parametros)
        {
            return _guiaRemisionRepository.SetGRDetalle(parametros);
        }
        public Response SetGRMotivoTraslado(SetGRMotTraslado parametros)
        {
            return _guiaRemisionRepository.SetGRMotivoTraslado(parametros);
        }
        public Response SetCierrePeriodo(SetCierrePeriodoParam parametros)
        {
            return _guiaRemisionRepository.SetCierrePeriodo(parametros);
        }
        public Response SetValidarPeriodo(string periodo)
        {
            return _guiaRemisionRepository.SetValidarPeriodo(periodo);
        }
    }
}
