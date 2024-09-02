using AccesoDatos.Estandar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.NoTransaccional.GestionProduccion
{ 
    public class OtNTAD
    {
        private readonly IStandarProcedure _standarProcedure;

        public OtNTAD(IStandarProcedure standarProcedure)
        {
            _standarProcedure = standarProcedure;
        }

        public DataTable Listar_detg_pry_ot_sinfact(string sCENTRO_OPERATIVO, string sDIVISION, string sPROYECTO,string sAnio, string UserName)
        {
            string packageName = "CONSULTA.PKG_PROYECTOS.SP_DETG_PRY_OT_SINFACT";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("v_Centro_Opera", sCENTRO_OPERATIVO);
            parameters.Add("v_Division", sDIVISION);
            parameters.Add("v_Proyecto", sPROYECTO);
            parameters.Add("D_Año", sAnio);
            parameters.Add("UserName", UserName);

            try
            {
                return _standarProcedure.EjecutarProcedimiento(packageName, parameters);
            }
            catch
            {
                return null;
            }
        }

        public DataTable Listar_detalle_gasto_pry_ot_fac(string N_CEO, string V_CODDIV, string V_CODPRY, string V_PERIODO, string UserName)
        {
            string packageName = "CONSULTA.PKG_PRODUCCION.SP_DETALLE_GASTO_PRY_OT_FAC";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("N_CEO", N_CEO);
            parameters.Add("V_CODDIV", V_CODDIV);
            parameters.Add("V_CODPRY", V_CODPRY);
            parameters.Add("V_PERIODO", V_PERIODO);
            parameters.Add("UserName", UserName);

            try
            {
                return _standarProcedure.EjecutarProcedimiento(packageName, parameters);
            }
            catch
            {
                return null;
            }
        }

        public DataTable Listar_lista_ots_dq(string D_FECHAFIN, string D_FECHAINI, string N_CEO, string V_CODDIV, string UserName)
        {
            string packageName = "CONSULTA.PKG_PRODUCCION.SP_LISTA_OTS_DQ";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_FECHAFIN", D_FECHAFIN);
            parameters.Add("D_FECHAINI", D_FECHAINI);
            parameters.Add("N_CEO", N_CEO);
            parameters.Add("V_CODDIV", V_CODDIV);
            parameters.Add("UserName", UserName);

            try
            {
                return _standarProcedure.EjecutarProcedimiento(packageName, parameters);
            }
            catch
            {
                return null;
            }
        }

        public DataTable Listar_cabecera_ot(string N_CEO, string V_CODDIV, string V_NROOTS, string UserName)
        {
            string packageName = "CONSULTA.PKG_PRODUCCION.SP_CABECERA_OT";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("N_CEO", N_CEO);
            parameters.Add("V_CODDIV", V_CODDIV);
            parameters.Add("V_NROOTS", V_NROOTS);
            parameters.Add("UserName", UserName);

            try
            {
                return _standarProcedure.EjecutarProcedimiento(packageName, parameters);
            }
            catch
            {
                return null;
            }
        }

        public DataTable Listar_actividad_ot(string N_CEO, string V_CODDIV, string V_NROOTS, string UserName)
        {
            string packageName = "CONSULTA.PKG_PRODUCCION.SP_ACTIVIDAD_OT";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("N_CEO", N_CEO);
            parameters.Add("V_CODDIV", V_CODDIV);
            parameters.Add("V_NROOTS", V_NROOTS);
            parameters.Add("UserName", UserName);

            try
            {
                return _standarProcedure.EjecutarProcedimiento(packageName, parameters);
            }
            catch
            {
                return null;
            }
        }

        public DataTable Listar_lista_estado_ot(string D_FECHAFIN, string D_FECHAINI, string N_CEO, string V_CODDIV, string V_CODSTD, string V_NROOTS, string UserName)
        {
            string packageName = "CONSULTA.PKG_PRODUCCION.SP_LISTA_ESTADO_OT";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_FECHAFIN", D_FECHAFIN);
            parameters.Add("D_FECHAINI", D_FECHAINI);
            parameters.Add("N_CEO", N_CEO);
            parameters.Add("V_CODDIV", V_CODDIV);
            parameters.Add("V_CODSTD", V_CODSTD);
            parameters.Add("V_NROOTS", V_NROOTS);
            parameters.Add("UserName", UserName);

            try
            {
                return _standarProcedure.EjecutarProcedimiento(packageName, parameters);
            }
            catch
            {
                return null;
            }
        }
        // 1.-Proyecto OT's     (submarinos) 
        public DataTable Listar_det_gasto_pry_ot_sin_factsu(string V_CENTRO_OPERATIVO, string V_DIVISION, string V_PROYECTO, string UserName)
        {
            string packageName = "CONSULTA.PKG_PRODUCCION.SP_DET_GASTO_PRY_OT_SIN_FACTSU";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            
            V_PROYECTO = "'"+ V_PROYECTO+ "'"; // para el caso del campo que es string pero la base datos lo reconoce como númerico
            parameters.Add("V_CEO", V_CENTRO_OPERATIVO);
            parameters.Add("V_DIVISION", V_DIVISION);
            parameters.Add("V_PROYECTO",V_PROYECTO);
            parameters.Add("UserName", UserName);

            try
            {
                return _standarProcedure.EjecutarProcedimiento(packageName, parameters);
            }
            catch
            {
                return null;
            }
        }
        // 10.-Proyecto Facturación     (submarinos)
        public DataTable Listar_det_gasto_pry_ot_facsu(string V_CENTRO_OPERATIVO, string V_DIVISIÓN, string V_PROYECTO, string UserName)
        {
            string packageName = "CONSULTA.PKG_PRODUCCION.SP_DET_GASTO_PRY_OT_FACSU";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("V_CENTRO_OPERATIVO", V_CENTRO_OPERATIVO);
            parameters.Add("V_DIVISIÓN", V_DIVISIÓN);
            parameters.Add("V_PROYECTO", V_PROYECTO);
            parameters.Add("UserName", UserName);

            try
            {
                return _standarProcedure.EjecutarProcedimiento(packageName, parameters);
            }
            catch
            {
                return null;
            }
        }

        public DataTable Listar_actividades_jg(string D_FECHAFIN, string D_FECHAINI, string N_CEO, string N_OPCION, string V_CODDIV, string UserName)
        {
            string packageName = "CONSULTA.PKG_PRODUCCION.SP_ACTIVIDADES_JG";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_FECHAFIN", D_FECHAFIN);
            parameters.Add("D_FECHAINI", D_FECHAINI);
            parameters.Add("N_CEO", N_CEO);
            parameters.Add("N_OPCION", N_OPCION);
            parameters.Add("V_CODDIV", V_CODDIV);
            parameters.Add("UserName", UserName);

            try
            {
                return _standarProcedure.EjecutarProcedimiento(packageName, parameters);
            }
            catch
            {
                return null;
            }
        }

        public DataTable Listar_actividades_jg2(string D_FECHAFIN, string D_FECHAINI, string N_CEO, string N_OPCION, string V_CODDIV, string V_CODTLLR, string UserName)
        {
            string packageName = "CONSULTA.PKG_PRODUCCION.SP_ACTIVIDADES_JG2";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_FECHAFIN", D_FECHAFIN);
            parameters.Add("D_FECHAINI", D_FECHAINI);
            parameters.Add("N_CEO", N_CEO);
            parameters.Add("N_OPCION", N_OPCION);
            parameters.Add("V_CODDIV", V_CODDIV);
            parameters.Add("V_CODTLLR", V_CODTLLR);
            parameters.Add("UserName", UserName);

            try
            {
                return _standarProcedure.EjecutarProcedimiento(packageName, parameters);
            }
            catch
            {
                return null;
            }
        }

        public DataTable Listar_gasto_otsx(string D_FECHAFIN, string D_FECHAINI, string N_CEO, string V_CODDIV, string V_CODPROY, string V_NROOTS, string UserName)
        {
            string packageName = "CONSULTA.PKG_PRODUCCION.SP_GASTO_OTSX";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_FECHAFIN", D_FECHAFIN);
            parameters.Add("D_FECHAINI", D_FECHAINI);
            parameters.Add("N_CEO", N_CEO);
            parameters.Add("V_CODDIV", V_CODDIV);
            parameters.Add("V_CODPROY", V_CODPROY);
            parameters.Add("V_NROOTS", V_NROOTS);
            parameters.Add("UserName", UserName);

            try
            {
                return _standarProcedure.EjecutarProcedimiento(packageName, parameters);
            }
            catch
            {
                return null;
            }
        }
        public DataTable Listar_acta_conf_inf_gen(string V_CODUND, string V_NROOTS, string UserName)
        {
            string packageName = "CONSULTA.PKG_PRODUCCION.SP_ACTA_CONF_INF_GEN";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("V_CODUND", V_CODUND);
            parameters.Add("V_NROOTS", V_NROOTS);
            parameters.Add("UserName", UserName);

            try
            {
                return _standarProcedure.EjecutarProcedimiento(packageName, parameters);
            }
            catch
            {
                return null;
            }
        }

        public DataTable Listar_acta_conf_solmn(string V_CODUND, string V_NROOTS, string UserName)
        {
            string packageName = "CONSULTA.PKG_PRODUCCION.SP_ACTA_CONF_SOLMN";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("V_CODUND", V_CODUND);
            parameters.Add("V_NROOTS", V_NROOTS);
            parameters.Add("UserName", UserName);

            try
            {
                return _standarProcedure.EjecutarProcedimiento(packageName, parameters);
            }
            catch
            {
                return null;
            }
        }
        public DataTable Listar_acta_conf(string V_CODUND, string V_NROOTS, string UserName)
        {
            string packageName = "CONSULTA.PKG_PRODUCCION.SP_Acta_Conf";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("V_CODUND", V_CODUND);
            parameters.Add("V_NROOTS", V_NROOTS);
            parameters.Add("UserName", UserName);

            try
            {
                return _standarProcedure.EjecutarProcedimiento(packageName, parameters);
            }
            catch
            {
                return null;
            }
        }
        public DataTable Listar_detalle_ots_recursos_pryc(string N_CEO, string V_CODATV, string V_CODDIV, string V_CODPROY, string V_NROOTS, string V_TIPRCS, string UserName)
        {
            string packageName = "CONSULTA.PKG_PRODUCCION.SP_DETALLE_OTS_RECURSOS_PRYCT";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("N_CEO", N_CEO);
            parameters.Add("V_CODATV", V_CODATV);
            parameters.Add("V_CODDIV", V_CODDIV);
            parameters.Add("V_CODPROY", V_CODPROY);
            parameters.Add("V_NROOTS", V_NROOTS);
            parameters.Add("V_TIPRCS", V_TIPRCS);
            parameters.Add("UserName", UserName);

            try
            {
                return _standarProcedure.EjecutarProcedimiento(packageName, parameters);
            }
            catch
            {
                return null;
            }
        }
       
        public DataTable Listar_detalle_ots_recursos(string N_CEO, string V_CATVCRV, string V_CODDIV, string V_NROOTS, string V_TIPRCS, string UserName)
        {
            string packageName = "CONSULTA.PKG_PRODUCCION.SP_DETALLE_OTS_RECURSOS";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("N_CEO", N_CEO);
            parameters.Add("V_CATVCRV", V_CATVCRV);
            parameters.Add("V_CODDIV", V_CODDIV);
            parameters.Add("V_NROOTS", V_NROOTS);
            parameters.Add("V_TIPRCS", V_TIPRCS);
            parameters.Add("UserName", UserName);

            try
            {
                return _standarProcedure.EjecutarProcedimiento(packageName, parameters);
            }
            catch
            {
                return null;
            }
        }

        public DataTable Listar_actividad_ot_proy(string N_CEO, string V_CODDIV, string V_CODPRY, string UserName)
        {
            string packageName = "CONSULTA.PKG_PRODUCCION.SP_ACTIVIDAD_OT_PROY";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("N_CEO", N_CEO);
            parameters.Add("V_CODDIV", V_CODDIV);
            parameters.Add("V_CODPRY", V_CODPRY);
            parameters.Add("UserName", UserName);

            try
            {
                return _standarProcedure.EjecutarProcedimiento(packageName, parameters);
            }
            catch
            {
                return null;
            }
        }

        public DataTable SP_LISTA_PLANILAxTpxDvxAuxFech(string sTipo, string sDivision, string sAreaU, string sFecha,string sAmbiente, string UserName)
        {
            string packageName = "CONSULTA.PKG_PRODUCCION.SP_LISTA_PLANILAxTpxDvxAuxFech";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("v_ambiente", sAmbiente);
            parameters.Add("v_mod", sTipo);
            parameters.Add("v_tllini", sAreaU);
            parameters.Add("v_linea", sDivision);
            parameters.Add("v_fecha", sFecha);
            parameters.Add("UserName", UserName);

            try
            {
                return _standarProcedure.EjecutarProcedimiento(packageName, parameters);
            }
            catch
            {
                return null;
            }
        }

        public DataTable BuscaAprobaciónPLL(string sTipoPL, string sAreaU, string sNivel, string sFecha, string sAmbiente, string UserName)
        {
            string packageName = "CONSULTA.PKG_PRODUCCION.SP_LISTA_CONFOR_PLANILLA";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("v_ambiente", sAmbiente);
            parameters.Add("v_mod", sTipoPL);
            parameters.Add("v_tllini", sAreaU);
            parameters.Add("v_nivel", sNivel);
            parameters.Add("v_fecha", sFecha);
            parameters.Add("UserName", UserName);

            try
            {
                return _standarProcedure.EjecutarProcedimiento(packageName, parameters);
            }
            catch
            {
                return null;
            }
        }


    }
}
