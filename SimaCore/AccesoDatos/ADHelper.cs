using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    class ADHelper
    {



        public struct Data
        {
            public static object[] ParamsValues(System.Data.OleDb.OleDbParameter[] Param)
            {
                object[] mParamsValues = new object[Param.Length];
                int i = 0;
                foreach (System.Data.OleDb.OleDbParameter mParam in Param)
                {
                    mParamsValues[i] = mParam.Value;
                    i++;
                }
                return mParamsValues;
            }

            public static OleDbParameter[] ConvertToOleDbParameter(OleDbParameterCollection paramCollection)
            {
                OleDbParameter[] paramArray = new OleDbParameter[paramCollection.Count];
                OleDbParameter param = new OleDbParameter();

                paramArray.Initialize();
                IEnumerator enumParams = paramCollection.GetEnumerator();

                for (int i = 0; i < paramCollection.Count; i++)
                {
                    enumParams.MoveNext();
                    param = (OleDbParameter)enumParams.Current;
                    paramArray[i] = param;
                }
                return paramArray;
            }

            public struct Oraclei
            {
                public static object[] ParamsValues(object[] Param)
                {
                    object[] mParamsValues = new object[Param.Length];
                    int i = 0;
                    if (Param.GetType() == typeof(Oracle.DataAccess.Client.OracleParameter))
                    {
                        foreach (Oracle.DataAccess.Client.OracleParameter mParam in Param)
                        {
                            if (mParam.DbType == DbType.String)
                            {
                                mParam.Value = mParam.Value.ToString().Replace("[s]", " ");
                            }
                            i++;
                        }
                    }
                    return Param;
                }
                public static object[] ParamsValues(Oracle.DataAccess.Client.OracleParameter[] Param)
                {
                    int i = 0;
                    foreach (Oracle.DataAccess.Client.OracleParameter mParam in Param)
                    {
                        if (mParam.DbType == DbType.String)
                        {
                            mParam.Value = mParam.Value.ToString().Replace("[s]", " ");
                        }
                        i++;
                    }
                    return Param;
                }

                public static Oracle.DataAccess.Client.OracleParameter[] ConvertToOracleParameter(Oracle.DataAccess.Client.OracleParameterCollection paramCollection)
                {
                    Oracle.DataAccess.Client.OracleParameter[] paramArray = new Oracle.DataAccess.Client.OracleParameter[paramCollection.Count];
                    Oracle.DataAccess.Client.OracleParameter param = new Oracle.DataAccess.Client.OracleParameter();

                    paramArray.Initialize();
                    IEnumerator enumParams = paramCollection.GetEnumerator();

                    for (int i = 0; i < paramCollection.Count; i++)
                    {
                        enumParams.MoveNext();
                        param = (Oracle.DataAccess.Client.OracleParameter)enumParams.Current;
                        paramArray[i] = param;
                    }
                    return paramArray;
                }

                public static System.Data.OracleClient.OracleParameter[] ConvertToMsOraclebParameter(System.Data.OracleClient.OracleParameterCollection paramCollection)
                {
                    System.Data.OracleClient.OracleParameter[] paramArray = new System.Data.OracleClient.OracleParameter[paramCollection.Count];
                    System.Data.OracleClient.OracleParameter param = new System.Data.OracleClient.OracleParameter();

                    paramArray.Initialize();
                    IEnumerator enumParams = paramCollection.GetEnumerator();

                    for (int i = 0; i < paramCollection.Count; i++)
                    {
                        enumParams.MoveNext();
                        param = (System.Data.OracleClient.OracleParameter)enumParams.Current;
                        paramArray[i] = param;
                    }
                    return paramArray;
                }
            }



        }



    }
}
