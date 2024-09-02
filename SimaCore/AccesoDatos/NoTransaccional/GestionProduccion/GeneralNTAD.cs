using AccesoDatos.Estandar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.NoTransaccional.GestionProduccion
{
    public class GeneralNTAD
    { 
        private readonly IStandarProcedure _standarProcedure;

        public GeneralNTAD(IStandarProcedure standarProcedure)
        {
            _standarProcedure = standarProcedure;
        }

        public DataTable Listar_tarifa_maq(string V_TALLER, string UserName)
        {
            string packageName = "CONSULTA.PKG_PRODUCCION.SP_TARIFA_MAQ";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("V_TALLER", V_TALLER);
            parameters.Add("UserName", UserName);

            try
            {
                DataTable dt = _standarProcedure.EjecutarProcedimiento(packageName, parameters);
                return dt;
            }
            catch
            {
                return null;
            }
        }
    }
}