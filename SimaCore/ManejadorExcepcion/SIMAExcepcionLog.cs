using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejadorExcepcion
{
    /// <summary>
    /// Excepcion empleada en el Manejador de Log
    /// </summary>
    public class SIMAExcepcionLog : SIMAExcepcion
    {
        public SIMAExcepcionLog(string error) : base(error)
        {
            this.error = error;
        }

        public SIMAExcepcionLog(string error, string mensaje) : base(error, mensaje)
        {
            this.error = error;
            this.mensaje = mensaje;
        }
    }
}
