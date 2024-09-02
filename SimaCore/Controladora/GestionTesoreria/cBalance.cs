using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.NoTransaccional.GestionTesoreria;

namespace Controladora.GestionTesoreria
{
    public class cBalance
    {
        private readonly BalanceNTAD _balance;

        public cBalance(BalanceNTAD balance)
        {
            _balance = balance;
        }

        public DataTable Listar_conci_banc_r_cartola_conc(string D_AÑO, string D_MES, string V_CARTOLA, string V_CENTRO_OPERATIVO, string V_MONEDA, string UserName)
        {
            return _balance.Listar_conci_banc_r_cartola_conc(D_AÑO, D_MES, V_CARTOLA, V_CENTRO_OPERATIVO, V_MONEDA,
                UserName);
        }

        public DataTable Listar_conci_bancaria_res_cartol(string D_AÑO, string D_MES, string V_CARTOLA, string V_CENTRO_OPERATIVO, string V_MONEDA, string UserName)
        {
            return _balance.Listar_conci_bancaria_res_cartol(D_AÑO, D_MES, V_CARTOLA, V_CENTRO_OPERATIVO, V_MONEDA,
                UserName);
        }

        public DataTable Listar_conciliacion_banc_cartola(string D_AÑO, string D_MES, string V_CARTOLA,
            string V_CENTRO_OPERATIVO, string V_MONEDA, string UserName)
        {
            return _balance.Listar_conciliacion_banc_cartola(D_AÑO, D_MES, V_CARTOLA, V_CENTRO_OPERATIVO, V_MONEDA,
                UserName);
        }

        public DataTable Listar_detalle_ffj_gf(string D_AÑO, string V_LIQUIDACION, string UserName)
        {
            return _balance.Listar_detalle_ffj_gf(D_AÑO, V_LIQUIDACION, UserName);
        }

        public DataTable Listar_libro_banco(string D_AÑO, string D_MES, string V_BANCO, string V_CENTRO_OPERATIVO,
            string V_CUENTA_CORRIENTE, string UserName)
        {
            return _balance.Listar_libro_banco(D_AÑO, D_MES, V_BANCO, V_CENTRO_OPERATIVO, V_CUENTA_CORRIENTE, UserName);
        }

        public DataTable Listar_res_ffj_x_centro_costos(string D_AÑO, string V_LIQUIDACION, string UserName)
        {
            return _balance.Listar_res_ffj_x_centro_costos(D_AÑO, V_LIQUIDACION, UserName);
        }
        public DataTable Listar_cheques_egresos_directos(string D_AÑO, string D_MES_DESDE, string D_MES_HASTA, string V_CENTRO_OPERATIVO, string V_MONEDA, string V_TIPO_DE_OPERACION, string UserName)
        {
            return _balance.Listar_cheques_egresos_directos(D_AÑO,D_MES_DESDE,D_MES_HASTA,V_CENTRO_OPERATIVO,V_MONEDA,V_TIPO_DE_OPERACION,UserName);
        }

    }
}
