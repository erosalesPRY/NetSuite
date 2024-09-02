using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario;

namespace Log
{
    public class LogErrorBE : LogBE
    {
        public string exceptionName { get; set; }
        LogErrorBE()
        {
        }
        public override string ToString()
        {
            //Linea 1
            string linea1 = DateTime.Now.ToString(Constante.Formato.Fecha.ddddMMMdd) + " " + DateTime.Now.ToString(Constante.Formato.Hora.Estandar) + " " + DateTime.Now.ToString(Constante.Formato.Fecha.AÑO);

            string linea2 = "===> ";
            linea2 = linea2 + "Versión [01.00.00] ";
            linea2 = linea2 + "Usuario" + " [" + usuario + "] ";
            linea2 = linea2 + "Módulo" + " [" + modulo + "] ";
            linea2 = linea2 + "TipoExcep" + " [" + this.exceptionName + "] ";
            linea2 = linea2 + "Descripción" + " [" + descripcion + "] ";
            return linea1 + Environment.NewLine + linea2;
        }
        public LogErrorBE(string Usuario, string Modulo, string ExceptionName, string Descripcion)
        {
            this.usuario = Usuario;
            this.modulo = Modulo;
            this.descripcion = Descripcion;
            this.exceptionName = ExceptionName;
        }

    }
}
