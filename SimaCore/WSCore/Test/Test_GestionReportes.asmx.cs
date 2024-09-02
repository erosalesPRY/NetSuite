using Controladora;
using EntidadNegocio.GestionReportes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using WSCore.GestionReportes;

namespace WSCore.Test
{
    /// <summary>
    /// Descripción breve de Test_GestionReportes
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Test_GestionReportes : System.Web.Services.WebService
    {

        [System.Web.Services.WebMethod]
        public int InsertaModificaObjeto(int IdObjeto, int IdPadre, string Nombre, int IdTipo, int IdTipoControl, string Descripcion, string Ref1, string Ref2, string Ref3, string Ref4, int IdUsuarioAnalista, int IdUsuarioSolicitante, int IdUsuario, string UserName)
        {
            try
            {
                ObjetoBE oObjetoBE = new ObjetoBE();
                oObjetoBE.IdObjeto = IdObjeto;
                oObjetoBE.IdPadre = IdPadre;
                oObjetoBE.Nombre = Nombre;
                oObjetoBE.IdTipo = IdTipo;
                oObjetoBE.IdTipoControl = IdTipoControl;
                oObjetoBE.Descripcion = Descripcion;
                oObjetoBE.Ref1 = Ref1;
                oObjetoBE.Ref2 = Ref2;
                oObjetoBE.Ref3 = Ref3;
                oObjetoBE.Ref4 = Ref4;
                oObjetoBE.IdUsuarioAnalista = IdUsuarioAnalista;
                oObjetoBE.IdUsuarioSolicitante = IdUsuarioSolicitante;
                oObjetoBE.IdUsuario = IdUsuario;
                oObjetoBE.UserName = UserName;
                int id = (new AdministrarReportes()).InsertarObjeto(oObjetoBE);
                return id;
            }
            catch (Exception ex)
            {
                return -1;
            }

        }


        [System.Web.Services.WebMethod]
        public DataTable BuscarProyecto(string  Criterio){
        DataTable dt = new DataTable();
            dt = (new CTestOracle()).Listar(Criterio);
        return dt;

        }

       

        

    }
}
