using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Oracle.DataAccess.Client;
using Business.Common;

namespace DAL
{
    public class DataServiceBase
    {
        public DataServiceBase()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        

        #region Make Connection and maintain transaction
        private bool _isOwner = true;
        //True if service owns the transaction        
        private OracleTransaction _txn;
        //public DataServiceBase() : this(null) { }
        public DataServiceBase(IDbTransaction txn)
        {
            if (txn == null)
            {
                _isOwner = true;
            }
            else
            {
                _txn = (OracleTransaction)txn;
                _isOwner = false;
            }
        }

        public static IDbTransaction BeginTransaction()
        {
            OracleConnection txnConnection =
                new OracleConnection(GetConnectionString());
            txnConnection.Open();
            return txnConnection.BeginTransaction();
        }

        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["RBSConnectionString"].ConnectionString;
        }

        private class State
        {
            public OracleCommand Cmd = null;
            public OracleConnection Cnx = null;
            public string TableName = string.Empty;
        }
        #endregion

        #region Stored Procedure Execution
        protected DataSet ExecuteDataSetProcedure(string Procedure, string tableName,
          params IDataParameter[] sqlParams)
        {
            OracleCommand cmd;
            return ExecuteDataSetProcedure(out cmd, Procedure, tableName, sqlParams);
        }

        protected DataSet ExecuteDataSetProcedure(out OracleCommand cmd, string Procedure, string tableName,
            params IDataParameter[] sqlParams)
        {
            OracleConnection cnx = null;
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            cmd = null;

            try
            {
                //Setup command object
                cmd = new OracleCommand(Procedure);
                cmd.CommandType = CommandType.StoredProcedure;
                if (sqlParams != null)
                {
                    for (int index = 0; index < sqlParams.Length; index++)
                    {
                        cmd.Parameters.Add(sqlParams[index]);
                    }
                }
                da.SelectCommand = (OracleCommand)cmd;

                //Determine the transaction owner and process accordingly
                if (_isOwner)
                {
                    cnx = new OracleConnection(GetConnectionString());
                    cmd.Connection = cnx;
                    cnx.Open();
                }
                else
                {
                    cmd.Connection = _txn.Connection;
                    cmd.Transaction = _txn;
                }
                //Fill the dataset
                if (!string.IsNullOrEmpty(tableName))
                    da.Fill(ds, tableName);
                else
                    da.Fill(ds);
            }
            catch
            {
                throw;
            }
            finally
            {
                if (da != null) da.Dispose();
                if (cmd != null) cmd.Dispose();
                if (_isOwner)
                {
                    cnx.Dispose(); //Implicitly calls cnx.Close()
                }
            }
            return ds;
        }


        protected void ExecuteNonQueryProcedure(string Procedure, params IDataParameter[] procParams)
        {
            OracleCommand cmd;
            ExecuteNonQueryProcedure(out cmd, Procedure, procParams);
        }

        protected void ExecuteNonQueryProcedure(out OracleCommand cmd, string Procedure, params IDataParameter[] procParams)
        {
            //Method variables
            OracleConnection cnx = null;
            cmd = null;  //Avoids "Use of unassigned variable" compiler error
            try
            {
                //Setup command object
                cmd = new OracleCommand(Procedure);
                cmd.CommandType = CommandType.StoredProcedure;
                if (procParams != null)
                {
                    for (int index = 0; index < procParams.Length; index++)
                    {
                        if (procParams[index] != null)
                            cmd.Parameters.Add(procParams[index]);
                    }
                }
                //Determine the transaction owner and process accordingly
                if (_isOwner)
                {
                    cnx = new OracleConnection(GetConnectionString());
                    cmd.Connection = cnx;
                    cnx.Open();
                }
                else
                {
                    cmd.Connection = _txn.Connection;
                    cmd.Transaction = _txn;
                }
                //Execute the command
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                if (_isOwner)
                {
                    cnx.Dispose(); //Implicitly calls cnx.Close()
                }
                if (cmd != null) cmd.Dispose();
            }
        }

        protected IDataParameter[] ExecuteReturnableDataSetAndParameterProcedure(out DataSet ds, string Procedure, params IDataParameter[] procParams)
        {
            OracleCommand cmd;
            return ExecuteReturnableDataSetAndParameterProcedure(out ds, out cmd, Procedure, procParams);
        }

        protected IDataParameter[] ExecuteReturnableDataSetAndParameterProcedure(out DataSet ds, out OracleCommand cmd, string Procedure, params IDataParameter[] procParams)
        {
            OracleConnection cnx = null;
            ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            cmd = null;

            try
            {
                //Setup command object
                cmd = new OracleCommand(Procedure);
                cmd.CommandType = CommandType.StoredProcedure;
                if (procParams != null)
                {
                    for (int index = 0; index < procParams.Length; index++)
                    {
                        cmd.Parameters.Add(procParams[index]);
                    }
                }
                da.SelectCommand = (OracleCommand)cmd;

                //Determine the transaction owner and process accordingly
                if (_isOwner)
                {
                    cnx = new OracleConnection(GetConnectionString());
                    cmd.Connection = cnx;
                    cnx.Open();
                }
                else
                {
                    cmd.Connection = _txn.Connection;
                    cmd.Transaction = _txn;
                }
                //Fill the dataset
                da.Fill(ds);

                return procParams;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (da != null) da.Dispose();
                if (cmd != null) cmd.Dispose();
                if (_isOwner)
                {
                    cnx.Dispose(); //Implicitly calls cnx.Close()
                }
            }
        }

        protected IDataParameter[] ExecuteReturnableParameterProcedure(string Procedure, params IDataParameter[] procParams)
        {
            OracleCommand cmd;
            return ExecuteReturnableParameterProcedure(out cmd, Procedure, procParams);
        }

        protected IDataParameter[] ExecuteReturnableParameterProcedure(out OracleCommand cmd, string Procedure, params IDataParameter[] procParams)
        {
            //Method variables
            OracleConnection cnx = null;
            cmd = null;  //Avoids "Use of unassigned variable" compiler error
            try
            {
                //Setup command object
                cmd = new OracleCommand(Procedure);
                cmd.CommandType = CommandType.StoredProcedure;
                if (procParams != null)
                {
                    for (int index = 0; index < procParams.Length; index++)
                    {
                        if (procParams[index] != null)
                            cmd.Parameters.Add(procParams[index]);
                    }
                }
                //Determine the transaction owner and process accordingly
                if (_isOwner)
                {
                    cnx = new OracleConnection(GetConnectionString());
                    cmd.Connection = cnx;
                    cnx.Open();
                }
                else
                {
                    cmd.Connection = _txn.Connection;
                    cmd.Transaction = _txn;
                }
                //Execute the command
                cmd.ExecuteNonQuery();

                return procParams;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (_isOwner)
                {
                    cnx.Dispose(); //Implicitly calls cnx.Close()
                }
                if (cmd != null) cmd.Dispose();



            }
        }
        #endregion

        #region Query Execution

        protected DataSet ExecuteDataSet(string sql, string tableName,
           params IDataParameter[] sqlParams)
        {
            OracleCommand cmd;
            return ExecuteDataSet(out cmd, sql, tableName, sqlParams);
        }

        protected DataSet ExecuteDataSet(out OracleCommand cmd, string sql, string tableName,
            params IDataParameter[] sqlParams)
        {
            OracleConnection cnx = null;
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            cmd = null;
            try
            {
                //Setup command object
                cmd = new OracleCommand(sql);
                if (sqlParams != null)
                {
                    for (int index = 0; index < sqlParams.Length; index++)
                    {
                        cmd.Parameters.Add(sqlParams[index]);
                    }
                }
                da.SelectCommand = (OracleCommand)cmd;

                //Determine the transaction owner and process accordingly
                if (_isOwner)
                {
                    cnx = new OracleConnection(GetConnectionString());
                    cmd.Connection = cnx;
                    cnx.Open();
                }
                else
                {
                    cmd.Connection = _txn.Connection;
                    cmd.Transaction = _txn;
                }
                //Fill the dataset
                if (!string.IsNullOrEmpty(tableName))
                    da.Fill(ds, tableName);
                else
                    da.Fill(ds);
            }
            catch
            {
                throw;
            }
            finally
            {
                if (da != null) da.Dispose();
                if (cmd != null) cmd.Dispose();
                if (_isOwner)
                {
                    cnx.Dispose(); //Implicitly calls cnx.Close()
                }
            }
            return ds;
        }

        protected void ExecuteNonQuery(string sql, params IDataParameter[] procParams)
        {
            OracleCommand cmd;
            ExecuteNonQuery(out cmd, sql, procParams);
        }

        protected void ExecuteNonQuery(out OracleCommand cmd, string sql, params IDataParameter[] procParams)
        {
            //Method variables
            OracleConnection cnx = null;
            cmd = null;  //Avoids "Use of unassigned variable" compiler error
            try
            {
                //Setup command object
                cmd = new OracleCommand(sql);
                if (procParams != null)
                {
                    for (int index = 0; index < procParams.Length; index++)
                    {
                        if (procParams[index] != null)
                            cmd.Parameters.Add(procParams[index]);
                    }
                }
                //Determine the transaction owner and process accordingly
                if (_isOwner)
                {
                    cnx = new OracleConnection(GetConnectionString());
                    cmd.Connection = cnx;
                    cnx.Open();
                }
                else
                {
                    cmd.Connection = _txn.Connection;
                    cmd.Transaction = _txn;
                }
                //Execute the command
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                if (_isOwner)
                {
                    cnx.Dispose(); //Implicitly calls cnx.Close()
                }
                if (cmd != null) cmd.Dispose();
            }
        }
        #endregion

        #region Parameter Criteria
        protected object CheckParamValue(TimeSpan paramValue)
        {
            if (paramValue.Equals(Constants.NullDateTime))
            {
                return DBNull.Value;
            }
            else
            {
                return paramValue;
            }
        }

        protected object CheckParamValue(char paramValue)
        {
            if (char.MinValue == paramValue)
            {
                return DBNull.Value;
            }
            else
            {
                return paramValue;
            }
        }

        protected object CheckParamValue(string paramValue)
        {
            if (string.IsNullOrEmpty(paramValue))
            {
                return DBNull.Value;
            }
            else
            {
                return paramValue;
            }
        }

        protected object CheckParamValue(DateTime? paramValue)
        {
            if (paramValue.Equals(null))
            {
                return null;
            }
            else
            {
                return paramValue;
            }
        }

        protected object CheckParamValue(DateTime paramValue)
        {
            if (paramValue.Equals(Constants.NullDateTime))
            {
                return DBNull.Value;
            }
            else
            {
                return paramValue;
            }
        }

        protected object CheckParamValue(double paramValue)
        {
            if (paramValue.Equals(Constants.NullDouble))
            {
                return DBNull.Value;
            }
            else
            {
                return paramValue;
            }
        }

        protected object CheckParamValue(float paramValue)
        {
            if (paramValue.Equals(Constants.NullFloat))
            {
                return DBNull.Value;
            }
            else
            {
                return paramValue;
            }
        }

        protected object CheckParamValue(Decimal paramValue)
        {
            decimal value = Convert.ToDecimal("0");
            //if (paramValue <= value)
            //{
            //    return value;
            //}
            //else
            //{
            return paramValue;
            //}
        }

        protected object CheckParamValue(Decimal? paramValue)
        {
            if (paramValue == null)
            {
                return null;
            }
            else
            {
                return paramValue;
            }
        }

        protected object CheckParamValue(int paramValue)
        {
            if (paramValue.Equals(Constants.NullInt))
            {
                return DBNull.Value;
            }
            else
            {
                return paramValue;
            }
        }

        protected object CheckParamValue(Int64 paramValue)
        {
            if (paramValue.Equals(Constants.NullInt))
            {
                return DBNull.Value;
            }
            else
            {
                return paramValue;
            }
        }

        protected object CheckParamValue(byte[] paramValue)
        {
            if (paramValue.Equals(Constants.NullByteArray))
            {
                return DBNull.Value;
            }
            else
            {
                return paramValue;
            }
        }

        protected object CheckParamValue(Byte paramValue)
        {
            if (paramValue.Equals(byte.MinValue))
            {
                return DBNull.Value;
            }
            else
            {
                return paramValue;
            }
        }

        protected OracleParameter CreateParameter(string paramName, OracleDbType paramType, object paramValue)
        {
            OracleParameter param = new OracleParameter(paramName, paramType);
            if (paramValue != DBNull.Value)
            {
                switch (paramType)
                {
                    case OracleDbType.Char:
                        paramValue = CheckParamValue((char)paramValue);
                        break;
                    case OracleDbType.Clob:
                    case OracleDbType.Long:
                    case OracleDbType.NClob:
                    case OracleDbType.NChar:
                    case OracleDbType.NVarchar2:
                    case OracleDbType.Varchar2:
                    case OracleDbType.XmlType:
                        paramValue = CheckParamValue((string)paramValue);
                        break;

                    case OracleDbType.Date:
                    case OracleDbType.TimeStamp:
                    case OracleDbType.TimeStampLTZ:
                    case OracleDbType.TimeStampTZ:
                        paramValue = CheckParamValue((DateTime)paramValue);
                        break;

                    case OracleDbType.Int16:
                    case OracleDbType.Int32:
                    case OracleDbType.Int64:
                    case OracleDbType.IntervalYM:
                        paramValue = CheckParamValue((int)paramValue);
                        break;

                    case OracleDbType.Byte:
                        paramValue = CheckParamValue(Convert.ToSingle(paramValue));
                        break;

                    case OracleDbType.Double:
                        paramValue = CheckParamValue(Convert.ToSingle(paramValue));
                        break;

                    case OracleDbType.Decimal:
                        paramValue = CheckParamValue((decimal)paramValue);
                        break;

                    case OracleDbType.Raw:
                    case OracleDbType.LongRaw:
                    case OracleDbType.Blob:
                    case OracleDbType.BFile:
                        paramValue = CheckParamValue((byte[])paramValue);
                        break;

                    case OracleDbType.IntervalDS:
                        paramValue = CheckParamValue((TimeSpan)paramValue);
                        break;
                }
            }
            param.Value = paramValue;
            return param;
        }

        protected OracleParameter CreateProcedureParameter(string paramName, OracleDbType paramType, object paramValue, ParameterDirection paramDirection)
        {
            OracleParameter param = new OracleParameter(paramName, paramType);
            if (paramValue != DBNull.Value)
            {
                switch (paramType)
                {
                    case OracleDbType.Char:
                        paramValue = CheckParamValue((char)paramValue);
                        break;
                    case OracleDbType.Clob:
                    case OracleDbType.Long:
                    case OracleDbType.NClob:
                    case OracleDbType.NChar:
                    case OracleDbType.NVarchar2:
                    case OracleDbType.Varchar2:
                    case OracleDbType.XmlType:
                        paramValue = CheckParamValue((string)paramValue);
                        break;

                    case OracleDbType.Date:
                    case OracleDbType.TimeStamp:
                    case OracleDbType.TimeStampLTZ:
                    case OracleDbType.TimeStampTZ:
                        if (paramValue != null)
                            paramValue = CheckParamValue((DateTime)paramValue);
                        else
                            paramValue = CheckParamValue((DateTime?)paramValue);
                        break;

                    case OracleDbType.Int16:
                    case OracleDbType.Int32:
                    case OracleDbType.Int64:
                    case OracleDbType.IntervalYM:
                        paramValue = CheckParamValue((int)paramValue);
                        break;

                    case OracleDbType.Byte:
                        paramValue = CheckParamValue(Convert.ToSingle(paramValue));
                        break;

                    case OracleDbType.Double:
                        paramValue = CheckParamValue(Convert.ToSingle(paramValue));
                        break;

                    case OracleDbType.Decimal:
                        paramValue = CheckParamValue((decimal)paramValue);
                        break;

                    case OracleDbType.Raw:
                    case OracleDbType.LongRaw:
                    case OracleDbType.Blob:
                    case OracleDbType.BFile:
                        paramValue = CheckParamValue((byte[])paramValue);
                        break;

                    case OracleDbType.IntervalDS:
                        paramValue = CheckParamValue((TimeSpan)paramValue);
                        break;
                }
            }
            param.Direction = paramDirection;
            param.Value = paramValue;
            return param;
        }
        #endregion

    }
}