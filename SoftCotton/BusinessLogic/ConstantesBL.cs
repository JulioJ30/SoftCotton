using SoftCotton.Repository;
using SoftCotton.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftCotton.BusinessLogic
{
    public class ConstantesBL
    {
        ConstanteRepository _constantesRepository;

        public ConstantesBL()
        {
            _constantesRepository = new ConstanteRepository();
        }


        // ### GET ###
        public List<Constantes> Get1_Constantes()
        {
            return _constantesRepository.Get1_Constantes();
        }

    }
}
