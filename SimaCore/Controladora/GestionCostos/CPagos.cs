using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AccesoDatos.NoTransaccional.GestionCostos;

namespace Controladora.GestionCostos
{ 
    public class CPagos
    {
        private readonly PagosNTAD _pagos;

        public CPagos(PagosNTAD pagos)
        {
            _pagos = pagos;
        }
        public DataTable Listar_analisis_gastos_ccnatudet(string D_AÑO_DE_PROCESO, string D_MES_DE_PROCESO, string V_CENTRO_OPERATIVO, string V_CUENTA_MAYOR, string UserName)
        {
            return _pagos.Listar_analisis_gastos_ccnatudet(D_AÑO_DE_PROCESO,D_MES_DE_PROCESO,V_CENTRO_OPERATIVO,V_CUENTA_MAYOR,UserName);
        }
        public DataTable Listar_analisis_gast_itemsasient(string V_CENTRO_OPERATIVO, string V_DIVISION, string V_NUMERO_OT, string UserName)
        {
            return _pagos.Listar_analisis_gast_itemsasient(V_CENTRO_OPERATIVO,V_DIVISION,V_NUMERO_OT,UserName);
        }
    }
}
