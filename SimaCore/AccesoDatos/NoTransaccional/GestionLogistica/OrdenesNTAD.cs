using AccesoDatos.Estandar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.NoTransaccional.GestionLogistica
{
    public class OrdenesNTAD
    {
        private readonly IStandarProcedure _standarProcedure;

        public OrdenesNTAD(IStandarProcedure standarProcedure)
        {
            _standarProcedure = standarProcedure;
        }

        public DataTable Listar_OrdenComP_VFechaEntre(string Centro_Operativo, string Procedencia, string Fecha_Inicio,
            string Fecha_Termino, string Clase_Material, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_OrdenComP_VFechaEntre";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Centro_Operativo", Centro_Operativo);
            parameters.Add("Procedencia", Procedencia);
            parameters.Add("Fecha_Inicio", Fecha_Inicio);
            parameters.Add("Fecha_Termino", Fecha_Termino);
            parameters.Add("Clase_Material", Clase_Material);
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

        public DataTable Listar_OcoEmiContral(string Centro_Operativo, string Procedencia, string Tipo, string Estado,
            string Fecha_Inicial, string Fecha_Final, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_OcoEmiContral";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Centro_Operativo", Centro_Operativo);
            parameters.Add("Procedencia", Procedencia);
            parameters.Add("Tipo", Tipo);
            parameters.Add("Estado", Estado);
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

        public DataTable Listar_ordcompraporrepo(string DESTINO_COMPRA, string FECHA_MOVIMIENTO_INICIO, string FECHA_MOVIMIENTO_TERMINO, string MATERIAL_FINAL,
            string MATERIAL_INICIAL, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_ORDCOMPRAPORREPO";
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("Fecha_Movimiento_Inicio", FECHA_MOVIMIENTO_INICIO);
            parameters.Add("Fecha_Movimiento_Termino", FECHA_MOVIMIENTO_TERMINO);
            parameters.Add("Material_Inicial", MATERIAL_FINAL);
            parameters.Add("Material_Final", MATERIAL_INICIAL);
            parameters.Add("Destino_Compra", DESTINO_COMPRA);
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

        public DataTable Listar_OrdServicioLond(string Fecha_Emision_Inicio, string Fecha_Emision_Termino,
            string Procedencia, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_OrdServicioLond";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Fecha_Emision_Inicio", Fecha_Emision_Inicio);
            parameters.Add("Fecha_Emision_Termino", Fecha_Emision_Termino);
            parameters.Add("Procedencia", Procedencia);
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

        public DataTable Listar_ModiFEntreOcoOse(string Centro_Operativo, string Tipo_Orden, string Procedencia,
            string Numero_Orden, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_ModiFEntreOcoOse";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Centro_Operativo", Centro_Operativo);
            parameters.Add("Tipo_Orden", Tipo_Orden);
            parameters.Add("Procedencia", Procedencia);
            parameters.Add("Numero_Orden", Numero_Orden);
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

        public DataTable Listar_OcoEmiLogi(string Centro_Operativo, string Procedencia, string Tipo, string Estado,
            string Fecha_Emision_Inicial, string Fecha_Emision_Final, string Cotizador, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_OcoEmiLogi";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Centro_Operativo", Centro_Operativo);
            parameters.Add("Procedencia", Procedencia);
            parameters.Add("Tipo", Tipo);
            parameters.Add("Estado", Estado);
            parameters.Add("Fecha_Emision_Inicial", Fecha_Emision_Inicial);
            parameters.Add("Fecha_Emision_Final", Fecha_Emision_Final);
            parameters.Add("Cotizador", Cotizador);
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

        public DataTable Listar_AVANCE_OSE_VALJDE(string D_FECHAINI, string D_FECHAFIN, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.AVANCE_OSE_VALJDE";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
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

        public DataTable Listar_ALMAC_OCO_VALJDE(string D_FECHAINI, string D_FECHAFIN, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.ALMAC_OCO_VALJDE";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
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

        public DataTable Listar_AtencionesServiciosCC(string N_CEO, string V_CODCCO, string D_FECHAINI,
            string D_FECHAFIN, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_AtencionesServiciosCC";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("N_CEO", N_CEO);
            parameters.Add("V_CODCCO", V_CODCCO);
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

        public DataTable Listar_REQUERIMIENTO_OCO_VALJDE(string Fecha_Emision, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_REQUERIMIENTO_OCO_VALJDE";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
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

        public DataTable Listar_OCO_OGC(string Centro_Operativo, string Procedencia, string año_de_Orden,
            string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_OCO_OGC";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Centro_Operativo", Centro_Operativo);
            parameters.Add("Procedencia", Procedencia);
            parameters.Add("año_de_Orden", año_de_Orden);
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

        public DataTable Listar_OSE_OGC(string Centro_Operativo, string año_de_Orden, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_OSE_OGC";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Centro_Operativo", Centro_Operativo);
            parameters.Add("año_de_Orden", año_de_Orden);
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

        public DataTable Listar_LOG_OSE_OTS_RN(string V_Centro_Operativo, string V_división,
            string D_Fecha_Emision_OSE_Inicio, string D_Fecha_Emision_OSE_Termino, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_LOG_OSE_OTS_RN";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("V_Centro_Operativo", V_Centro_Operativo);
            parameters.Add("V_división", V_división);
            parameters.Add("D_Fecha_Emision_OSE_Inicio", D_Fecha_Emision_OSE_Inicio);
            parameters.Add("D_Fecha_Emision_OSE_Termino", D_Fecha_Emision_OSE_Termino);
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

        public DataTable Listar_OrdenesServicioCC(string D_FECHAINI, string D_FECHAFIN, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_OrdenesServicioCC";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
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

        public DataTable Listar_OrdenesCompraCC(string D_FECHAINI, string D_FECHAFIN, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_OrdenesCompraCC";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
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

        public DataTable Listar_ORDENCOM_SER_OT_CONTRALORIA(string Centro_Operativo, string DIVISION,
            string ORDEN_DE_TRABAJO, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_ORDENCOM_SER_OT_CONTRALORIA";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Centro_Operativo", Centro_Operativo);
            parameters.Add("DIVISION", DIVISION);
            parameters.Add("ORDEN_DE_TRABAJO", ORDEN_DE_TRABAJO);
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

        public DataTable Listar_Ordenes_Entrega_FacPrv(string FECHA_INICIAL, string FECHA_FINAL, string TIPO_DE_ORDEN,
            string PROCEDENCIA, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_Ordenes_Entrega_FacPrv";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("FECHA_INICIAL", FECHA_INICIAL);
            parameters.Add("FECHA_FINAL", FECHA_FINAL);
            parameters.Add("TIPO_DE_ORDEN", TIPO_DE_ORDEN);
            parameters.Add("PROCEDENCIA", PROCEDENCIA);
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

        public DataTable Listar_Egresos_Directos_OCO(string D_FECHAINI, string D_FECHAFIN, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_Egresos_Directos_OCO";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
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

        public DataTable Listar_ORDENES_COM_SER_OT(string Centro_Operativo, string DIVISION, string ORDEN_DE_TRABAJO,
            string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_ORDENES_COM_SER_OT";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Centro_Operativo", Centro_Operativo);
            parameters.Add("DIVISION", DIVISION);
            parameters.Add("ORDEN_DE_TRABAJO", ORDEN_DE_TRABAJO);
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

        public DataTable Listar_DIF_CMB_PRY_OSE(string Centro_Operativo, string división, string Proyecto, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_DIF_CMB_PRY_OSE";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Centro_Operativo", Centro_Operativo);
            parameters.Add("división", división);
            parameters.Add("Proyecto", Proyecto);
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

        public DataTable Listar_DIF_CMB_PRY_OSE_MNT_AVA(string Centro_Operativo, string división, string Proyecto, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_DIF_CMB_PRY_OSE_MNT_AVA";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Centro_Operativo", Centro_Operativo);
            parameters.Add("división", división);
            parameters.Add("Proyecto", Proyecto);
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

        public DataTable Listar_DIF_CMB_PRY_EGR_DIR_SIN_OT(string Centro_Operativo, string división, string Proyecto, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_DIF_CMB_PRY_EGR_DIR_SIN_OT";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Centro_Operativo", Centro_Operativo);
            parameters.Add("división", división);
            parameters.Add("Proyecto", Proyecto);
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

        public DataTable Listar_OseAvance(string FECHA_EMISION_INICIAL, string FECHA_EMISION_FINAL, string NMRO_OSE,
            string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_OseAvance";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("FECHA_EMISION_INICIAL", FECHA_EMISION_INICIAL);
            parameters.Add("FECHA_EMISION_FINAL", FECHA_EMISION_FINAL);
            parameters.Add("NMRO_OSE", NMRO_OSE);
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

        public DataTable Listar_DIF_CMB_PRY_OCO_PCI(string Centro_Operativo, string división, string Proyecto,
            string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_DIF_CMB_PRY_OCO_PCI";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Centro_Operativo", Centro_Operativo);
            parameters.Add("división", división);
            parameters.Add("Proyecto", Proyecto);
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

        public DataTable Listar_DIF_CMB_PRY_OCO_SIN_OT(string Centro_Operativo, string división, string Proyecto,
            string Numero_Orden, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_DIF_CMB_PRY_OCO_SIN_OT";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Centro_Operativo", Centro_Operativo);
            parameters.Add("división", división);
            parameters.Add("Proyecto", Proyecto);
            parameters.Add("Numero_Orden", Numero_Orden);
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

        public DataTable Listar_DIF_CMB_PRY_EGR_DIR(string Centro_Operativo, string división, string Proyecto,
            string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_DIF_CMB_PRY_EGR_DIR";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("Centro_Operativo", Centro_Operativo);
            parameters.Add("división", división);
            parameters.Add("Proyecto", Proyecto);
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

        public DataTable Listar_ALM_OCO_ATE_RSV(string D_INICIO_ALMACENAMIENTO, string D_FINAL_ALMACENAMIENTO,
            string V_DESTINO_COMPRA, string V_Filtro_PRY_AUS, string V_PRY_AUS, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_ALM_OCO_ATE_RSV";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("D_INICIO_ALMACENAMIENTO", D_INICIO_ALMACENAMIENTO);
            parameters.Add("D_FINAL_ALMACENAMIENTO", D_FINAL_ALMACENAMIENTO);
            parameters.Add("V_DESTINO_COMPRA", V_DESTINO_COMPRA);
            parameters.Add("V_Filtro_PRY_AUS", V_Filtro_PRY_AUS);
            parameters.Add("V_PRY_AUS", V_PRY_AUS);
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
