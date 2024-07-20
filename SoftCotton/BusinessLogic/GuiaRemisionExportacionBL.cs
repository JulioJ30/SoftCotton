using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoftCotton.Util;
using SoftCotton.Model.ReferralGuide;
using SoftCotton.Repository;
using System.Data;
using SoftCotton.Reports.RemittanceGuide.ExportGuide;

namespace SoftCotton.BusinessLogic
{
    public class GuiaRemisionExportacionBL
    {
        private GuiaRemisionExportacionRepository _guiaRemisionExportacionRepository;

        public GuiaRemisionExportacionBL()
        {
            _guiaRemisionExportacionRepository = new GuiaRemisionExportacionRepository();
        }

        public GetGR2_CabeceraXCod Get2_CabeceraXCod(int idEmpresa, string serie, string numero, string ruc)
        {
            return _guiaRemisionExportacionRepository.Get2_CabeceraXCod(idEmpresa, serie, numero, ruc);
        }

        public List<GetGR3_DetalleXCod> Get3_DetalleXCod(int idEmpresa, string serie, string numero, string ruc)
        {
            return _guiaRemisionExportacionRepository.Get3_DetalleXCod(idEmpresa, serie, numero, ruc);
        }

        public DataTable Get8_ReporteExportacion(string filtro1, string filtro2, string filtro3, string filtro4)
        {
            return _guiaRemisionExportacionRepository.Get8_ReporteExportacion(filtro1, filtro2, filtro3, filtro4);
        }

        public GuiaRemisionExportacionModel RpteGuiaRemisionExportacion(int idEmpresa, string serie, string numero, string ruc)
        {
            GuiaRemisionExportacionModel modelo = new GuiaRemisionExportacionModel();
            modelo.greCab = _guiaRemisionExportacionRepository.Get7_GRExportacionCab(idEmpresa, serie, numero, ruc);
            modelo.greDet = _guiaRemisionExportacionRepository.Get8_GRExportacionDet(idEmpresa, serie, numero, ruc);
            return modelo;
        }

        public Response SetGRCabeceraExportacion(SetGRCabExportacionParam parametros)
        {
            return _guiaRemisionExportacionRepository.SetGRCabeceraExportacion(parametros);
        }

        public Response SetGRDetalleExportacion(SetGRDetExportacionParam parametros)
        {
            return _guiaRemisionExportacionRepository.SetGRDetalleExportacion(parametros);
        }
    }
}
