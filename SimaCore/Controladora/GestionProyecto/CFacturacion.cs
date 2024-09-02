using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AccesoDatos.NoTransaccional.GestionProyecto;

namespace Controladora.GestionProyecto
{ 
    public class CFacturacion
    {
        private readonly FacturacionNTAD _facturacion;

        public CFacturacion(FacturacionNTAD facturacion)
        {
            _facturacion = facturacion;
        }

        public DataTable Listar_detalle_gasto_pry_ot_fac(string N_CEO, string V_CODDIV, string V_CODPRY, string V_PERIODO, string UserName)
        {
            return _facturacion.Listar_detalle_gasto_pry_ot_fac(N_CEO,V_CODDIV,V_CODPRY,V_PERIODO,UserName);
        }

    }
}
