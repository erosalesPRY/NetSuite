using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.General;
using AccesoDatos.Transaccional.General;
using EntidadNegocio;

namespace Controladora.General
{
    public class CItemTablaGeneral
    {
        public DataTable ListarTodos(string Id1, string UserName)
        {
            return (new ItemTablaGeneralNTAD()).ListarTodos(Id1, UserName);
        }
        public DataTable ListarTablasdeApoyo(string IdtblModulo, string UserName)
        {
            return (new ItemTablaGeneralNTAD()).ListarTablasdeApoyo(IdtblModulo, UserName);
        }


        public int Modificar(BaseBE oBaseBE)
        {
            return (new ItemTablaGeneralTAD()).Modificar(oBaseBE);
        }

        public DataTable ListaConfiguracion(string PageName, string UserName)
        {
            return (new ItemTablaGeneralNTAD()).ListaConfiguracion(PageName, UserName);        }
    }
}
