using System.Collections.Generic;
using System.Data;
using AccesoDatos.Estandar;

namespace AccesoDatos.NoTransaccional.GestionLogistica
{
    public class ProyectosNTAD
    {
        private readonly IStandarProcedure _standarProcedure;

        public ProyectosNTAD(IStandarProcedure standarProcedure)
        {
            _standarProcedure = standarProcedure;
        }

        public DataTable Listar_PRY_PAG_TOT(string Centro_Operativo, string división, string Proyecto, string Nro_Orden,
            string Procedencia, string Tipo_Orden, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_PRY_PAG_TOT";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Centro_Operativo", Centro_Operativo);
            parameters.Add("división", división);
            parameters.Add("Proyecto", Proyecto);
            parameters.Add("Nro_Orden", Nro_Orden);
            parameters.Add("Procedencia", Procedencia);
            parameters.Add("Tipo_Orden", Tipo_Orden);
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