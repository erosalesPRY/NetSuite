using System.Collections.Generic;
using System.Data;
using AccesoDatos.Estandar;

namespace AccesoDatos.NoTransaccional.GestionLogistica
{
    public class ServiciosNTAD
    {
        private readonly IStandarProcedure _standarProcedure;

        public ServiciosNTAD(IStandarProcedure standarProcedure)
        {
            _standarProcedure = standarProcedure;
        }

        public DataTable Listar_Catalogo_Servicios_SR(string CLASE, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_Catalogo_Servicios_SR";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("CLASE", CLASE);
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