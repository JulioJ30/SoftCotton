using SoftCotton.Model.Shared;
using SoftCotton.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.BusinessLogic
{
    public class CompartidoBL
    {
        CompartidoRepository _compartidoRepository;

        public CompartidoBL()
        {
            _compartidoRepository = new CompartidoRepository();
        }


        public List<GetShared1_ProvClientes> Get1_ProvClientes(string filtroBusqueda)
        {
            return _compartidoRepository.Get1_ProvClientes(filtroBusqueda);
        }

        public List<GetShared2_BuscarProdServ> Get2_BuscarProdServ(string codNivel, string codGrupo)
        {
            return _compartidoRepository.Get2_BuscarProdServ(codNivel, codGrupo);
        }

        public List<GetShared3_BuscarCuenta> Get3_BuscarCuenta(string cuentaFiltro)
        {
            return _compartidoRepository.Get3_BuscarCuenta(cuentaFiltro);
        }

        public List<GetShared4_BuscarGR> Get4_BuscarGR(int idEmpresa, string serie, string numero)
        {
            return _compartidoRepository.Get4_BuscarGR(idEmpresa, serie, numero);
        }
    }
}
