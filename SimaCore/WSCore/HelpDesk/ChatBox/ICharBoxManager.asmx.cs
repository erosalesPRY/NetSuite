using Controladora.HelpDesk.ChatBox;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WSCore.HelpDesk.ChatBox
{
    /// <summary>
    /// Descripción breve de ICharBoxManager
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ICharBoxManager : System.Web.Services.WebService
    {

        [WebMethod(Description = "Busca y Lista los Contactos según criterio o Lista Contactos por grupo")]
        public DataTable ListarContatos(string NOMBRECONTACTO, string UserName)
        {
            return (new CCBContactoGrupo()).ListarTodos(NOMBRECONTACTO, UserName);
        }
        [WebMethod(Description = "Busca y Lista Miembro de  Contactos id Contacto")]
        public DataTable ListarMiembros(int  IdContacto, string UserName)
        {
            return (new CCBContactoGrupo()).ListarTodos(IdContacto, UserName);
        }


        [WebMethod(Description = "Listado de Historial de Dialogo entre contactos")]
        public DataTable LstHistorialDialogo(string IdContactoOrg,int IdContactoDes, string UserName)
        {
            return (new CCBHistorialMsg()).ListarTodos(IdContactoOrg.ToString(), IdContactoDes.ToString(), UserName);
        }
        [WebMethod(Description = "Listado de Historial de Dialogo entre contactos COntenido de mensajes")]
        public DataTable LstHistorialDialogoContenido(string Idmsg, string UserName)
        {
            return (new CCBHistorialMsg()).ListarChatContenido(Idmsg, UserName);
        }
        [WebMethod(Description = "Listado de Historial Like por Dialogo de mensajes")]
        public DataTable LstHistorialDialogoContenidoLikes(string IdContents, string UserName)
        {
            return (new CCBHistorialMsg()).LstHistorialDialogoContenidoLikes(IdContents, UserName);
        }



    }
}
