using AccesoDatos.Estandar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.NoTransaccional.GestionContabilidad
{
    public class BalanceNTAD
    {
        private readonly IStandarProcedure _standarProcedure;

        public BalanceNTAD(IStandarProcedure standarProcedure)
        {
            _standarProcedure = standarProcedure;
        }

        public DataTable Listar_balance_constructivo_mef(string D_AÑO, string D_MES, string D_MES_AJUSTE, string V_CODCEO, string UserName)
        {
            string packageName = "CONSULTA.PKG_CONTABILIDAD.SP_BALANCE_CONSTRUCTIVO_MEF";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_AÑO", D_AÑO);
            parameters.Add("D_MES", D_MES);
            parameters.Add("D_MES_AJUSTE", D_MES_AJUSTE);
            parameters.Add("V_CODCEO", V_CODCEO);
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

        public DataTable Listar_balance_de_comprobacion(string D_MES, string D_PERIODO, string V_CENTRO_OPERATIVO, string V_CUENTA_DESDE, string V_CUNETA_HASTA, string UserName)
        {
            string packageName = "CONSULTA.PKG_CONTABILIDAD.SP_BALANCE_DE_COMPROBACION";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_MES", D_MES);
            parameters.Add("D_PERIODO", D_PERIODO);
            parameters.Add("V_CENTRO_OPERATIVO", V_CENTRO_OPERATIVO);
            parameters.Add("V_CUENTA_DESDE", V_CUENTA_DESDE);
            parameters.Add("V_CUNETA_HASTA", V_CUNETA_HASTA);
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

        public DataTable Listar_balance_de_comprobacion_p(string D_AÑO, string D_MES, string D_MES_AJUSTE, string UserName)
        {
            string packageName = "CONSULTA.PKG_CONTABILIDAD.SP_BALANCE_DE_COMPROBACION_PDT";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_AÑO", D_AÑO);
            parameters.Add("D_MES", D_MES);
            parameters.Add("D_MES_AJUSTE", D_MES_AJUSTE);
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

        public DataTable Listar_bal_constructivo_susalud(string D_AÑO, string D_MES, string UserName)
        {
            string packageName = "CONSULTA.PKG_CONTABILIDAD.SP_BAL_CONSTRUCTIVO_SUSALUD";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_AÑO", D_AÑO);
            parameters.Add("D_MES", D_MES);
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