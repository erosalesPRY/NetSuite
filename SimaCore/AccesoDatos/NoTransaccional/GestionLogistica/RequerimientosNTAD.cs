using System.Collections.Generic;
using System.Data;
using AccesoDatos.Estandar;

namespace AccesoDatos.NoTransaccional.GestionLogistica
{
    public class RequerimientosNTAD
    {
        private readonly IStandarProcedure _standarProcedure;

        public RequerimientosNTAD(IStandarProcedure standarProcedure)
        {
            _standarProcedure = standarProcedure;
        }

        public DataTable Listar_Presupuesto(string PERIODO_PRESUPUESTO, string TIPO_DE_RECURSO, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_Presupuesto";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("PERIODO_PRESUPUESTO", PERIODO_PRESUPUESTO);
            parameters.Add("TIPO_DE_RECURSO", TIPO_DE_RECURSO);
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