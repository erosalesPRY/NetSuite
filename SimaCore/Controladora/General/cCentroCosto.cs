using AccesoDatos.NoTransaccional.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.General
{
    public class cCentroCosto
    {
        public DataTable BuscarCentrosCosto(string NombreCC, string UserName)
        {
            return (new InformacionGeneralNTAD()).BuscarCentrosCosto(NombreCC, UserName);
        }

        public DataTable ListarCentroOperativoPorPerfil(string IdUsuario, string UserName)
        {
            return (new InformacionGeneralNTAD()).ListarCentroOperativoPorPerfil(IdUsuario, UserName);
        }
    }
}
