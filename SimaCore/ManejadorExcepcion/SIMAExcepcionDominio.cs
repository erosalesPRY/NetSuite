using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejadorExcepcion
{
    /// <summary>
    /// Excepcion empleada en todas las capas detras de la IU
    /// </summary>
    public class SIMAExcepcionDominio : SIMAExcepcion
    {
        public SIMAExcepcionDominio(string error) : base(error)
        {
            this.error = error;
        }

        public SIMAExcepcionDominio(string error, string mensaje) : base(error, mensaje)
        {
            this.error = error;
            this.mensaje = mensaje;
        }
    }
}
