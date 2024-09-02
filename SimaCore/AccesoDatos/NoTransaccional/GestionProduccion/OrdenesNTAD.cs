using AccesoDatos.Estandar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.NoTransaccional.GestionProduccion
{ 
    public class OrdenesNTAD
    {
        private readonly IStandarProcedure _standarProcedure;

        public OrdenesNTAD(IStandarProcedure standarProcedure)
        {
            _standarProcedure = standarProcedure;
        }

        public DataTable Listar_detalle_gasto_pry_ot_oses(string N_CEO, string V_CODDIV, string V_CODPRY, string V_NROOTS, string UserName)
        {
            string packageName = "CONSULTA.PKG_PRODUCCION.SP_DETALLE_GASTO_PRY_OT_OSESU";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("N_CEO", N_CEO);
            parameters.Add("V_CODDIV", V_CODDIV);
            parameters.Add("V_CODPRY", V_CODPRY);
            parameters.Add("V_NROOTS", V_NROOTS);
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

        public DataTable Listar_det_gasto_pry_ot_ocosu(string V_CENTRO_OPERATIVO, string V_DIVISIÓN, string V_NROOTS, string V_PROYECTO, string V_ANIO, string UserName)
        {
            string packageName = "CONSULTA.PKG_PRODUCCION.SP_DET_GASTO_PRY_OT_OCOSU";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("N_CEO", V_CENTRO_OPERATIVO);
            parameters.Add("V_CODDIV", V_DIVISIÓN);
            parameters.Add("V_NROOTS", V_NROOTS);
            parameters.Add("V_PROYECTO", V_PROYECTO);
            parameters.Add("V_ANIO", V_ANIO);
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

        public DataTable Listar_ot_ocompra(string D_FECHA_INICIO, string D_FECHA_FIN, string V_DIVISION, string UserName)
        {
            string packageName = "CONSULTA.PKG_PRODUCCION.SP_OT_OCOMPRA";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_FECHA_INICIO", D_FECHA_INICIO);
            parameters.Add("D_FECHA_FIN", D_FECHA_FIN);
            parameters.Add("V_DIVISION", V_DIVISION);
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