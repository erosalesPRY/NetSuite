using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManejadorExcepcion;
using Utilitario;

namespace Log
{
    /// <summary>
	/// Summary description for LogTransaccional.
	/// </summary>
	/// 

    public class LogTransaccional : LogBE
    {
        public LogTransaccional()
        {
        }

        private string resultado;
        private string detalle;
        private string procedimientoAlmacenado;
        private string parametros;


        /// <summary>
        /// Constructor empleado para inicializar los Datos del Log Transaccional
        /// </summary>
        /// <param name="Usuario"></param>
        /// <param name="Modulo"></param>
        /// <param name="Descripcion"></param>
        /// <param name="ProcedimientoAlmacenado"></param>
        /// <param name="Parametros"></param>
        /// <param name="Resultado"></param>
        /// <param name="Detalle"></param>
        /// <param name="NivelLog"></param>
        public LogTransaccional(string Usuario, string Modulo, string Descripcion, string ProcedimientoAlmacenado, string Parametros, string Resultado, string Detalle, string NivelLog)
        {
            usuario = Usuario;
            modulo = Modulo;
            descripcion = Descripcion;
            procedimientoAlmacenado = ProcedimientoAlmacenado;
            parametros = Parametros;
            resultado = Resultado;
            detalle = Detalle;
            nivel = NivelLog;
        }

        public override string ToString()
        {
            //Linea 1
            string linea1 = DateTime.Now.ToString(Constante.Formato.Fecha.ddddMMMdd) + " " + DateTime.Now.ToString(Constante.Formato.Hora.Estandar) + " " + DateTime.Now.ToString(Constante.Formato.Fecha.AÑO) + ": [" + nivel.Trim() + "]";

            string linea2 = "===> ";
            linea2 = linea2 + "Versión [01.00.00] ";
            linea2 = linea2 + "Usuario" + " [" + usuario + "] ";
            linea2 = linea2 + "Módulo" + " [" + modulo + "] ";
            linea2 = linea2 + "Descripción" + " [" + descripcion + "] ";
            linea2 = linea2 + "Procedimiento Almacenado" + " [" + procedimientoAlmacenado + "] ";
            linea2 = linea2 + "Parametros" + " [" + parametros + "] ";
            linea2 = linea2 + "Resultado" + " [" + resultado.ToString().Trim() + "] ";
            linea2 = linea2 + "Detalle" + " [" + detalle + "] ";

            return linea1 + Environment.NewLine + linea2;
        }


        /// <summary>
        /// Crea una Excepcion del Tipo SIMAExcepcionDominio y guarda en el Log la informacion del error
        /// </summary>
        /// <param name="user"></param>
        /// <param name="modulo"></param>
        /// <param name="origen"></param>
        /// <param name="codError"></param>
        /// <param name="excepcion"></param>
        public static void LanzarSIMAExcepcionDominio(string user, string modulo, string origen, string codError, string excepcion)
        {
            //Grabar en Log
            LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(user, modulo, "Error - Origen: [" + origen + "]", "", "", codError, excepcion, Convert.ToString(Utilitario.Enumerados.NivelesErrorLog.E)));
            throw ManejoExcepcion.CrearSIMAExcepcionDominio(codError, excepcion);
        }


        /// <summary>
        /// Crea una Excepcion del Tipo SIMAExcepcionIU y guarda en el Log la informacion del error
        /// </summary>
        /// <param name="user"></param>
        /// <param name="modulo"></param>
        /// <param name="origen"></param>
        /// <param name="codError"></param>
        /// <param name="excepcion"></param>
        /// <returns></returns>
        public static SIMAExcepcionIU LanzarSIMAExcepcionIU(string user, string modulo, string origen, string codError, string excepcion)
        {
            LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(user, modulo, "Error - Origen: [" + origen + "]", "", "", codError, excepcion, Convert.ToString(Utilitario.Enumerados.NivelesErrorLog.E)));
            throw ManejoExcepcion.CrearSIMAExcepcionIU(codError, excepcion);
        }

        public static SIMAExcepcionIU CrearSIMAExcepcionIU(string user, string modulo, string origen, string codError, string excepcion)
        {
            LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(user, modulo, "Error - Origen: [" + origen + "]", "", "", codError, excepcion, Convert.ToString(Utilitario.Enumerados.NivelesErrorLog.E)));
            return ManejoExcepcion.CrearSIMAExcepcionIU(codError, excepcion);
        }



        /// <summary>
        /// Crea una Excepcion del Tipo SIMAExcepcionLog y guarda en el Log la informacion del error
        /// </summary>
        /// <param name="user"></param>
        /// <param name="modulo"></param>
        /// <param name="origen"></param>
        /// <param name="codError"></param>
        /// <param name="excepcion"></param>
        public static void LanzarSIMAExcepcionLog(string user, string modulo, string origen, string codError, string excepcion)
        {
            LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(user, modulo, "Error - Origen: [" + origen + "]", "", "", codError, excepcion, Convert.ToString(Utilitario.Enumerados.NivelesErrorLog.E)));
            throw ManejoExcepcion.CrearSIMAExcepcionLog(codError, excepcion);
        }


        /// <summary>
        /// Graba el Log Transaccional
        /// </summary>
        /// <param name="Log"></param>
        public static void GrabarLogTransaccionalArchivo(LogTransaccional Log)
        {
            ManejoLog.GrabarLog(Log, Enumerados.TipoLog.T.ToString());
        }
        public static void GrabarLogErrorArchivo(LogErrorBE Log)
        {
            ManejoLog.GrabarLogError(Log);
        }

    }
}
