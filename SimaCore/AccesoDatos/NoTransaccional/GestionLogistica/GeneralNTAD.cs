using AccesoDatos.Estandar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.NoTransaccional.GestionLogistica
{
    public class GeneralNTAD
    {
        private readonly IStandarProcedure _standarProcedure;

        public GeneralNTAD(IStandarProcedure standarProcedure)
        {
            _standarProcedure = standarProcedure;
        }

        public DataTable Listar_TG_EQUIVALENICIASGENERICAS(string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_TG_EQUIVALENICIASGENERICAS";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
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

        public DataTable Listar_TG_EQUIVALENICIASPORMATERIA(string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_TG_EQUIVALENICIASPORMATERIA";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
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

        public DataTable Listar_Tg_Unidad_Medida(string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_Tg_Unidad_Medida";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
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
