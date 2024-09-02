using AccesoDatos.Estandar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.NoTransaccional.GestionProduccion
{ 
    public class MobNTAD
    {
        private readonly IStandarProcedure _standarProcedure;

        public MobNTAD(IStandarProcedure standarProcedure)
        {
            _standarProcedure = standarProcedure;
        }

        public DataTable Listar_vacaciones(string D_PERIODO, string V_CO, string V_ROL, string UserName)
        {
            string packageName = "CONSULTA.PKG_PRODUCCION.SP_VACACIONES";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_PERIODO", D_PERIODO);
            parameters.Add("V_CO", V_CO);
            parameters.Add("V_ROL", V_ROL);
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

        public DataTable Listar_novedades_paus(string N_CEO, string V_CODUNS, string V_PERIODO, string UserName)
        {
            string packageName = "CONSULTA.PKG_PRODUCCION.SP_NOVEDADES_PAUS";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("N_CEO", N_CEO);
            parameters.Add("V_CODUNS", V_CODUNS);
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

        public DataTable Listar_mob_x_fecha(string D_FECHAFIN, string D_FECHAINI, string N_CEO, string UserName)
        {
            string packageName = "CONSULTA.PKG_PRODUCCION.SP_MOB_X_FECHA";
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

        public DataTable Listar_lista_saldo_mo(string N_CEO, string V_CATVCRV, string V_CODDIV, string V_CODPROY, string V_NROOTS, string UserName)
        {
            string packageName = "CONSULTA.PKG_PRODUCCION.SP_LISTA_SALDO_MO";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("N_CEO", N_CEO);
            parameters.Add("V_CATVCRV", V_CATVCRV);
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
    }
}