using AccesoDatos.NoTransaccional.GestionCalidad;
using AccesoDatos.Transaccional.GestionCalidad;
using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.GestionCalidad
{
    public class CInspectores
    {

        public string ModificaInserta(BaseBE oBaseBE)
        {
            return (new InspectoresTAD()).ModificaInserta(oBaseBE);
        }
            public DataTable ListarTodos(string Id1, string UserName)
        {
            return (new InspectoresNTAD()).ListarTodos(Id1, UserName);
        }
    }
}
