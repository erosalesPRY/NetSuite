using AccesoDatos.NoTransaccional.GestionLogistica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.GestionLogistica
{
    public  class cTestMySQL
    {
        public DataTable ListarTodos(string Id1, string UserName)
        {
        return (new TestNTAD()).ListarTodos(Id1, UserName);
        }
    }
}
