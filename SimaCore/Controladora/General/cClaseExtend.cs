using AccesoDatos.NoTransaccional.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.General
{
    public class cClaseExtend
    {
        public DataTable ListarPropiedades(string NombreClase, string UserName)
        {
            return (new ClaseExtendNTAD()).ListarPropiedades(NombreClase, UserName);
        }
    }
}
