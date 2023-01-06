using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace DataAccessHandler
{
    public class DataAccessLayer
    {
        SqlConnection sqlConn;
        SqlCommand SqlCmd;
        SqlDataAdapter DatAdptr;
        SqlDataReader DtRdr;
        #region Openconnection Method
        public string OpenConnection()
        {
            if (sqlConn == null)
            {
                sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            }
            if (sqlConn.State == ConnectionState.Closed)
            {
                sqlConn.Open();
            }
            SqlCmd = new SqlCommand();
            SqlCmd.CommandTimeout = 120;
            SqlCmd.Connection = sqlConn;
            return ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        }
        #endregion
        #region CloseConnection and Dispose Connection Method
        public void CloseConnection()
        {
            if (sqlConn.State == ConnectionState.Open)
            {
                sqlConn.Close();
            }
            DisposeConnection();
        }
        #endregion
        #region DisposeConnection Method
        public void DisposeConnection()
        {
            if (sqlConn != null)
            {
                sqlConn.Dispose();
                sqlConn = null;
            }
        }
        #endregion
        #region GetDataTable Method

        public DataTable GetDataTable(string strsql)
        {
            OpenConnection();
            DatAdptr = new SqlDataAdapter(strsql, sqlConn);
            DataTable dtTble = new DataTable();
            DatAdptr.Fill(dtTble);
            DatAdptr.Dispose();
            CloseConnection();
            return dtTble;
        }

        #endregion
        #region GetDataSet Method

        public DataSet GetDataSet(string strsql)
        {
            OpenConnection();
            DatAdptr = new SqlDataAdapter(strsql, sqlConn);
            DataSet dtSet = new DataSet();
            DatAdptr.Fill(dtSet);
            DatAdptr.Dispose();
            CloseConnection();
            return dtSet;
        }

        #endregion
        #region GetDataSet using Stored Procedure Method

        public DataSet GetDataSetExecuteProcedure(string ProcName, SqlParameter[] SqlParams)
        {
            OpenConnection();
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = ProcName;
            SqlCmd.Parameters.Clear();
            foreach (SqlParameter thisParam in SqlParams)
            {
                SqlCmd.Parameters.Add((SqlParameter)thisParam);
            }
            DataSet ds = new DataSet();
            SqlDataAdapter sd = new SqlDataAdapter();
            sd.SelectCommand = SqlCmd;
            sd.Fill(ds);
            CloseConnection();
            return ds;
        }

        #endregion
        #region Execute Sclare with Proc
        public string ExecuteScalarWithProc(string ProcName, SqlParameter[] SqlParams)
        {
            OpenConnection();
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = ProcName;
            SqlCmd.Parameters.Clear();
            foreach (SqlParameter thisParam in SqlParams)
            {
                SqlCmd.Parameters.Add((SqlParameter)thisParam);
            }
            String result;
            result = Convert.ToString(SqlCmd.ExecuteScalar());
            CloseConnection();
            DisposeConnection();
            return result;
        }

        #endregion
        #region  Execute Stored Procedure Return DataTable
        public DataTable ExecuteStoredProcedureDataTable(string ProcName, SqlParameter[] SqlParams)
        {
            OpenConnection();
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = ProcName;
            SqlCmd.Parameters.Clear();
            foreach (SqlParameter thisParam in SqlParams)
            {
                SqlCmd.Parameters.Add((SqlParameter)thisParam);
            }
            SqlDataAdapter sd = new SqlDataAdapter(SqlCmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            CloseConnection();
            return dt;
        }
        #endregion
        #region  Execute Stored Procedure Return DataSet
        public DataSet ExecuteStoredProcedureDataSet(string ProcName, SqlParameter[] SqlParams)
        {
            OpenConnection();
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = ProcName;
            SqlCmd.Parameters.Clear();
            foreach (SqlParameter thisParam in SqlParams)
            {
                SqlCmd.Parameters.Add((SqlParameter)thisParam);
            }
            SqlDataAdapter sd = new SqlDataAdapter(SqlCmd);
            DataSet ds = new DataSet();
            sd.Fill(ds);
            CloseConnection();
            return ds;
        }
        #endregion
        #region ExecuteScalar Method
        public string ExecuteScalar(string strsql)
        {
            OpenConnection();
            SqlCmd.CommandType = CommandType.Text;
            SqlCmd.CommandText = strsql;
            string strresult;
            strresult = Convert.ToString(SqlCmd.ExecuteScalar());
            CloseConnection();
            DisposeConnection();
            return strresult;
        }
        #endregion
        #region Execute Stored Procedure Return Integer
        public int ExecuteStoredProcedureRetnInt(string ProcName, SqlParameter[] SqlParams)
        {
            OpenConnection();
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = ProcName;
            SqlCmd.Parameters.Clear();
            foreach (SqlParameter thisParam in SqlParams)
            {
                SqlCmd.Parameters.Add((SqlParameter)thisParam);
            }
            SqlCmd.Parameters["@ReturnVal"].Direction = ParameterDirection.Output;
            SqlCmd.ExecuteNonQuery();
            int returnvalue = Convert.ToInt32(SqlCmd.Parameters["@ReturnVal"].Value.ToString());
            CloseConnection();
            return returnvalue;
        }
        public string ExecuteStoredProcedureRetnString(string ProcName, SqlParameter[] SqlParams)
        {
            OpenConnection();
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = ProcName;
            SqlCmd.Parameters.Clear();
            foreach (SqlParameter thisParam in SqlParams)
            {
                SqlCmd.Parameters.Add((SqlParameter)thisParam);
            }
            SqlCmd.Parameters["@ReturnVal"].Direction = ParameterDirection.Output;
            SqlCmd.ExecuteNonQuery();
            string returnvalue = SqlCmd.Parameters["@ReturnVal"].Value.ToString();
            CloseConnection();
            return returnvalue;
        }
        #endregion
        #region Execute Stored Procedure Return void
        public void ExecuteStoredProcedure(string ProcName, SqlParameter[] SqlParams)
        {
            OpenConnection();
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = ProcName;
            SqlCmd.Parameters.Clear();
            foreach (SqlParameter thisParam in SqlParams)
            {
                SqlCmd.Parameters.Add((SqlParameter)thisParam);
            }
            SqlCmd.ExecuteNonQuery();
            CloseConnection();
        }
        #endregion
        #region Execute Stored Procedure Return void
        public string ExecuteStoredProcedureString(string ProcName, SqlParameter[] SqlParams)
        {
            OpenConnection();
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = ProcName;
            SqlCmd.Parameters.Clear();
            foreach (SqlParameter thisParam in SqlParams)
            {
                SqlCmd.Parameters.Add((SqlParameter)thisParam);
            }
            //SqlCmd.ExecuteNonQuery();
             SqlCmd.Parameters["@ReturnVal"].Direction = ParameterDirection.Output;
            SqlCmd.ExecuteNonQuery();
            string returnvalue = SqlCmd.Parameters["@ReturnVal"].Value.ToString();
            CloseConnection();

            return returnvalue;
        }

        #endregion
    }
}

