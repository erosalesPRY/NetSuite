using EntidadNegocio;
using EntidadNegocio.GestionLogistica;
using Log;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario;

namespace AccesoDatos.Transaccional.GestionLogistica
{
    public class ProcesoSelecTAD : BaseAD, IMantenimientoTAD
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
            LogisticaBE oLogisticaBE = new LogisticaBE();
            //  LogisticaBE oLogisticaBE = (LogisticaBE)oBaseBE;

            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oLogisticaBE.ToString(true));
                string PackagName = "sp_inserta_proceso";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oLogisticaBE.UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                                 );




                MySql.Data.MySqlClient.MySqlParameter[] Param = new MySql.Data.MySqlClient.MySqlParameter[2];
                Param[0] = new MySql.Data.MySqlClient.MySqlParameter("v_codigo", MySqlDbType.VarChar);
                Param[0].Direction = ParameterDirection.Input;
                //Param[0].Value = oLogisticaBE.tdo_codigo;
                Param[0].Value = oBaseBE.IdCodigo;

                Param[1] = new MySql.Data.MySqlClient.MySqlParameter("v_proceso", MySqlDbType.VarChar);
                Param[1].Direction = ParameterDirection.Input;
                //Param[1].Value = oLogisticaBE.c_estado;
              //  Param[1].Value = oBaseBE.IdEstado2;



                int idResult = Convert.ToInt32(MySQL(MySQLVersion.oMySql).ExecuteNonQuery(true, PackagName, Param));


                //Graba en el Log Salida del Metodo
                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oLogisticaBE.UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , ""
                                                                                     , "Return ID:" + idResult
                                                                                     , Helper.MensajesSalirMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I)));





                return idResult;
            }

            catch (SqlException oracleException)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(oLogisticaBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return -1;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(oLogisticaBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return -1;
            }


        }

        public string Modifica(BaseBE oBaseBE)
        {
            throw new NotImplementedException();
        }
        
        public string ModificaInserta(BaseBE oBaseBE)
        {
            throw new NotImplementedException();
        }

        public int Modificar(BaseBE oBaseBE)
        {
            LogisticaBE oLogisticaBE = new LogisticaBE();
            //  LogisticaBE oLogisticaBE = (LogisticaBE)oBaseBE;

            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oLogisticaBE.ToString(true));
                string PackagName = "sp_actualiza_estado_doc";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oLogisticaBE.UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                                 );




                MySql.Data.MySqlClient.MySqlParameter[] Param = new MySql.Data.MySqlClient.MySqlParameter[2];
                Param[0] = new MySql.Data.MySqlClient.MySqlParameter("v_codigo", MySqlDbType.VarChar);
                Param[0].Direction = ParameterDirection.Input;
                //Param[0].Value = oLogisticaBE.tdo_codigo;
                Param[0].Value = oBaseBE.IdCodigo;

                Param[1] = new MySql.Data.MySqlClient.MySqlParameter("c_estado", MySqlDbType.VarChar);
                Param[1].Direction = ParameterDirection.Input;
                //Param[1].Value = oLogisticaBE.c_estado;
               // Param[1].Value = oBaseBE.IdEstado2;



                int idResult = Convert.ToInt32(MySQL(MySQLVersion.oMySql).ExecuteNonQuery( true,PackagName, Param));


                //Graba en el Log Salida del Metodo
                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oLogisticaBE.UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , ""
                                                                                     , "Return ID:" + idResult
                                                                                     , Helper.MensajesSalirMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I)));





                return idResult;
            }

            catch (SqlException oracleException)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(oLogisticaBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return -1;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(oLogisticaBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return -1;
            }


        }
        public int ModificarInsertar(BaseBE oBaseBE)
        {
            throw new NotImplementedException();
        }

    }
}
