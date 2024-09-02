using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Estandar;

namespace AccesoDatos.NoTransaccional.GestionTesoreria
{
    public class CobrosNTAD
    {
        private readonly IStandarProcedure _standarProcedure;

        public CobrosNTAD(IStandarProcedure standarProcedure)
        {
            _standarProcedure = standarProcedure;
        }

        public DataTable Listar_folios_pendientes_o7(string D_AÑO, string D_MES, string UserName)
        {
            string packageName = "CONSULTA.PKG_TESORERIA.SP_FOLIOS_PENDIENTES_O7";
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

        public DataTable Listar_ingresos_contabilizados(string D_FECHA_DESDE, string D_FECHA_HASTA, string V_CENTRO_OPERATIVO, string V_CONCEPTO, string V_DESDE, string V_EMPRESA_DESDE, string V_EMPRESA_HASTA, string V_HASTA, string V_MONEDA, string UserName)
        {
            string packageName = "CONSULTA.PKG_TESORERIA.SP_INGRESOS_CONTABILIZADOS";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("V_CENTRO_OPERATIVO", V_CENTRO_OPERATIVO);
            parameters.Add("D_FECHA_DESDE", D_FECHA_DESDE);
            parameters.Add("D_FECHA_HASTA", D_FECHA_HASTA);
            parameters.Add("V_MONEDA", V_MONEDA);
            parameters.Add("V_DESDE", V_DESDE);
            parameters.Add("V_HASTA", V_HASTA);
            parameters.Add("V_CONCEPTO", V_CONCEPTO);
            parameters.Add("V_EMPRESA_DESDE", V_EMPRESA_DESDE);
            parameters.Add("V_EMPRESA_HASTA", V_EMPRESA_HASTA);           
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

        public DataTable Listar_ventas_x_orden_trabajo(string V_CENTRO_OPERATIVO, string V_DIVISION, string V_NUMERO_OT, string UserName)
        {
            string packageName = "CONSULTA.PKG_TESORERIA.SP_VENTAS_X_ORDEN_TRABAJO";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("V_CENTRO_OPERATIVO", V_CENTRO_OPERATIVO);
            parameters.Add("V_DIVISION", V_DIVISION);
            parameters.Add("V_NUMERO_OT", V_NUMERO_OT);
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
        public DataTable Listar_fact_cobrar_sector_privado(string UserName)
        {
            string packageName = "CONSULTA.PKG_TESORERIA.SP_Fact_Cobrar_Sector_Privado";
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
        public DataTable Listar_fact_cobrar_sector_marina(string UserName)
        {
            string packageName = "CONSULTA.PKG_TESORERIA.SP_Fact_Cobrar_Sector_Marina";
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
