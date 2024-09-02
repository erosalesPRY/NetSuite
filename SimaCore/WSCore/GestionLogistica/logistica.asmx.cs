using Controladora.GestionLogistica;
using EntidadNegocio;
using EntidadNegocio.GestionLogistica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Services;
using AccesoDatos.Estandar;
using AccesoDatos.NoTransaccional.GestionLogistica;
using System.Web.UI.WebControls;
using WSCore.General;

namespace WSCore.GestionLogistica
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class logistica : System.Web.Services.WebService
    {
        #region Referencias a Controladores de Logistica

        private static OrdenesNTAD ordenes = new OrdenesNTAD(new StandarProcedure());
        cOrdenes controladorOrdenes = new cOrdenes(ordenes);

        private static GeneralNTAD general = new GeneralNTAD(new StandarProcedure());
        cGeneral controladorGeneral = new cGeneral(general);

        private static MaterialesNTAD materiales = new MaterialesNTAD(new StandarProcedure());
        cMateriales controladorMateriales = new cMateriales(materiales);

        private static StockNTAD stock = new StockNTAD(new StandarProcedure());
        cStock controladorStock = new cStock(stock);

        private static ProveedoresNTAD proveedores = new ProveedoresNTAD(new StandarProcedure());
        cProveedores controladorProveedores = new cProveedores(proveedores);

        private static BienesNTAD bienes = new BienesNTAD(new StandarProcedure());
        cBienes controladorBienes = new cBienes(bienes);

        private static RequerimientosNTAD requerimientos = new RequerimientosNTAD(new StandarProcedure());
        cRequerimientos controladorRequerimientos = new cRequerimientos(requerimientos);

        private static ServiciosNTAD servicios = new ServiciosNTAD(new StandarProcedure());
        cServicios controladorServicios = new cServicios(servicios);

        private static ProyectosNTAD proyectos = new ProyectosNTAD(new StandarProcedure());
        cProyectos controladorProyectos = new cProyectos(proyectos);

        #endregion

        #region Clases de LOGISTICA - MPV

        //-------------------------------------------------
        [WebMethod(Description = "Modificar El Estado del Proceso")]
        public int Modificar_EstadoProcesoSelec(string sCodigo, string sEstado)
        {
    
            BaseBE oBaseBE = new BaseBE(); // instanciamos para pasar parametros

            oBaseBE.IdCodigo = sCodigo.ToString();
            //oBaseBE.IdEstado2 = sEstado.ToString();

            return (new cProcesoSelec()).Modificar(oBaseBE);
        }

        //-****************************************************************************
        [WebMethod(Description = "Listar Procesos de selección MPV por Estado")]
        public DataTable ListarProcesoSelec(string sCodigo, string sEstado) 
        {
            return (new cProcesoSelec()).ListarTodos(sCodigo, sEstado);
        }
        
        //-****************************************************************************
        [WebMethod(Description = "Insertar procesos de Selección MPV")]

        public int Insertar_Proceso(string sCodigo, string sDescripcion)

        {
            BaseBE oBaseBE = new BaseBE();
            oBaseBE.IdCodigo = sCodigo.ToString();
            // oBaseBE.IdEstado2 = sDescripcion.ToString();

            return (new cProcesoSelec()).Insertar(oBaseBE);
        }

        //-****************************************************************************
        [WebMethod(Description = "Listar Procesos de Selección SISTRADES")]
        public DataTable ListarProcesoSelec2(string sCodigo, string sEstado )
        {
            return (new cProcesoSelec()).ListarTodos2(sCodigo, sEstado);
        }

        //-****************************************************************************
        [WebMethod(Description = "Terminar El Proceso de selección ")]
        public int ModificarProceso(string sCodigo,string sUsuario)
        {
          
            LogisticaSqlBE oLogisticaSqlBE = new LogisticaSqlBE(); // instanciamos para pasar parametros

            oLogisticaSqlBE.IdCodigoChar = sCodigo;
            oLogisticaSqlBE.UserName = sUsuario.ToString();

            return (new cProcesoSelec()).ModificarProcesos(oLogisticaSqlBE);
        }

        #endregion

        #region Procedimientos almacenados de clasificacion: ORDENES

        [WebMethod(Description = "Muestra la ordenes de servicio atendidas en un rango de fechas de atenci¿n")]
        public DataTable Listar_OrdenComP_VFechaEntre(string Centro_Operativo, string Procedencia, string Fecha_Inicio,
            string Fecha_Termino, string Clase_Material, string UserName)
        {
            return controladorOrdenes.Listar_OrdenComP_VFechaEntre(Centro_Operativo, Procedencia, Fecha_Inicio, Fecha_Termino, Clase_Material, UserName);
        }

        [WebMethod(Description = "ORDENES DE COMPRA GENERADAS")]
        public DataTable Listar_OcoEmiContral(string Centro_Operativo, string Procedencia, string Tipo, string Estado,
            string Fecha_Inicial, string Fecha_Final, string UserName)
        {
            return controladorOrdenes.Listar_OcoEmiContral(Centro_Operativo, Procedencia, Tipo, Estado, Fecha_Inicial, Fecha_Final, UserName);
        }

        [WebMethod(Description = "Lista O/C generadas para tipo de programas de Reposición de Stock.")]
        public DataTable Listar_ordcompraporrepo(string DESTINO_COMPRA, string FECHA_MOVIMIENTO_INICIO,
            string FECHA_MOVIMIENTO_TERMINO, string MATERIAL_FINAL,
            string MATERIAL_INICIAL, string UserName)
        {
            return controladorOrdenes.Listar_ordcompraporrepo(DESTINO_COMPRA, FECHA_MOVIMIENTO_INICIO,
                FECHA_MOVIMIENTO_TERMINO, MATERIAL_FINAL, MATERIAL_INICIAL, UserName);
        }

        [WebMethod(Description = "ORDENES DE SERVICIOS")]
        public DataTable Listar_OrdServicioLond(string Fecha_Emision_Inicio, string Fecha_Emision_Termino,
            string Procedencia, string UserName)
        {
            return controladorOrdenes.Listar_OrdServicioLond(Fecha_Emision_Inicio, Fecha_Emision_Termino, Procedencia, UserName);
        }

        [WebMethod(Description = "MODIFICACION DE FECHA DE ENTREGA EN ORDENES DE COMPRA Y SERVICIOS")]
        public DataTable Listar_ModiFEntreOcoOse(string Centro_Operativo, string Tipo_Orden, string Procedencia,
            string Numero_Orden, string UserName)
        {
            return controladorOrdenes.Listar_ModiFEntreOcoOse(Centro_Operativo, Tipo_Orden, Procedencia, Numero_Orden, UserName);
        }

        [WebMethod(Description = "ORDENES DE COMPRAS EMITIDAS(Solicitado para proporcionar información a Contraloría)")]
        public DataTable Listar_OcoEmiLogi(string Centro_Operativo, string Procedencia, string Tipo, string Estado,
            string Fecha_Emision_Inicial, string Fecha_Emision_Final, string Cotizador, string UserName)
        {
            return controladorOrdenes.Listar_OcoEmiLogi(Centro_Operativo, Procedencia, Tipo, Estado, Fecha_Emision_Inicial,
                Fecha_Emision_Final, Cotizador, UserName);
        }

        [WebMethod(Description = "Muestra la ordenes de servicio atendidas en un rango de fechas de atenci¿n")]
        public DataTable Listar_AVANCE_OSE_VALJDE(string D_FECHAINI, string D_FECHAFIN, string UserName)
        {
            return controladorOrdenes.Listar_AVANCE_OSE_VALJDE(D_FECHAINI, D_FECHAFIN, UserName);
        }

        [WebMethod(Description = "Muestra la ordenes de compra dispuestas en almacenamiento en un rango de fechas")]
        public DataTable Listar_ALMAC_OCO_VALJDE(string D_FECHAINI, string D_FECHAFIN, string UserName)
        {
            return controladorOrdenes.Listar_ALMAC_OCO_VALJDE(D_FECHAINI, D_FECHAFIN, UserName);
        }

        [WebMethod(Description = "Muestra las atenciones de los servicios que provienen de las: OS/Rend.Cta./Fondos Fijos, de cada centro de costos en un rango de fechas")]
        public DataTable Listar_AtencionesServiciosCC(string N_CEO, string V_CODCCO, string D_FECHAINI,
            string D_FECHAFIN, string UserName)
        {
            return controladorOrdenes.Listar_AtencionesServiciosCC(N_CEO, V_CODCCO, D_FECHAINI, D_FECHAFIN, UserName);
        }

        [WebMethod(Description = "REQUERIMIENTOS DE ORDENES DE COMPRA")]
        public DataTable Listar_REQUERIMIENTO_OCO_VALJDE(string Fecha_Emision, string UserName)
        {
            return controladorOrdenes.Listar_REQUERIMIENTO_OCO_VALJDE(Fecha_Emision, UserName);
        }

        [WebMethod(Description = "ORDENES DE COMPRA")]
        public DataTable Listar_OCO_OGC(string Centro_Operativo, string Procedencia, string año_de_Orden,
            string UserName)
        {
            return controladorOrdenes.Listar_OCO_OGC(Centro_Operativo, Procedencia, año_de_Orden, UserName);
        }

        [WebMethod(Description = "ORDENES DE SERVICIO")]
        public DataTable Listar_OSE_OGC(string Centro_Operativo, string año_de_Orden, string UserName)
        {
            return controladorOrdenes.Listar_OSE_OGC(Centro_Operativo, año_de_Orden, UserName);
        }

        [WebMethod(Description = "ORDENES DE SERVICIO DE OT'S POR DIVISIONES")]
        public DataTable Listar_LOG_OSE_OTS_RN(string V_Centro_Operativo, string V_división,
            string D_Fecha_Emision_OSE_Inicio, string D_Fecha_Emision_OSE_Termino, string UserName)
        {
            return controladorOrdenes.Listar_LOG_OSE_OTS_RN(V_Centro_Operativo, V_división, D_Fecha_Emision_OSE_Inicio,
                D_Fecha_Emision_OSE_Termino, UserName);
        }

        [WebMethod(Description = "Muestra: Las Ordenes de Servicio por  Rango de Fecha Emision")]
        public DataTable Listar_OrdenesServicioCC(string D_FECHAINI, string D_FECHAFIN, string UserName)
        {
            return controladorOrdenes.Listar_OrdenesServicioCC(D_FECHAINI, D_FECHAFIN, UserName);
        }

        [WebMethod(Description = "Las Ordenes de Compra de Materiales por  Rango de Fecha Emision")]
        public DataTable Listar_OrdenesCompraCC(string D_FECHAINI, string D_FECHAFIN, string UserName)
        {
            return controladorOrdenes.Listar_OrdenesCompraCC(D_FECHAINI, D_FECHAFIN, UserName);
        }

        [WebMethod(Description = "ORDENES DE COMPRAS Y SERVICIOS RELACIONADAS A OT")]
        public DataTable Listar_ORDENCOM_SER_OT_CONTRALORIA(string Centro_Operativo, string DIVISION,
            string ORDEN_DE_TRABAJO, string UserName)
        {
            return controladorOrdenes.Listar_ORDENCOM_SER_OT_CONTRALORIA(Centro_Operativo, DIVISION, ORDEN_DE_TRABAJO,
                UserName);
        }

        [WebMethod(Description = "Ordenes con fecha de ultima entrega y facturas de proveedores")]
        public DataTable Listar_Ordenes_Entrega_FacPrv(string FECHA_INICIAL, string FECHA_FINAL, string TIPO_DE_ORDEN,
            string PROCEDENCIA, string UserName)
        {
            return controladorOrdenes.Listar_Ordenes_Entrega_FacPrv(FECHA_INICIAL, FECHA_FINAL, TIPO_DE_ORDEN,
                PROCEDENCIA, UserName);
        }

        [WebMethod(Description = "ORDENES DE SERVICIO POR PROYECTOS INCLUYE DOCUMENTOS POR PAGAR INGRESADOS POR EL PDF505")]
        public DataTable Listar_Egresos_Directos_OCO(string D_FECHAINI, string D_FECHAFIN, string UserName)
        {
            return controladorOrdenes.Listar_Egresos_Directos_OCO(D_FECHAINI, D_FECHAFIN, UserName);
        }

        [WebMethod(Description = "ORDENES DE COMPRAS Y SERVICIOS RELACIONADAS A OT")]
        public DataTable Listar_ORDENES_COM_SER_OT(string Centro_Operativo, string DIVISION, string ORDEN_DE_TRABAJO,
            string UserName)
        {
            return controladorOrdenes.Listar_ORDENES_COM_SER_OT(Centro_Operativo, DIVISION, ORDEN_DE_TRABAJO, UserName);
        }

        [WebMethod(Description = "ORDENES DE SERVICIO POR PROYECTOS - (DIFERENCIAL CAMBIARIO) basado en ORDENES DE COMPRA POR PROYECTOS INCLUYE DOCUMENTOS POR PAGAR INGRESADOS POR EL PDF505.")]
        public DataTable Listar_DIF_CMB_PRY_OSE(string Centro_Operativo, string división, string Proyecto,
            string UserName)
        {
            return controladorOrdenes.Listar_DIF_CMB_PRY_OSE(Centro_Operativo, división, Proyecto, UserName);
        }

        [WebMethod(Description = "ORDENES DE SERVICIO POR PROYECTOS INCLUYE DOCUMENTOS POR PAGAR INGRESADOS POR EL PDF505")]
        public DataTable Listar_DIF_CMB_PRY_OSE_MNT_AVA(string Centro_Operativo, string división, string Proyecto,
            string UserName)
        {
            return controladorOrdenes.Listar_DIF_CMB_PRY_OSE_MNT_AVA(Centro_Operativo, división, Proyecto, UserName);
        }

        [WebMethod(Description = "EGRESOS DIRECTOS POR PROYECTOS (DIFERENCIAL CAMBIARIO) basado en ORDENES DE SERVICIO POR PROYECTOS INCLUYE DOCUMENTOS POR PAGAR INGRESADOS POR EL PDF505")]
        public DataTable Listar_DIF_CMB_PRY_EGR_DIR_SIN_OT(string Centro_Operativo, string división, string Proyecto,
            string UserName)
        {
            return controladorOrdenes.Listar_DIF_CMB_PRY_EGR_DIR_SIN_OT(Centro_Operativo, división, Proyecto, UserName);
        }

        [WebMethod(Description = "AVANCE DE PAGOS DE ORDENES DE SERVICIO")]
        public DataTable Listar_OseAvance(string FECHA_EMISION_INICIAL, string FECHA_EMISION_FINAL, string NMRO_OSE,
            string UserName)
        {
            return controladorOrdenes.Listar_OseAvance(FECHA_EMISION_INICIAL, FECHA_EMISION_FINAL, NMRO_OSE, UserName);
        }

        [WebMethod(Description = "ORDENES DE COMPRA POR PROYECTOS - (DIFERENCIAL CAMBIARIO) basado en ORDENES DE COMPRA POR PROYECTOS INCLUYE DOCUMENTOS POR PAGAR INGRESADOS POR EL PDF505")]
        public DataTable Listar_DIF_CMB_PRY_OCO_PCI(string Centro_Operativo, string división, string Proyecto,
            string UserName)
        {
            return controladorOrdenes.Listar_DIF_CMB_PRY_OCO_PCI(Centro_Operativo, división, Proyecto, UserName);
        }

        [WebMethod(Description = "ORDENES DE COMPRA POR PROYECTOS - (DIFERENCIAL CAMBIARIO) basado en ORDENES DE COMPRA POR PROYECTOS INCLUYE DOCUMENTOS POR PAGAR INGRESADOS POR EL PDF505")]
        public DataTable Listar_DIF_CMB_PRY_OCO_SIN_OT(string Centro_Operativo, string división, string Proyecto,
            string Numero_Orden, string UserName)
        {
            return controladorOrdenes.Listar_DIF_CMB_PRY_OCO_SIN_OT(Centro_Operativo, división, Proyecto, Numero_Orden,
                UserName);
        }

        [WebMethod(Description = "EGRESOS DIRECTOS POR PROYECTOS (DIFERENCIAL CAMBIARIO) basado en ORDENES DE SERVICIO POR PROYECTOS INCLUYE DOCUMENTOS POR PAGAR INGRESADOS POR EL PDF505")]
        public DataTable Listar_DIF_CMB_PRY_EGR_DIR(string Centro_Operativo, string división, string Proyecto,
            string UserName)
        {
            return controladorOrdenes.Listar_DIF_CMB_PRY_EGR_DIR(Centro_Operativo, división, Proyecto, UserName);
        }

        [WebMethod(Description = "ALMACENAMIENTO DE ORDENES DE COMPRA POR PERIODO")]
        public DataTable Listar_ALM_OCO_ATE_RSV(string D_INICIO_ALMACENAMIENTO, string D_FINAL_ALMACENAMIENTO,
            string V_DESTINO_COMPRA, string V_Filtro_PRY_AUS, string V_PRY_AUS, string UserName)
        {
            return controladorOrdenes.Listar_ALM_OCO_ATE_RSV(D_INICIO_ALMACENAMIENTO, D_FINAL_ALMACENAMIENTO,
                V_DESTINO_COMPRA, V_Filtro_PRY_AUS, V_PRY_AUS, UserName);
        }

        #endregion

        #region Procedimientos almacenados de clasificacion: GENERAL

        [WebMethod(Description = "Tablas Generales - EQUIVALENCIAS GENERICAS (CONVERSION) DE UNIDADES DE MEDIDA")]
        public DataTable Listar_TG_EQUIVALENICIASGENERICAS(string UserName)
        {
            return controladorGeneral.Listar_TG_EQUIVALENICIASGENERICAS(UserName);
        }

        [WebMethod(Description = "Tablas Generales - EQUIVALENCIAS POR MATERIAL (CONVERSION) DE UNIDADES DE MEDIDA")]
        public DataTable Listar_TG_EQUIVALENICIASPORMATERIA(string UserName)
        {
            return controladorGeneral.Listar_TG_EQUIVALENICIASPORMATERIA(UserName);
        }

        [WebMethod(Description = "Tablas Generales - UNIDADES DE MEDIDA")]
        public DataTable Listar_Tg_Unidad_Medida(string UserName)
        {
            return controladorGeneral.Listar_Tg_Unidad_Medida(UserName);
        }

        #endregion

        #region Procedimientos almacenados de clasificacion: MATERIALES

        [WebMethod(Description = "Lista consumo Anual de materiales por Vales de Salida en el almacén")]
        public DataTable Listar_ConsumoAnualMateriales(string N_CEO, string PERIODO, string TIPO,
            string CLASIFICACION, string UserName)
        {
            return controladorMateriales.Listar_ConsumoAnualMateriales(N_CEO, PERIODO, TIPO, CLASIFICACION, UserName);
        }

        [WebMethod(Description = "Materiales por Centro Operativo")]
        public DataTable Listar_Mat_CentroOperativo(string Fecha_Emision_Inicio, string Fecha_Emision_Termino,
            string UserName)
        {
            return controladorMateriales.Listar_Mat_CentroOperativo(Fecha_Emision_Inicio, Fecha_Emision_Termino,
                UserName);
        }

        [WebMethod(Description = "MATERIAL LLEGADO DE COMPRAS")]
        public DataTable Listar_MatLLegadoCompras(string Codigo_Division, string Codigo_OT, string Fecha_LLegada_Inicio,
            string Fecha_Llegada_Termino, string UserName)
        {
            return controladorMateriales.Listar_MatLLegadoCompras(Codigo_Division, Codigo_OT, Fecha_LLegada_Inicio,
                Fecha_Llegada_Termino, UserName);
        }

        [WebMethod(Description = "Muestra el  CATALOGO DE MATERIALES por rango de fechas de creación")]
        public DataTable Listar_CatalogoMaterialesFC(string D_FechaIEmision, string D_FechaFEmision, string UserName)
        {
            return controladorMateriales.Listar_CatalogoMaterialesFC(D_FechaIEmision, D_FechaFEmision, UserName);
        }

        [WebMethod(Description = "CONSUMO DE MATERIALES POR CENTRO DE COSTOS")]
        public DataTable Listar_VM_CC(string N_CEO, string V_CODCC, string D_FECHAINI, string D_FECHAFIN,
            string UserName)
        {
            return controladorMateriales.Listar_VM_CC(N_CEO, V_CODCC, D_FECHAINI, D_FECHAFIN, UserName);
        }

        [WebMethod(Description = "MOVIMIENTO DE MATERIALES")]
        public DataTable Listar_MoviMatIOCVSMVD(string Centro_Operativo, string FECHA_INICIAL_MOVIMIENTO,
            string FECHA_FINAL_MOVIMIENTO, string CODIGO_MATERIAL, string UserName)
        {
            return controladorMateriales.Listar_MoviMatIOCVSMVD(Centro_Operativo, FECHA_INICIAL_MOVIMIENTO,
                FECHA_FINAL_MOVIMIENTO, CODIGO_MATERIAL, UserName);
        }

        [WebMethod(Description = "MOVIMIENTO DE MATERIALES POR CORTE DE INVENTARIO")]
        public DataTable Listar_MoviMaterialAud(string Almacen, string año_Inventario, string Corte,
            string Fecha_Inicial, string Fecha_Final, string UserName)
        {
            return controladorMateriales.Listar_MoviMaterialAud(Almacen, año_Inventario, Corte, Fecha_Inicial,
                Fecha_Final, UserName);
        }

        [WebMethod(Description = "CALCULO CANTIDAD EQUIVALENTE DE UN MATERIAL CON DIMENSIONES")]
        public DataTable Listar_EQUIVA2013(string V_MATERIAL, string V_DIMLARGO, string V_DIMANCHO, string V_UNMEDIDA,
            string V_CANTREQ, string UserName)
        {
            return controladorMateriales.Listar_EQUIVA2013(V_MATERIAL, V_DIMLARGO, V_DIMANCHO, V_UNMEDIDA, V_CANTREQ,
                UserName);
        }

        [WebMethod(Description = "CONSUMO DE MATERIALES POR CENTRO DE COSTOS")]
        public DataTable Listar_VM_CC_ESPECIFICO(string N_CEO, string V_CODCC, string D_FECHAINI, string D_FECHAFIN,
            string UserName)
        {
            return controladorMateriales.Listar_VM_CC_ESPECIFICO(N_CEO, V_CODCC, D_FECHAINI, D_FECHAFIN, UserName);
        }

        [WebMethod(Description = "RESERVAS DE MATERIALES -OTS PRODUCCION")]
        public DataTable Listar_ControlReservaMat(string V_CODIGO_MATERIAL, string D_FECHA_RESERVA_inicial,
            string D_FECHA_RESERVA_final, string UserName)
        {
            return controladorMateriales.Listar_ControlReservaMat(V_CODIGO_MATERIAL, D_FECHA_RESERVA_inicial,
                D_FECHA_RESERVA_final, UserName);
        }

        [WebMethod(Description = "Saldo de almacén")]
        public DataTable Listar_SaldoAlmacen(string Material_Inicial, string Material_Final, string UserName)
        {
            return controladorMateriales.Listar_SaldoAlmacen(Material_Inicial, Material_Final, UserName);
        }

        [WebMethod(Description = "Salidas de material  que provienen de las: OS/Rend.Cta./Fondos Fijos, de cada centro de costos en un rango de fechas")]
        public DataTable Listar_AtencionMaterialesCC(string V_Centro_Operativo, string D_Fecha_Inicio,
            string D_Fecha_Termino, string V_CC, string UserName)
        {
            return controladorMateriales.Listar_AtencionMaterialesCC(V_Centro_Operativo, D_Fecha_Inicio,
                D_Fecha_Termino, V_CC, UserName);
        }

        [WebMethod(Description = "Muestra el consumo de Vales de Salida de Material  por Tipo de V/M {OTS o CIN}")]
        public DataTable Listar_CONSUMO_VM_VALJDE(string V_TIPO_VALE, string D_FECHAINI, string D_FECHAFIN,
            string UserName)
        {
            return controladorMateriales.Listar_CONSUMO_VM_VALJDE(V_TIPO_VALE, D_FECHAINI, D_FECHAFIN, UserName);
        }

        [WebMethod(Description = "SEGUIMIENTO DE ATENCION DE REQUERIMIENTOS POR OTS")]
        public DataTable Listar_SeguiRequeDeta_OTS(string Codigo_Division, string Codigo_OT,
            string FECHA_EMISION_OT_Inicio, string FECHA_EMISION_OT_Termino, string FECHA_ATENCION_INICIO,
            string FECHA_ATENCION_TERMINO, string UserName)
        {
            return controladorMateriales.Listar_SeguiRequeDeta_OTS(Codigo_Division, Codigo_OT, FECHA_EMISION_OT_Inicio,
                FECHA_EMISION_OT_Termino, FECHA_ATENCION_INICIO, FECHA_ATENCION_TERMINO, UserName);
        }

        [WebMethod(Description = "PRECIOS DE REPOSICION A LA FECHA")]
        public DataTable Listar_PRECIOSREPOSICION(string CLAS_MATERIAL, string UserName)
        {
            return controladorMateriales.Listar_PRECIOSREPOSICION(CLAS_MATERIAL, UserName);
        }

        [WebMethod(Description = "punto de repedido por stock disponible (gravado/exonerado) con un indicador de materiales criticos")]
        public DataTable Listar_Punto_Reposicion(string TIPO_STOCK, string CLASE_MATERIAL, string MAT_CRI,
            string UserName)
        {
            return controladorMateriales.Listar_Punto_Reposicion(TIPO_STOCK, CLASE_MATERIAL, MAT_CRI, UserName);
        }

        [WebMethod(Description = "Punto de Reposición por Stock, precios promedios gravado y exonerado")]
        public DataTable Listar_Punto_Repo_Precios_Prome(string TIPO_STOCK, string CLASE_MATERIAL, string MAT_CRI,
            string UserName)
        {
            return controladorMateriales.Listar_Punto_Repo_Precios_Prome(TIPO_STOCK, CLASE_MATERIAL, MAT_CRI, UserName);
        }

        [WebMethod(Description = "Pedidos de Materiales - MULTIPROPOSITO")]
        public DataTable Listar_PedidoMateMultipropo(string NUMERO_PEDIDO, string EMISION_INICIAL_PEDIDO,
            string EMISION_FINAL_PEDIDO, string CODIGO_MATERIAL, string CODIGO_AUXILIAR, string UserName)
        {
            return controladorMateriales.Listar_PedidoMateMultipropo(NUMERO_PEDIDO, EMISION_INICIAL_PEDIDO,
                EMISION_FINAL_PEDIDO, CODIGO_MATERIAL, CODIGO_AUXILIAR, UserName);
        }

        [WebMethod(Description = "Reservas Pendientes ( OTs PRODUCCION )")]
        public DataTable Listar_Reserva_OT_Produccion(string Codigo_OT, string Codigo_Material, string Estado_OT,
            string Estado_Seguimiento_OT, string UserName)
        {
            return controladorMateriales.Listar_Reserva_OT_Produccion(Codigo_OT, Codigo_Material, Estado_OT,
                Estado_Seguimiento_OT, UserName);
        }

        [WebMethod(Description = "MATERIALES - CARGA MASIVA ")]
        public DataTable Listar_MAT_MASIVA(string CLASE_SUBCLASE, string UserName)
        {
            return controladorMateriales.Listar_MAT_MASIVA(CLASE_SUBCLASE, UserName);
        }

        [WebMethod(Description = "Reservas de Materiales de Areas Usuarias y OT's Internas (SE/PC)")]
        public DataTable Listar_ReserMateAreasUsua(string Area_Usuaria, string división, string Material, string OT,
            string UserName)
        {
            return controladorMateriales.Listar_ReserMateAreasUsua(Area_Usuaria, división, Material, OT, UserName);
        }

        [WebMethod(Description = "Muestra el catalogo CUBSO por su clase, la cual esta en los dos primeros digitos del codigo del material")]
        public DataTable Listar_CODIFICACION_CUBSO(string CLASE, string UserName)
        {
            return controladorMateriales.Listar_CODIFICACION_CUBSO(CLASE, UserName);
        }

        [WebMethod(Description = "ORDENES DE COMPRAS GENERADAS POR PAQUETES - DETALLE DEL PAQUETE")]
        public DataTable Listar_PedidoMaterialCompraOTS(string DIVISION, string NRO_PEDIDO, string UserName)
        {
            return controladorMateriales.Listar_PedidoMaterialCompraOTS(DIVISION, NRO_PEDIDO, UserName);
        }

        [WebMethod(Description = "Materiales  Con o sin stock por Centro Operativo")]
        public DataTable Listar_MatlesSinMov_PDR8701(string Centro_Operativo, string Almacen, string Fecha_Inicial,
            string Fecha_Final, string Clase, string Stock, string UserName)
        {
            return controladorMateriales.Listar_MatlesSinMov_PDR8701(Centro_Operativo, Almacen, Fecha_Inicial,
                Fecha_Final, Clase, Stock, UserName);
        }

        [WebMethod(Description = "Muestra la entrada y salida de materiales del centro operativo Sima Callao, en un rango de fechas")]
        public DataTable Listar_controlmateriales(string N_OPC, string N_CEO, string D_FECHAINI, string D_FECHAFIN, string C_DESTINO_OPER,  string V_COD_CLASE_MAT, string UserName)
        {
            return controladorMateriales.Listar_controlmateriales( N_OPC,  N_CEO,  D_FECHAINI, D_FECHAFIN, C_DESTINO_OPER,  V_COD_CLASE_MAT, UserName);
        }

        [WebMethod(Description = "SALDOS HISTORICOS DE MATERIALES EN EL ALMACEN (CIERRE)")]
        public DataTable Listar_saldo_historico_mat(string CENTRO_OPERATIVO, string FECHA_DE_PROCESO, string MATERIAL,
            string UserName)
        {
            return controladorMateriales.Listar_saldo_historico_mat(CENTRO_OPERATIVO, FECHA_DE_PROCESO, MATERIAL,
                UserName);
        }

        [WebMethod(Description = "GASTOS DIRECTOS POR OT'S POR PROYECTOS (MATERIALES), mediante Un Reporte elaborados para el PCI")]
        public DataTable Listar_DET_G_PRY_OT_VSM_PCI(string Centro_Operativo, string Division, string Proyecto, string Fecha_Emision, string UserName)
        {
            return controladorMateriales.Listar_DET_G_PRY_OT_VSM_PCI(Centro_Operativo, Division, Proyecto, Fecha_Emision, UserName);
        }

        [WebMethod(Description = "Lista los Recursos del Vales de Salida de Material  por Tipo CEO, Nro Vale ó Cód. Almacen ó  Cod. Área Usuaria")]
        public DataTable Listar_Vale_Salida_Mat(string s_CEO, string s_NRO_VALE, string s_COD_ALMA, string s_AREA_USU,
              string UserName)
        {
            return controladorMateriales.Listar_Vale_Salida_Mat(s_CEO, s_NRO_VALE, s_COD_ALMA, s_AREA_USU,
               UserName);
        }

        #endregion

        #region Procedimientos almacenados de clasificacion: STOCK

        [WebMethod(Description = "El detalle de las Transferidas de stock")]
        public DataTable Listar_TransStockVerFec(string FECHA_DE_TRANSFERENCIA_Inicio,
            string FECHA_DE_TRANSFERENCIA_Termino, string Material_Inicial, string Material_Final, string UserName)
        {
            return controladorStock.Listar_TransStockVerFec(FECHA_DE_TRANSFERENCIA_Inicio,
                FECHA_DE_TRANSFERENCIA_Termino, Material_Inicial, Material_Final, UserName);
        }

        [WebMethod(Description = "")]
        public DataTable Listar_TransStockVerCon(string Fecha_Inicial, string Fecha_Final, string USUARIO,
            string TERMINAL, string UserName)
        {
            return controladorStock.Lista_TransStockVerCon(Fecha_Inicial, Fecha_Final, USUARIO, TERMINAL, UserName);
        }

        [WebMethod(Description = "DISPONIBILIDAD DE STOCK COMPRADO")]
        public DataTable Listar_Valorizacion_Disp_Stock(string N_CEO, string V_CODDIV, string V_NROVAL, string UserName)
        {
            return controladorStock.Listar_Valorizacion_Disp_Stock(N_CEO, V_CODDIV, V_NROVAL, UserName);
        }

        [WebMethod(Description = "Punto de Reposición por Stock (Control), por una lista diaria de los materiales de reposicion de stock gravado y exonerado cuyo stock disponible es menor o igual al stock de repedido")]
        public DataTable Listar_Punto_Reposicion_Pedido(string TIPO_STOCK, string CLASE_MATERIAL, string CLASIFICACION,
            string MATERIAL_CRITICO, string UserName)
        {
            return controladorStock.Listar_Punto_Reposicion_Pedido(TIPO_STOCK, CLASE_MATERIAL, CLASIFICACION,
                MATERIAL_CRITICO, UserName);
        }

        [WebMethod(Description = "Liberacion de reservas,  incluye consumo  a partir de la fecha minima de liberacion.")]
        public DataTable Listar_liberareservascon(string FECHA_FINAL, string FECHA_INICIAL, string UserName)
        {
            return controladorStock.Listar_liberareservascon(FECHA_FINAL, FECHA_INICIAL, UserName);
        }

        [WebMethod(Description = "Transferidas de stock por Liberaciones de Reservas incluye consumo a partir de la fecha minima de liberacion")]
        public DataTable Listar_liberareservastrf(string FECHA_DE_LIBERACION_INICIO, string FECHA_DE_LIBERACION_TERMINO,
            string MATERIAL_FINAL, string MATERIAL_INICIAL, string UserName)
        {
            return controladorStock.Listar_liberareservastrf(FECHA_DE_LIBERACION_INICIO, FECHA_DE_LIBERACION_TERMINO,
                MATERIAL_FINAL, MATERIAL_INICIAL, UserName);
        }


        #endregion

        #region Procedimientos almacenados de clasificacion: PROVEEDORES

        [WebMethod(Description = "Archivo 4ta")]
        public DataTable Listar_PDT601_4TA(string D_FECHAPRO, string UserName)
        {
            return controladorProveedores.Listar_PDT601_4TA(D_FECHAPRO, UserName);
        }

        [WebMethod(Description = "Pdt0601 Extension Ps4")]
        public DataTable Listar_PDT601_PS4(string D_FECHAPRO, string UserName)
        {
            return controladorProveedores.Listar_PDT601_PS4(D_FECHAPRO, UserName);
        }

        [WebMethod(Description = "RETENCIONES DE 4TA. CATEGORIA - SIMA-CALLAO")]
        public DataTable Listar_Reg_Retencion_4TA(string D_FECHAPRO, string UserName)
        {
            return controladorProveedores.Listar_Reg_Retencion_4TA(D_FECHAPRO, UserName);
        }

        [WebMethod(Description = "DEVOLUCION A PROVEEDORES (SALIDAS DE ALMACEN)")]
        public DataTable Listar_Salidas_Dev_Prov(string N_CEO, string V_PROCESO, string UserName)
        {
            return controladorProveedores.Listar_Salidas_Dev_Prov(N_CEO, V_PROCESO, UserName);
        }

        [WebMethod(Description = "PROGRAMA DE ADQUISICION PARA ENVIO DE COTIZACION AL PROVEEDOR")]
        public DataTable Listar_ProgramaAdquiEnvioCot(string PROGRAMA_ADQUISICION, string UserName)
        {
            return controladorProveedores.Listar_ProgramaAdquiEnvioCot(PROGRAMA_ADQUISICION, UserName);
        }

        [WebMethod(Description = "Registro de Proveedores")]
        public DataTable Listar_RegistroProveedores(string Fecha_Registro, string Estado, string Tipo, string RUC,
            string Procedencia, string UserName)
        {
            return controladorProveedores.Listar_RegistroProveedores(Fecha_Registro, Estado, Tipo, RUC, Procedencia,
                UserName);
        }

        #endregion

        #region Procedimientos almacenados de clasificacion: BIENES

        [WebMethod(Description = "los bienes almacenados")]
        public DataTable Listar_BienesAlmacenados(string V_CLASE_MATERIAL, string D_FECHA_ALMACENAMIENTO_inicial,
            string D_FECHA_ALMACENAMIENTO_fina, string UserName)
        {
            return controladorBienes.Listar_BienesAlmacenados(V_CLASE_MATERIAL, D_FECHA_ALMACENAMIENTO_inicial,
                D_FECHA_ALMACENAMIENTO_fina, UserName);
        }

        #endregion

        #region Procedimientos almacenados de clasificacion: REQUERIMIENTOS

        [WebMethod(Description = "Presupuesto (cantidades de recursos Requeridos segun nro de cta contable)")]
        public DataTable Listar_Presupuesto(string PERIODO_PRESUPUESTO, string TIPO_DE_RECURSO, string UserName)
        {
            return controladorRequerimientos.Listar_Presupuesto(PERIODO_PRESUPUESTO, TIPO_DE_RECURSO, UserName);
        }

        #endregion

        #region Procedimientos almacenados de clasificacion: SERVICIOS

        [WebMethod(Description = "Muestra el Catalogo General de Servicios SR ")]
        public DataTable Listar_Catalogo_Servicios_SR(string CLASE, string UserName)
        {
            return controladorServicios.Listar_Catalogo_Servicios_SR(CLASE, UserName);
        }

        #endregion

        #region Procedimientos almacenados de clasificacion: PROYECTOS

        [WebMethod(Description = "RESUMEN DE PAGOS (nro documento) POR PROYECTOS")]
        public DataTable Listar_PRY_PAG_TOT(string Centro_Operativo, string división, string Proyecto, string Nro_Orden,
            string Procedencia, string Tipo_Orden, string UserName)
        {
            return controladorProyectos.Listar_PRY_PAG_TOT(Centro_Operativo, división, Proyecto, Nro_Orden, Procedencia,
                Tipo_Orden, UserName);
        }

        #endregion
    }
}