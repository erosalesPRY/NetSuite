using EntidadNegocio;
using Log;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitario;
using EntidadNegocio.GestionProduccion; // referenciamos la entidad
using AccesoDatos.Estandar;

namespace AccesoDatos.Transaccional.GestionProduccion
{

    public class ActividadTAD : BaseAD, IMantenimientoTAD
    {
        // --- creamos su constructor ----
        /*
        private readonly IStandarProcedure _standarProcedure;
        public ActividadTAD(IStandarProcedure standarProcedure)
        {
            _standarProcedure = standarProcedure;
        }
        */
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
            ActividadBE oActividadBE = (ActividadBE)oBaseBE;
            int  iRpta;
            try
            {

                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(0).GetMethod().Name;

                InfoMetodoBE oInfoMetodoBE = (InfoMetodoBE)this.MetodoInfo(NombreMetodo, oActividadBE.ToString(true)); // pasamos toda la entidad  el metodo de control log
                string PackagName = "CONSULTA.Pkg_Produccion.SP_UPD_Descrip_ATV_OT"; // Procedimiento almacenado



                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oActividadBE.UserName
                                                                                , oInfoMetodoBE.FullName
                                                                                , NombreMetodo
                                                                                , PackagName
                                                                                , oInfoMetodoBE.VoidParams
                                                                                , ""
                                                                                , Helper.MensajesIngresarMetodo()
                                                                                , Convert.ToString(Enumerados.NivelesErrorLog.I)));


                // ----- transaccion a la BD empleando paramatros en diccionario ----
                /*
                  Dictionary<string, object> parameters = new Dictionary<string, object>();
*/

                OracleParameter[] oParam = new OracleParameter[9];
                oParam[0] = new OracleParameter("v_ambiente", OracleDbType.Varchar2);
                oParam[0].Direction = ParameterDirection.Input;
                oParam[0].Value = oActividadBE.ambiente;

                oParam[1] = new OracleParameter("n_cod_ot", OracleDbType.Int32);
                oParam[1].Direction = ParameterDirection.Input;
                oParam[1].Value = oActividadBE.CodigoOT;

                oParam[2] = new OracleParameter("v_cod_div", OracleDbType.Varchar2);
                oParam[2].Direction = ParameterDirection.Input;
                oParam[2].Value = oActividadBE.CodigoDiv;

                oParam[3] = new OracleParameter("V_COD_ATV", OracleDbType.Varchar2);
                oParam[3].Direction = ParameterDirection.Input;
                oParam[3].Value = oActividadBE.CodigoActiv;

                oParam[4] = new OracleParameter("N_NRO_CRV", OracleDbType.Int32);
                oParam[4].Direction = ParameterDirection.Input;
                oParam[4].Value = oActividadBE.NroCrv;

                oParam[5] = new OracleParameter("V_USR_REG", OracleDbType.Varchar2);
                oParam[5].Direction = ParameterDirection.Input;
                oParam[5].Value = oActividadBE.UserReg;

                oParam[6] = new OracleParameter("V_COD_TLL", OracleDbType.Varchar2);
                oParam[6].Direction = ParameterDirection.Input;
                oParam[6].Value = oActividadBE.CodigoTll;

                oParam[7] = new OracleParameter("V_DES_DET", OracleDbType.Varchar2);
                oParam[7].Direction = ParameterDirection.Input;
                oParam[7].Value = oActividadBE.DescripcionD;

                oParam[8] = new OracleParameter("N_result", OracleDbType.Int32);
                oParam[8].Direction = ParameterDirection.Output;
            



                object ID = Oracle(ORACLEVersion.oJDE).ExecuteNonQuery(true, PackagName, oParam);

                // el objeto anterior ID no esta retornando valor, asi que, tomaremos el parámetro de salida
                object IDe = oParam[8].Value ;

            
                //-----------------------------------------------------------------------------




                //Graba en el Log Salida del Metodo
                LogTransaccional.GrabarLogTransaccionalArchivo(new LogTransaccional(oActividadBE.UserName
                                                                                     , oInfoMetodoBE.FullName
                                                                                     , NombreMetodo
                                                                                     , PackagName
                                                                                     , ""
                                                                                     , "Return ID:" + IDe
                                                                                     , Helper.MensajesSalirMetodo()
                                                                                     , Convert.ToString(Enumerados.NivelesErrorLog.I)));

                                                   

                return Convert.ToString(IDe);
            }

            catch (SqlException oracleException)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(oActividadBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.Archivo.Prefijo.PREFIJOCODIGOERRORNTAD.ToString() + Helper.Cadena.CortarTextoDerecha(5, Utilitario.Constante.LogCtrl.CEROS + oracleException.Number.ToString()), "Código de Error:" + oracleException.Number.ToString() + Utilitario.Constante.Caracteres.SeperadorSimple + "Número de Línea:" + "1" + Utilitario.Constante.Caracteres.SeperadorSimple + oracleException.Message);
                return null;
            }
            catch (Exception exception)
            {
                LogTransaccional.LanzarSIMAExcepcionDominio(oActividadBE.UserName, this.GetType().Name, Utilitario.Enumerados.LogCtrl.OrigenError.AccesoDatos.ToString(), Utilitario.Constante.LogCtrl.CODIGOERRORGENERICONTAD.ToString(), exception.Message);
                return null;
            }
        }

        public string ModificaInserta(BaseBE oBaseBE)
        {
            throw new NotImplementedException();
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
