using AccesoDatos.Estandar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.NoTransaccional.GestionProyecto
{ 
    public class PagosNTAD
    {
        private readonly IStandarProcedure _standarProcedure;

        public PagosNTAD(IStandarProcedure standarProcedure)
        {
            _standarProcedure = standarProcedure;
        }

        public DataTable Listar_resumen_ose_partida(string N_CEO, string V_CODDIV, string V_CODPRY, string V_PERIODO, string UserName)
        {
            string packageName = "CONSULTA.PKG_PROYECTOS.SP_RESUMEN_OSE_PARTIDA";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("N_CEO", N_CEO);
            parameters.Add("V_CODDIV", V_CODDIV);
            parameters.Add("V_CODPRY", V_CODPRY);
            parameters.Add("V_PERIODO", V_PERIODO);
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

        public DataTable Listar_det_gto_mat_pry_ot_partid(string N_CEO, string V_CODDIV, string V_CODPRY, string UserName)
        {
            string packageName = "CONSULTA.PKG_PROYECTOS.SP_DET_GTO_MAT_PRY_OT_PARTIDA";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("N_CEO", N_CEO);
            parameters.Add("V_CODDIV", V_CODDIV);
            parameters.Add("V_CODPRY", V_CODPRY);
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

        public DataTable Listar_det_gast_pry_ot_oco_ate_acu(string D_AÑO, string V_CENTRO_OPERATIVO, string V_DIVISION, string V_PROYECTO, string UserName)
        {
            string packageName = "CONSULTA.PKG_PROYECTOS.SP_DET_GAST_PRY_OT_OCO_ATE_ACU";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_AÑO", D_AÑO);
            parameters.Add("V_CENTRO_OPERATIVO", V_CENTRO_OPERATIVO);
            parameters.Add("V_DIVISION", V_DIVISION);
            parameters.Add("V_PROYECTO", V_PROYECTO);
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
        public DataTable Listar_gastos_proyectos_ot_v3(string N_CEO, string V_CODDIV, string V_CODPRY, string UserName)
        {
            string packageName = "CONSULTA.PKG_PRODUCCION.SP_GASTOS_PROYECTOS_OT_V3";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("N_CEO", N_CEO);
            parameters.Add("V_CODDIV", V_CODDIV);
            parameters.Add("V_CODPRY", V_CODPRY);
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