using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using DAL;
namespace BAL
{
    public class clsErrorLogs
    {
        #region Global Varialble
        DBManager Sqldbmanager = new DBManager(DataProvider.SqlServer, ConfigurationManager.ConnectionStrings["LMSDBConnectionString"].ConnectionString);
        IDataReader dr;
        #endregion


        public object GetErrorLogs()
        {
            List<object> lstErrlogs = new List<object>();
            try
            {
                Sqldbmanager.Open();
                Sqldbmanager.CreateParameters(0);
                dr = Sqldbmanager.ExecuteReader(CommandType.StoredProcedure, "USP_GetErrorLogs");
                while (dr.Read())
                {
                    object obj = new
                    {
                        id = dr["Id"],
                        ModuleName = dr["ModuleName"],
                        ErrorSource = dr["ErrorSource"],
                        Description = dr["Description"],
                        UserName = dr["UserName"],
                        LDateTime = dr["LDateTime"],
                    };
                    lstErrlogs.Add(obj);
                }
            }
            catch (Exception Ex)
            {
                throw;
            }
            finally
            {
                dr.Close();
            }
            return lstErrlogs;
        }
    }
}
