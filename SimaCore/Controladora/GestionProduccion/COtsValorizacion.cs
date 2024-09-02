using AccesoDatos.NoTransaccional.GestionProduccion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.GestionProduccion
{
    public class COtsValorizacion
    {

        public DataTable ListarTodos(int Centro, string CodigoDivision, string FechaIni, string FechaFin, int NOT, string UserName)
        {
            return (new OtsValorizacionNTAD()).ListarTodos(Centro, CodigoDivision, FechaIni, FechaFin, NOT, UserName);
        }
    }
}
