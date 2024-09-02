using EntidadNegocio;
using Log;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario;
using System.Data.OleDb;

namespace AccesoDatos.NoTransaccional.GestionProduccion
{
    public class OtsValorizacionNTAD : BaseAD, IMantenimientoNTAD
    {
        public DataTable Buscar(string TextFind, string UserName)
        {
            throw new NotImplementedException();
        }

        public BaseBE Detalle(string Id1)
        {
            throw new NotImplementedException();
        }

        public BaseBE Detalle(string Id1, string UserName)
        {
            throw new NotImplementedException();
        }

        public BaseBE Detalle(string Id1, string Id2, string UserName)
        {
            throw new NotImplementedException();
        }

        public BaseBE Detalle(string Id1, string Id2, string Id3, string UserName)
        {
            throw new NotImplementedException();
        }

        public DataTable ListarTodos()
        {
            throw new NotImplementedException();
        }

        public DataTable ListarTodos(string Id1, string UserName)
        {
            return null;
        }

        public DataTable ListarTodos(int Centro, string CodigoDivision, string FechaIni, string FechaFin,int NOT, string UserName)
        {

            try
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, Centro.ToString(), UserName);
                string PackagName = "CONSULTA.Pkg_Produccion.SP_Lista_OTS_SE";

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , oInfoMetodoBE.VoidParams
                                                                                     , ""
                                                                                     , Helper.MensajesIngresarMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I))
                                                                 );

                System.Data.OleDb.OleDbParameter[] Param = new OleDbParameter[5];
                Param[0] = new System.Data.OleDb.OleDbParameter("N_CEO", OleDbType.Numeric);
                Param[0].Direction = ParameterDirection.Input;
                Param[0].Value = Centro;

                Param[1] = new System.Data.OleDb.OleDbParameter("V_CODDIV", OleDbType.VarChar);
                Param[1].Direction = ParameterDirection.Input;
                Param[1].Value = CodigoDivision;

                Param[2] = new System.Data.OleDb.OleDbParameter("D_FECHAINI", OleDbType.VarChar);
                Param[2].Direction = ParameterDirection.Input;
                Param[2].Value = FechaIni;

                Param[3] = new System.Data.OleDb.OleDbParameter("D_FECHAFIN", OleDbType.VarChar);
                Param[3].Direction = ParameterDirection.Input;
                Param[3].Value = FechaFin;

                Param[4] = new System.Data.OleDb.OleDbParameter("N_OT", OleDbType.Numeric);
                Param[4].Direction = ParameterDirection.Input;
                Param[4].Value = NOT;

             
                DataSet ds = Oracle(ORACLEVersion.UNISYS).ExecuteDataSet(true,PackagName, Param);
                

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

        public DataTable ListarTodos(string Id1, string Id2, string UserName)
        {
            throw new NotImplementedException();
        }

        public DataTable ListarTodos(string Id1, string Id2, string Id3, string UserName)
        {
            throw new NotImplementedException();
        }
    }
}
