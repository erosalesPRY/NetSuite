using AccesoDatos.NoTransaccional.GestionTesoreria;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.GestionTesoreria
{
    public class cCobros
    {
        private readonly CobrosNTAD _cobros;

        public cCobros(CobrosNTAD cobros)
        {
            _cobros = cobros;
        }

        public DataTable Listar_folios_pendientes_o7(string D_AÑO, string D_MES, string UserName)
        {
            return _cobros.Listar_folios_pendientes_o7(D_AÑO, D_MES, UserName);
        }

        public DataTable Listar_ingresos_contabilizados(string D_FECHA_DESDE, string D_FECHA_HASTA,
            string V_CENTRO_OPERATIVO, string V_CONCEPTO, string V_DESDE, string V_EMPRESA_DESDE,
            string V_EMPRESA_HASTA, string V_HASTA, string V_MONEDA, string UserName)
        {
            return _cobros.Listar_ingresos_contabilizados(D_FECHA_DESDE, D_FECHA_HASTA, V_CENTRO_OPERATIVO, V_CONCEPTO,
                V_DESDE, V_EMPRESA_DESDE, V_EMPRESA_HASTA, V_HASTA, V_MONEDA, UserName);
        }

        public DataTable Listar_ventas_x_orden_trabajo(string V_CENTRO_OPERATIVO, string V_DIVISION, string V_NUMERO_OT,
            string UserName)
        {
            return _cobros.Listar_ventas_x_orden_trabajo(V_CENTRO_OPERATIVO, V_DIVISION, V_NUMERO_OT, UserName);
        }
        public DataTable Listar_fact_cobrar_sector_privado(string UserName)
        {
            return _cobros.Listar_fact_cobrar_sector_privado(UserName);
        }
        public DataTable Listar_fact_cobrar_sector_marina(string UserName)
        {
            return _cobros.Listar_fact_cobrar_sector_marina(UserName);
        }
    }
}
