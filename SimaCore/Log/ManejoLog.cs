using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManejadorExcepcion;
using Utilitario;

namespace Log
{
    /// <summary>
	/// Summary description for ManejoLog.
	/// </summary>
    public class ManejoLog : LogBE
    {
        private static string FechaLog;
        private static string FechaLogError;
        private static string ListenerTransaccional;
        private static string ListenerAplicativo;
        private static TextWriterTraceListener FileListenerTransaccional;
        private static TextWriterTraceListener FileListenerAplicativo;

        private static TextWriterTraceListener FileListenerErrorAplicativo;
        private static string ListenerAplicativoError;

        private static String DirectorioLog;

        private struct LogFile
        {
            private const string SeccionConfig = "LogSeccion";
            private const string FlagEstado = "LogEncendido";
            public static bool VerificaEstadoGrabarLog
            {
                get
                {
                    return (Convert.ToBoolean(((Hashtable)ConfigurationManager.GetSection(LogFile.SeccionConfig))[LogFile.FlagEstado].ToString()));
                }
            }

        }



        public ManejoLog()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        private static void VerificaFechaLog()
        {
            string FechaAct = DateTime.Now.Date.ToString(Utilitario.Constante.Formato.Fecha.yyyyMMdd);
            if (FechaLog != FechaAct)
            {
                CierraLogs();
                AbreLogs();
            }
        }

        private static void VerificaFechaLogError()
        {
            string FechaAct = DateTime.Now.Date.ToString(Utilitario.Constante.Formato.Fecha.yyyyMMdd);
            if (FechaLogError != FechaAct)
            {
                CierraLogsError();
                AbreLogsError();
            }
        }

        public static void AbreLogs()
        {

            if (LogFile.VerificaEstadoGrabarLog)
            {
                try
                {
                    DirectorioLog = LogTransaccional.RutaLog;
                    FechaLog = DateTime.Now.Date.ToString(Utilitario.Constante.Formato.Fecha.yyyyMMdd);
                    ListenerTransaccional = Utilitario.Constante.Archivo.Prefijo.LOGTRANSACCIONAL + FechaLog;
                    ListenerAplicativo = Utilitario.Constante.Archivo.Prefijo.LOGAPLICATIVO + FechaLog;

                    FileListenerTransaccional = new TextWriterTraceListener(DirectorioLog + ListenerTransaccional + Utilitario.Constante.Archivo.Extension.TXT, ListenerTransaccional);
                    FileListenerAplicativo = new TextWriterTraceListener(DirectorioLog + ListenerAplicativo + Utilitario.Constante.Archivo.Extension.TXT, ListenerAplicativo);
                    System.Diagnostics.Trace.Listeners.Add(FileListenerTransaccional);
                    System.Diagnostics.Trace.Listeners.Add(FileListenerAplicativo);
                }
                catch (Exception exception)
                {
                    throw ManejoExcepcion.CrearSIMAExcepcionLog(Utilitario.Constante.Archivo.Prefijo.CODIGOERRORLOG, exception.Message);
                }
            }
        }

        public static void CierraLogs()
        {
            if (LogFile.VerificaEstadoGrabarLog)
            {
                try
                {
                    System.Diagnostics.Trace.Listeners.Remove(FileListenerTransaccional);
                    System.Diagnostics.Trace.Listeners.Remove(FileListenerAplicativo);
                    if (FileListenerTransaccional != null)
                        FileListenerTransaccional.Close();
                    if (FileListenerAplicativo != null)
                        FileListenerAplicativo.Close();
                }
                catch { }
            }
        }







        public static void AbreLogsError()
        {

            if (LogFile.VerificaEstadoGrabarLog)
            {
                try
                {
                    DirectorioLog = LogTransaccional.RutaLog;
                    FechaLogError = DateTime.Now.Date.ToString(Utilitario.Constante.Formato.Fecha.yyyyMMdd);
                    ListenerAplicativoError = Utilitario.Constante.Archivo.Prefijo.LOGAPLICATIVOERROR + FechaLogError;
                    FileListenerErrorAplicativo = new TextWriterTraceListener(DirectorioLog + ListenerAplicativoError + Utilitario.Constante.Archivo.Extension.TXT, ListenerAplicativoError);
                    System.Diagnostics.Trace.Listeners.Add(FileListenerErrorAplicativo);
                }
                catch (Exception exception)
                {
                    throw ManejoExcepcion.CrearSIMAExcepcionLog(Utilitario.Constante.Archivo.Prefijo.CODIGOERRORLOG, exception.Message);
                }
            }
        }

        public static void CierraLogsError()
        {
            if (LogFile.VerificaEstadoGrabarLog)
            {
                try
                {
                    System.Diagnostics.Trace.Listeners.Remove(FileListenerErrorAplicativo);
                    if (FileListenerErrorAplicativo != null)
                        FileListenerErrorAplicativo.Close();
                }
                catch { }
            }
        }



        public static void GrabarLog(Object MensajeLog, string TipoLog)
        {
            if (LogFile.VerificaEstadoGrabarLog)
            {
                try
                {
                    VerificaFechaLog();

                    Enumerados.TipoLog tipoLog = (Enumerados.TipoLog)Enum.Parse(typeof(Enumerados.TipoLog), TipoLog);
                    switch (tipoLog)
                    {
                        case Enumerados.TipoLog.A:
                            Trace.Listeners[ListenerAplicativo].WriteLine(MensajeLog);
                            break;
                        case Enumerados.TipoLog.T:
                            Trace.Listeners[ListenerTransaccional].WriteLine(MensajeLog);
                            break;
                    }
                    Trace.Flush();
                }
                catch (Exception exception)
                {
                    throw ManejoExcepcion.CrearSIMAExcepcionLog(Utilitario.Constante.Archivo.Prefijo.CODIGOERRORLOG + "00001", exception.Message);
                }
            }
        }

        public static void GrabarLogError(Object MensajeLog)
        {
            if (LogFile.VerificaEstadoGrabarLog)
            {
                try
                {
                    VerificaFechaLogError();
                    Trace.Listeners[ListenerAplicativoError].WriteLine(MensajeLog.ToString());
                    Trace.Flush();
                }
                catch (Exception exception)
                {
                    throw ManejoExcepcion.CrearSIMAExcepcionLog(Utilitario.Constante.Archivo.Prefijo.CODIGOERRORLOG + "00001", exception.Message);
                }
            }
        }

    }
}
