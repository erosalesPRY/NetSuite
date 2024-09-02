using AccesoDatos.Estandar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.NoTransaccional.GestionProyecto
{ 
    public class OtNTAD
    {
        private readonly IStandarProcedure _standarProcedure;

        public OtNTAD(IStandarProcedure standarProcedure)
        {
            _standarProcedure = standarProcedure;
        }
        DataTable tb_Error = new DataTable("Tabla_Errores");
        public DataTable Listar_detg_pry_ot_sinfact(string CENTRO_OPERATIVO, string DIVISION, string PROYECTO,string AÑO, string UserName)
        {
            string packageName = "CONSULTA.PKG_PROYECTOS.SP_DetG_PRY_OT_SINFACT";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("v_Centro_Opera", CENTRO_OPERATIVO);
            parameters.Add("v_Division", DIVISION);
            parameters.Add("v_Proyecto", PROYECTO.Replace("-","" ));
            parameters.Add("V_ANIO", AÑO);
            parameters.Add("UserName", UserName);

            try
            {
                return _standarProcedure.EjecutarProcedimiento(packageName, parameters);
            }
            catch (Exception exception)
            {
                tb_Error.Clear();
                tb_Error.Columns.Clear();
                tb_Error.Columns.Add("Descripcion_Error", typeof(string));
                tb_Error.Rows.Add(exception.Message);
                return tb_Error; //  return null;
            }
        }
        public DataTable Listar_ots_por_proyecto(string V_CENTRO_OPERATIVO, string V_DIVISION, string V_PROYECTO, string UserName)
        {
            string packageName = "CONSULTA.PKG_PROYECTOS.SP_OTS_POR_PROYECTO";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

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


    }
}