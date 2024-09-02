using AccesoDatos.NoTransaccional.HelpDesk.ChatBox;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.HelpDesk.ChatBox
{
    public  class CCBContactoGrupo
    {
        public DataTable ListarTodos(string Id1, string UserName)
        { 
            return(new CBContactoGrupoNTAD()).ListarTodos(Id1, UserName);
        }
        public DataTable ListarTodos(int IdContacto, string UserName)
        {
            return (new CBContactoGrupoNTAD()).ListarTodos(IdContacto, UserName);
        }
    }

}
