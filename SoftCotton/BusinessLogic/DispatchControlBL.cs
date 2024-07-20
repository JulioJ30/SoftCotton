using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftCotton.Repository;
using SoftCotton.Util;
using System.Data;

using SoftCotton.Model.DispatchControl;


namespace SoftCotton.BusinessLogic
{
    public class DispatchControlBL
    {

        DispatchControlRespository _dispatchControlRepository;

        public DispatchControlBL()
        {
            _dispatchControlRepository = new DispatchControlRespository();
        }

        public IEnumerable<controlDespachoDetTallas> GetDetalleTallasOs(int idOs)
        {
            return _dispatchControlRepository.GetDetalleTallasOs(idOs);

        }

        public IEnumerable<busquedaControlDespacho> GetControlDespachos(int idProceso, string pedido)
        {
            return _dispatchControlRepository.GetControlDespachos(idProceso, pedido);
        }

        public parametrosRegistros SetControlDespacho(int opcion, parametrosRegistros parametro)
        {
            return _dispatchControlRepository.SetControlDespacho(opcion,parametro);
        }

        public DataTable GetControlDespachoDetalleTalla(int? idControlDespachoCabecera)
        {
            return _dispatchControlRepository.GetControlDespachoDetalleTalla(idControlDespachoCabecera);

        }

    }
}
