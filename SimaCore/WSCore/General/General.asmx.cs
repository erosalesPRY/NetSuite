using Controladora.General;
using EntidadNegocio.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Services;
using static ManejadorExcepcion.ManejoExcepcion.Configuracion.Seccion;

namespace WSCore.General
{
    /// <summary>
    /// Descripción breve de General
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class General : System.Web.Services.WebService
    {

        [WebMethod]
        public DataTable ListarItemTablas(string IdTablaGeneral, string UserName)
        {
            return (new CItemTablaGeneral()).ListarTodos(IdTablaGeneral, UserName);
        }

        [WebMethod(Description = "Buscar Clientes")]
        public DataTable BuscarCliente(string RazonSocial, string UserName)
        {
            return (new CCliente()).Buscar(RazonSocial, UserName);
        }
        [WebMethod(Description = "Listar Tablas de Apoyo por modulo")]
        public DataTable ListarTablasdeApoyo(string IdtblModulo, string UserName)
        {
            return (new CItemTablaGeneral()).ListarTablasdeApoyo(IdtblModulo, UserName);
        }

        [WebMethod(Description = "Mantenimiento de Tabla tablas Items")]
        public int InsertaModificaItemsTabla(TablaItemBE oTablaItemBE)
        {
            return (new CItemTablaGeneral()).Modificar(oTablaItemBE);
        }

        [WebMethod(Description = "Gestion de la Configuracion")]
        public DataTable  ListarOpcionesConfiguracion(string PageName,string UserName)
        {
            return (new CItemTablaGeneral()).ListaConfiguracion(PageName, UserName);
        }

        [WebMethod(Description = "lista Centros de Costo por nombre o código")]
        public DataTable ListarCentrosCosto(string NombreCC, string UserName)
        {
            return ((new cCentroCosto()).BuscarCentrosCosto(NombreCC, UserName));
        }

        [WebMethod(Description = "Lista de Centros Operativos por Perfil")]
        public DataTable ListarCentroOperativoPorPerfil(string IdUsuario, string UserName)
        {
            return ((new cCentroCosto()).ListarCentroOperativoPorPerfil(IdUsuario, UserName));
        }
    }
}
