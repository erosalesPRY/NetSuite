using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejadorExcepcion
{
    /// <summary>
	/// Summary description for ManejoExcepcion.
	/// </summary>
	public class ManejoExcepcion
    {
        public ManejoExcepcion()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        /// Obtiene el Mensaje de Usuario del Archivo de Mensajes en base al Codigo de Error
        /// </summary>
        /// <param name="codigoError">Codigo de Error</param>
        /// <returns></returns>
        private static string obtenerMensajeUsuario(string codigoError)
        {
            string mensajeErrorUsuario = Configuracion.Seccion.get(Configuracion.Seccion.Nombre.MensajesError.ToString(), codigoError);

            if (mensajeErrorUsuario == "")
            {
                mensajeErrorUsuario = getSeccionConfig(Configuracion.Seccion.Nombre.MensajesError.ToString(), Configuracion.Seccion.CodigoGenerico);
            }
            return mensajeErrorUsuario;
        }
        /// <summary>
        /// Crea una Excepcion del tipo SIMAExcepcion
        /// </summary>
        /// <param name="codigoError">Codigo de Error</param>
        /// <param name="errorTecnico">Descripcion del Error</param>
        /// <returns>SIMAExcepcion</returns>
        public static SIMAExcepcion CrearSIMAExcepcion(string codigoError, string errorTecnico)
        {
            return new SIMAExcepcion(errorTecnico, ManejoExcepcion.obtenerMensajeUsuario(codigoError));
        }

        /// <summary>
        /// Crea una Excepcion del tipo SIMAExcepcionLog
        /// </summary>
        /// <param name="codigoError">Codigo de Error</param>
        /// <param name="errorTecnico">Descripcion del Error</param>
        /// <returns>SIMAExcepcionLog</returns>
        public static SIMAExcepcionLog CrearSIMAExcepcionLog(string codigoError, string errorTecnico)
        {
            return new SIMAExcepcionLog(errorTecnico, ManejoExcepcion.obtenerMensajeUsuario(codigoError));
        }

        /// <summary>
        /// Crea una Excepcion del tipo SIMAExcepcionIU
        /// </summary>
        /// <param name="codigoError">Codigo de Error</param>
        /// <param name="errorTecnico">Descripcion del Error</param>
        /// <returns>SIMAExcepcionIU</returns>
        public static SIMAExcepcionIU CrearSIMAExcepcionIU(string codigoError, string errorTecnico)
        {
            return new SIMAExcepcionIU(errorTecnico, ManejoExcepcion.obtenerMensajeUsuario(codigoError));
        }

        /// <summary>
        /// Crea una Excepcion del tipo SIMAExcepcionDominio
        /// </summary>
        /// <param name="codigoError">Codigo de Error</param>
        /// <param name="errorTecnico">Descripcion del Error</param>
        /// <returns>SIMAExcepcionIU</returns>
        public static SIMAExcepcionDominio CrearSIMAExcepcionDominio(string codigoError, string errorTecnico)
        {
            return new SIMAExcepcionDominio(errorTecnico, ManejoExcepcion.obtenerMensajeUsuario(codigoError));
        }



        private static string getSeccionConfig(string Seccion, string Llave)
        {
            Hashtable configData;
            string valor = "";

            try
            {
                configData = (Hashtable)ConfigurationManager.GetSection(Seccion);
                if (configData != null)
                {
                    valor = Convert.ToString(configData[Llave]);

                }
                return valor;
            }
            catch (Exception e)
            {
                string a = e.Message;
                return "";
            }

        }

        public struct Configuracion
        {
            public struct Seccion
            {

                public static string get(string Seccion, string Llave)
                {
                    Hashtable configData;
                    string valor = "";

                    try
                    {
                        configData = (Hashtable)ConfigurationManager.GetSection(Seccion);
                        if (configData != null)
                        {
                            valor = Convert.ToString(configData[Llave]);

                        }
                        return valor;
                    }
                    catch (Exception e)
                    {
                        string a = e.Message;
                        return "";
                    }

                }
                public enum Nombre
                {
                    MensajesError,
                }
                public const string CodigoGenerico = "00000";
            }
        }

    }
}
