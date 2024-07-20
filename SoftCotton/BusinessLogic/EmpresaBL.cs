using SoftCotton.Database;
using SoftCotton.Model.Enterprise;
using SoftCotton.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using SoftCotton.Util;
using DocumentFormat.OpenXml.Drawing.Diagrams;

namespace SoftCotton.BusinessLogic
{
    public class EmpresaBL
    {
        EmpresaRepository _empresasRepository;

        public EmpresaBL()
        {
            _empresasRepository = new EmpresaRepository();
        }

        // ### GET ###
        public List<Get1_Empresas> Get1_Empresas()
        {
            return _empresasRepository.Get1_Empresas();
        }

        public Get1_Empresas Get1_EmpresasConf()
        {
            return _empresasRepository.Get1_EmpresasConf();
        }
        public string uspSetempresa(Get1_Empresas obj)
        {
            return _empresasRepository.uspSetempresa(obj);            
        }

    }
}
