using Controladora.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WSCore.GestionComercial
{
    /// <summary>
    /// Descripción breve de Proceso
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Cliente : System.Web.Services.WebService
    {

        [WebMethod(Description ="Busca los Clientes en la BD del SIMANET")]
        public DataTable BuscarCliente(string RazonSocialCliente, string UserName)
        {
            return ((new CCliente()).Buscar(RazonSocialCliente, UserName));
        }
    }
}
