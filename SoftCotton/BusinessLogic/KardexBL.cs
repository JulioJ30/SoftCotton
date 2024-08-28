using DocumentFormat.OpenXml.Presentation;
using SoftCotton.Model.Kardex;
using SoftCotton.Repository;
using SoftCotton.Util;
using SoftCotton.Views.Requerimiento;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SoftCotton.BusinessLogic
{
    class KardexBL
    {
        KardexRepository _kardexRepository;

        public KardexBL()
        {
            _kardexRepository = new KardexRepository();
        }

        // ### GET ###
        public Response GetValidarKadex(string codNivel, string codGrupo, string codTalla, string codColor)
        {
            return _kardexRepository.GetValidarKadex(codNivel, codGrupo, codTalla, codColor);
        }

        public List<KardexValorizado> uspGetMovimientoKardexValorizado(string codNivel, string codCuenta, string codGrupo, string codTalla, string codColor, string periodo)
        {
            return _kardexRepository.uspGetMovimientoKardexValorizado(codNivel, codCuenta, codGrupo, codTalla, codColor, periodo);
        }

        public List<KardexValorizadoPrincipal> uspGetMovimientoKardex(string codNivel, string codCuenta, string codGrupo, string codTalla, string codColor,string fechaIni, string fechafin)
        {
            return _kardexRepository.uspGetMovimientoKardex(codNivel, codCuenta, codGrupo, codTalla, codColor,fechaIni,fechafin);
        }
        public List<KardexElectronico> uspGetkardexElectronicovalorizado(string codNivel, string codCuenta, string desde, string hasta, string codigo)
        {
            return _kardexRepository.uspGetkardexElectronicovalorizado(codNivel, codCuenta, desde, hasta, codigo);

        }
        public DataTable GetListArticulos(string filtro)
        {
            return _kardexRepository.GetListArticulos(filtro);
        }
        public DataTable GetListarNiveles(string filtro)
        {
            return _kardexRepository.GetListarNiveles(filtro);
        }

        public DataTable GetKardexCentral(string filtro)
        {
            return _kardexRepository.GetKardexCentral(filtro);
        }

        public DataTable GetKardexCentralMovimientos(string filtro)
        {
            return _kardexRepository.GetKardexCentralMovimientos(filtro);
        }
        public DataTable GetKardexCentralMovimientosFecha(int tipo, string fechaInicio, string fechaFin, string codigo, string nivel)
        {
            return _kardexRepository.GetKardexCentralMovimientosFecha(tipo, fechaInicio, fechaFin, codigo, nivel);
        }

        public DataTable GetKardexArticulos(string filtro, string almacen)
        {
            return _kardexRepository.GetKardexArticulos(filtro, almacen);
        }
        public string RegistrarReq_Cabe(double idRequerimiento, string AlmacenDespacho, string AlmacenRequiere,
            int estado, string observacion, int usuarioRegistro)
        {
            string resultado = _kardexRepository.RegistrarReq_Cabe(idRequerimiento, AlmacenDespacho, AlmacenRequiere, estado, observacion, usuarioRegistro);
            return resultado;
        }

        public string RegistrarReq_Deta(double idRequerimiento, string ProductoID, double cantidad, double stock_actual, double cantidad_atendida)
        {
            string resultado = _kardexRepository.RegistrarReq_Deta(idRequerimiento, ProductoID, cantidad, stock_actual, cantidad_atendida);
            return resultado;
        }

        public string update_RequerimientoCabe(int tipo, double idRequerimiento, int usuario)
        {
            string resultado = _kardexRepository.update_RequerimientoCabe(tipo, idRequerimiento, usuario);
            return resultado;
        }

        public string update_RequerimientoDeta(int tipo, E_Producto_Reque item, double idRequerimiento, string almacenSalida, string almaceningreso, string usuario)
        {
            string resultado = _kardexRepository.update_RequerimientoDeta(tipo, item, idRequerimiento, almacenSalida, almaceningreso, usuario);
            return resultado;
        }

    }
}
