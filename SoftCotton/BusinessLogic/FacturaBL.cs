using SoftCotton.Model.Invoices;
using SoftCotton.Repository;
using SoftCotton.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.BusinessLogic
{
    public class FacturaBL
    {
        FacturaRepository _facturaRepository;

        public FacturaBL()
        {
            _facturaRepository = new FacturaRepository();
        }

        // ### GET ###
        public List<GetFact1_Detalle> Get1_Detalle(int idEmpresa, string serie, int numero, string ruc, string tipoComprobante, string serienota = "0", int numeronota = 0)
        {
            return _facturaRepository.Get1_Detalle(idEmpresa, serie, numero, ruc,tipoComprobante,serienota,numeronota);
        }
        public List<GetFact2_TipoMoneda> Get2_TipoMoneda()
        {
            return _facturaRepository.Get2_TipoMoneda();
        }
        public GetFact3_Cabecera Get3_Cabecera(int idEmpresa, string serie, string numero, string ruc,string tipoComprobante, string serienota = "0", int numeronota = 0)
        {
            return _facturaRepository.Get3_Cabecera(idEmpresa, serie, Convert.ToInt32(numero), ruc,tipoComprobante, serienota, numeronota);
        }

        // ### SET ###
        public Response SetFacCab(SetFacCabParam parametros)
        {
            return _facturaRepository.SetFacCab(parametros);
        }
        public Response SetFacDet(SetFacDetParam parametros)
        {
            return _facturaRepository.SetFacDet(parametros);
        }

    }
}
