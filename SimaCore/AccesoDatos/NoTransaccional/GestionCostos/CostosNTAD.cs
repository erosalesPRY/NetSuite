using AccesoDatos.Estandar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.NoTransaccional.GestionCostos
{
    public class CostosNTAD
    {
        private readonly IStandarProcedure _standarProcedure;

        public CostosNTAD(IStandarProcedure standarProcedure)
        {
            _standarProcedure = standarProcedure;
        }

        public DataTable Listar_costo_prod_linea_neg_resu(string D_AÑO, string D_MES, string V_CENTRO_OPERATIVO, string V_LINEA_NEGOCIO, string UserName)
        {
            string packageName = "CONSULTA.PKG_COSTOS.SP_COSTO_PROD_LINEA_NEG_RESU";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_AÑO", D_AÑO);
            parameters.Add("D_MES", D_MES);
            parameters.Add("V_CENTRO_OPERATIVO", V_CENTRO_OPERATIVO);
            parameters.Add("V_LINEA_NEGOCIO", V_LINEA_NEGOCIO);
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
        public DataTable Listar_costo_prod_linea_neg_det(string D_AÑO, string D_MES, string V_CENTRO_OPERATIVO, string V_LINEA_NEGOCIO, string UserName)
        {
            string packageName = "CONSULTA.PKG_COSTOS.SP_COSTO_PROD_LINEA_NEG_DET";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_AÑO", D_AÑO);
            parameters.Add("D_MES", D_MES);
            parameters.Add("V_CENTRO_OPERATIVO", V_CENTRO_OPERATIVO);
            parameters.Add("V_LINEA_NEGOCIO", V_LINEA_NEGOCIO);
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