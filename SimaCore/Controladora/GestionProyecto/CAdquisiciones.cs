using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AccesoDatos.NoTransaccional.GestionProyecto;

namespace Controladora.GestionProyecto
{ 
    public class CAdquisiciones
    {
        private readonly AdquisicionesNTAD _adquisiciones;

        public CAdquisiciones(AdquisicionesNTAD adquisiciones)
        {
            _adquisiciones = adquisiciones;
        }

        public DataTable Listar_det_gasto_pry_ot_pgmsu(string V_CENTRO_OPERATIVO, string V_DIVISION, string V_PROYECTO, string UserName)
        {
            return _adquisiciones.Listar_det_gasto_pry_ot_pgmsu(V_CENTRO_OPERATIVO, V_DIVISION, V_PROYECTO, UserName);
        }

    }
}
