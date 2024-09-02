using AccesoDatos.Estandar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.NoTransaccional.GestionContabilidad
{
    public class OperacionesNTAD
    {
        private readonly IStandarProcedure _standarProcedure;

        public OperacionesNTAD(IStandarProcedure standarProcedure)
        {
            _standarProcedure = standarProcedure;
        }

        public DataTable Listar_subdiario_por_cuenta_res(string D_AÑO, string D_MES, string V_CENTRO_OPERATIVO, string V_CUENTA, string V_SUBDIARIO, string UserName)
        {
            string packageName = "CONSULTA.PKG_CONTABILIDAD.SP_SUBDIARIO_POR_CUENTA_RES";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_AÑO", D_AÑO);
            parameters.Add("D_MES", D_MES);
            parameters.Add("V_CENTRO_OPERATIVO", V_CENTRO_OPERATIVO);
            parameters.Add("V_CUENTA", V_CUENTA);
            parameters.Add("V_SUBDIARIO", V_SUBDIARIO);
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

        public DataTable Listar_libro_caja_y_bancos_sunat(string D_AÑO, string D_MES, string V_CENTRO_OPERATIVO, string UserName)
        {
            string packageName = "CONSULTA.PKG_CONTABILIDAD.SP_LIBRO_CAJA_Y_BANCOS_SUNAT";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_AÑO", D_AÑO);
            parameters.Add("D_MES", D_MES);
            parameters.Add("V_CENTRO_OPERATIVO", V_CENTRO_OPERATIVO);
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
        public DataTable Listar_libro_diario_sunat(string N_CEO, string V_ANIO, string V_MES, string V_SUBDIARIOFIN, string V_SUBDIARIOINI, string UserName)
        {
            string packageName = "CONSULTA.PKG_CONTABILIDAD.SP_LIBRO_DIARIO_SUNAT";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("N_CEO", N_CEO);
            parameters.Add("V_ANIO", V_ANIO);
            parameters.Add("V_MES", V_MES);
            parameters.Add("V_SUBDIARIOFIN", V_SUBDIARIOFIN);
            parameters.Add("V_SUBDIARIOINI", V_SUBDIARIOINI);
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

        public DataTable Listar_libro_mayor_sunat_2digito(string N_CEO, string V_ANIO, string V_MES, string UserName)
        {
            string packageName = "CONSULTA.PKG_CONTABILIDAD.SP_LIBRO_MAYOR_SUNAT_2DIGITOS";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("N_CEO", N_CEO);
            parameters.Add("V_ANIO", V_ANIO);
            parameters.Add("V_MES", V_MES);
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

        public DataTable Listar_pdt3500_operaciones3os_da(string N_MNTMIN, string V_ANIO, string UserName)
        {
            string packageName = "CONSULTA.PKG_CONTABILIDAD.SP_PDT3500_OPERACIONES3OS_DAOT";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("N_MNTMIN", N_MNTMIN);
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
        public DataTable Listar_pdt3550_detalle_operacion(string V_ANIO, string UserName)
        {
            string packageName = "CONSULTA.PKG_CONTABILIDAD.SP_PDT3550_DETALLE_OPERACIONES";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

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
        public DataTable Listar_mov_cuenta_91_92(string D_FECHA_DESDE, string D_FECHA_HASTA, string V_CENTRO_OPERATIVO, string V_CUENTA_DESDE, string V_CUENTA_HASTA, string V_SUBDIARIO_DESDE, string V_SUBDIARIO_HASTA, string UserName)
        {
            string packageName = "CONSULTA.PKG_CONTABILIDAD.SP_MOV_CUENTA_91_92";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_FECHA_DESDE", D_FECHA_DESDE);
            parameters.Add("D_FECHA_HASTA", D_FECHA_HASTA);
            parameters.Add("V_CENTRO_OPERATIVO", V_CENTRO_OPERATIVO);
            parameters.Add("V_CUENTA_DESDE", V_CUENTA_DESDE);
            parameters.Add("V_CUENTA_HASTA", V_CUENTA_HASTA);
            parameters.Add("V_SUBDIARIO_DESDE", V_SUBDIARIO_DESDE);
            parameters.Add("V_SUBDIARIO_HASTA", V_SUBDIARIO_HASTA);
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
        public DataTable Listar_plan_cuentas_pcge_2019(string V_CTA_FIN, string V_CTA_INI, string UserName)
        {
            string packageName = "CONSULTA.PKG_CONTABILIDAD.SP_PLAN_CUENTAS_PCGE_2019";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("V_CTA_FIN", V_CTA_FIN);
            parameters.Add("V_CTA_INI", V_CTA_INI);
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
        public DataTable Listar_movimiento_cuenta_96(string D_FECHA_DESDE, string D_FECHA_HASTA, string V_CENTRO_OPERATIVO, string V_CUENTA_DESDE, string V_CUENTA_HASTA, string V_SUBDIARIO_DESDE, string V_SUBDIARIO_HASTA, string UserName)
        {
            string packageName = "CONSULTA.PKG_CONTABILIDAD.SP_MOVIMIENTO_CUENTA_96";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_FECHA_DESDE", D_FECHA_DESDE);
            parameters.Add("D_FECHA_HASTA", D_FECHA_HASTA);
            parameters.Add("V_CENTRO_OPERATIVO", V_CENTRO_OPERATIVO);
            parameters.Add("V_CUENTA_DESDE", V_CUENTA_DESDE);
            parameters.Add("V_CUENTA_HASTA", V_CUENTA_HASTA);
            parameters.Add("V_SUBDIARIO_DESDE", V_SUBDIARIO_DESDE);
            parameters.Add("V_SUBDIARIO_HASTA", V_SUBDIARIO_HASTA);
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
        public DataTable Listar_asientos_por_subdiario(string D_DIAFIN, string D_DIAINI, string N_CEO, string V_ANIO, string V_ASIENTOFIN, string V_ASIENTOINI, string V_CENTROFIN, string V_CENTROINI, string V_CUENTAFIN, string V_CUENTAINI, string V_MES, string V_SUBDIARIO, string UserName)
        {
            string packageName = "CONSULTA.PKG_CONTABILIDAD.SP_ASIENTOS_POR_SUBDIARIO";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_DIAFIN", D_DIAFIN);
            parameters.Add("D_DIAINI", D_DIAINI);
            parameters.Add("N_CEO", N_CEO);
            parameters.Add("V_ANIO", V_ANIO);
            parameters.Add("V_ASIENTOFIN", V_ASIENTOFIN);
            parameters.Add("V_ASIENTOINI", V_ASIENTOINI);
            parameters.Add("V_CENTROFIN", V_CENTROFIN);
            parameters.Add("V_CENTROINI", V_CENTROINI);
            parameters.Add("V_CUENTAFIN", V_CUENTAFIN);
            parameters.Add("V_CUENTAINI", V_CUENTAINI);
            parameters.Add("V_MES", V_MES);
            parameters.Add("V_SUBDIARIO", V_SUBDIARIO);
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
        public DataTable Listar_mayor_auxi_pend_doc_res(string D_AÑO, string D_MES, string V_CUENTA, string V_RELACION_DESDE, string V_RELACION_HASTA, string UserName)
        {
            string packageName = "CONSULTA.PKG_CONTABILIDAD.SP_MAYOR_AUXI_PEND_DOC_RES";
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
        public DataTable Listar_mayor_auxi_doc_resu(string D_AÑO, string D_MES, string V_CUENTA_DESDE, string V_CUENTA_HASTA, string V_RELACION_DESDE, string V_RELACION_HASTA, string UserName)
        {
            string packageName = "CONSULTA.PKG_CONTABILIDAD.SP_MAYOR_AUXI_DOC_RESU";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_AÑO", D_AÑO);
            parameters.Add("D_MES", D_MES);
            parameters.Add("V_CUENTA_DESDE", V_CUENTA_DESDE);
            parameters.Add("V_CUENTA_HASTA", V_CUENTA_HASTA);
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
        public DataTable Listar_movimiento_cuenta_97(string D_FECHA_DESDE, string D_FECHA_HASTA, string V_CENTRO_OPERATIVO, string V_CUENTA_DESDE, string V_CUENTA_HASTA, string V_SUBDIARIO_DESDE, string V_SUBDIARIO_HASTA, string UserName)
        {
            string packageName = "CONSULTA.PKG_CONTABILIDAD.SP_MOVIMIENTO_CUENTA_97";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_FECHA_DESDE", D_FECHA_DESDE);
            parameters.Add("D_FECHA_HASTA", D_FECHA_HASTA);
            parameters.Add("V_CENTRO_OPERATIVO", V_CENTRO_OPERATIVO);
            parameters.Add("V_CUENTA_DESDE", V_CUENTA_DESDE);
            parameters.Add("V_CUENTA_HASTA", V_CUENTA_HASTA);
            parameters.Add("V_SUBDIARIO_DESDE", V_SUBDIARIO_DESDE);
            parameters.Add("V_SUBDIARIO_HASTA", V_SUBDIARIO_HASTA);
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
        public DataTable Listar_mayor_auxiliar_detalle(string D_AÑO, string D_MES, string V_CUENTA_DESDE, string V_CUENTA_HASTA, string V_RELACION_DESDE, string V_RELACION_HASTA, string UserName)
        {
            string packageName = "CONSULTA.PKG_CONTABILIDAD.SP_MAYOR_AUXILIAR_DETALLE";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_AÑO", D_AÑO);
            parameters.Add("D_MES", D_MES);
            parameters.Add("V_CUENTA_DESDE", V_CUENTA_DESDE);
            parameters.Add("V_CUENTA_HASTA", V_CUENTA_HASTA);
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
        public DataTable Listar_mayor_auxiliar_pend_deta(string D_AÑO, string D_MES, string V_CUENTA, string V_DOCUMENTO, string V_RELACION, string UserName)
        {
            string packageName = "CONSULTA.PKG_CONTABILIDAD.SP_MAYOR_AUXILIAR_PEND_DETA";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_AÑO", D_AÑO);
            parameters.Add("D_MES", D_MES);
            parameters.Add("V_CUENTA", V_CUENTA);
            parameters.Add("V_DOCUMENTO", V_DOCUMENTO);
            parameters.Add("V_RELACION", V_RELACION);
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
        public DataTable Listar_movimiento_por_cuenta(string D_FECHA_DESDE, string D_FECHA_HASTA, string V_CENTRO_OPERATIVO, string V_CUENTA_DESDE, string V_CUENTA_HASTA, string V_SUBDIARIO_DESDE, string V_SUBDIARIO_HASTA, string UserName)
        {
            string packageName = "CONSULTA.PKG_CONTABILIDAD.SP_MOVIMIENTO_POR_CUENTA";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_FECHA_DESDE", D_FECHA_DESDE);
            parameters.Add("D_FECHA_HASTA", D_FECHA_HASTA);
            parameters.Add("V_CENTRO_OPERATIVO", V_CENTRO_OPERATIVO);
            parameters.Add("V_CUENTA_DESDE", V_CUENTA_DESDE);
            parameters.Add("V_CUENTA_HASTA", V_CUENTA_HASTA);
            parameters.Add("V_SUBDIARIO_DESDE", V_SUBDIARIO_DESDE);
            parameters.Add("V_SUBDIARIO_HASTA", V_SUBDIARIO_HASTA);
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
        public DataTable Listar_asientos_por_subdiario_02(string D_DIAFIN, string D_DIAINI, string N_CEO, string V_ANIO, string V_ASIENTOFIN, string V_ASIENTOINI, string V_CENTROFIN, string V_CENTROINI, string V_CODDIV, string V_CUENTAFIN, string V_CUENTAINI, string V_MES, string V_NROOTS, string UserName)
        {
            string packageName = "CONSULTA.PKG_CONTABILIDAD.SP_ASIENTOS_POR_SUBDIARIO_020";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_DIAFIN", D_DIAFIN);
            parameters.Add("D_DIAINI", D_DIAINI);
            parameters.Add("N_CEO", N_CEO);
            parameters.Add("V_ANIO", V_ANIO);
            parameters.Add("V_ASIENTOFIN", V_ASIENTOFIN);
            parameters.Add("V_ASIENTOINI", V_ASIENTOINI);
            parameters.Add("V_CENTROFIN", V_CENTROFIN);
            parameters.Add("V_CENTROINI", V_CENTROINI);
            parameters.Add("V_CODDIV", V_CODDIV);
            parameters.Add("V_CUENTAFIN", V_CUENTAFIN);
            parameters.Add("V_CUENTAINI", V_CUENTAINI);
            parameters.Add("V_MES", V_MES);
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

        public DataTable Listar_asientos_subdiario_resu_c(string D_DIAFIN, string D_DIAINI, string N_CEO, string V_ANIO, string V_ASIENTOFIN, string V_ASIENTOINI, string V_CENTROFIN, string V_CENTROINI, string V_CUENTAFIN, string V_CUENTAINI, string V_MES, string V_SUBDIARIO, string UserName)
        {
            string packageName = "CONSULTA.PKG_CONTABILIDAD.SP_ASIENTOS_SUBDIARIO_RESU_CC";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_DIAFIN", D_DIAFIN);
            parameters.Add("D_DIAINI", D_DIAINI);
            parameters.Add("N_CEO", N_CEO);
            parameters.Add("V_ANIO", V_ANIO);
            parameters.Add("V_ASIENTOFIN", V_ASIENTOFIN);
            parameters.Add("V_ASIENTOINI", V_ASIENTOINI);
            parameters.Add("V_CENTROFIN", V_CENTROFIN);
            parameters.Add("V_CENTROINI", V_CENTROINI);
            parameters.Add("V_CUENTAFIN", V_CUENTAFIN);
            parameters.Add("V_CUENTAINI", V_CUENTAINI);
            parameters.Add("V_MES", V_MES);
            parameters.Add("V_SUBDIARIO", V_SUBDIARIO);
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
        public DataTable Listar_tabulado_por_subdiarios(string V_ANIO, string V_CUENTA, string V_MES, string UserName)
        {
            string packageName = "CONSULTA.PKG_CONTABILIDAD.SP_TABULADO_POR_SUBDIARIOS";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("V_ANIO", V_ANIO);
            parameters.Add("V_CUENTA", V_CUENTA);
            parameters.Add("V_MES", V_MES);
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
        public DataTable Listar_mayor_auxi_canceladas_det(string D_AÑO, string D_MES, string V_CUENTA, string V_DOCUMENTO, string V_RELACION_DESDE, string V_RELACION_HASTA, string UserName)
        {
            string packageName = "CONSULTA.PKG_CONTABILIDAD.SP_MAYOR_AUXI_CANCELADAS_DET";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_AÑO", D_AÑO);
            parameters.Add("D_MES", D_MES);
            parameters.Add("V_CUENTA", V_CUENTA);
            parameters.Add("V_DOCUMENTO", V_DOCUMENTO);
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


    }
}