using AccesoDatos.Estandar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.NoTransaccional.GestionTesoreria
{
    public class BalanceNTAD
    {
        private readonly IStandarProcedure _standarProcedure;

        public BalanceNTAD(IStandarProcedure standarProcedure)
        {
            _standarProcedure = standarProcedure;
        }

        public DataTable Listar_conci_banc_r_cartola_conc(string D_AÑO, string D_MES, string V_CARTOLA, string V_CENTRO_OPERATIVO, string V_MONEDA, string UserName)
        {
            string packageName = "CONSULTA.PKG_TESORERIA.SP_CONCI_BANC_R_CARTOLA_CONCI";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_AÑO", D_AÑO);
            parameters.Add("D_MES", D_MES);
            parameters.Add("V_CARTOLA", V_CARTOLA);
            parameters.Add("V_CENTRO_OPERATIVO", V_CENTRO_OPERATIVO);
            parameters.Add("V_MONEDA", V_MONEDA);
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

        public DataTable Listar_conci_bancaria_res_cartol(string D_AÑO, string D_MES, string V_CARTOLA, string V_CENTRO_OPERATIVO, string V_MONEDA, string UserName)
        {
            string packageName = "CONSULTA.PKG_TESORERIA.SP_CONCI_BANCARIA_RES_CARTOLA";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("V_CENTRO_OPERATIVO", V_CENTRO_OPERATIVO);
            parameters.Add("D_AÑO", D_AÑO);
            parameters.Add("D_MES", D_MES);
            parameters.Add("V_MONEDA", V_MONEDA);
            parameters.Add("V_CARTOLA", V_CARTOLA);
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

        public DataTable Listar_conciliacion_banc_cartola(string D_AÑO, string D_MES, string V_CARTOLA, string V_CENTRO_OPERATIVO, string V_MONEDA, string UserName)
        {
            string packageName = "CONSULTA.PKG_TESORERIA.SP_CONCILIACION_BANC_CARTOLA";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("V_CENTRO_OPERATIVO", V_CENTRO_OPERATIVO);
            parameters.Add("D_AÑO", D_AÑO);
            parameters.Add("D_MES", D_MES);
            parameters.Add("V_MONEDA", V_MONEDA);
            parameters.Add("V_CARTOLA", V_CARTOLA); 
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

        public DataTable Listar_detalle_ffj_gf(string D_AÑO, string V_LIQUIDACION, string UserName)
        {
            string packageName = "CONSULTA.PKG_TESORERIA.SP_DETALLE_FFJ_GF";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_AÑO", D_AÑO);
            parameters.Add("V_LIQUIDACION", V_LIQUIDACION);
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

        public DataTable Listar_libro_banco(string D_AÑO, string D_MES, string V_BANCO, string V_CENTRO_OPERATIVO, string V_CUENTA_CORRIENTE, string UserName)
        {
            string packageName = "CONSULTA.PKG_TESORERIA.SP_LIBRO_BANCO";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_AÑO", D_AÑO);
            parameters.Add("D_MES", D_MES);
            parameters.Add("V_BANCO", V_BANCO);
            parameters.Add("V_CENTRO_OPERATIVO", V_CENTRO_OPERATIVO);
            parameters.Add("V_CUENTA_CORRIENTE", V_CUENTA_CORRIENTE);
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

        public DataTable Listar_res_ffj_x_centro_costos(string D_AÑO, string V_LIQUIDACION, string UserName)
        {
            string packageName = "CONSULTA.PKG_TESORERIA.SP_RES_FFJ_X_CENTRO_COSTOS";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_AÑO", D_AÑO);
            parameters.Add("V_LIQUIDACION", V_LIQUIDACION);
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
        public DataTable Listar_cheques_egresos_directos(string D_AÑO, string D_MES_DESDE, string D_MES_HASTA, string V_CENTRO_OPERATIVO, string V_MONEDA, string V_TIPO_DE_OPERACION, string UserName)
        {
            string packageName = "CONSULTA.PKG_TESORERIA.SP_CHEQUES_EGRESOS_DIRECTOS";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("V_CENTRO_OPERATIVO", V_CENTRO_OPERATIVO);
            parameters.Add("D_AÑO", D_AÑO);
            parameters.Add("D_MES_DESDE", D_MES_DESDE);
            parameters.Add("D_MES_HASTA", D_MES_HASTA);
            parameters.Add("V_MONEDA", V_MONEDA);
            parameters.Add("V_TIPO_DE_OPERACION", V_TIPO_DE_OPERACION);
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
