﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Estandar;
using AccesoDatos.NoTransaccional.GestionLogistica;

namespace Controladora.GestionLogistica
{
    public class cOrdenes
    {
        private readonly OrdenesNTAD _ordenes;

        public cOrdenes(OrdenesNTAD ordenes)
        {
            _ordenes = ordenes;
        }

        public DataTable Listar_OrdenComP_VFechaEntre(string Centro_Operativo, string Procedencia, string Fecha_Inicio,
            string Fecha_Termino, string Clase_Material, string UserName)
        {
            return _ordenes.Listar_OrdenComP_VFechaEntre(Centro_Operativo,Procedencia, Fecha_Inicio, Fecha_Termino, Clase_Material, UserName);
        }

        public DataTable Listar_OcoEmiContral(string Centro_Operativo, string Procedencia, string Tipo, string Estado,
            string Fecha_Inicial, string Fecha_Final, string UserName)
        {
            return _ordenes.Listar_OcoEmiContral(Centro_Operativo, Procedencia, Tipo, Estado, Fecha_Inicial, Fecha_Final,
                UserName);
        }

        public DataTable Listar_ordcompraporrepo(string DESTINO_COMPRA, string FECHA_MOVIMIENTO_INICIO,
            string FECHA_MOVIMIENTO_TERMINO, string MATERIAL_FINAL,
            string MATERIAL_INICIAL, string UserName)
        {
            return _ordenes.Listar_ordcompraporrepo(DESTINO_COMPRA, FECHA_MOVIMIENTO_INICIO, FECHA_MOVIMIENTO_TERMINO,
                MATERIAL_FINAL, MATERIAL_INICIAL, UserName);
        }

        public DataTable Listar_OrdServicioLond(string Fecha_Emision_Inicio, string Fecha_Emision_Termino,
            string Procedencia, string UserName)
        {
            return _ordenes.Listar_OrdServicioLond(Fecha_Emision_Inicio, Fecha_Emision_Termino, Procedencia, UserName);
        }

        public DataTable Listar_ModiFEntreOcoOse(string Centro_Operativo, string Tipo_Orden, string Procedencia,
            string Numero_Orden, string UserName)
        {
            return _ordenes.Listar_ModiFEntreOcoOse(Centro_Operativo, Tipo_Orden, Procedencia, Numero_Orden, UserName);
        }

        public DataTable Listar_OcoEmiLogi(string Centro_Operativo, string Procedencia, string Tipo, string Estado,
            string Fecha_Emision_Inicial, string Fecha_Emision_Final, string Cotizador, string UserName)
        {
            return _ordenes.Listar_OcoEmiLogi(Centro_Operativo, Procedencia, Tipo, Estado, Fecha_Emision_Inicial,
                Fecha_Emision_Final, Cotizador, UserName);
        }

        public DataTable Listar_AVANCE_OSE_VALJDE(string D_FECHAINI, string D_FECHAFIN, string UserName)
        {
            return _ordenes.Listar_AVANCE_OSE_VALJDE(D_FECHAINI, D_FECHAFIN, UserName);
        }

        public DataTable Listar_ALMAC_OCO_VALJDE(string D_FECHAINI, string D_FECHAFIN, string UserName)
        {
            return _ordenes.Listar_ALMAC_OCO_VALJDE(D_FECHAINI, D_FECHAFIN, UserName);
        }

        public DataTable Listar_AtencionesServiciosCC(string N_CEO, string V_CODCCO, string D_FECHAINI,
            string D_FECHAFIN, string UserName)
        {
            return _ordenes.Listar_AtencionesServiciosCC(N_CEO, V_CODCCO, D_FECHAINI, D_FECHAFIN, UserName);
        }

        public DataTable Listar_REQUERIMIENTO_OCO_VALJDE(string Fecha_Emision, string UserName)
        {
            return _ordenes.Listar_REQUERIMIENTO_OCO_VALJDE(Fecha_Emision, UserName);
        }

        public DataTable Listar_OCO_OGC(string Centro_Operativo, string Procedencia, string año_de_Orden,
            string UserName)
        {
            return _ordenes.Listar_OCO_OGC(Centro_Operativo, Procedencia, año_de_Orden, UserName);
        }

        public DataTable Listar_OSE_OGC(string Centro_Operativo, string año_de_Orden,
            string UserName)
        {
            return _ordenes.Listar_OSE_OGC(Centro_Operativo, año_de_Orden, UserName);
        }

        public DataTable Listar_LOG_OSE_OTS_RN(string V_Centro_Operativo, string V_división,
            string D_Fecha_Emision_OSE_Inicio, string D_Fecha_Emision_OSE_Termino, string UserName)
        {
            return _ordenes.Listar_LOG_OSE_OTS_RN(V_Centro_Operativo, V_división, D_Fecha_Emision_OSE_Inicio,
                D_Fecha_Emision_OSE_Termino, UserName);
        }

        public DataTable Listar_OrdenesServicioCC(string D_FECHAINI, string D_FECHAFIN, string UserName)
        {
            return _ordenes.Listar_OrdenesServicioCC(D_FECHAINI, D_FECHAFIN, UserName);
        }

        public DataTable Listar_OrdenesCompraCC(string D_FECHAINI, string D_FECHAFIN, string UserName)
        {
            return _ordenes.Listar_OrdenesCompraCC(D_FECHAINI, D_FECHAFIN, UserName);
        }

        public DataTable Listar_ORDENCOM_SER_OT_CONTRALORIA(string Centro_Operativo, string DIVISION,
            string ORDEN_DE_TRABAJO, string UserName)
        {
            return _ordenes.Listar_ORDENCOM_SER_OT_CONTRALORIA(Centro_Operativo, DIVISION, ORDEN_DE_TRABAJO, UserName);
        }

        public DataTable Listar_Ordenes_Entrega_FacPrv(string FECHA_INICIAL, string FECHA_FINAL, string TIPO_DE_ORDEN,
            string PROCEDENCIA, string UserName)
        {
            return _ordenes.Listar_Ordenes_Entrega_FacPrv(FECHA_INICIAL, FECHA_FINAL, TIPO_DE_ORDEN, PROCEDENCIA,
                UserName);
        }

        public DataTable Listar_Egresos_Directos_OCO(string D_FECHAINI, string D_FECHAFIN, string UserName)
        {
            return _ordenes.Listar_Egresos_Directos_OCO(D_FECHAINI, D_FECHAFIN, UserName);
        }

        public DataTable Listar_ORDENES_COM_SER_OT(string Centro_Operativo, string DIVISION, string ORDEN_DE_TRABAJO,
            string UserName)
        {
            return _ordenes.Listar_ORDENES_COM_SER_OT(Centro_Operativo, DIVISION, ORDEN_DE_TRABAJO, UserName);
        }

        public DataTable Listar_DIF_CMB_PRY_OSE(string Centro_Operativo, string división, string Proyecto,
            string UserName)
        {
            return _ordenes.Listar_DIF_CMB_PRY_OSE(Centro_Operativo, división, Proyecto, UserName);
        }

        public DataTable Listar_DIF_CMB_PRY_OSE_MNT_AVA(string Centro_Operativo, string división, string Proyecto,
            string UserName)
        {
            return _ordenes.Listar_DIF_CMB_PRY_OSE_MNT_AVA(Centro_Operativo, división, Proyecto, UserName);
        }

        public DataTable Listar_DIF_CMB_PRY_EGR_DIR_SIN_OT(string Centro_Operativo, string división, string Proyecto,
            string UserName)
        {
            return _ordenes.Listar_DIF_CMB_PRY_EGR_DIR_SIN_OT(Centro_Operativo, división, Proyecto, UserName);
        }

        public DataTable Listar_OseAvance(string FECHA_EMISION_INICIAL, string FECHA_EMISION_FINAL, string NMRO_OSE,
            string UserName)
        {
            return _ordenes.Listar_OseAvance(FECHA_EMISION_INICIAL, FECHA_EMISION_FINAL, NMRO_OSE, UserName);
        }

        public DataTable Listar_DIF_CMB_PRY_OCO_PCI(string Centro_Operativo, string división, string Proyecto,
            string UserName)
        {
            return _ordenes.Listar_DIF_CMB_PRY_OCO_PCI(Centro_Operativo, división, Proyecto, UserName);
        }

        public DataTable Listar_DIF_CMB_PRY_OCO_SIN_OT(string Centro_Operativo, string división, string Proyecto,
            string Numero_Orden, string UserName)
        {
            return _ordenes.Listar_DIF_CMB_PRY_OCO_SIN_OT(Centro_Operativo, división, Proyecto, Numero_Orden, UserName);
        }

        public DataTable Listar_DIF_CMB_PRY_EGR_DIR(string Centro_Operativo, string división, string Proyecto,
            string UserName)
        {
            return _ordenes.Listar_DIF_CMB_PRY_EGR_DIR(Centro_Operativo, división, Proyecto, UserName);
        }

        public DataTable Listar_ALM_OCO_ATE_RSV(string D_INICIO_ALMACENAMIENTO, string D_FINAL_ALMACENAMIENTO,
            string V_DESTINO_COMPRA, string V_Filtro_PRY_AUS, string V_PRY_AUS, string UserName)
        {
            return _ordenes.Listar_ALM_OCO_ATE_RSV(D_INICIO_ALMACENAMIENTO, D_FINAL_ALMACENAMIENTO, V_DESTINO_COMPRA,
                V_Filtro_PRY_AUS, V_PRY_AUS, UserName);
        }
    }
}
