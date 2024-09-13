﻿using AccesoDatos.NoTransaccional.HelpDesk.ChatBot;
using Controladora.GestionPersonal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.HelpDesk.ChatBot
{
    public class CCBContactoGrupo
    {
        public DataTable DetalleContacto(string CodPersonal, string UserName)
        {
            return (new CBContactoGrupoNTAD()).DetalleContacto(CodPersonal, UserName);
        }
        public DataTable ListarTodos(string Id1, string UserName)
        {
            return (new CBContactoGrupoNTAD()).ListarTodos(Id1, UserName);
        }
        public DataTable ListarTodos(int IdContacto, string UserName)
        {
            return (new CBContactoGrupoNTAD()).ListarTodos(IdContacto, UserName);
        }
        public DataTable IsMiembrodeGrupo(int IdContactGrupo, string CodPersonal, string UserName)
        {
            return (new CBContactoGrupoNTAD()).IsMiembrodeGrupo(IdContactGrupo, CodPersonal, UserName);
        }
        public DataTable LstContactSendtoGrupo(int IdContactGrupo, string UserName)
        {
            return (new CBContactoGrupoNTAD()).LstContactSendtoGrupo(IdContactGrupo, UserName);
        }
    }

}
