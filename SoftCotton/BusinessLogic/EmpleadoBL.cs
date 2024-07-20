using SoftCotton.Model.Employee;
using SoftCotton.Repository;
using SoftCotton.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.BusinessLogic
{
    public class EmpleadoBL
    {
        EmpleadoRepository _empleadoRepository;

        public EmpleadoBL()
        {
            _empleadoRepository = new EmpleadoRepository();
        }

        // ### GET ###
        public List<GetEmp1_Personas> Get1_Personas()
        {
            return _empleadoRepository.Get1_Personas();
        }
        public List<GetEmp2_Colaboradores> Get2_Colaboradores()
        {
            return _empleadoRepository.Get2_Colaboradores();
        }
        public GetEmp3_BuscarPersona Get3_BuscarPersona(string numeroDocumento)
        {
            return _empleadoRepository.Get3_BuscarPersona(numeroDocumento);
        }
        public List<GetEmp4_Cargos> Get4_Cargos()
        {
            return _empleadoRepository.Get4_Cargos();
        }
        public List<GetEmp5_Areas> Get5_Areas()
        {
            return _empleadoRepository.Get5_Areas();
        }
        public GetEmp6_BuscarXDNI Get6_BuscarXDNI(string numeroDocumento)
        {
            return _empleadoRepository.Get6_BuscarXDNI(numeroDocumento);
        }


        // ### SET ###
        public Response SetEmpPersona(SetPersonaParam parametros)
        {
            return _empleadoRepository.SetEmpPersona(parametros);
        }
        public Response SetEmpColaborador(SetColaboradorParam parametros)
        {
            return _empleadoRepository.SetEmpColaborador(parametros);
        }

       
    }
}
