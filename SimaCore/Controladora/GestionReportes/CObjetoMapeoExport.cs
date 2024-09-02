using AccesoDatos.Transaccional.GestionReportes;
using AccesoDatos.NoTransaccional.GestionReportes;
using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.GestionReportes
{
    public  class CObjetoMapeoExport
    {
        public DataTable ListarTodos(string Id1, string UserName)
        {
            return (new ObjetoMapeoExportNTAD()).ListarTodos(Id1, UserName);
        }

        public int ModificarInsertar(BaseBE oBaseBE)
        {
            return (new ObjetoMapeoExportTAD()).ModificarInsertar(oBaseBE);
        }
    }
}
