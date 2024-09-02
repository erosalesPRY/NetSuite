using AccesoDatos.NoTransaccional.GestionContabilidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.GestionContabilidad
{ 
    public class CBalance
    {
        private readonly BalanceNTAD _balance;

        public CBalance(BalanceNTAD balance)
        {
            _balance = balance;
        }
        public DataTable Listar_balance_de_comprobacion(string D_MES, string D_PERIODO, string V_CENTRO_OPERATIVO, string V_CUENTA_DESDE, string V_CUNETA_HASTA, string UserName)
        {
            return _balance.Listar_balance_de_comprobacion(D_MES,D_PERIODO,V_CENTRO_OPERATIVO,V_CUENTA_DESDE,V_CUNETA_HASTA,UserName);
        }
        

    }
}
