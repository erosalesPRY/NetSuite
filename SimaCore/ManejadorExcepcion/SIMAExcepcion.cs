using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejadorExcepcion
{
    /// <summary>
    /// Summary description for SIMAExcepcion.
    /// </summary>
    public class SIMAExcepcion : ApplicationException
    {
        protected string error;
        protected string mensaje;

        public string Error
        {
            get { return this.error; }
        }

        public string Mensaje
        {
            get { return this.mensaje; }
        }

        public SIMAExcepcion(string error) : base(error)
        {
            this.error = error;
        }

        public SIMAExcepcion(string error, string mensaje) : base(error)
        {
            this.error = error;
            this.mensaje = mensaje;
        }
    }
}
