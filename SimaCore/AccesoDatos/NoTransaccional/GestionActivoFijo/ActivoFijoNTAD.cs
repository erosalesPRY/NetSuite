using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Estandar;

namespace AccesoDatos.NoTransaccional.GestionActivoFijo
{
    public class ActivoFijoNTAD
    {
        private readonly IStandarProcedure _standarProcedure;

        public ActivoFijoNTAD(IStandarProcedure standarProcedure)
        {
            _standarProcedure = standarProcedure;
        }

        public DataTable Listar_actfijo_cons_inv(string COD_EMP, string EST_BIEN, string UserName)
        {
            string packageName = "CONSULTA.PKG_ACTIVO_FIJO.SP_ACTFIJO_CONS_INV";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("COD_EMP", COD_EMP);
            parameters.Add("EST_BIEN", EST_BIEN);
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
        
        public DataTable Listar_actfijo_pen(string COD_EMP, string EST_BIEN, string UserName)
        {
            string packageName = "CONSULTA.PKG_ACTIVO_FIJO.SP_ACTFIJO_PEN";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("COD_EMP", COD_EMP);
            parameters.Add("EST_BIEN", EST_BIEN);
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

        public DataTable Listar_altascuentord_m(string ANIO, string COD_EMP, string EST_BIEN, string MES, string UserName)
        {
            string packageName = "CONSULTA.PKG_ACTIVO_FIJO.SP_ALTASCUENTORD_M";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("ANIO", ANIO);
            parameters.Add("COD_EMP", COD_EMP);
            parameters.Add("EST_BIEN", EST_BIEN);
            parameters.Add("MES", MES);
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

        public DataTable Listar_altasmes_actf(string ANIO, string COD_EMP, string EST_BIEN, string MES, string UserName)
        {
            string packageName = "CONSULTA.PKG_ACTIVO_FIJO.SP_ALTASMES_ACTF";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("ANIO", ANIO);
            parameters.Add("COD_EMP", COD_EMP);
            parameters.Add("EST_BIEN", EST_BIEN);
            parameters.Add("MES", MES);
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

        public DataTable Listar_formato_7_1(string COD_EMP, string N_ANIO, string UserName)
        {
            string packageName = "CONSULTA.PKG_ACTIVO_FIJO.SP_FORMATO_7_1";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("COD_EMP", COD_EMP);
            parameters.Add("N_ANIO", N_ANIO);
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

        public DataTable Listar_invent_actxgrupoysubgrsmn(string COD_EMPE, string GRUPOBN, string SUBGRUPOBN, string TIPOACTV, string UserName)
        {
            string packageName = "CONSULTA.PKG_ACTIVO_FIJO.SP_INVENT_ACTXGRUPOYSUBGRSMN";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("COD_EMPE", COD_EMPE);
            parameters.Add("GRUPOBN", GRUPOBN);
            parameters.Add("SUBGRUPOBN", SUBGRUPOBN);
            parameters.Add("TIPOACTV", TIPOACTV);
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

        public DataTable Listar_inventario_activosxcc(string CCOSTO1, string CCOSTO2, string COD_EMPE, string COD_PANOL, string TIPOACTV, string UserName)
        {
            string packageName = "CONSULTA.PKG_ACTIVO_FIJO.SP_INVENTARIO_ACTIVOSXCC";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("CCOSTO1", CCOSTO1);
            parameters.Add("CCOSTO2", CCOSTO2);
            parameters.Add("COD_EMPE", COD_EMPE);
            parameters.Add("COD_PANOL", COD_PANOL);
            parameters.Add("TIPOACTV", TIPOACTV);
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

        public DataTable Listar_inventario_activosxccrsm(string CCOSTO1, string CCOSTO2, string COD_EMPE, string TIPOACTV, string UserName)
        {
            string packageName = "CONSULTA.PKG_ACTIVO_FIJO.SP_INVENTARIO_ACTIVOSXCCRSM";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("CCOSTO1", CCOSTO1);
            parameters.Add("CCOSTO2", CCOSTO2);
            parameters.Add("COD_EMPE", COD_EMPE);
            parameters.Add("TIPOACTV", TIPOACTV);
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

        public DataTable Listar_inventario_activosxcustod(string COD_EMPE, string COD_ROL, string TIPOACTV, string UserName)
        {
            string packageName = "CONSULTA.PKG_ACTIVO_FIJO.SP_INVENTARIO_ACTIVOSXCUSTODIO";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("COD_EMPE", COD_EMPE);
            parameters.Add("COD_ROL", COD_ROL);
            parameters.Add("TIPOACTV", TIPOACTV);
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

        public DataTable Listar_inventario_actsgrup_sub(string COD_EMP, string EST_BIEN, string GRUPO, string SUBGRUPO, string TIPO_BIEN, string UserName)
        {
            string packageName = "CONSULTA.PKG_ACTIVO_FIJO.SP_INVENTARIO_ACTSGRUP_SUB";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("COD_EMP", COD_EMP);
            parameters.Add("EST_BIEN", EST_BIEN);
            parameters.Add("GRUPO", GRUPO);
            parameters.Add("SUBGRUPO", SUBGRUPO);
            parameters.Add("TIPO_BIEN", TIPO_BIEN);
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

        public DataTable Lista_Bienes_toma_inventario(string CODEMP, string NRO_PR, string CCO_INI, string CCO_FIN, string UserName)
        {
            string packageName = "CONSULTA.PKg_ACTIVO_FIJO.SP_Bienes_toma_inventario";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("CODEMP", CODEMP);
            parameters.Add("NRO_PR", NRO_PR);
            parameters.Add("CCO_INI", CCO_INI);
            parameters.Add("CCO_FIN", CCO_FIN);
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
