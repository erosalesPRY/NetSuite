using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Utilitario;

namespace Log
{
    /// <summary>
    /// Summary description for LogTransaccional.
    /// </summary>
    /// 

    public class LogAplicativo : LogBE
    {


        public LogAplicativo()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private string ipCliente;
        private string paginaCliente;

        /// <summary>
        /// Constructor empleado para inicializar los Datos del Log Aplicativo
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="modulo"></param>
        /// <param name="paginaCliente"></param>
        /// <param name="descripcion"></param>
        /// <param name="nivelLog"></param>

        public LogAplicativo(string usuario, string modulo, string paginaCliente, string descripcion, string nivelLog)
        {
            this.usuario = usuario;
            this.modulo = modulo;
            this.paginaCliente = paginaCliente;
            this.descripcion = descripcion;
            this.ipCliente = HttpContext.Current.Request.UserHostAddress;
            this.nivel = nivelLog;
        }

        public override string ToString()
        {
            string linea1 = DateTime.Now.ToString(Constante.Formato.Fecha.ddddMMMdd) + " " + DateTime.Now.ToString(Constante.Formato.Hora.Estandar) + " " + DateTime.Now.ToString(Constante.Formato.Fecha.AÑO) + ": [" + nivel.Trim() + "]";

            string linea2 = "===> ";
            linea2 = linea2 + "Versión [01.00.00] ";
            linea2 = linea2 + "IP Cliente" + " [" + ipCliente + "] ";
            linea2 = linea2 + "Usuario" + " [" + usuario + "] ";
            linea2 = linea2 + "Módulo" + " [" + modulo + "] ";
            linea2 = linea2 + "Página" + " [" + paginaCliente + "] ";
            linea2 = linea2 + "Descripción" + " [" + descripcion + "] ";

            return linea1 + Environment.NewLine + linea2;
        }

        /// <summary>
        /// Graba el Log Aplicativo
        /// </summary>
        /// <param name="Log"></param>
        public static void GrabarLogAplicativoArchivo(LogAplicativo Log)
        {
            ManejoLog.GrabarLog(Log, Enumerados.TipoLog.A.ToString());
        }


    }
}
