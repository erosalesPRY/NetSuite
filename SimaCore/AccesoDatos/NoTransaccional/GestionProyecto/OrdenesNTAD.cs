using AccesoDatos.Estandar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.NoTransaccional.GestionProyecto
{ 
    public class OrdenesNTAD
    {
        private readonly IStandarProcedure _standarProcedure;

        public OrdenesNTAD(IStandarProcedure standarProcedure)
        {
            _standarProcedure = standarProcedure;
        }

        public DataTable Listar_det_gasto_pry_ot_ose_ava(string N_CEO, string V_CODDIV, string V_CODPRY, string V_ORDSRV, string UserName)
        {
            string packageName = "CONSULTA.PKG_PRODUCCION.SP_DET_GASTO_PRY_OT_OSE_AVA";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("N_CEO", N_CEO);
            parameters.Add("V_CODDIV", V_CODDIV);
            parameters.Add("V_CODPRY", V_CODPRY);
            parameters.Add("V_ORDSRV", V_ORDSRV);
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

        public DataTable Listar_detalle_gasto_pry_ot_ose(string N_CEO, string V_CODDIV, string V_CODPRY, string V_PERIODO, string UserName)
        {
            string packageName = "CONSULTA.PKG_PRODUCCION.SP_DETALLE_GASTO_PRY_OT_OSE";
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

        public DataTable Listar_det_gasto_pry_ot_oco(string D_AÑO, string V_CENTRO_OPERATIVO, string V_DIVISION, string V_PROYECTO, string UserName)
        {
            string packageName = "CONSULTA.PKG_PROYECTOS.SP_DET_GASTO_PRY_OT_OCO";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_AÑO", D_AÑO);
            parameters.Add("V_CENTRO_OPERATIVO", V_CENTRO_OPERATIVO);
            parameters.Add("V_DIVISION", V_DIVISION);
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

        public DataTable Listar_resumen_ose(string D_AÑO, string V_CENTRO_OPERATIVO, string V_DIVISION, string V_PROYECTO, string UserName)
        {
            string packageName = "CONSULTA.PKG_PROYECTOS.SP_RESUMEN_OSE";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_AÑO", D_AÑO);
            parameters.Add("V_CENTRO_OPERATIVO", V_CENTRO_OPERATIVO);
            parameters.Add("V_DIVISION", V_DIVISION);
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

        public DataTable Listar_detalle_ose_femision(string D_FECHAFIN, string D_FECHAINI, string N_CEO, string UserName)
        {
            string packageName = "CONSULTA.PKG_PROYECTOS.SP_DETALLE_OSE_FEMISION";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_FECHAFIN", D_FECHAFIN);
            parameters.Add("D_FECHAINI", D_FECHAINI);
            parameters.Add("N_CEO", N_CEO);
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