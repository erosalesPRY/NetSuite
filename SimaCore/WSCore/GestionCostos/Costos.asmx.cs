using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using AccesoDatos.NoTransaccional.GestionCostos;
using Controladora.GestionCostos;
using AccesoDatos.Estandar;
using System.Data;
using EntidadNegocio;
using WSCore.General;
using System.Web.Services.Description;

namespace WSCore.GestionCostos
{
    /// <summary>
    /// Descripción breve de Costos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Costos : System.Web.Services.WebService
    {
        #region Referencias a Controladores de Costos
        private static CostosNTAD costos = new CostosNTAD(new StandarProcedure());
        CCostos controladorCostos = new CCostos(costos);

        private static PagosNTAD pagos = new PagosNTAD(new StandarProcedure());
        CPagos controladorPagos = new CPagos(pagos);
        #endregion

        #region Procedimientos almacenados de clasificacion: Costos

        [WebMethod(Description = "Resumen - Costos de Producción (Por Línea de Negocio)")]
        public DataTable Listar_costo_prod_linea_neg_resu(string D_AÑO, string D_MES, string V_CENTRO_OPERATIVO, string V_LINEA_NEGOCIO, string UserName)
        {
            return controladorCostos.Listar_costo_prod_linea_neg_resu(D_AÑO,D_MES,V_CENTRO_OPERATIVO,V_LINEA_NEGOCIO,UserName);
        }
        
        [WebMethod(Description = "Detalle - Costos de Producción(Por Línea de Negocio)")]
        public DataTable Listar_costo_prod_linea_neg_det(string D_AÑO, string D_MES, string V_CENTRO_OPERATIVO, string V_LINEA_NEGOCIO, string UserName)
        {
            return controladorCostos.Listar_costo_prod_linea_neg_det(D_AÑO, D_MES, V_CENTRO_OPERATIVO, V_LINEA_NEGOCIO, UserName);
        }
        #endregion

        #region Procedimientos almacenados de clasificacion: Pagos

        [WebMethod(Description = "Detalle - Analisis de Gastos (Por C.Costo y Naturaleza)")]
        public DataTable Listar_analisis_gastos_ccnatudet(string D_AÑO_DE_PROCESO, string D_MES_DE_PROCESO, string V_CENTRO_OPERATIVO, string V_CUENTA_MAYOR, string UserName)
        {
            return controladorPagos.Listar_analisis_gastos_ccnatudet(D_AÑO_DE_PROCESO, D_MES_DE_PROCESO, V_CENTRO_OPERATIVO, V_CUENTA_MAYOR, UserName);
        }

        [WebMethod(Description = "Detalle - Analisis de Gastos Directos de OT por Items de Asiento")]
        public DataTable Listar_analisis_gast_itemsasient(string V_CENTRO_OPERATIVO, string V_DIVISION, string V_NUMERO_OT, string UserName)
        {
            return controladorPagos.Listar_analisis_gast_itemsasient(V_CENTRO_OPERATIVO, V_DIVISION, V_NUMERO_OT,UserName);
        }

        #endregion
    }
}
