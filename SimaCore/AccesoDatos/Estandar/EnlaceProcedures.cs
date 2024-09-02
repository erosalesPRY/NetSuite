using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Estandar
{
    public class EnlaceProcedures
    {
        private readonly IStandarProcedure _standarProcedure;

        public EnlaceProcedures(IStandarProcedure standarProcedure)
        {
            _standarProcedure = standarProcedure;
        }

        public DataTable SP_AtencionesServiciosCC(string N_CEO, string V_CODCCO, string D_FECHAINI, string D_FECHAFIN, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_AtencionesServiciosCC";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("N_CEO", N_CEO);
            parameters.Add("V_CODCCO", V_CODCCO);
            parameters.Add("D_FECHAINI", D_FECHAINI);
            parameters.Add("D_FECHAFIN", D_FECHAFIN);
            parameters.Add("UserName", UserName);

            try
            {
                // Ejecutar el procedimiento almacenado utilizando el servicio de StandarProcedure
                return _standarProcedure.EjecutarProcedimiento(packageName, parameters);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable ALMAC_OCO_VALJDE(string D_FECINIALM, string D_FECFINALM, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.ALMAC_OCO_VALJDE";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("D_FECINIALM", D_FECINIALM);
            parameters.Add("D_FECFINALM", D_FECFINALM);
            parameters.Add("UserName", UserName);

            try
            {
                return _standarProcedure.EjecutarProcedimiento(packageName, parameters);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable AVANCE_OSE_VALJDE(string D_FECHAINI, string D_FECHAFIN, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.AVANCE_OSE_VALJDE";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("D_FECHAINI", D_FECHAINI);
            parameters.Add("D_FECHAFIN", D_FECHAFIN);
            parameters.Add("UserName", UserName);

            try
            {
                return _standarProcedure.EjecutarProcedimiento(packageName, parameters);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
