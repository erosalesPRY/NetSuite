using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using AccesoDatos.Estandar;
using AccesoDatos.NoTransaccional.GestionActivoFijo;
using Controladora.GestionActivoFijo;

namespace WSCore.GestionActivoFijo
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class ActivoFijo : System.Web.Services.WebService
    {

        private static ActivoFijoNTAD activoFijo = new ActivoFijoNTAD(new StandarProcedure());
        cActivoFijo controladorActivoFijo = new cActivoFijo(activoFijo);

        [WebMethod(Description = "")]
        public DataTable Listar_actfijo_cons_inv(string COD_EMP, string EST_BIEN, string UserName)
        {
            return controladorActivoFijo.Listar_actfijo_cons_inv(COD_EMP, EST_BIEN, UserName);
        }

        [WebMethod(Description = "")]
        public DataTable Listar_actfijo_pen(string COD_EMP, string EST_BIEN, string UserName)
        {
            return controladorActivoFijo.Listar_actfijo_pen(COD_EMP, EST_BIEN, UserName);
        }

        [WebMethod(Description = "")]
        public DataTable Listar_altascuentord_m(string ANIO, string COD_EMP, string EST_BIEN, string MES,
            string UserName)
        {
            return controladorActivoFijo.Listar_altascuentord_m(ANIO, COD_EMP, EST_BIEN, MES, UserName);
        }

        [WebMethod(Description = "")]
        public DataTable Listar_altasmes_actf(string ANIO, string COD_EMP, string EST_BIEN, string MES, string UserName)
        {
            return controladorActivoFijo.Listar_altasmes_actf(ANIO, COD_EMP, EST_BIEN, MES, UserName);
        }

        [WebMethod(Description = "")]
        public DataTable Listar_formato_7_1(string COD_EMP, string N_ANIO, string UserName)
        {
            return controladorActivoFijo.Listar_formato_7_1(COD_EMP, N_ANIO, UserName);
        }

        [WebMethod(Description = "")]
        public DataTable Listar_invent_actxgrupoysubgrsmn(string COD_EMPE, string GRUPOBN, string SUBGRUPOBN,
            string TIPOACTV, string UserName)
        {
            return controladorActivoFijo.Listar_invent_actxgrupoysubgrsmn(COD_EMPE, GRUPOBN, SUBGRUPOBN, TIPOACTV, UserName);
        }

        [WebMethod(Description = "")]
        public DataTable Listar_inventario_activosxcc(string CCOSTO1, string CCOSTO2, string COD_EMPE, string COD_PANOL,
            string TIPOACTV, string UserName)
        {
            return controladorActivoFijo.Listar_inventario_activosxcc(CCOSTO1, CCOSTO2, COD_EMPE, COD_PANOL, TIPOACTV, UserName);
        }

        [WebMethod(Description = "")]
        public DataTable Listar_inventario_activosxccrsm(string CCOSTO1, string CCOSTO2, string COD_EMPE,
            string TIPOACTV, string UserName)
        {
            return controladorActivoFijo.Listar_inventario_activosxccrsm(CCOSTO1, CCOSTO2, COD_EMPE, TIPOACTV, UserName);
        }

        [WebMethod(Description = "")]
        public DataTable Listar_inventario_activosxcustod(string COD_EMPE, string COD_ROL, string TIPOACTV,
            string UserName)
        {
            return controladorActivoFijo.Listar_inventario_activosxcustod(COD_EMPE, COD_ROL, TIPOACTV, UserName);
        }

        [WebMethod(Description = "")]
        public DataTable Listar_inventario_actsgrup_sub(string COD_EMP, string EST_BIEN, string GRUPO, string SUBGRUPO,
            string TIPO_BIEN, string UserName)
        {
            return controladorActivoFijo.Listar_inventario_actsgrup_sub(COD_EMP, EST_BIEN, GRUPO, SUBGRUPO, TIPO_BIEN, UserName);
        }

        [WebMethod(Description = "")]
        public DataTable Lista_Bienes_toma_inventario(string CODEMP, string NRO_PR, string CCO_INI, string CCO_FIN,
            string UserName)
        {
            return activoFijo.Lista_Bienes_toma_inventario(CODEMP, NRO_PR, CCO_INI, CCO_FIN, UserName);
        }
    }
}
