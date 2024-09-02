using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionProduccion;
using System.Data;

namespace Controladora.GestionProduccion
{ 
    public class CMateriales
    {
        private readonly MaterialesNTAD _materiales;

        public CMateriales(MaterialesNTAD materiales)
        {
            _materiales = materiales;
        }

        public DataTable Listar_Lista_Materiales(string V_CODDIV, string V_NROVAL, string UserName)
        {
            return _materiales.Listar_lista_materiales(V_CODDIV, V_NROVAL, UserName);
        }

    }
}
