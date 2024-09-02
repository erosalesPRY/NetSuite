using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionProduccion;
using System.Data;

namespace Controladora.GestionProduccion
{ 
    public class cGeneral
    {
        private readonly GeneralNTAD _general;

        public cGeneral(GeneralNTAD general)
        {
            _general = general;
        }

        public DataTable Listar_tarifa_maq(string V_TALLER, string UserName)
        {
            return _general.Listar_tarifa_maq(V_TALLER, UserName);
        }

    }
}