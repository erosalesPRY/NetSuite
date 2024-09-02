using AccesoDatos.Estandar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.NoTransaccional.GestionContabilidad
{
    public class PagosNTAD
    {
        private readonly IStandarProcedure _standarProcedure;

        public PagosNTAD(IStandarProcedure standarProcedure)
        {
            _standarProcedure = standarProcedure;
        }

        public DataTable Listar_det_pend_de_pago_new(string D_PERIODO, string UserName)
        {
            string packageName = "CONSULTA.PKG_CONTABILIDAD.SP_DET_PEND_DE_PAGO_NEW";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("D_PERIODO", D_PERIODO);
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

        public DataTable Listar_reg_compras_sunat_coa_txt(string D_AÑO, string D_MES, string V_CENTRO_OPERATIVO, string UserName)
        {
            string packageName = "CONSULTA.PKG_CONTABILIDAD.SP_REG_COMPRAS_SUNAT_COA_TXT";
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

        public DataTable Listar_voucher_por_documento(string V_NUMERO, string V_PROVEEDOR, string V_SERIE, string V_TIPO, string UserName)
        {
            string packageName = "CONSULTA.PKG_CONTABILIDAD.SP_VOUCHER_POR_DOCUMENTO";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("V_NUMERO", V_NUMERO);
            parameters.Add("V_PROVEEDOR", V_PROVEEDOR);
            parameters.Add("V_SERIE", V_SERIE);
            parameters.Add("V_TIPO", V_TIPO);
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
        public DataTable Listar_libro_retenciones_4ta_cat(string N_CEO, string V_ANIO, string V_MES, string V_TIPRET, string UserName)
        {
            string packageName = "CONSULTA.PKG_CONTABILIDAD.SP_LIBRO_RETENCIONES_4TA_CATEG";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("N_CEO", N_CEO);
            parameters.Add("V_ANIO", V_ANIO);
            parameters.Add("V_MES", V_MES);
            parameters.Add("V_TIPRET", V_TIPRET);
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

        public DataTable Listar_registro_retenciones_suna(string N_CEO, string V_ANIO, string V_NROMES, string UserName)
        {
            string packageName = "CONSULTA.PKG_CONTABILIDAD.SP_REGISTRO_RETENCIONES_SUNAT";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("N_CEO", N_CEO);
            parameters.Add("V_ANIO", V_ANIO);
            parameters.Add("V_NROMES", V_NROMES);
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

        public DataTable Listar_reg_compras_sunat_pdb_txt(string D_AÑO, string D_MES, string UserName)
        {
            string packageName = "CONSULTA.PKG_CONTABILIDAD.SP_REG_COMPRAS_SUNAT_PDB_TXT";
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

        public DataTable Listar_pagos_por_cuenta_detraccion(string N_CEO, string V_ANIO, string V_MESFIN, string V_MESINI, string UserName)
        {
            string packageName = "CONSULTA.PKG_CONTABILIDAD.SP_PAGOS_POR_CUENTA_DETRACCION";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("N_CEO", N_CEO);
            parameters.Add("V_ANIO", V_ANIO);
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