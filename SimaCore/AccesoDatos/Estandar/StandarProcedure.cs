using Log;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AccesoDatos.BaseAD;
using Utilitario;

namespace AccesoDatos.Estandar
{
    public class StandarProcedure : IStandarProcedure
    {
        public DataTable EjecutarProcedimiento(string packageName, Dictionary<string, object> parameters)
        {
            try
            {
                StackTrace stack = new StackTrace();
                string methodName = stack.GetFrame(0).GetMethod().Name;

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(
                    parameters.ContainsKey("UserName") ? parameters["UserName"].ToString() : "",
                    methodName,
                    packageName,
                    "",
                    "",
                    "",
                    Helper.MensajesIngresarMetodo(),
                    Convert.ToString(Enumerados.NivelesErrorLog.I)
                ));

                List<OracleParameter> oParamList = new List<OracleParameter>();

                foreach (var param in parameters)
                {
                    Debug.WriteLine($"Nombre del parámetro: {param.Key}, Valor: {param.Value}");

                    if (param.Key != "UserName")
                    {
                        OracleParameter oracleParam = new OracleParameter(param.Key, OracleDbType.Varchar2);
                        oracleParam.Direction = ParameterDirection.Input;
                        oracleParam.Value = param.Value;
                        oParamList.Add(oracleParam);
                    }
                }

                OracleParameter cRegistrosParam = new OracleParameter("cRegistros", OracleDbType.RefCursor);
                cRegistrosParam.Direction = ParameterDirection.Output;
                oParamList.Add(cRegistrosParam);

                OracleParameter[] oParam = oParamList.ToArray();


                DataSet ds = BaseAD.Oracle(ORACLEVersion.oJDE).ExecuteDataSet(true, packageName, oParam);

                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(
                    parameters.ContainsKey("UserName") ? parameters["UserName"].ToString() : "",
                    methodName,
                    packageName,
                    "",
                    "",
                    "rstCount:" + ds.Tables[0].Rows.Count.ToString(),
                    Helper.MensajesSalirMetodo(),
                    Convert.ToString(Enumerados.NivelesErrorLog.I)
                ));

                return ds.Tables[0];
            }
            catch (SqlException oracleException)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(parameters.ContainsKey("UserName") ? parameters["UserName"].ToString() : "", this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return null;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(parameters.ContainsKey("UserName") ? parameters["UserName"].ToString() : "", this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return null;
            }
        }
    }
}
