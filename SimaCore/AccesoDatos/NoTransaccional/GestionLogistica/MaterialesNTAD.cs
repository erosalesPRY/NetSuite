using AccesoDatos.Estandar;
using EntidadNegocio;
using Log;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario;

namespace AccesoDatos.NoTransaccional.GestionLogistica
{
    public class MaterialesNTAD
    {
        private readonly IStandarProcedure _standarProcedure;

        public MaterialesNTAD(IStandarProcedure standarProcedure)
        {
            _standarProcedure = standarProcedure;
        }

        public DataTable Listar_ConsumoAnualMateriales(string N_CEO, string PERIODO, string TIPO,
            string CLASIFICACION, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_ConsumoAnualMateriales";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("N_CEO", N_CEO);
            parameters.Add("PERIODO", PERIODO);
            parameters.Add("TIPO", TIPO);
            parameters.Add("CLASIFICACION", CLASIFICACION);
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

        public DataTable Listar_Mat_CentroOperativo(string Fecha_Emision_Inicio, string Fecha_Emision_Termino,
            string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_Mat_CentroOperativo";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Fecha_Emision_Inicio", Fecha_Emision_Inicio);
            parameters.Add("Fecha_Emision_Termino", Fecha_Emision_Termino);
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

        public DataTable Listar_MatLLegadoCompras(string Codigo_Division, string Codigo_OT, string Fecha_LLegada_Inicio,
            string Fecha_Llegada_Termino, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_MatLLegadoCompras";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Codigo_Division", Codigo_Division);
            parameters.Add("Codigo_OT", Codigo_OT);
            parameters.Add("Fecha_LLegada_Inicio", Fecha_LLegada_Inicio);
            parameters.Add("Fecha_Llegada_Termino", Fecha_Llegada_Termino);
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

        public DataTable Listar_CatalogoMaterialesFC(string D_FechaIEmision, string D_FechaFEmision, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_CatalogoMaterialesFC";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("D_FechaIEmision", D_FechaIEmision);
            parameters.Add("D_FechaFEmision", D_FechaFEmision);
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

        public DataTable Listar_VM_CC(string N_CEO, string V_CODCC, string D_FECHAINI, string D_FECHAFIN,
            string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_VM_CC";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("N_CEO", N_CEO);
            parameters.Add("V_CODCC", V_CODCC);
            parameters.Add("D_FECHAINI", D_FECHAINI);
            parameters.Add("D_FECHAFIN", D_FECHAFIN);
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

        public DataTable Listar_MoviMatIOCVSMVD(string Centro_Operativo, string FECHA_INICIAL_MOVIMIENTO,
            string FECHA_FINAL_MOVIMIENTO, string CODIGO_MATERIAL, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_MoviMatIOCVSMVDE";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Centro_Operativo", Centro_Operativo);
            parameters.Add("FECHA_INICIAL_MOVIMIENTO", FECHA_INICIAL_MOVIMIENTO);
            parameters.Add("FECHA_FINAL_MOVIMIENTO", FECHA_FINAL_MOVIMIENTO);
            parameters.Add("CODIGO_MATERIAL", CODIGO_MATERIAL);
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

        public DataTable Listar_MoviMaterialAud(string Almacen, string año_Inventario, string Corte,
            string Fecha_Inicial, string Fecha_Final, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_MoviMaterialAud";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Almacen", Almacen);
            parameters.Add("año_Inventario", año_Inventario);
            parameters.Add("Corte", Corte);
            parameters.Add("Fecha_Inicial", Fecha_Inicial);
            parameters.Add("Fecha_Final", Fecha_Final);
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

        public DataTable Listar_EQUIVA2013(string V_MATERIAL, string V_DIMLARGO, string V_DIMANCHO, string V_UNMEDIDA,
            string V_CANTREQ, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_EQUIVA2013";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("V_MATERIAL", V_MATERIAL);
            parameters.Add("V_DIMLARGO", V_DIMLARGO);
            parameters.Add("V_DIMANCHO", V_DIMANCHO);
            parameters.Add("V_UNMEDIDA", V_UNMEDIDA);
            parameters.Add("V_CANTREQ", V_CANTREQ);
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

        public DataTable Listar_VM_CC_ESPECIFICO(string N_CEO, string V_CODCC, string D_FECHAINI, string D_FECHAFIN,
            string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_VM_CC_ESPECIFICO";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("N_CEO", N_CEO);
            parameters.Add("V_CODCC", V_CODCC);
            parameters.Add("D_FECHAINI", D_FECHAINI);
            parameters.Add("D_FECHAFIN", D_FECHAFIN);
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

        public DataTable Listar_ControlReservaMat(string V_CODIGO_MATERIAL, string D_FECHA_RESERVA_inicial,
            string D_FECHA_RESERVA_final, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_ControlReservaMat";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("V_CODIGO_MATERIAL", V_CODIGO_MATERIAL);
            parameters.Add("D_FECHA_RESERVA_inicial", D_FECHA_RESERVA_inicial);
            parameters.Add("D_FECHA_RESERVA_final", D_FECHA_RESERVA_final);
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

        public DataTable Listar_SaldoAlmacen(string Material_Inicial, string Material_Final, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_SaldoAlmacen";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Material_Inicial", Material_Inicial);
            parameters.Add("Material_Final", Material_Final);
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

        public DataTable Listar_AtencionMaterialesCC(string V_Centro_Operativo, string D_Fecha_Inicio,
            string D_Fecha_Termino, string V_CC, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_AtencionMaterialesCC";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("V_Centro_Operativo", V_Centro_Operativo);
            parameters.Add("D_Fecha_Inicio", D_Fecha_Inicio);
            parameters.Add("D_Fecha_Termino", D_Fecha_Termino);
            parameters.Add("V_CC", V_CC);
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

        public DataTable Listar_CONSUMO_VM_VALJDE(string V_TIPO_VALE, string D_FECHAINI, string D_FECHAFIN,
            string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_CONSUMO_VM_VALJDE";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("V_TIPO_VALE", V_TIPO_VALE);
            parameters.Add("D_FECHAINI", D_FECHAINI);
            parameters.Add("D_FECHAFIN", D_FECHAFIN);
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

        public DataTable Listar_SeguiRequeDeta_OTS(string Codigo_Division, string Codigo_OT,
            string FECHA_EMISION_OT_Inicio, string FECHA_EMISION_OT_Termino, string FECHA_ATENCION_INICIO,
            string FECHA_ATENCION_TERMINO, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_SeguiRequeDeta_OTS";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Codigo_Division", Codigo_Division);
            parameters.Add("Codigo_OT", Codigo_OT);
            parameters.Add("FECHA_EMISION_OT_Inicio", FECHA_EMISION_OT_Inicio);
            parameters.Add("FECHA_EMISION_OT_Termino", FECHA_EMISION_OT_Termino);
            parameters.Add("FECHA_ATENCION_INICIO", FECHA_ATENCION_INICIO);
            parameters.Add("FECHA_ATENCION_TERMINO", FECHA_ATENCION_TERMINO);
            parameters.Add("UserName", UserName);

            try
            {
                return _standarProcedure.EjecutarProcedimiento(packageName, parameters);
            }
            catch (Exception ex)
            {
                // Crear un DataTable para contener la información de error
                DataTable errorTable = new DataTable("Error");
                errorTable.Columns.Add("ErrorMessage", typeof(string));
                errorTable.Columns.Add("StackTrace", typeof(string));

                DataRow row = errorTable.NewRow();
                row["ErrorMessage"] = ex.Message;
                row["StackTrace"] = ex.StackTrace;
                errorTable.Rows.Add(row);

                return errorTable;
            }
        }

        public DataTable Listar_PRECIOSREPOSICION(string CLAS_MATERIAL, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_PRECIOSREPOSICION";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("CLAS_MATERIAL", CLAS_MATERIAL);
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

        public DataTable Listar_Punto_Reposicion(string TIPO_STOCK, string CLASE_MATERIAL, string MAT_CRI,
            string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_Punto_Reposicion";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("TIPO_STOCK", TIPO_STOCK);
            parameters.Add("CLASE_MATERIAL", CLASE_MATERIAL);
            parameters.Add("MAT_CRI", MAT_CRI);
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

        public DataTable Listar_Punto_Repo_Precios_Prome(string TIPO_STOCK, string CLASE_MATERIAL, string MAT_CRI,
            string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_Punto_Repo_Precios_Prome";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("TIPO_STOCK", TIPO_STOCK);
            parameters.Add("CLASE_MATERIAL", CLASE_MATERIAL);
            parameters.Add("MAT_CRI", MAT_CRI);
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

        public DataTable Listar_PedidoMateMultipropo(string NUMERO_PEDIDO, string EMISION_INICIAL_PEDIDO,
            string EMISION_FINAL_PEDIDO, string CODIGO_MATERIAL, string CODIGO_AUXILIAR, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_PedidoMateMultipropo";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("NUMERO_PEDIDO", NUMERO_PEDIDO);
            parameters.Add("EMISION_INICIAL_PEDIDO", EMISION_INICIAL_PEDIDO);
            parameters.Add("EMISION_FINAL_PEDIDO", EMISION_FINAL_PEDIDO);
            parameters.Add("CODIGO_MATERIAL", CODIGO_MATERIAL);
            parameters.Add("CODIGO_AUXILIAR", CODIGO_AUXILIAR);
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

        public DataTable Listar_Reserva_OT_Produccion(string Codigo_OT, string Codigo_Material, string Estado_OT,
            string Estado_Seguimiento_OT, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_Reserva_OT_Produccion";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Codigo_OT", Codigo_OT);
            parameters.Add("Codigo_Material", Codigo_Material);
            parameters.Add("Estado_OT", Estado_OT);
            parameters.Add("Estado_Seguimiento_OT", Estado_Seguimiento_OT);
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

        public DataTable Listar_MAT_MASIVA(string CLASE_SUBCLASE, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_MAT_MASIVA";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("CLASE_SUBCLASE", CLASE_SUBCLASE);
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

        public DataTable Listar_ReserMateAreasUsua(string Area_Usuaria, string división, string Material, string OT,
            string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_ReserMateAreasUsua";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Area_Usuaria", Area_Usuaria);
            parameters.Add("división", división);
            parameters.Add("Material", Material);
            parameters.Add("OT", OT);
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

        public DataTable Listar_CODIFICACION_CUBSO(string CLASE, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_CODIFICACION_CUBSO";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("CLASE", CLASE);
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

        public DataTable Listar_PedidoMaterialCompraOTS(string DIVISION, string NRO_PEDIDO, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_PedidoMaterialCompraOTS";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("DIVISION", DIVISION);
            parameters.Add("NRO_PEDIDO", NRO_PEDIDO);
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

        public DataTable Listar_MatlesSinMov_PDR8701(string Centro_Operativo, string Almacen, string Fecha_Inicial,
            string Fecha_Final, string Clase, string Stock, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_MatlesSinMov_PDR8701";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Centro_Operativo", Centro_Operativo);
            parameters.Add("Almacen", Almacen);
            parameters.Add("Fecha_Inicial", Fecha_Inicial);
            parameters.Add("Fecha_Final", Fecha_Final);
            parameters.Add("Clase", Clase);
            parameters.Add("Stock", Stock);
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


        public DataTable Listar_Vale_Salida_Mat(string s_CEO, string s_NRO_VALE, string s_COD_ALMA, string s_AREA_USU,
               string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_VALE_SALIDA_MAT";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("V_CEO", s_CEO);
            parameters.Add("V_NRO_VALE", s_NRO_VALE);
            parameters.Add("V_COD_ALMA", s_COD_ALMA);
            parameters.Add("V_AREA_USU", s_AREA_USU);
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

        // recuperado //

        public DataTable Listar_controlmateriales(string N_OPC, string N_CEO, string D_FECHAINI,  string D_FECHAFIN, string C_DESTINO_OPER, string V_COD_CLASE_MAT, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_ControlMateriales";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("N_CEO", N_CEO);
            parameters.Add("D_FECHAINI", D_FECHAINI);
            parameters.Add("D_FECHAFIN", D_FECHAFIN);
            parameters.Add("V_Cod_Clase_mat", V_COD_CLASE_MAT);
            parameters.Add("C_Destino_Oper", C_DESTINO_OPER);
            parameters.Add("N_OPC", N_OPC);
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

        public DataTable Listar_saldo_historico_mat(string CENTRO_OPERATIVO, string FECHA_DE_PROCESO, string MATERIAL, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_SALDO_HISTORICO_MAT";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("CENTRO_OPERATIVO", CENTRO_OPERATIVO);
            parameters.Add("FECHA_DE_PROCESO", FECHA_DE_PROCESO);
            parameters.Add("MATERIAL", MATERIAL);
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

        public DataTable Listar_DET_G_PRY_OT_VSM_PCI(string Centro_Operativo, string Division, string Proyecto, string Fecha_Emision, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_DET_G_PRY_OT_VSM_PCI";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Centro_Operativo", Centro_Operativo);
            parameters.Add("Division", Division);
            parameters.Add("Proyecto", Proyecto);
            parameters.Add("Fecha_Emision", Fecha_Emision);
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
