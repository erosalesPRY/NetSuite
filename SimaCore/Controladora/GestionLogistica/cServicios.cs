using AccesoDatos.NoTransaccional.GestionLogistica;
using System.Data;

namespace Controladora.GestionLogistica
{
    public class cServicios
    {
        private readonly ServiciosNTAD _servicios;

        public cServicios(ServiciosNTAD servicios)
        {
            _servicios = servicios;
        }

        public DataTable Listar_Catalogo_Servicios_SR(string CLASE, string UserName)
        {
            return _servicios.Listar_Catalogo_Servicios_SR(CLASE, UserName);
        }
    }
}