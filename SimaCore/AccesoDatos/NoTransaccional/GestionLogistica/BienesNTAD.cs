using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Estandar;

namespace AccesoDatos.NoTransaccional.GestionLogistica
{
    public class BienesNTAD
    {
        private readonly IStandarProcedure _standarProcedure;

        public BienesNTAD(IStandarProcedure standarProcedure)
        {
            _standarProcedure = standarProcedure;
        }

        public DataTable Listar_BienesAlmacenados(string V_CLASE_MATERIAL, string D_FECHA_ALMACENAMIENTO_inicial,
            string D_FECHA_ALMACENAMIENTO_fina, string UserName)
        {
            string packageName = "CONSULTA.PKG_LOGISTICA.SP_BienesAlmacenados";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("V_CLASE_MATERIAL", V_CLASE_MATERIAL);
            parameters.Add("D_FECHA_ALMACENAMIENTO_inicial", D_FECHA_ALMACENAMIENTO_inicial);
            parameters.Add("D_FECHA_ALMACENAMIENTO_fina", D_FECHA_ALMACENAMIENTO_fina);
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
