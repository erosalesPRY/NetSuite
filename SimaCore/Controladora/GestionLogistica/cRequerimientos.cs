using AccesoDatos.NoTransaccional.GestionLogistica;
using System.Data;

namespace Controladora.GestionLogistica
{
    public class cRequerimientos
    {
        private readonly RequerimientosNTAD _requerimientos;

        public cRequerimientos(RequerimientosNTAD requerimientos)
        {
            _requerimientos = requerimientos;
        }

        public DataTable Listar_Presupuesto(string PERIODO_PRESUPUESTO, string TIPO_DE_RECURSO, string UserName)
        {
            return _requerimientos.Listar_Presupuesto(PERIODO_PRESUPUESTO, TIPO_DE_RECURSO, UserName);
        }
    }
}