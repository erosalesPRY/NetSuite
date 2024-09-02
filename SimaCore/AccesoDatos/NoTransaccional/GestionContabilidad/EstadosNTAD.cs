using AccesoDatos.Estandar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.NoTransaccional.GestionContabilidad
{
    public class EstadosNTAD
    {
        private readonly IStandarProcedure _standarProcedure;

        public EstadosNTAD(IStandarProcedure standarProcedure)
        {
            _standarProcedure = standarProcedure;
        }

        public DataTable Listar_estado_finan_casillas_txt(string D_AÑO, string V_CASILLA, string V_MONTO_MINIMO, string UserName)
        {
            string packageName = "CONSULTA.PKG_CONTABILIDAD.SP_ESTADO_FINAN_CASILLAS_TXT";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_AÑO", D_AÑO);
            parameters.Add("V_CASILLA", V_CASILLA);
            parameters.Add("V_MONTO_MINIMO", V_MONTO_MINIMO);
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

        public DataTable Listar_mayor_auxi_cuenta_resumen(string D_AÑO, string D_MES, string V_CUENTA_DESDE, string V_CUENTA_HASTA, string UserName)
        {
            string packageName = "CONSULTA.PKG_CONTABILIDAD.SP_MAYOR_AUXI_CUENTA_RESUMEN";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_AÑO", D_AÑO);
            parameters.Add("D_MES", D_MES);
            parameters.Add("V_CUENTA_DESDE", V_CUENTA_DESDE);
            parameters.Add("V_CUENTA_HASTA", V_CUENTA_HASTA);
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
        public DataTable Listar_analisis_cuentas_nat(string D_AÑO, string D_MES_DESDE, string D_MES_HASTA, string V_CENTRO_OPERATIVO, string V_CTA_MAYOR_DESDE, string V_CTA_MAYOR_HASTA, string V_C_COSTO_DESDE, string V_C_COSTO_HASTA, string UserName)
        {
            string packageName = "CONSULTA.PKG_CONTABILIDAD.SP_ANALISIS_CUENTAS_NAT";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_AÑO", D_AÑO);
            parameters.Add("D_MES_DESDE", D_MES_DESDE);
            parameters.Add("D_MES_HASTA", D_MES_HASTA);
            parameters.Add("V_CENTRO_OPERATIVO", V_CENTRO_OPERATIVO);
            parameters.Add("V_CTA_MAYOR_DESDE", V_CTA_MAYOR_DESDE);
            parameters.Add("V_CTA_MAYOR_HASTA", V_CTA_MAYOR_HASTA);
            parameters.Add("V_C_COSTO_DESDE", V_C_COSTO_DESDE);
            parameters.Add("V_C_COSTO_HASTA", V_C_COSTO_HASTA);
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
        public DataTable Listar_mayor_auxi_pend_rel_res(string D_AÑO, string D_MES, string V_CUENTA, string V_RELACION_DESDE, string V_RELACION_HASTA, string UserName)
        {
            string packageName = "CONSULTA.PKG_CONTABILIDAD.SP_MAYOR_AUXI_PEND_REL_RES";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_AÑO", D_AÑO);
            parameters.Add("D_MES", D_MES);
            parameters.Add("V_CUENTA", V_CUENTA);
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

        public DataTable Listar_conci_bancaria_resumen(string D_AÑO, string D_MES, string V_COD_BCO, string V_CUENTA_CORRIENTE, string UserName)
        {
            string packageName = "CONSULTA.PKG_CONTABILIDAD.SP_CONCI_BANCARIA_RESUMEN";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_AÑO", D_AÑO);
            parameters.Add("D_MES", D_MES);
            parameters.Add("V_COD_BCO", V_COD_BCO);
            parameters.Add("V_CUENTA_CORRIENTE", V_CUENTA_CORRIENTE);
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

        public DataTable Listar_Estado_del_Proceso(string UserName)
        {
            string packageName = "CONSULTA.PKG_CONTABILIDAD.SP_Estado_del_Proceso";
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
        public DataTable Listar_Mayor_Auxiliar_Pendientes_por_Cuenta_Resumen(string V_Cuenta_Desde,string V_Cuenta_Hasta,string D_Año,string D_Mes, string UserName)
        {
            string packageName = "CONSULTA.PKG_CONTABILIDAD.SP_MaXAuxiliar_PendCuenta_Res";
    
            Dictionary<string, object> parameters = new Dictionary<string, object>();
           
            parameters.Add("V_Cuenta_Desde", V_Cuenta_Desde);
            parameters.Add("V_Cuenta_Hasta", V_Cuenta_Hasta);
            parameters.Add("D_Año", D_Año);
            parameters.Add("D_Mes", D_Mes);
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
