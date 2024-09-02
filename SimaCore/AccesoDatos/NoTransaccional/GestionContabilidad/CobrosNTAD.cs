using AccesoDatos.Estandar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.NoTransaccional.GestionContabilidad
{
    public class CobrosNTAD
    {
        private readonly IStandarProcedure _standarProcedure;

        public CobrosNTAD(IStandarProcedure standarProcedure)
        {
            _standarProcedure = standarProcedure;
        }

        public DataTable Listar_reg_ventas_sunat_conso_pl(string D_AÑO, string D_MES, string UserName)
        {
            string packageName = "CONSULTA.PKG_CONTABILIDAD.SP_REG_VENTAS_SUNAT_CONSO_PLE";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_AÑO", D_AÑO);
            parameters.Add("D_MES", D_MES);
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
        public DataTable Listar_reg_ventas_sunat_pdb_txt(string D_AÑO, string D_MES, string UserName)
        {
            string packageName = "CONSULTA.PKG_CONTABILIDAD.SP_REG_VENTAS_SUNAT_PDB_TXT";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_AÑO", D_AÑO);
            parameters.Add("D_MES", D_MES);
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

        public DataTable Listar_registro_de_ventas(string D_AÑO, string D_MES, string V_CENTRO_OPERATIVO, string V_CONCEPTO, string V_LINEA_NEGOCIO, string V_ORIGEN, string V_SERIE, string V_TIPO_DOCUMENTO, string UserName)
        {
            string packageName = "CONSULTA.PKG_CONTABILIDAD.SP_REGISTRO_DE_VENTAS";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_AÑO", D_AÑO);
            parameters.Add("D_MES", D_MES);
            parameters.Add("V_CENTRO_OPERATIVO", V_CENTRO_OPERATIVO);
            parameters.Add("V_CONCEPTO", V_CONCEPTO);
            parameters.Add("V_LINEA_NEGOCIO", V_LINEA_NEGOCIO);
            parameters.Add("V_ORIGEN", V_ORIGEN);
            parameters.Add("V_SERIE", V_SERIE);
            parameters.Add("V_TIPO_DOCUMENTO", V_TIPO_DOCUMENTO);
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
