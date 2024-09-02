using Log;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Estandar;
using Utilitario;
using Oracle.DataAccess.Client;

namespace AccesoDatos.NoTransaccional.General
{
    public class InformacionGeneralNTAD : BaseAD
    {
        private readonly IStandarProcedure _standarProcedure;

        public InformacionGeneralNTAD()
        {

        }
        //public InformacionGeneralNTAD(IStandarProcedure standarProcedure)
        //{
        //    _standarProcedure = standarProcedure;
        //}

        public DataTable BuscarCentrosCosto(string NombreCC, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, NombreCC.ToString(), UserName);
                string PackagName = "CONSULTA.Pkg_General.SP_SP_ListaCC_xNombre"; // CONSULTA.PKG_LOGISTICA.SP_CENTROCOSTO

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                                 );



                    string packageName = "CONSULTA.Pkg_General.SP_SP_ListaCC_xNombre";
                    Dictionary<string, object> parameters = new Dictionary<string, object>();


                    OracleParameter[] oParam = new OracleParameter[2];
                    oParam[0] = new OracleParameter("NOMBRE_CC", OracleDbType.Varchar2);
                    oParam[0].Direction = ParameterDirection.Input;
                    oParam[0].Value = NombreCC;
                    oParam[1] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                    oParam[1].Direction = ParameterDirection.Output;


                    DataSet ds = Oracle(ORACLEVersion.oJDE).ExecuteDataSet(true, packageName, oParam);

                return ds.Tables[0]; 


                //OracleParameter[] oParam = new OracleParameter[2];
                //oParam[0] = new OracleParameter("NOMBRE_CC", OracleDbType.Varchar2);
                //oParam[0].Direction = ParameterDirection.Input;
                //oParam[0].Value = NombreCC;
                //oParam[1] = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                //oParam[1].Direction = ParameterDirection.Output;


                //DataSet ds = Oracle(ORACLEVersion.oJDE).ExecuteDataSet(true, PackagName, oParam);
                ////DataSet ds = Sql(SQLVersion.sqlSIMANET).ExecuteDataSet(PackagName, TextFind);

                //Graba en el Log Salida del Metodo
                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , ""
                                                                                     , "rstCount:" /*ds.Tables[0].Rows.Count.ToString()*/
                                                                                     , Helper.MensajesSalirMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I)));





                //return ds.Tables[0];
            }

            catch (SqlException oracleException)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return null;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return null;
            }
        }

        public DataTable ListarCentroOperativoPorPerfil(string IdUsuario, string UserName)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, IdUsuario.ToString(), UserName);
                string PackagName = "GENuspNTADListarCentroOperativoAccesoUsuario";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                                 );

                DataSet ds = Sql(SQLVersion.sqlSIMANET).ExecuteDataSet(PackagName, IdUsuario);


                //Graba en el Log Salida del Metodo
                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , ""
                                                                                     , "rstCount:" + ds.Tables[0].Rows.Count.ToString()
                                                                                     , Helper.MensajesSalirMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I)));





                return ds.Tables[0];
            }

            catch (SqlException oracleException)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return null;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return null;
            }
        }
    }
}
