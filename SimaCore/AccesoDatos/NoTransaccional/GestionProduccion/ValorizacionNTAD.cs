using AccesoDatos.Estandar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.NoTransaccional.GestionProduccion
{ 
    public class ValorizacionNTAD
    {
        private readonly IStandarProcedure _standarProcedure;

        public ValorizacionNTAD(IStandarProcedure standarProcedure)
        {
            _standarProcedure = standarProcedure;
        }

        public DataTable Listar_est_actividad(string N_CEO, string V_CODDIV, string V_NROVAL, string UserName)
        {
            string packageName = "CONSULTA.PKG_PRODUCCION.SP_EST_ACTIVIDAD";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("N_CEO", N_CEO);
            parameters.Add("V_CODDIV", V_CODDIV);
            parameters.Add("V_NROVAL", V_NROVAL);
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

        public DataTable Listar_est_actividad_01(string N_CEO, string V_CODDIV, string V_NROVAL, string UserName)
        {
            string packageName = "CONSULTA.PKG_PRODUCCION.SP_EST_ACTIVIDAD_01";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("N_CEO", N_CEO);
            parameters.Add("V_CODDIV", V_CODDIV);
            parameters.Add("V_NROVAL", V_NROVAL);
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

        public DataTable Listar_lista_ots_se_01(string V_ANIO, string V_OPCION, string UserName)
        {
            string packageName = "CONSULTA.PKG_PRODUCCION.SP_LISTA_OTS_SE_01";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("V_ANIO", V_ANIO);
            parameters.Add("V_OPCION", V_OPCION);
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

        public DataTable Listar_valorizacionr(string D_FECHAFIN, string D_FECHAINI, string N_CEO, string V_CODDIV, string UserName)
        {
            string packageName = "CONSULTA.PKG_PRODUCCION.SP_VALORIZACIONR";
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

        public DataTable Listar_valorizacionr_(string D_FECHAFIN, string D_FECHAINI, string V_CO, string V_DIVISION, string UserName)
        {
            string packageName = "CONSULTA.PKG_PRODUCCION.SP_VALORIZACIONR_";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_FECHAFIN", D_FECHAFIN);
            parameters.Add("D_FECHAINI", D_FECHAINI);
            parameters.Add("V_CO", V_CO);
            parameters.Add("V_DIVISION", V_DIVISION);
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

        public DataTable Listar_valorizacionrproy(string V_CO, string V_DIVISION, string V_OT, string V_PROYECTO, string UserName)
        {
            string packageName = "CONSULTA.PKG_PRODUCCION.SP_VALORIZACIONRPROY";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("V_CO", V_CO);
            parameters.Add("V_DIVISION", V_DIVISION);
            parameters.Add("V_OT", V_OT);
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

        public DataTable Listar_valorizacionrproy_02(string D_FECHAFIN, string D_FECHAINI, string V_CO, string V_DIVISION, string V_PROYECTO, string UserName)
        {
            string packageName = "CONSULTA.PKG_PRODUCCION.SP_VALORIZACIONRPROY_02";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_FECHAFIN", D_FECHAFIN);
            parameters.Add("D_FECHAINI", D_FECHAINI);
            parameters.Add("V_CO", V_CO);
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

        public DataTable Listar_valorizacionrunidad(string N_CEO, string V_CODCLI, string V_CODDIV, string V_CODUND, string V_PERIODO, string UserName)
        {
            string packageName = "CONSULTA.PKG_PRODUCCION.SP_VALORIZACIONRUNIDAD";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("N_CEO", N_CEO);
            parameters.Add("V_CODCLI", V_CODCLI);
            parameters.Add("V_CODDIV", V_CODDIV);
            parameters.Add("V_CODUND", V_CODUND);
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

        public DataTable Listar_valorizacionrxan(string N_CEO, string V_CODDIV, string V_PAAMM, string UserName)
        {
            string packageName = "CONSULTA.PKG_PRODUCCION.SP_VALORIZACIONRXAN";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("N_CEO", N_CEO);
            parameters.Add("V_CODDIV", V_CODDIV);
            parameters.Add("V_PAAMM", V_PAAMM);
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

        public DataTable Listar_valorizacionr01(string D_FECHAFIN, string D_FECHAINI, string V_CO, string V_DIVISION, string UserName)
        {
            string packageName = "CONSULTA.PKG_PRODUCCION.SP_VALORIZACIONR01";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_FECHAFIN", D_FECHAFIN);
            parameters.Add("D_FECHAINI", D_FECHAINI);
            parameters.Add("V_CO", V_CO);
            parameters.Add("V_DIVISION", V_DIVISION);
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

        public DataTable Listar_valorizacionrproy01(string V_CO, string V_DIVISION, string V_PROYECTO, string UserName)
        {
            string packageName = "CONSULTA.PKG_PRODUCCION.SP_VALORIZACIONRPROY01";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("V_CO", V_CO);
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
    }
  }
 