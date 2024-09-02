using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Estandar;

namespace AccesoDatos.NoTransaccional.GestionTesoreria
{
    public class PagosNTAD
    {
        private readonly IStandarProcedure _standarProcedure;

        public PagosNTAD(IStandarProcedure standarProcedure)
        {
            _standarProcedure = standarProcedure;
        }

        public DataTable Listar_cheque_giradoxnum(string V_CENTRO_OPERATIVO, string V_CHEQUE_NUMERO, string UserName)
        {
            string packageName = "CONSULTA.PKG_TESORERIA.SP_CHEQUE_GIRADOXNUM";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("V_CENTRO_OPERATIVO", V_CENTRO_OPERATIVO);
            parameters.Add("V_CHEQUE_NUMERO", V_CHEQUE_NUMERO);
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

        public DataTable Listar_cheques_egresos_directos(string D_AÑO, string D_MES_DESDE, string D_MES_HASTA, string V_CENTRO_OPERATIVO, string V_MONEDA, string V_TIPO_DE_OPERACION, string UserName)
        {
            string packageName = "CONSULTA.PKG_TESORERIA.SP_CHEQUES_EGRESOS_DIRECTOS";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("V_CENTRO_OPERATIVO", V_CENTRO_OPERATIVO);
            parameters.Add("D_AÑO", D_AÑO);
            parameters.Add("D_MES_DESDE", D_MES_DESDE);
            parameters.Add("D_MES_HASTA", D_MES_HASTA);
            parameters.Add("V_MONEDA", V_MONEDA);
            parameters.Add("V_TIPO_DE_OPERACION", V_TIPO_DE_OPERACION);
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

        public DataTable Listar_cheques_emitidos_resumen(string D_AÑO, string V_CENTRO_OPERATIVO, string UserName)
        {
            string packageName = "CONSULTA.PKG_TESORERIA.SP_CHEQUES_EMITIDOS_RESUMEN";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("V_CENTRO_OPERATIVO", V_CENTRO_OPERATIVO);
            parameters.Add("D_AÑO", D_AÑO);  
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

        public DataTable Listar_cheques_giradosxprove_det(string D_FECHA_DESDE, string D_FECHA_HASTA, string V_CENTRO_OPERATIVO, string V_RELACION_DESDE, string V_RELACION_HASTA, string UserName)
        {
            string packageName = "CONSULTA.PKG_TESORERIA.SP_CHEQUES_GIRADOSXPROVE_DET";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("V_CENTRO_OPERATIVO", V_CENTRO_OPERATIVO);
            parameters.Add("V_RELACION_DESDE", V_RELACION_DESDE);
            parameters.Add("V_RELACION_HASTA", V_RELACION_HASTA);
            parameters.Add("D_FECHA_DESDE", D_FECHA_DESDE);
            parameters.Add("D_FECHA_HASTA", D_FECHA_HASTA);    
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

        public DataTable Listar_cheques_giradosxprove_res(string D_AÑO, string D_MES, string V_CENTRO_OPERATIVO, string V_RELACION_DESDE, string V_RELACION_HASTA, string UserName)
        {
            string packageName = "CONSULTA.PKG_TESORERIA.SP_CHEQUES_GIRADOSXPROVE_RES";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("V_CENTRO_OPERATIVO", V_CENTRO_OPERATIVO);
            parameters.Add("V_RELACION_DESDE", V_RELACION_DESDE);
            parameters.Add("V_RELACION_HASTA", V_RELACION_HASTA);
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

        public DataTable Listar_cheques_por_observacion(string D_FECHA_DESDE, string D_FECHA_HASTA, string V_CENTRO_OPERATIVO, string V_OBSERVACION, string UserName)
        {
            string packageName = "CONSULTA.PKG_TESORERIA.SP_CHEQUES_POR_OBSERVACION";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("V_CENTRO_OPERATIVO", V_CENTRO_OPERATIVO);
            parameters.Add("D_FECHA_DESDE", D_FECHA_DESDE);
            parameters.Add("D_FECHA_HASTA", D_FECHA_HASTA);
            parameters.Add("V_OBSERVACION", V_OBSERVACION);
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
        public DataTable Listar_lote_de_detrac_por_doc(string V_CENTRO_OPERATIVO, string V_NUMERO_DE_LOTE, string UserName)
        {
            string packageName = "CONSULTA.PKG_TESORERIA.SP_LOTE_DE_DETRAC_POR_DOC";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("V_CENTRO_OPERATIVO", V_CENTRO_OPERATIVO);
            parameters.Add("V_NUMERO_DE_LOTE", V_NUMERO_DE_LOTE);
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
        public DataTable Listar_fact_pagar_pendientes(string V_RECURSO,string V_RUC,string V_PROYECTO,string UserName)
        {
            string packageName = "CONSULTA.PKG_TESORERIA.SP_FACT_PAGAR_PENDIENTES";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("V_RECURSO", V_RECURSO);
            parameters.Add("V_RUC", V_RUC);
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
        public DataTable Listar_fact_por_pagar_doc(string D_AÑO, string D_MES, string V_RELACION_DESDE, string V_RELACION_HASTA, string UserName)
        {
            string packageName = "CONSULTA.PKG_TESORERIA.SP_FACT_POR_PAGAR_DOC";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_AÑO", D_AÑO);
            parameters.Add("D_MES", D_MES);
            parameters.Add("V_RELACION_DESDE", V_RELACION_DESDE);
            parameters.Add("V_RELACION_HASTA", V_RELACION_HASTA);
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
        public DataTable Listar_facturas_por_pagar_total(string UserName)
        {
            string packageName = "CONSULTA.PKG_TESORERIA.SP_Facturas_por_Pagar_Total";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
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
