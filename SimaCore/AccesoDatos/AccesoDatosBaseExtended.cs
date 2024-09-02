using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using MySql.Data.MySqlClient;
using Oracle.DataAccess.Client;
using Log;
using static AccesoDatos.BaseAD;
using Utilitario;

namespace AccesoDatos
{
    public static class AccesoDatosBaseExtended
    {
        #region ExecuteDataSet
        public static DataSet ExecuteDataSet(this Microsoft.Practices.EnterpriseLibrary.Data.Database odbGeneral, bool Sup, string storeProcedureName, System.Data.OleDb.OleDbParameter[] Params)
        {
            DataSet ds = new DataSet();

            try
            {
                OleDbConnection cn = (System.Data.OleDb.OleDbConnection)odbGeneral.CreateConnection();
                cn.Open();

                OleDbCommand cmd = new OleDbCommand(storeProcedureName, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (System.Data.OleDb.OleDbParameter oParam in Params)
                {
                    cmd.Parameters.Add(oParam);
                }
                (new OleDbDataAdapter(cmd)).Fill(ds);
                cn.Close();
                cn.Dispose();

            }
            catch (Exception ex)
            {
                ds = odbGeneral.ExecuteDataSet(storeProcedureName, ADHelper.Data.ParamsValues(Params));
            }
            return ds;
        }
        public static DataSet ExecuteDataSet(this Microsoft.Practices.EnterpriseLibrary.Data.Database odbGeneral, bool Sup, string storeProcedureName)
        {
            try
            {
                DataSet ds = new DataSet();
                OleDbConnection cn = (System.Data.OleDb.OleDbConnection)odbGeneral.CreateConnection();
                cn.Open();
                OleDbCommand cmd = new OleDbCommand(storeProcedureName, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                (new OleDbDataAdapter(cmd)).Fill(ds);
                cn.Close();
                cn.Dispose();
                return ds;
            }
            catch (Exception ex)
            {
                return odbGeneral.ExecuteDataSet(CommandType.StoredProcedure, storeProcedureName);
            }
        }



        public static DataSet ExecuteDataSet(this Microsoft.Practices.EnterpriseLibrary.Data.Database odbGeneral, bool Sup, string storeProcedureName, Oracle.DataAccess.Client.OracleParameter[] Params)
        {
            try
            {
                DataSet ds = new DataSet();
                Oracle.DataAccess.Client.OracleConnection cn = (Oracle.DataAccess.Client.OracleConnection)odbGeneral.CreateConnection();
                cn.Open();
                Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(storeProcedureName, cn);
                cmd.CommandType = CommandType.StoredProcedure;

                foreach (Oracle.DataAccess.Client.OracleParameter oParam in Params)
                {
                    if (oParam.OracleDbType == OracleDbType.Varchar2)
                    {
                        oParam.Value = oParam.Value.ToString().Replace("[s]", " ");
                    }
                    cmd.Parameters.Add(oParam);
                }

                (new Oracle.DataAccess.Client.OracleDataAdapter(cmd)).Fill(ds);
                cn.Close();
                cn.Dispose();
                return ds;
            }
            catch (Exception ex)
            {
                return odbGeneral.ExecuteDataSet(CommandType.StoredProcedure, storeProcedureName);
            }
        }
        public static DataSet ExecuteDataSet(this Microsoft.Practices.EnterpriseLibrary.Data.Database odbGeneral, bool Sup, string storeProcedureName, System.Data.OracleClient.OracleParameter[] Params)
        {
            try
            {
                DataSet ds = new DataSet();
                System.Data.OracleClient.OracleConnection cn = (System.Data.OracleClient.OracleConnection)odbGeneral.CreateConnection();
                cn.Open();
                System.Data.OracleClient.OracleCommand cmd = new System.Data.OracleClient.OracleCommand(storeProcedureName, cn);
                cmd.CommandType = CommandType.StoredProcedure;

                foreach (System.Data.OracleClient.OracleParameter oParam in Params)
                {
                    if (oParam.OracleType == OracleType.VarChar)
                    {
                        oParam.Value = oParam.Value.ToString().Replace("[s]", " ");
                    }
                    cmd.Parameters.Add(oParam);
                }

                (new System.Data.OracleClient.OracleDataAdapter(cmd)).Fill(ds);
                cn.Close();
                cn.Dispose();
                return ds;
            }
            catch (Exception ex)
            {
                return odbGeneral.ExecuteDataSet(CommandType.StoredProcedure, storeProcedureName);
            }
        }


        public static DataSet ExecuteDataSet(this Microsoft.Practices.EnterpriseLibrary.Data.Database odbGeneral, bool Sup, string storeProcedureName, MySql.Data.MySqlClient.MySqlParameter[] Params)
        {
            try
            {
                DataSet ds = new DataSet();
                MySqlConnection cn = (MySqlConnection)odbGeneral.CreateConnection();
                cn.Open();

                MySqlCommand cmd = new MySqlCommand(storeProcedureName, cn);
                cmd.CommandType = CommandType.StoredProcedure;

                foreach (MySqlParameter oParam in Params)
                {
                    if (oParam.MySqlDbType == MySqlDbType.VarChar)
                    {
                        oParam.Value = oParam.Value.ToString().Replace("[s]", " ");
                    }
                    cmd.Parameters.Add(oParam);
                }

                (new MySqlDataAdapter(cmd)).Fill(ds);
                cn.Close();
                cn.Dispose();
                return ds;
            }
            catch (Exception ex)
            {
                return odbGeneral.ExecuteDataSet(CommandType.StoredProcedure, storeProcedureName);
            }
        }

        #endregion

        #region ExecuteScalar
        public static object ExecuteScalar(this Microsoft.Practices.EnterpriseLibrary.Data.Database odbGeneral, bool Sup, string storeProcedureName, System.Data.OleDb.OleDbParameter[] Params)
        {
            object IdPrc;
            try
            {
                OleDbConnection cn = (System.Data.OleDb.OleDbConnection)odbGeneral.CreateConnection();
                cn.Open();
                OleDbCommand cmd = new OleDbCommand(storeProcedureName, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (System.Data.OleDb.OleDbParameter oParam in Params)
                {
                    if (oParam.OleDbType == OleDbType.VarChar)
                    {
                        oParam.Value = oParam.Value.ToString().Replace("[s]", " ");
                    }
                    cmd.Parameters.Add(oParam);
                }
                IdPrc = cmd.ExecuteScalar();
                cn.Close();
                cn.Dispose();
                return IdPrc;
            }
            catch (Exception ex)
            {
                IdPrc = odbGeneral.ExecuteScalar(storeProcedureName);
                return IdPrc;
            }
        }
        public static object ExecuteScalar(this Microsoft.Practices.EnterpriseLibrary.Data.Database odbGeneral, bool Sup, string storeProcedureName, Oracle.DataAccess.Client.OracleParameter[] Params)
        {
            object IdPrc;
            try
            {
                Oracle.DataAccess.Client.OracleConnection cn = (Oracle.DataAccess.Client.OracleConnection)odbGeneral.CreateConnection();
                cn.Open();
                Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(storeProcedureName, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (Oracle.DataAccess.Client.OracleParameter oParam in Params)
                {
                    if (oParam.OracleDbType == OracleDbType.Varchar2)
                    {
                        if (oParam.Value != null)
                        {
                            oParam.Value = oParam.Value.ToString().Replace("[s]", " ");
                        }
                    }
                    cmd.Parameters.Add(oParam);
                }
                IdPrc = cmd.ExecuteScalar();
                cn.Close();
                cn.Dispose();
                return IdPrc;
            }
            catch (Exception ex)
            {

                IdPrc = odbGeneral.ExecuteScalar(storeProcedureName, ADHelper.Data.Oraclei.ParamsValues(Params));
                return IdPrc;
            }

        }
        #endregion

        #region ExecuteNonQuery

        public static object ExecuteNonQuery(this Microsoft.Practices.EnterpriseLibrary.Data.Database odbGeneral, bool Sup, string storeProcedureName, Oracle.DataAccess.Client.OracleParameter[] Params)
        {
            object IdPrc;
            try
            {
                Oracle.DataAccess.Client.OracleConnection cn = (Oracle.DataAccess.Client.OracleConnection)odbGeneral.CreateConnection();
                cn.Open();
                Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(storeProcedureName, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (Oracle.DataAccess.Client.OracleParameter oParam in Params)
                {
                    if (oParam.OracleDbType == OracleDbType.Varchar2)
                    {
                        if (oParam.Value != null)
                        {
                            oParam.Value = oParam.Value.ToString().Replace("[s]", " ");
                        }
                    }
                    cmd.Parameters.Add(oParam);
                }
                IdPrc = cmd.ExecuteNonQuery();
                cn.Close();
                cn.Dispose();
                return IdPrc;
            }
            catch (Exception ex)
            {

                IdPrc = odbGeneral.ExecuteScalar(storeProcedureName, ADHelper.Data.Oraclei.ParamsValues(Params));
                return IdPrc;
            }
        }

        public static object ExecuteNonQuery(this Microsoft.Practices.EnterpriseLibrary.Data.Database odbGeneral, bool Sup, string storeProcedureName, System.Data.OracleClient.OracleParameter[] Params)
        {
            object IdPrc;
            try
            {
                System.Data.OracleClient.OracleConnection cn = (System.Data.OracleClient.OracleConnection)odbGeneral.CreateConnection();

                cn.Open();
                System.Data.OracleClient.OracleCommand cmd = new System.Data.OracleClient.OracleCommand(storeProcedureName, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (System.Data.OracleClient.OracleParameter oParam in Params)
                {
                    if (oParam.OracleType == OracleType.VarChar)
                    {
                        oParam.Value = oParam.Value.ToString().Replace("[s]", " ");
                    }
                    cmd.Parameters.Add(oParam);
                }
                IdPrc = cmd.ExecuteNonQuery();
                cn.Close();
                cn.Dispose();
                return IdPrc;
            }
            catch (Exception ex)
            {

                IdPrc = odbGeneral.ExecuteScalar(storeProcedureName, ADHelper.Data.Oraclei.ParamsValues(Params));
                return IdPrc;
            }
        }


        public static object ExecuteNonQuery(this Microsoft.Practices.EnterpriseLibrary.Data.Database odbGeneral, bool Sup, string storeProcedureName, OleDbParameter[] Params)
        {
            object IdPrc;
            try
            {
                OleDbConnection cn = (System.Data.OleDb.OleDbConnection)odbGeneral.CreateConnection();
                cn.Open();
                OleDbCommand cmd = new OleDbCommand(storeProcedureName, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (System.Data.OleDb.OleDbParameter oParam in Params)
                {
                    if (oParam.OleDbType == OleDbType.VarChar)
                    {
                        oParam.Value = oParam.Value.ToString().Replace("[s]", " ");
                    }
                    cmd.Parameters.Add(oParam);
                }
                IdPrc = cmd.ExecuteNonQuery();
                cn.Close();
                cn.Dispose();
                return IdPrc;
            }
            catch (Exception ex)
            {

                IdPrc = odbGeneral.ExecuteScalar(storeProcedureName, ADHelper.Data.ParamsValues(Params));
                return IdPrc;
            }
        }
        public static object ExecuteNonQuery(this Microsoft.Practices.EnterpriseLibrary.Data.Database odbGeneral, bool Sup, string storeProcedureName, MySql.Data.MySqlClient.MySqlParameter[] Params)
        {
            object IdPrc;
            try
            {
                MySqlConnection cn = (MySqlConnection)odbGeneral.CreateConnection();
                cn.Open();

                MySqlCommand cmd = new MySqlCommand(storeProcedureName, cn);
                cmd.CommandType = CommandType.StoredProcedure;

                foreach (MySqlParameter oParam in Params)
                {
                    if (oParam.MySqlDbType == MySqlDbType.VarChar)
                    {
                        oParam.Value = oParam.Value.ToString().Replace("[s]", " ");
                    }
                    cmd.Parameters.Add(oParam);
                }
                IdPrc = cmd.ExecuteNonQuery();
                cn.Close();
                cn.Dispose();
                return IdPrc;
            }
            catch (Exception ex)
            {

                IdPrc = 0;// odbGeneral.ExecuteScalar(storeProcedureName, ADHelper.Data.ParamsValues(Params));
                return IdPrc;
            }
        }



        #endregion


    }
}
