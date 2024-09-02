using AccesoDatos.NoTransaccional.GestionProduccion;
using AccesoDatos.Transaccional.GestionProduccion;
using EntidadNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.GestionProduccion
{
    public class CActividad
    {
        /*
        private readonly ActividadTAD _Actividad;

        public CActividad(ActividadTAD actividad)
        {
            _Actividad = actividad;
        }
        */
        public string Modifica(BaseBE oBaseBE)
        {
            return (new ActividadTAD()).Modifica(oBaseBE);
        }
    }
}
