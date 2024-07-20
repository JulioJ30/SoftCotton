using SoftCotton.Model.Maintenance;
using SoftCotton.Repository;
using SoftCotton.Util;
using System.Collections.Generic;
using System.Data;

namespace SoftCotton.BusinessLogic
{
    public class MantenimientoBL
    {
        MantenimientoRepository _mantenimientoRepository;

        public MantenimientoBL()
        {
            _mantenimientoRepository = new MantenimientoRepository();
        }

        public IEnumerable<GetMant53_Estilos> GetEstilos()
        {
            return _mantenimientoRepository.GetEstilos();
        }

        public IEnumerable<GetMant54_Programas> GetProgramas()
        {
            return _mantenimientoRepository.GetProgramas();
        }

        public IEnumerable<GetMant55_Pedidos> GetPedidos()
        {
            return _mantenimientoRepository.GetPedidos();
        }

        public IEnumerable<GetMant56_PedidosColor> GetPedidosColor(int idPedido)
        {
            return _mantenimientoRepository.GetPedidosColor(idPedido);
        }


        // ### GET ###

        public IEnumerable<GetMant34_Programa> Get34_ProgramaPorPedido(string filtroBusqueda = "")
        {
            return _mantenimientoRepository.Get34_ProgramaPorPedido(filtroBusqueda);
        }

        public GetMant23_TipoCambio GetTipoCambioFecha(string fecha, int idtipomoneda)
        {
            return _mantenimientoRepository.GetTipoCambioFecha(fecha, idtipomoneda);
        }

        public IEnumerable<GetUbigeos> GetUbigeos(int opcion = 44, string codigo = null)
        {
            return _mantenimientoRepository.GetUbigeos(opcion,codigo);
        }   
        public List<GetMant7_CeCos> GetMant7_CeCos()
        {
            return _mantenimientoRepository.GetMant7_CeCos();
        }
        public List<GetMant8_TipoCpte> GetMant8_TipoDoc()
        {
            return _mantenimientoRepository.GetMant8_TipoDoc();
        }
        public List<GetMant9_CondPago> GetMant9_CondPago()
        {
            return _mantenimientoRepository.GetMant9_CondPago();
        }
        public List<GetMant10_TipoMoneda> GetMant10_TipoMoneda()
        {
            return _mantenimientoRepository.GetMant10_TipoMoneda();
        }
        public List<GetMant11_TipoDoc> GetMant11_TipoDoc()
        {
            return _mantenimientoRepository.GetMant11_TipoDoc();
        }
        public List<GetMant12_ProvClientes> GetMant12_ProvClientes()
        {
            return _mantenimientoRepository.GetMant12_ProvClientes();
        }
        public List<GetMant13_TipoDoc> GetMant13_TipoDoc()
        {
            return _mantenimientoRepository.GetMant13_TipoDoc();
        }
        public List<GetMant14_RelEmpresas> GetMant14_RelEmpresas()
        {
            return _mantenimientoRepository.GetMant14_RelEmpresas();
        }
        public List<GetMant15_Nivel> GetMant15_Nivel()
        {
            return _mantenimientoRepository.GetMant15_Nivel();
        }
        public List<GetMant16_NivelCBX> Get16_NivelCBX()
        {
            return _mantenimientoRepository.Get16_NivelCBX();
        }
        public List<GetMant17_TallasCBX> Get17_TallasCBX()
        {
            return _mantenimientoRepository.Get17_TallasCBX();
        }
        public List<GetMant18_ColoresCBX> Get18_ColoresCBX()
        {
            return _mantenimientoRepository.Get18_ColoresCBX();
        }
        public List<GetMant19_UMCBX> Get19_UMCBX()
        {
            return _mantenimientoRepository.Get19_UMCBX();
        }
        public List<GetMant20_Productos> Get20_Productos()
        {
            return _mantenimientoRepository.Get20_Productos();
        }
        public List<GetMant21_Tallas> Get21_Tallas()
        {
            return _mantenimientoRepository.Get21_Tallas();
        }
        public List<GetMant22_Color> Get22_Color()
        {
            return _mantenimientoRepository.Get22_Color();
        }
        public List<GetMant23_TipoCambio> Get23_TipoCambio()
        {
            return _mantenimientoRepository.Get23_TipoCambio();
        }
        public List<GetMant24_TipoMoneda> Get24_TipoMoneda()
        {
            return _mantenimientoRepository.Get24_TipoMoneda();
        }
        public List<GetMant25_Grupos> Get25_Grupos(string codNivel, string codGrupo)
        {
            return _mantenimientoRepository.Get25_Grupos(codNivel, codGrupo);
        }
        public List<GetMant26_ProdServicios> Get26_ProductosServicios(string codNivel, string codGrupo)
        {
            return _mantenimientoRepository.Get26_ProductosServicios(codNivel, codGrupo);
        }
        public List<GetMant27_Cuentas> Get27_Cuentas()
        {
            return _mantenimientoRepository.Get27_Cuentas();
        }
        public List<GetMant28_CuentaNivelCBX> Get28_CuentaNiveles()
        {
            return _mantenimientoRepository.Get28_CuentaNiveles();
        }
        public List<GetMant29_CuentaTipoCBX> Get29_CuentaTipos()
        {
            return _mantenimientoRepository.Get29_CuentaTipos();
        }
        public List<GetMant30_UM> Get30_UM()
        {
            return _mantenimientoRepository.Get30_UM();
        }
        public List<GetMant32_BuscarColor> Get32_BuscarColor(string color)
        {
            return _mantenimientoRepository.Get32_BuscarColor(color);
        }
        public List<GetMant33_Servicio> Get33_Servicio(string filtroBusqueda = "", int estado = 0)
        {
            return _mantenimientoRepository.Get33_Servicio(filtroBusqueda, estado);
        }
        public List<GetMant34_Programa> Get34_Programa(string filtroBusqueda = "", int estado = 0)
        {
            return _mantenimientoRepository.Get34_Programa(filtroBusqueda, estado);
        }

        // AGREGADOS
        public List<GetMant41_NumeroLicenciaConducir> GetMant41_NumeroLicenciaConducir(string estado = null)
        {
            return _mantenimientoRepository.GetMant41_NumeroLicenciaConducir(estado);
        }

        public List<GetMant40_ConstanciaInscripcion> GetMant40_ConstanciaInscripcion(string estado = null)
        {
            return _mantenimientoRepository.GetMant40_ConstanciaInscripcion(estado);
        }

        public List<GetMant42_CatalogoNubeFact> GetMant42_CatalogoNubeFact(int inicio,int final,string filtro)
        {
            return _mantenimientoRepository.GetMant42_CatalogoNubeFact(inicio,final,filtro);
        }

        public List<GetMant43_Categorias> GetMant43_Categorias()
        {
            return _mantenimientoRepository.GetMant43_Categorias();
        }

        // ### SET ###
        public Response SetCentroCosto(SetCeCoParam parametros)
        {
            return _mantenimientoRepository.SetCentroCosto(parametros);
        }
        public Response SetTipoComprobante(SetTipoComprobanteParam parametros)
        {
            return _mantenimientoRepository.SetTipoComprobante(parametros);
        }
        public Response SetCondicionesPago(SetCondPagoParam parametros)
        {
            return _mantenimientoRepository.SetCondicionesPago(parametros);
        }
        public Response SetTipoMoneda(SetTipoMonedaParam parametros)
        {
            return _mantenimientoRepository.SetTipoMoneda(parametros);
        }
        public Response SetTipoDocumento(SetTipoDocumentoParam parametros)
        {
            return _mantenimientoRepository.SetTipoDocumento(parametros);
        }
        public Response SetProvClientes(SetProvClientesParam parametros)
        {
            return _mantenimientoRepository.SetProvClientes(parametros);
        }
        public Response SetNivel(SetNivelParam parametros)
        {
            return _mantenimientoRepository.SetNivel(parametros);
        }
        public Response SetProducto(SetProductoParam parametros)
        {
            return _mantenimientoRepository.SetProducto(parametros);
        }
        public Response SetTalla(SetTallaParam parametros)
        {
            return _mantenimientoRepository.SetTalla(parametros);
        }
        public Response SetColor(SetColorParam parametros)
        {
            return _mantenimientoRepository.SetColor(parametros);
        }
        public Response SetTipoCambio(SetTipoCambioParam parametros)
        {
            return _mantenimientoRepository.SetTipoCambio(parametros);
        }
        public Response SetGrupo(SetGrupoParam parametros)
        {
            return _mantenimientoRepository.SetGrupo(parametros);
        }
        public Response SetProductoServicio(SetProductoServicioParam parametros)
        {
            return _mantenimientoRepository.SetProductoServicio(parametros);
        }
        public Response SetCuenta(SetCuentaParam parametros)
        {
            return _mantenimientoRepository.SetCuenta(parametros);
        }
        public Response SetUnidadMedida(SetUMParam parametros)
        {
            return _mantenimientoRepository.SetUnidadMedida(parametros);
        }
        public Response SetServicio(SetServicioParam parametros)
        {
            return _mantenimientoRepository.SetServicio(parametros);
        }
        public Response SetPrograma(SetProgramaParam parametros)
        {
            return _mantenimientoRepository.SetPrograma(parametros);
        }
        public Response SetNumeroLicenciaConducir(SetNumeroLicenciaConducirParam parametros)
        {
            return _mantenimientoRepository.SetNumeroLicenciaConducir(parametros);
        }

        public Response SetConstanciaInscripciones(SetConstanciaInscripcionParam parametros)
        {
            return _mantenimientoRepository.SetConstanciaInscripciones(parametros);
        }

        public Response SetCatalogoNubeFact(SetCalagoNumbeFactParam parametros)
        {
            return _mantenimientoRepository.SetCatalogoNubeFact(parametros);
        }


        // ### REPORTES ###
        public List<GetRpte1_ProvClientes> GetRpte1_ProvClientes()
        {
            return _mantenimientoRepository.GetRpte1_ProvClientes();
        }
        public List<GetMantRpte2_Productos> Get31_Productos(string codNivel, string grupo, string talla, string color)
        {
            return _mantenimientoRepository.Get31_Productos(codNivel, grupo, talla, color);
        }


        // AGREGADO CONTROL DESPACHO
        public IEnumerable<GetMant21_Tallas> Get48_Tallas()
        {
            return _mantenimientoRepository.Get48_Tallas(); 
        }

        public Response setEstilosMantenimiento(SetEstilosParam param)
        {
            return _mantenimientoRepository.setEstilosMantenimiento(param);
        }

        public Response setPedidosMantenimiento(SetPedidosParam param)
        {
            return _mantenimientoRepository.setPedidosMantenimiento(param);
        }

        public Response setPedidosColorMantenimiento(SetPedidosColorParam param)
        {
            return _mantenimientoRepository.setPedidosColorMantenimiento(param);
        }


        public IEnumerable<GetMant56_PedidosColor> getPedidosColorFiltro(string filtro)
        {
            return _mantenimientoRepository.getPedidosColorFiltro(filtro);

        }

        // GCAA 04052024
        public List<SetAreasAlmacen> GetListarAreasAlmacen(string filtro)
        {
            return _mantenimientoRepository.GetListarAreasAlmacen(filtro);
        }

        public Response SetAreasAlmacen(SetAreasAlmacen parametros)
        {
            return _mantenimientoRepository.SetAreasAlmacen(parametros);
        }

        public DataTable SetDatatable(int opcion, string filtroTxt1, string filtroTxt2, int filtroInt1, int filtroInt2,decimal filtroDecimal1 = 0)
        {
            return _mantenimientoRepository.SetDatatable(opcion, filtroTxt1, filtroTxt2, filtroInt1, filtroInt2, filtroDecimal1);
        }

        public DataTable SetDatatableReporte(int opcion, string var1, string var2, string var3, string var4, string var5, string var6)
        {
            return _mantenimientoRepository.SetDatatableReporte(opcion, var1, var2, var3, var4, var5, var6);
        }

    }
}
