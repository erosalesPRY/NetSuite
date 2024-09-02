using AccesoDatos.Estandar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.NoTransaccional.GestionCostos
{
    public class PagosNTAD
    {
        private readonly IStandarProcedure _standarProcedure;

        public PagosNTAD(IStandarProcedure standarProcedure)
        {
            _standarProcedure = standarProcedure;
        }

        public DataTable Listar_analisis_gastos_ccnatudet(string D_AÑO_DE_PROCESO, string D_MES_DE_PROCESO, string V_CENTRO_OPERATIVO, string V_CUENTA_MAYOR, string UserName)
        {
            string packageName = "CONSULTA.PKG_COSTOS.SP_ANALISIS_GASTOS_CCNATUDET";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_AÑO_DE_PROCESO", D_AÑO_DE_PROCESO);
            parameters.Add("D_MES_DE_PROCESO", D_MES_DE_PROCESO);
            parameters.Add("V_CENTRO_OPERATIVO", V_CENTRO_OPERATIVO);
            parameters.Add("V_CUENTA_MAYOR", V_CUENTA_MAYOR);
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

        public DataTable Listar_analisis_gast_itemsasient(string V_CENTRO_OPERATIVO, string V_DIVISION, string V_NUMERO_OT, string UserName)
        {
            string packageName = "CONSULTA.PKG_COSTOS.SP_ANALISIS_GAST_ITEMSASIENTOT";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("V_CENTRO_OPERATIVO", V_CENTRO_OPERATIVO);
            parameters.Add("V_DIVISION", V_DIVISION);
            parameters.Add("V_NUMERO_OT", V_NUMERO_OT);
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