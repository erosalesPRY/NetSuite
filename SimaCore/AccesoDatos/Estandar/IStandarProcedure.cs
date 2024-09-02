using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Estandar
{
    public interface IStandarProcedure
    {
        DataTable EjecutarProcedimiento(string packageName, Dictionary<string, object> parameters);
    }
}
