using AccesoDatos.NoTransaccional.GestionLogistica;
using System.Data;

namespace Controladora.GestionLogistica
{
    public class cProyectos
    {
        private readonly ProyectosNTAD _proyectos;

        public cProyectos(ProyectosNTAD proyectos)
        {
            _proyectos = proyectos;
        }

        public DataTable Listar_PRY_PAG_TOT(string Centro_Operativo, string división, string Proyecto, string Nro_Orden,
            string Procedencia, string Tipo_Orden, string UserName)
        {
            return _proyectos.Listar_PRY_PAG_TOT(Centro_Operativo, división, Proyecto, Nro_Orden, Procedencia,
                Tipo_Orden, UserName);
        }
    }
}