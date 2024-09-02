using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Services;
using WSCore.WorkingBack;
using System.Threading.Tasks;
using EntidadNegocio.GestionFinanciera.Tesoreria.Pagos;
using System.Text.Json;

namespace WSCore.Test
{
    /// <summary>
    /// Descripción breve de CnsumirApiRest
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class CnsumirApiRest : System.Web.Services.WebService
    {
        //Referencia : https://www.youtube.com/watch?v=jGyIo2B-3AI
        [WebMethod]
        public string HelloWorld()
        {
            
            return "";
        }
        
      

      

    }
}
