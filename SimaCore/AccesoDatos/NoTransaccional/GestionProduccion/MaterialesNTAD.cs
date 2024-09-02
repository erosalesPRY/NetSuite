using AccesoDatos.Estandar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.NoTransaccional.GestionProduccion
{
    public class MaterialesNTAD
    { 
        private readonly IStandarProcedure _standarProcedure;

        public MaterialesNTAD(IStandarProcedure standarProcedure)
        {
            _standarProcedure = standarProcedure;
        }

        public DataTable Listar_lista_materiales(string V_CODDIV, string V_NROVAL, string UserName)
        {
            string packageName = "CONSULTA.PKG_PRODUCCION.SP_LISTA_MATERIALES";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

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
    }
}