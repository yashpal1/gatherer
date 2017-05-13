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
        DBManager Sqldbmanager = new DBManager(DataProvider.SqlServer, ConfigurationManager.ConnectionStrings["Gatherer"].ConnectionString);
        public DataSet login(clsJsonMember.loginDetails obj)
        {
            DataSet DS = new DataSet();
            try
            {
                Sqldbmanager.Open();
                Sqldbmanager.CreateParameters(2);
                Sqldbmanager.AddParameters(0, "@UserId", obj.UserId);
                Sqldbmanager.AddParameters(1, "@Password", obj.Password);
                DS = Sqldbmanager.ExecuteDataSet(CommandType.StoredProcedure, "usp_login");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {

            }
            return DS;
        }
        

    }
}
