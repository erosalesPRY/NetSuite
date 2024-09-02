using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using AccesoDatos.NoTransaccional.GestionProyecto;
using Controladora.GestionProyecto;
using AccesoDatos.Estandar;
using System.Data;
using EntidadNegocio;

using Controladora.GestionLogistica;
using WSCore.General;


namespace WSCore.GestionProyecto
{
    /// <summary>
    /// Descripción breve de Proyecto
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Proyecto : System.Web.Services.WebService
    {
        #region Referencias a Controladores de Proyecto

        private static AdquisicionesNTAD adquisiciones = new AdquisicionesNTAD(new StandarProcedure());
        CAdquisiciones controladorAdquisiciones = new CAdquisiciones(adquisiciones);

        private static FacturacionNTAD facturacion = new FacturacionNTAD(new StandarProcedure());
        CFacturacion controladorFacturacion = new CFacturacion(facturacion);

        private static MaterialesNTAD materiales = new MaterialesNTAD(new StandarProcedure());
        CMateriales controladorMateriales = new CMateriales(materiales);

        private static MobNTAD mob = new MobNTAD(new StandarProcedure());
        CMob controladorMob = new CMob(mob);

        private static OrdenesNTAD ordenes = new OrdenesNTAD(new StandarProcedure());
        COrdenes controladorOrdenes = new COrdenes(ordenes);

        private static OtNTAD ot = new OtNTAD(new StandarProcedure());
        COt controladorOt = new COt(ot);

        private static PagosNTAD pagos = new PagosNTAD(new StandarProcedure());
        CPagos controladorPagos = new CPagos(pagos);

        #endregion

        #region Procedimientos almacenados de clasificacion: Adquisiciones

        [WebMethod(Description = "PROGRAMA DE ADQUISICIONES DE REQUERIMIENTOS DE OT'S POR PROYECTOS")]
        public DataTable Listar_det_gasto_pry_ot_pgmsu(string V_CENTRO_OPERATIVO, string V_DIVISION, string V_PROYECTO, string UserName)
        {
            return controladorAdquisiciones.Listar_det_gasto_pry_ot_pgmsu(V_CENTRO_OPERATIVO, V_DIVISION, V_PROYECTO, UserName);
        }

        #endregion

        #region Procedimientos almacenados de clasificacion: Facturacion

        [WebMethod(Description = "FACTURACION DE OT'S POR PROYECTOS")]
        public DataTable Listar_detalle_gasto_pry_ot_fac(string N_CEO, string V_CODDIV, string V_CODPRY, string V_PERIODO, string UserName)
        {
            return controladorFacturacion.Listar_detalle_gasto_pry_ot_fac(N_CEO, V_CODDIV, V_CODPRY, V_PERIODO, UserName);
        }

        #endregion

        #region Procedimientos almacenados de clasificacion: Materiales

        [WebMethod(Description = "UTILIZACION DE MATERIALES Y SERVICIOS DE OT'S POR PROYECTOS")]
        public DataTable Listar_det_gasto_pry_ot_uti(string V_CENTRO_OPERATIVO, string V_DIVISION, string V_PROYECTO, string UserName)
        {
            return controladorMateriales.Listar_det_gasto_pry_ot_uti(V_CENTRO_OPERATIVO, V_DIVISION, V_PROYECTO, UserName);
        }

        [WebMethod(Description = " VALES DE SALIDA DE MATERIALES DE OT'S POR PROYECTOS")]
        public DataTable Listar_det_gasto_pry_ot_vsm(string V_CENTRO_OPERATIVO, string V_DIVISION, string V_PROYECTO, string UserName)
        {
            return controladorMateriales.Listar_det_gasto_pry_ot_vsm(V_CENTRO_OPERATIVO, V_DIVISION, V_PROYECTO, UserName);
        }

        #endregion

        #region Procedimientos almacenados de clasificacion: Mob

        [WebMethod(Description = "UTILIZACION DE MOB DE OT'S POR PROYECTOS")]
        public DataTable Listar_det_gasto_pry_ot_mob(string D_FECHA_DE_TRABAJO_DESDE, string D_FECHA_DE_TRABAJO_HASTA, string V_CENTRO_OPERATIVO, string V_DIVISION, string V_PROYECTO, string UserName)
        {
            return controladorMob.Listar_det_gasto_pry_ot_mob(D_FECHA_DE_TRABAJO_DESDE, D_FECHA_DE_TRABAJO_HASTA, V_CENTRO_OPERATIVO, V_DIVISION, V_PROYECTO, UserName);
        }

        #endregion

        #region Procedimientos almacenados de clasificacion: Ordenes

        [WebMethod(Description = "AVANCE POR ORDENES DE SERVICIO DE OT'S POR PROYECTOS")]
        public DataTable Listar_det_gasto_pry_ot_ose_ava(string N_CEO, string V_CODDIV, string V_CODPRY, string V_ORDSRV, string UserName)
        {
            return controladorOrdenes.Listar_det_gasto_pry_ot_ose_ava(N_CEO, V_CODDIV, V_CODPRY, V_ORDSRV, UserName);
        }

        [WebMethod(Description = "ORDENES DE SERVICIO DE OT'S POR PROYECTOS")]
        public DataTable Listar_detalle_gasto_pry_ot_ose(string N_CEO, string V_CODDIV, string V_CODPRY, string V_PERIODO, string UserName)
        {
            return controladorOrdenes.Listar_detalle_gasto_pry_ot_ose(N_CEO, V_CODDIV, V_CODPRY, V_PERIODO, UserName);
        }

        [WebMethod(Description = "ORDENES DE COMPRA DE OT'S POR PROYECTOS")]
        public DataTable Listar_det_gasto_pry_ot_oco(string D_AÑO, string V_CENTRO_OPERATIVO, string V_DIVISION, string V_PROYECTO, string UserName)
        {
            return controladorOrdenes.Listar_det_gasto_pry_ot_oco(D_AÑO, V_CENTRO_OPERATIVO, V_DIVISION, V_PROYECTO, UserName);
        }

        [WebMethod(Description = "ORDENES DE SERVICIO POR PROYECTO (RESUMEN)")]
        public DataTable Listar_resumen_ose(string D_AÑO, string V_CENTRO_OPERATIVO, string V_DIVISION, string V_PROYECTO, string UserName)
        {
            return controladorOrdenes.Listar_resumen_ose(D_AÑO, V_CENTRO_OPERATIVO, V_DIVISION, V_PROYECTO, UserName);
        }

        [WebMethod(Description = "ORDENES DE SERVICIO POR FECHA DE EMISION")]
        public DataTable Listar_detalle_ose_femision(string D_FECHAFIN, string D_FECHAINI, string N_CEO, string UserName)
        {
            return controladorOrdenes.Listar_detalle_ose_femision(D_FECHAFIN, D_FECHAINI, N_CEO, UserName);
        }
        #endregion

        #region Procedimientos almacenados de clasificacion: Ot

        [WebMethod(Description = "RELACION DE OT'S POR PROYECTOS")]
        public DataTable Listar_detg_pry_ot_sinfact(string CENTRO_OPERATIVO, string DIVISION, string PROYECTO,string AÑO, string UserName)
        {
            return controladorOt.Listar_detg_pry_ot_sinfact(CENTRO_OPERATIVO, DIVISION, PROYECTO, AÑO, UserName);
        }
        #endregion

        #region Procedimientos almacenados de clasificacion: Pagos

        [WebMethod(Description = "GASTOS DIRECTOS DE OT'S  (SERVICIOS) POR PROYECTOS")]
        public DataTable Listar_resumen_ose_partida(string N_CEO, string V_CODDIV, string V_CODPRY, string V_PERIODO, string UserName)
        {
            return controladorPagos.Listar_resumen_ose_partida(N_CEO, V_CODDIV, V_CODPRY, V_PERIODO, UserName);
        }

        [WebMethod(Description = " GASTOS DIRECTOS DE OT'S  (MATERIALES) POR PROYECTOS")]
        public DataTable Listar_det_gto_mat_pry_ot_partid(string N_CEO, string V_CODDIV, string V_CODPRY, string UserName)
        {
            return controladorPagos.Listar_det_gto_mat_pry_ot_partid(N_CEO, V_CODDIV, V_CODPRY, UserName);
        }

        [WebMethod(Description = " ORDENES DE COMPRA DE OT'S POR PROYECTOS con tipo cambio")]
        public DataTable Listar_det_gast_pry_ot_oco_ate_acu(string D_AÑO, string V_CENTRO_OPERATIVO, string V_DIVISION, string V_PROYECTO, string UserName)
        {
            return controladorPagos.Listar_det_gast_pry_ot_oco_ate_acu(D_AÑO, V_CENTRO_OPERATIVO, V_DIVISION, V_PROYECTO, UserName);
        }

        [WebMethod(Description = "GASTOS DE PROYECTOS AGRUPADOR POR OT'S ")]
        public DataTable Listar_gastos_proyectos_ot_v3(string N_CEO, string V_CODDIV, string V_CODPRY, string UserName)
        {
            return controladorPagos.Listar_gastos_proyectos_ot_v3(N_CEO, V_CODDIV, V_CODPRY, UserName);
        }
        #endregion
    }
}

