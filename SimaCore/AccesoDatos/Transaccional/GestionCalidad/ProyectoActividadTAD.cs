﻿using EntidadNegocio;
using EntidadNegocio.GestionCalidad;
using Log;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario;

namespace AccesoDatos.Transaccional.GestionCalidad
{
    public class ProyectoActividadTAD : BaseAD, IMantenimientoTAD
    {
        public int Eliminar()
        {
            throw new NotImplementedException();
        }

        public int Eliminar(string Id1)
        {
            throw new NotImplementedException();
        }

        public int Eliminar(string Id1, string Id2)
        {
            throw new NotImplementedException();
        }

        public int Eliminar(string Id1, string Id2, string Id3)
        {
            throw new NotImplementedException();
        }

        public string Inserta(BaseBE oBaseBE)
        {
            throw new NotImplementedException();
        }

        public int Insertar(BaseBE oBaseBE)
        {
            throw new NotImplementedException();
        }

        public string Modifica(BaseBE oBaseBE)
        {
            throw new NotImplementedException();
        }

        public string ModificaInserta(BaseBE oBaseBE)
        {
            ProyectoActividadBE oProyectoActividadBE = (ProyectoActividadBE)oBaseBE;
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oProyectoActividadBE.ToString(true));
                string PackagName = "CALIDAD.CalUspTADInsActividad";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oProyectoActividadBE.UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                                 );
                object ID = Sql(SQLVersion.sqlSIMANET).ExecuteNonQuery(PackagName, oProyectoActividadBE.IdPryecto
                                                                                 , oProyectoActividadBE.NombreActividad
                                                                                  , oProyectoActividadBE.IdEstado
                                                                                 , oProyectoActividadBE.IdUsuario
                                                                               );


                //Graba en el Log Salida del Metodo
                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oProyectoActividadBE.UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , ""
                                                                                     , "Return ID:" + ID
                                                                                     , Helper.MensajesSalirMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I)));





                return ID.ToString();
            }

            catch (SqlException oracleException)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(oProyectoActividadBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return null;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(oProyectoActividadBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return null;
            }
        }

        public int Modificar(BaseBE oBaseBE)
        {
            throw new NotImplementedException();
        }

        public int ModificarInsertar(BaseBE oBaseBE)
        {
            throw new NotImplementedException();
        }
    }
}
