using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AccesoDatos.NoTransaccional.GestionCostos;

namespace Controladora.GestionCostos
{ 
    public class CCostos
    {
        private readonly CostosNTAD _costos;

        public CCostos(CostosNTAD costos)
        {
            _costos = costos;
        }
        public DataTable Listar_costo_prod_linea_neg_resu(string D_AÑO, string D_MES, string V_CENTRO_OPERATIVO, string V_LINEA_NEGOCIO, string UserName)
        {
            return _costos.Listar_costo_prod_linea_neg_resu(D_AÑO,D_MES,V_CENTRO_OPERATIVO,V_LINEA_NEGOCIO,UserName);
        }
        public DataTable Listar_costo_prod_linea_neg_det(string D_AÑO, string D_MES, string V_CENTRO_OPERATIVO, string V_LINEA_NEGOCIO, string UserName)
        {
            return _costos.Listar_costo_prod_linea_neg_det(D_AÑO, D_MES, V_CENTRO_OPERATIVO, V_LINEA_NEGOCIO, UserName);
        }

    }
}
