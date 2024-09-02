using AccesoDatos.Estandar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.NoTransaccional.GestionContabilidad
{
    public class GeneralNTAD
    {
        private readonly IStandarProcedure _standarProcedure;

        public GeneralNTAD(IStandarProcedure standarProcedure)
        {
            _standarProcedure = standarProcedure;
        }

        public DataTable Listar_forma_pago_sunat_pdb_txt(string D_AÑO, string D_MES, string UserName)
        {
            string packageName = "CONSULTA.PKG_CONTABILIDAD.SP_FORMA_PAGO_SUNAT_PDB_TXT";
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

        public DataTable Listar_tipo_de_cambio_txt(string D_AÑO, string D_MES_DESDE, string D_MES_HASTA, string V_MONEDA, string UserName)
        {
            string packageName = "CONSULTA.PKG_CONTABILIDAD.SP_TIPO_DE_CAMBIO_TXT";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_AÑO", D_AÑO);
            parameters.Add("D_MES_DESDE", D_MES_DESDE);
            parameters.Add("D_MES_HASTA", D_MES_HASTA);
            parameters.Add("V_MONEDA", V_MONEDA);
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
        public DataTable Listar_centros_de_costo(string V_CENTRO_OPERATIVO, string V_GRUPO_CC_DESDE, string V_GRUPO_CC_HASTA, string UserName)
        {
            string packageName = "CONSULTA.PKG_CONTABILIDAD.SP_CENTROS_DE_COSTO";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("V_CENTRO_OPERATIVO", V_CENTRO_OPERATIVO);
            parameters.Add("V_GRUPO_CC_DESDE", V_GRUPO_CC_DESDE);
            parameters.Add("V_GRUPO_CC_HASTA", V_GRUPO_CC_HASTA);
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

        public DataTable Listar_tipo_de_cambio(string V_ANIO, string V_CODMND, string V_MESFIN, string V_MESINI, string UserName)
        {
            string packageName = "CONSULTA.PKG_CONTABILIDAD.SP_TIPO_DE_CAMBIO";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("V_ANIO", V_ANIO);
            parameters.Add("V_CODMND", V_CODMND);
            parameters.Add("V_MESFIN", V_MESFIN);
            parameters.Add("V_MESINI", V_MESINI);
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