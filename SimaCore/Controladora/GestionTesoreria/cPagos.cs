using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionTesoreria;

namespace Controladora.GestionTesoreria
{
    public class cPagos
    {
        private readonly PagosNTAD _pagos;

        public cPagos(PagosNTAD pagos)
        {
            _pagos = pagos;
        }

        public DataTable Listar_cheque_giradoxnum(string V_CENTRO_OPERATIVO, string V_CHEQUE_NUMERO, string UserName)
        {
            return _pagos.Listar_cheque_giradoxnum(V_CENTRO_OPERATIVO, V_CHEQUE_NUMERO, UserName);
        }

        public DataTable Listar_cheques_egresos_directos(string D_AÑO, string D_MES_DESDE, string D_MES_HASTA,
            string V_CENTRO_OPERATIVO, string V_MONEDA, string V_TIPO_DE_OPERACION, string UserName)
        {
            return _pagos.Listar_cheques_egresos_directos(D_AÑO, D_MES_DESDE, D_MES_HASTA, V_CENTRO_OPERATIVO, V_MONEDA,
                V_TIPO_DE_OPERACION, UserName);
        }

        public DataTable Listar_cheques_emitidos_resumen(string D_AÑO, string V_CENTRO_OPERATIVO, string UserName)
        {
            return _pagos.Listar_cheques_emitidos_resumen(D_AÑO, V_CENTRO_OPERATIVO, UserName);
        }

        public DataTable Listar_cheques_giradosxprove_det(string D_FECHA_DESDE, string D_FECHA_HASTA,
            string V_CENTRO_OPERATIVO, string V_RELACION_DESDE, string V_RELACION_HASTA, string UserName)
        {
            return _pagos.Listar_cheques_giradosxprove_det(D_FECHA_DESDE, D_FECHA_HASTA, V_CENTRO_OPERATIVO,
                V_RELACION_DESDE, V_RELACION_HASTA, UserName);
        }

        public DataTable Listar_cheques_giradosxprove_res(string D_AÑO, string D_MES, string V_CENTRO_OPERATIVO,
            string V_RELACION_DESDE, string V_RELACION_HASTA, string UserName)
        {
            return _pagos.Listar_cheques_giradosxprove_res(D_AÑO, D_MES, V_CENTRO_OPERATIVO, V_RELACION_DESDE,
                V_RELACION_HASTA, UserName);
        }

        public DataTable Listar_cheques_por_observacion(string D_FECHA_DESDE, string D_FECHA_HASTA,
            string V_CENTRO_OPERATIVO, string V_OBSERVACION, string UserName)
        {
            return _pagos.Listar_cheques_por_observacion(D_FECHA_DESDE, D_FECHA_HASTA, V_CENTRO_OPERATIVO,
                V_OBSERVACION, UserName);
        }
        public DataTable Listar_lote_de_detrac_por_doc(string V_CENTRO_OPERATIVO, string V_NUMERO_DE_LOTE, string UserName)
        {
            return _pagos.Listar_lote_de_detrac_por_doc(V_CENTRO_OPERATIVO,V_NUMERO_DE_LOTE,UserName);
        }
        public DataTable Listar_fact_pagar_pendientes(string V_RECURSO, string V_RUC, string V_PROYECTO, string UserName)
        {
            return _pagos.Listar_fact_pagar_pendientes( V_RECURSO,V_RUC,V_PROYECTO,UserName);
        }
        public DataTable Listar_fact_por_pagar_doc(string D_AÑO, string D_MES, string V_RELACION_DESDE, string V_RELACION_HASTA, string UserName)
        {
            return _pagos.Listar_fact_por_pagar_doc(D_AÑO,D_MES,V_RELACION_DESDE,V_RELACION_HASTA,UserName);
        }
        public DataTable Listar_facturas_por_pagar_total(string UserName)
        {
            return _pagos.Listar_facturas_por_pagar_total(UserName);
        }
    }
}
