using SoftCotton.DTO.Security;
using SoftCotton.Model.Security;
using SoftCotton.Repository;
using SoftCotton.Util;
using System.Collections.Generic;

namespace SoftCotton.BusinessLogic
{
    public class SeguridadBL
    {
        SeguridadRepository _seguridadRepository;

        public SeguridadBL()
        {
            _seguridadRepository = new SeguridadRepository();
        }


        // ### GET ###
        public GetLogin Login(LoginDTO login)
        {
            return _seguridadRepository.Login(login);
        }

        public List<GetAcceso2_Mod> Get_Accesos(int idUsuario)
        {
            List<GetAcceso2_Mod> listaModulos = _seguridadRepository.GetAcceso2_Mod(idUsuario);
            foreach (var item in listaModulos)
            {
                item.subModulos = _seguridadRepository.GetAcceso3_SubMod(idUsuario, item.idModulo);
            }
            return listaModulos;
        }

        public List<GetAcceso4_Personas> Get4_Personas()
        {
            return _seguridadRepository.Get4_Personas();
        }


        public List<GetMant1_Usuarios> GetMant1_Usuarios()
        {
            return _seguridadRepository.GetMant1_Usuarios();
        }
        public List<GetMant2_Modulos> GetMant2_Modulos()
        {
            return _seguridadRepository.GetMant2_Modulos();
        }
        public List<GetMant3_SubModulos> GetMant3_SubModulos()
        {
            return _seguridadRepository.GetMant3_SubModulos();
        }
        public List<GetMant4_CbxModulos> GetMant4_CbxModulos()
        {
            return _seguridadRepository.GetMant4_CbxModulos();
        }
        public List<GetMant5_Usuarios> GetMant5_Usuarios()
        {
            return _seguridadRepository.GetMant5_Usuarios();
        }
        public List<GetMant6_Accesos> GetMant6_Accesos(int idUsuario)
        {
            return _seguridadRepository.GetMant6_Accesos(idUsuario);
        }


        // ### SET ###
        public Response SetUsuario(SetUsuarioParam parametros)
        {
            return _seguridadRepository.SetUsuario(parametros);
        }
        public Response SetModulo(SetModuloParam parametros)
        {
            return _seguridadRepository.SetModulo(parametros);
        }
        public Response SetSubModulo(SetSubModuloParam parametros)
        {
            return _seguridadRepository.SetSubModulo(parametros);
        }
        public Response SetAcceso(SetAccesoParam parametros)
        {
            return _seguridadRepository.SetAcceso(parametros);
        }
    
    }
}
