using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Description;
using AccesoDatos.Estandar;
using AccesoDatos.NoTransaccional.GestionProduccion;
using AccesoDatos.Transaccional.GestionProduccion;
using Controladora.GestionProduccion;
using EntidadNegocio.GestionProduccion;
using WSCore.GestionCostos;

using System.Configuration;

namespace WSCore.GestionProduccion
{
    /// <summary>
    /// Descripción breve de Produccion
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Produccion : System.Web.Services.WebService
    {

        // ----- traemos de la deficion "AppSettings" el key  connfigurado en el webconfig
        string sAmbiente = ConfigurationManager.AppSettings["Ambiente"];
       
        #region Referencias a Controladores 

        private static MaterialesNTAD materiales = new MaterialesNTAD(new StandarProcedure());
        CMateriales controladorMateriales = new CMateriales(materiales);

        private static MobNTAD mob = new MobNTAD(new StandarProcedure());
        CMob controladorMob = new CMob(mob);

        private static OrdenesNTAD ordenes = new OrdenesNTAD(new StandarProcedure());
        COrdenes controladorOrdenes = new COrdenes(ordenes);

        private static OtNTAD ot = new OtNTAD(new StandarProcedure());
        COt controladorOt = new COt(ot);

        private static GeneralNTAD general= new GeneralNTAD(new StandarProcedure());    
        cGeneral controladorGeneral= new cGeneral(general);

        private static ValorizacionNTAD valorizacion = new ValorizacionNTAD(new StandarProcedure());
        CValorizacion controladorValorizacion = new CValorizacion(valorizacion);



        #endregion
        #region Referencias Controladores DE TRANSACCION
             CActividad cActividad = new CActividad();
            
            private static OtNTAD ctot = new OtNTAD(new StandarProcedure()); // usamos una referencia a la clase NTAD por que la clases OT requiere para sus TAD
            COt cOt = new COt(ctot);

        #endregion
      
        
        #region Metodos Actividades

        [WebMethod(Description = "Actualiza Descripción de una Actividad de una OT")]
        public string Modifica_Actividad_Desc(int iCodigoOT, string sCodigoDiv, string sCodigoActiv,
            int iNroCrv, string sUserReg, string sCodigoTll, string sDescrip, string sUsuario)
        {
            try
            {

                ActividadBE oActividadBE = new ActividadBE();
                oActividadBE.ambiente = sAmbiente;
                oActividadBE.CodigoOT = iCodigoOT;
                oActividadBE.CodigoDiv = sCodigoDiv;
                oActividadBE.CodigoActiv = sCodigoActiv;
                oActividadBE.NroCrv = iNroCrv;
                oActividadBE.UserReg = sUserReg;
                oActividadBE.CodigoTll = sCodigoTll;
                oActividadBE.DescripcionD = sDescrip;
                oActividadBE.UserName = sUsuario;
                return cActividad.Modifica(oActividadBE);
            }
            catch (Exception ex)
            {
                return "-1";

            }
        }

        #endregion

        #region Metodos Ordenes Trabajo
        [WebMethod(Description = "Actualiza Descripción de la Orden de Trabajo")]
        public string Modifica_OT_Desc(int iCodigoOT, string sCodigoDiv, string sDescrip,
             string sUserReg, string sUsuario)
        {
            try
            {

                OtBE oOtBE = new OtBE();
                oOtBE.ambiente = sAmbiente;
                oOtBE.CodigoOT = iCodigoOT;
                oOtBE.CodigoDiv = sCodigoDiv;
                oOtBE.DescripcionD = sDescrip;
                oOtBE.UserReg = sUserReg; // usuario que solicita el cambio
                oOtBE.UserName = sUsuario; // usuario de OTIC que realizar el cambio
                return cOt.Modifica(oOtBE);
            }
            catch (Exception ex)
            {
                return "-1";

            }
        }
        #endregion

        #region Procedimientos almacenados de clasificacion: General

        [WebMethod(Description = " Tarifas maquinarias")]
        public DataTable Listar_tarifa_maq(string V_TALLER, string UserName)
        {
            return controladorGeneral.Listar_tarifa_maq(V_TALLER, UserName);
        }

        #endregion
        #region Procedimientos almacenados de clasificacion: Materiales

        [WebMethod(Description = "Lista De Materiales")]
        public DataTable Listar_lista_materiales(string V_CODDIV, string V_NROVAL, string UserName)
        {
            return controladorMateriales.Listar_Lista_Materiales(V_CODDIV, V_NROVAL, UserName);
        }

        #endregion

        #region Procedimientos almacenados de clasificacion: Mob

        [WebMethod(Description = "Vacaciones - Mano de obra directa e indirecta")]
        public DataTable Listar_vacaciones(string D_PERIODO, string V_CO, string V_ROL, string UserName)
        {
            return controladorMob.Listar_vacaciones(D_PERIODO, V_CO, V_ROL, UserName);
        }

        [WebMethod(Description = "Novedades de planilla")]
        public DataTable Listar_novedades_paus(string N_CEO, string V_CODUNS, string V_PERIODO, string UserName)
        {
            return controladorMob.Listar_novedades_paus(N_CEO, V_CODUNS, V_PERIODO, UserName);
        }

        [WebMethod(Description = "Mano de obra")]
        public DataTable Listar_mob_x_fecha(string D_FECHAFIN, string D_FECHAINI, string N_CEO, string UserName)
        {
            return controladorMob.Listar_mob_x_fecha(D_FECHAFIN, D_FECHAINI, N_CEO, UserName);
        }

        [WebMethod(Description = "Saldos de Mano de Obra")]
        public DataTable Listar_lista_saldo_mo(string N_CEO, string V_CATVCRV, string V_CODDIV, string V_CODPROY, string V_NROOTS, string UserName)
        {
            return controladorMob.Listar_lista_saldo_mo(N_CEO, V_CATVCRV, V_CODDIV, V_CODPROY, V_NROOTS, UserName);
        }
        #endregion

        #region Procedimientos almacenados de clasificacion: Ordenes

        [WebMethod(Description = "ORDENES DE SERVICIO DE OT'S POR PROYECTOS SUBMARINOS")]
        public DataTable Listar_detalle_gasto_pry_ot_oses(string N_CEO, string V_CODDIV, string V_CODPRY, string V_NROOTS, string UserName)
        {
            return controladorOrdenes.Listar_detalle_gasto_pry_ot_oses(N_CEO, V_CODDIV, V_CODPRY, V_NROOTS, UserName);
        }

        [WebMethod(Description = "ORDENES DE COMPRA DE OT'S POR PROYECTOS SUBMARINOS")]
        public DataTable Listar_det_gasto_pry_ot_ocosu(string V_CENTRO_OPERATIVO, string V_DIVISIÓN, string V_NROOTS, string V_PROYECTO,string V_ANIO, string UserName)
        {
            return controladorOrdenes.Listar_det_gasto_pry_ot_ocosu(V_CENTRO_OPERATIVO, V_DIVISIÓN, V_NROOTS, V_PROYECTO,V_ANIO, UserName);
        }

        [WebMethod(Description = "Ordenes de compra OTS")]
        public DataTable Listar_ot_ocompra(string D_FECHA_INICIO, string D_FECHA_FIN, string V_DIVISION, string UserName)
        {
            return controladorOrdenes.Listar_ot_ocompra(D_FECHA_INICIO, D_FECHA_FIN, V_DIVISION, UserName);
        }
        #endregion

        #region Procedimientos almacenados de clasificacion: Ot

        [WebMethod(Description = "RELACION DE OT'S POR PROYECTOS SUBMARINOS ACTIVOS")]
        public DataTable Listar_detg_pry_ot_sinfact(string CENTRO_OPERATIVO, string DIVISION, string PROYECTO, string sAnio, string UserName)
        {
            return controladorOt.Listar_detg_pry_ot_sinfact(CENTRO_OPERATIVO, DIVISION, PROYECTO, sAnio, UserName);
        }

        [WebMethod(Description = "FACTURACION DE OT'S POR PROYECTOS")]
        public DataTable Listar_detalle_gasto_pry_ot_fac(string N_CEO, string V_CODDIV, string V_CODPRY, string V_PERIODO, string UserName)
        {
            return controladorOt.Listar_detalle_gasto_pry_ot_fac(N_CEO, V_CODDIV, V_CODPRY, V_PERIODO, UserName);
        }

        [WebMethod(Description = "Ots con Facturas")]
        public DataTable Listar_lista_ots_dq(string D_FECHAFIN, string D_FECHAINI, string N_CEO, string V_CODDIV, string UserName)
        {
            return controladorOt.Listar_lista_ots_dq(D_FECHAFIN, D_FECHAINI, N_CEO, V_CODDIV, UserName);
        }

        [WebMethod(Description = "INFORMACION DE  DE CABERECA  DE LA OT")]
        public DataTable Listar_cabecera_ot(string N_CEO, string V_CODDIV, string V_NROOTS, string UserName)
        {
            return controladorOt.Listar_cabecera_ot(N_CEO, V_CODDIV, V_NROOTS, UserName);
        }

        [WebMethod(Description = "INFORMACION DE ACTIVIDADES DE LAS OT'S x OT")]
        public DataTable Listar_actividad_ot(string N_CEO, string V_CODDIV, string V_NROOTS, string UserName)
        {
            return controladorOt.Listar_actividad_ot(N_CEO, V_CODDIV, V_NROOTS, UserName);
        }

        [WebMethod(Description = "Gastos Directos de Ots por fecha de utilizacion")]
        public DataTable Listar_lista_estado_ot(string D_FECHAFIN, string D_FECHAINI, string N_CEO, string V_CODDIV, string V_CODSTD, string V_NROOTS, string UserName)
        {
            return controladorOt.Listar_lista_estado_ot(D_FECHAFIN, D_FECHAINI, N_CEO, V_CODDIV, V_CODSTD, V_NROOTS, UserName);
        }

        [WebMethod(Description = "1 Proyecto OT's  (submarinos)")]
        public DataTable Listar_det_gasto_pry_ot_sin_factsu(string V_CENTRO_OPERATIVO, string V_DIVISION, string V_PROYECTO, string UserName)
        {
            return controladorOt.Listar_det_gasto_pry_ot_sin_factsu(V_CENTRO_OPERATIVO, V_DIVISION, V_PROYECTO, UserName);
        }

        [WebMethod(Description = "10 FACTURACION DE OT'S POR PROYECTOS SUBMARINOS")]
        public DataTable Listar_det_gasto_pry_ot_facsu(string V_CENTRO_OPERATIVO, string V_DIVISIÓN, string V_PROYECTO, string UserName)
        {
            return controladorOt.Listar_det_gasto_pry_ot_facsu(V_CENTRO_OPERATIVO, V_DIVISIÓN, V_PROYECTO, UserName);
        }

        [WebMethod(Description = "INFORMACION DE  OT'S X FECHA")]
        public DataTable Listar_actividades_jg(string D_FECHAFIN, string D_FECHAINI, string N_CEO, string N_OPCION, string V_CODDIV, string UserName)
        {
            return controladorOt.Listar_actividades_jg(D_FECHAFIN, D_FECHAINI, N_CEO, N_OPCION, V_CODDIV, UserName);
        }

        [WebMethod(Description = "INFORMACION DE  OT'S X FECHA")]
        public DataTable Listar_actividades_jg2(string D_FECHAFIN, string D_FECHAINI, string N_CEO, string N_OPCION, string V_CODDIV, string V_CODTLLR, string UserName)
        {
            return controladorOt.Listar_actividades_jg2(D_FECHAFIN, D_FECHAINI, N_CEO, N_OPCION, V_CODDIV, V_CODTLLR, UserName);
        }

        [WebMethod(Description = "Gastos Directos de Ots por fecha de utilizacion")]
        public DataTable Listar_gasto_otsx(string D_FECHAFIN, string D_FECHAINI, string N_CEO, string V_CODDIV, string V_CODPROY, string V_NROOTS, string UserName)
        {
            return controladorOt.Listar_gasto_otsx(D_FECHAFIN, D_FECHAINI, N_CEO, V_CODDIV, V_CODPROY, V_NROOTS, UserName);
        }

        [WebMethod(Description = "INFORMACION DE ACTIVIDADES DE LAS OT'S X Proyecto")]
        public DataTable Listar_actividad_ot_proy(string N_CEO, string V_CODDIV, string V_CODPRY, string UserName)
        {
            return controladorOt.Listar_actividad_ot_proy(N_CEO, V_CODDIV, V_CODPRY, UserName);
        }

        [WebMethod(Description = "Acta de Conformidad registradas en unisys con nro de acta en el campo cod_acta de la tabla gestion.CG_ACT_CONF")]
        public DataTable Listar_acta_conf_inf_gen(string V_CODUND, string V_NROOTS, string UserName)
        {
            return controladorOt.Listar_acta_conf_inf_gen(V_CODUND, V_NROOTS, UserName);
        }

        [WebMethod(Description = "Acta de Conformidad - Detalla las valorizaciones realizadas")]
        public DataTable Listar_acta_conf_solmn(string V_CODUND, string V_NROOTS, string UserName)
        {
            return controladorOt.Listar_acta_conf_solmn(V_CODUND, V_NROOTS, UserName);
        }

        [WebMethod(Description = " Acta de Conformidad registradas en unisys con nro de acta en el campo cod_acta de la tabla gestion")]
        public DataTable Listar_acta_conf(string V_CODUND, string V_NROOTS, string UserName)
        {
            return controladorOt.Listar_acta_conf(V_CODUND, V_NROOTS, UserName);
        }

        [WebMethod(Description = " Actividades que incluyen Servicios en Ordenes de Trabajo ")]
        public DataTable Listar_detalle_ots_recursos(string N_CEO, string V_CATVCRV, string V_CODDIV, string V_NROOTS, string V_TIPRCS, string UserName)
        {
            return controladorOt.Listar_detalle_ots_recursos(N_CEO, V_CATVCRV, V_CODDIV, V_NROOTS, V_TIPRCS, UserName);
        }

        [WebMethod(Description = " Actividades que incluyen Servicios en Ordenes de Trabajo ")]
        public DataTable Listar_detalle_ots_recursos_pryc(string N_CEO, string V_CODATV, string V_CODDIV, string V_CODPROY, string V_NROOTS, string V_TIPRCS, string UserName)
        {
            return controladorOt.Listar_detalle_ots_recursos_pryc(N_CEO, V_CODATV, V_CODDIV, V_CODPROY, V_NROOTS, V_TIPRCS, UserName);
        }
        #endregion

        #region Procedimientos almacenados de clasificacion: Valorizacion

        [WebMethod(Description = "Listado de actividades de Valorizacion")]
        public DataTable Listar_est_actividad(string N_CEO, string V_CODDIV, string V_NROVAL, string UserName)
        {
            return controladorValorizacion.Listar_est_actividad(N_CEO, V_CODDIV, V_NROVAL, UserName);
        }

        [WebMethod(Description = "Listado de actividades de Valorizacion 2")]
        public DataTable Listar_est_actividad_01(string N_CEO, string V_CODDIV, string V_NROVAL, string UserName)
        {
            return controladorValorizacion.Listar_est_actividad_01(N_CEO, V_CODDIV, V_NROVAL, UserName);
        }

        [WebMethod(Description = "Valorizaciones de Mtto.")]
        public DataTable Listar_lista_ots_se_01(string V_ANIO, string V_OPCION, string UserName)
        {
            return controladorValorizacion.Listar_lista_ots_se_01(V_ANIO, V_OPCION, UserName);
        }

        [WebMethod(Description = "Listado de Valorizacion - Recursos")]
        public DataTable Listar_valorizacionr(string D_FECHAFIN, string D_FECHAINI, string N_CEO, string V_CODDIV, string UserName)
        {
            return controladorValorizacion.Listar_valorizacionr(D_FECHAFIN, D_FECHAINI, N_CEO, V_CODDIV, UserName);
        }

        [WebMethod(Description = "Listado de Valorizacion - Recursos")]
        public DataTable Listar_valorizacionr_(string D_FECHAFIN, string D_FECHAINI, string V_CO, string V_DIVISION, string UserName)
        {
            return controladorValorizacion.Listar_valorizacionr_(D_FECHAFIN, D_FECHAINI, V_CO, V_DIVISION, UserName);
        }

        [WebMethod(Description = "Listado de Valorizacion - Recursos")]
        public DataTable Listar_valorizacionrproy(string V_CO, string V_DIVISION, string V_OT, string V_PROYECTO, string UserName)
        {
            return controladorValorizacion.Listar_valorizacionrproy(V_CO, V_DIVISION, V_OT, V_PROYECTO, UserName);
        }

        [WebMethod(Description = "Listado de Valorizacion por fecha _ Recursos")]
        public DataTable Listar_valorizacionrproy_02(string D_FECHAFIN, string D_FECHAINI, string V_CO, string V_DIVISION, string V_PROYECTO, string UserName)
        {
            return controladorValorizacion.Listar_valorizacionrproy_02(D_FECHAFIN, D_FECHAINI, V_CO, V_DIVISION, V_PROYECTO, UserName);
        }

        [WebMethod(Description = "Listado de Valorizacion - Recursos")]
        public DataTable Listar_valorizacionrunidad(string N_CEO, string V_CODCLI, string V_CODDIV, string V_CODUND, string V_PERIODO, string UserName)
        {
            return controladorValorizacion.Listar_valorizacionrunidad(N_CEO, V_CODCLI, V_CODDIV, V_CODUND, V_PERIODO, UserName);
        }

        [WebMethod(Description = "Listado Recursos de  las Valorizaciones x periodo")]
        public DataTable Listar_valorizacionrxan(string N_CEO, string V_CODDIV, string V_PAAMM, string UserName)
        {
            return controladorValorizacion.Listar_valorizacionrxan(N_CEO, V_CODDIV, V_PAAMM, UserName);
        }

        [WebMethod(Description = "Listado de Valorizacion - Recursos 01")]
        public DataTable Listar_valorizacionr01(string D_FECHAFIN, string D_FECHAINI, string V_CO, string V_DIVISION, string UserName)
        {
            return controladorValorizacion.Listar_valorizacionr01(D_FECHAFIN, D_FECHAINI, V_CO, V_DIVISION, UserName);
        }

        [WebMethod(Description = "Listado de Valorizacion por fecha _ Recursos")]
        public DataTable Listar_valorizacionrproy01(string V_CO, string V_DIVISION, string V_PROYECTO, string UserName)
        {
            return controladorValorizacion.Listar_valorizacionrproy01(V_CO, V_DIVISION, V_PROYECTO, UserName);
        }
        #endregion

       


        }
}
