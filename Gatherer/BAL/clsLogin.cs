using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BAL;
using DAL;
using System.Configuration;
using System.Data;

namespace BAL
{
    public class clsLogin
    {
        DBManager Sqldbmanager = new DBManager(DataProvider.SqlServer, ConfigurationManager.ConnectionStrings["LMSDBConnectionString"].ConnectionString);
        public object login(clsJsonMember.loginDetails obj)
        {
            try
            {
                Sqldbmanager.Open();
                Sqldbmanager.CreateParameters(2);
                Sqldbmanager.AddParameters(0, "@UserId", obj.UserId);
                Sqldbmanager.AddParameters(1, "@Password", obj.Password);
                return Sqldbmanager.ExecuteDataSet(CommandType.StoredProcedure, "usp_login").ToString();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
            return "";
        }

    }
}
