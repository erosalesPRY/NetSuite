using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;

namespace AccesoDatos
{
    public class TestOracle : BaseAD
    {
        public void Prueba()
        {

            System.Data.OleDb.OleDbParameter[] Param = new OleDbParameter[6];
            Param[0] = new System.Data.OleDb.OleDbParameter("WCEN_OPE", OleDbType.Numeric);
            Param[0].Direction = ParameterDirection.Input;
            Param[0].Value = 1;

            Param[1] = new System.Data.OleDb.OleDbParameter("ANIO", OleDbType.Numeric);
            Param[1].Direction = ParameterDirection.Input;
            Param[1].Value = 2023;

            Param[2] = new System.Data.OleDb.OleDbParameter("CODBCO", OleDbType.VarChar);
            Param[2].Direction = ParameterDirection.Input;
            Param[2].Value = "11";

            Param[3] = new System.Data.OleDb.OleDbParameter("WCTA_CTE", OleDbType.Numeric);
            Param[3].Direction = ParameterDirection.Input;
            Param[3].Value = 600100003516;

            Param[4] = new System.Data.OleDb.OleDbParameter("WMONEDA", OleDbType.VarChar);
            Param[4].Direction = ParameterDirection.Input;
            Param[4].Value = "S";

            Param[5] = new System.Data.OleDb.OleDbParameter("WIMP", OleDbType.Numeric);
            Param[5].Direction = ParameterDirection.InputOutput;
            Param[5].Value = 0;

            DataSet ds1 = Oracle(ORACLEVersion.UNISYS).ExecuteDataSet(true, "BANCO.Bc_Cheque_Emite_Relacion_Pkg.RELACION_CHEQUE_GIRADOS", Param);

        }

        public DataTable Prueba2()
        {
            String strConnString, strStored;

            /*  PROPOSITO: Conectar al oracle
             *  ORIGEN: https://stackoverflow.com/questions/10786782/ora-12514-tnslistener-does-not-currently-know-of-service-requested-in-connect-d
             */

            strStored = "RPT_TEST_UNIX_PKG.Listar";

            OracleParameter[] oParam = new OracleParameter[2];
            oParam[0] = new OracleParameter("CODCEO", OracleDbType.Int32);
            oParam[0].Direction = ParameterDirection.Input;
            oParam[0].Value = 1;
            oParam[1] = new OracleParameter("RELACION", OracleDbType.RefCursor);
            oParam[1].Direction = ParameterDirection.Output;


            DataSet ds = Oracle(ORACLEVersion.oJDE).ExecuteDataSet(true, strStored, oParam);

            return ds.Tables[0];


            /*
           OracleConnection objConn = new OracleConnection();
            OracleCommand objCmd = new OracleCommand();
            OracleDataAdapter dtAdapter = new OracleDataAdapter();
             ds = new DataSet();
            DataTable dt;
            
            //Para esta cadena de conexion tomar como referencia el archivo TNSNAME.ORA cuya ubicacion esta referenciada y definida en el regedit  CUYO TAG ES: ORACLE_HOME  
            strConnString = "Data Source=UNISYS_PROD;User Id=U001;Password=U001;Min Pool Size=10;Connection Lifetime=120;Connection Timeout=60;Incr Pool Size=5;Decr Pool Size=2;";
            //Para esta cadena de conexion no se necesita tener referencia de TSNAME.ORA  esta version ODP.NET 12.2 es compatible con las BD 10g hacia adelante 
            strConnString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=10.10.90.25)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=o7PROD)));User Id=PLA01;Password=PLA01;";
            strConnString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=10.10.90.138)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=simamask)));User Id=INTEGRACION_JDE;Password=INTEGRACION_JDE;";
            
            strConnString = "Data Source=JDE_PROD;User Id=INTEGRACION_JDE;Password=INTEGRACION_JDE;Min Pool Size=10;Connection Lifetime=120;Connection Timeout=60;Incr Pool Size=5;Decr Pool Size=2;";

            objConn.ConnectionString = strConnString;

            objConn.Open();

           strStored = "BANCO.Bc_Cheque_Emite_Relacion_Pkg.RELACION_CHEQUE_GIRADOS";
           


            objCmd.Parameters.Add(new OracleParameter("WCEN_OPE", OracleDbType.Int32)).Value = 1;
            objCmd.Parameters.Add(new OracleParameter("ANIO", OracleDbType.Int32)).Value = 2023;
            objCmd.Parameters.Add(new OracleParameter("CODBCO", OracleDbType.Varchar2)).Value = "11";
            objCmd.Parameters.Add(new OracleParameter("WCTA_CTE", OracleDbType.Int64)).Value = 600100003516;
            objCmd.Parameters.Add(new OracleParameter("WMONEDA", OracleDbType.Varchar2)).Value = "S";
            objCmd.Parameters.Add(new OracleParameter("WIMP", OracleDbType.Int32)).Value = 0;
            objCmd.Parameters.Add(new OracleParameter("RELACION", OracleDbType.RefCursor)).Direction = ParameterDirection.Output; // OUT



            objCmd.Connection = objConn;
            objCmd.CommandText = strStored;
            objCmd.CommandType = CommandType.StoredProcedure;
            dtAdapter.SelectCommand = objCmd;
            dtAdapter.Fill(ds);

            objConn.Close();
            objConn = null;

            */
        }
        public DataTable Listar(string Criterio)
        {
            String strConnString, strStored;

            /*  PROPOSITO: Conectar al oracle
             *  ORIGEN: https://stackoverflow.com/questions/10786782/ora-12514-tnslistener-does-not-currently-know-of-service-requested-in-connect-d
             */

            strStored = "PKG_SIMA_PRODUCCION_NTAD.BuscarProyectos";

            OracleParameter[] oParam = new OracleParameter[3];
            oParam[0] = new OracleParameter("TypeFind", OracleDbType.Int32);
            oParam[0].Direction = ParameterDirection.Input;
            oParam[0].Value = 1;
            oParam[1] = new OracleParameter("CriterioProy", OracleDbType.Varchar2);
            oParam[1].Direction = ParameterDirection.Input;
            oParam[1].Value = Criterio;
            oParam[2] = new OracleParameter("RELACION", OracleDbType.RefCursor);
            oParam[2].Direction = ParameterDirection.Output;


            DataSet ds = Oracle(ORACLEVersion.oJDE).ExecuteDataSet(true, strStored, oParam);

            return ds.Tables[0];

        }

    }
}
