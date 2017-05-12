using DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BAL
{
    public class clsCommonClass
    {

        #region Global Varialble
        DBManager Sqldbmanager = new DBManager(DataProvider.SqlServer, ConfigurationManager.ConnectionStrings["LMSDBConnectionString"].ConnectionString);
        IDataReader dr;
        #endregion

        #region For Date
        public DateTime GetGMT()
        {
            DateTime dt = DateTime.Now.ToUniversalTime();
            DateTime time1;
            if (dt >= GetDateOfTheDay(dt.Year, 4) && dt <= GetDateOfTheDay(dt.Year, 10))
            {
                time1 = dt.AddHours(10);
            }
            else
            {
                time1 = dt.AddHours(11);
            }
            return time1;
        }
        private DateTime GetDateOfTheDay(int Year, int Month)
        {
            DateTime dts = new DateTime(Year, Month, 1);
            switch (dts.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    dts = dts.AddDays(6);
                    break;
                case DayOfWeek.Tuesday:
                    dts = dts.AddDays(5);
                    break;
                case DayOfWeek.Wednesday:
                    dts = dts.AddDays(4);
                    break;
                case DayOfWeek.Thursday:
                    dts = dts.AddDays(3);
                    break;
                case DayOfWeek.Friday:
                    dts = dts.AddDays(2);
                    break;
                case DayOfWeek.Saturday:
                    dts = dts.AddDays(1);
                    break;
                default:
                    dts = dts;
                    break;
            }
            return dts;
        }
        public int GetMonthDay(string mnth, int yer)
        {
            int day = 0;
            if (mnth == "Jan" || mnth == "Mar" || mnth == "May" || mnth == "Jul" || mnth == "Aug" || mnth == "Oct" || mnth == "Dec")
            {
                day = 31;
            }
            if (mnth == "Apr" || mnth == "Jun" || mnth == "Sep" || mnth == "Nov")
            {
                day = 30;
            }
            if (mnth == "Feb")
            {
                if (yer % 4 != 0)
                    day = 28;
                else
                    day = 29;
            }
            return day;
        }
        public string Currentdate()
        {
            return GetGMT().ToString("dd-MMM-yyyy");
        }
        public string CurrentTime()
        {
            return GetGMT().ToString("hh:mm:ss tt");
        }
        public string DateTimeFIleName()
        {
            return GetGMT().ToString("yyyymmdd") + "_" + GetGMT().ToString("HHmmss");
        }
        #endregion

        #region from AD User
        public string GetADPath()
        {
            string path = ConfigurationSettings.AppSettings["adserver"];
            return path;
        }
        public string GetADOrg()
        {
            string Org = ConfigurationSettings.AppSettings["adorg"];
            return Org;
        }
        public string encryptStringToBytes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the stream used to encrypt to an in memory
            // array of bytes.
            MemoryStream msEncrypt = null;

            // Declare the RijndaelManaged object
            // used to encrypt the data.
            RijndaelManaged aesAlg = null;

            try
            {
                // Create a RijndaelManaged object
                // with the specified key and IV.
                aesAlg = new RijndaelManaged();
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                msEncrypt = new MemoryStream();
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {

                        //Write all data to the stream.
                        swEncrypt.Write(plainText);
                    }
                }
            }
            finally
            {
                // Clear the RijndaelManaged object.
                if (aesAlg != null)
                    aesAlg.Clear();
            }

            // Return the encrypted bytes from the memory stream.
            //return msEncrypt.ToArray();
            return Convert.ToBase64String(msEncrypt.ToArray());
        }
        public string decryptStringFromBytes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the RijndaelManaged object
            // used to decrypt the data.
            RijndaelManaged aesAlg = null;

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            try
            {
                // Create a RijndaelManaged object
                // with the specified key and IV.
                aesAlg = new RijndaelManaged();
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }
            finally
            {
                // Clear the RijndaelManaged object.
                if (aesAlg != null)
                    aesAlg.Clear();
            }

            return plaintext;
        }
        #endregion

        public bool BulkCopy_UserMaster(DataTable dt)
        {
            bool error = false;
            using (SqlBulkCopy bulcopy = new SqlBulkCopy(ConfigurationManager.ConnectionStrings["LMSDBConnectionString"].ConnectionString))
            {
                bulcopy.DestinationTableName = "tbl_tempCLF_Users";
                try
                {
                    bulcopy.ColumnMappings.Add(0, 0);
                    bulcopy.ColumnMappings.Add(1, 1);
                    bulcopy.ColumnMappings.Add(2, 2);
                    bulcopy.ColumnMappings.Add(3, 3);
                    bulcopy.WriteToServer(dt);

                }
                catch (Exception ex)
                {
                    error = true;
                    throw new Exception("DatabaseUtility:BulkCopy:" + ex.Message);
                }
                return (error);
            }
        }

        public void CreateCsv(string fpath, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                StreamWriter sw = new StreamWriter(fpath, false);
                int iColCount = dt.Columns.Count;
                for (int i = 0; i < iColCount; i++)
                {
                    sw.Write(dt.Columns[i].ToString());
                    if (i < iColCount)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
                foreach (DataRow dr in dt.Rows)
                {
                    for (int i = 0; i < iColCount; i++)
                    {
                        if (!Convert.IsDBNull(dr[i]))
                        {
                            sw.Write(dr[i].ToString().Replace("\r\n", " "));
                        }
                        if (i < iColCount)
                        {
                            sw.Write(",");
                        }
                    }
                    sw.Write(sw.NewLine);
                }
                sw.Close();
            }
            dt.Rows.Clear();

        }

        public void LogError(string ModuleName, string ErrorSource, string Description)
        {
            try
            {
                Sqldbmanager.Open();
                Sqldbmanager.CreateParameters(3);
                Sqldbmanager.AddParameters(0, "@ModuleName", ModuleName);
                Sqldbmanager.AddParameters(1, "@ErroSource", ErrorSource);
                Sqldbmanager.AddParameters(2, "@Description", Description);
                int RowUpdated = Sqldbmanager.ExecuteNonQuery(CommandType.StoredProcedure, "usp_LogError");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Sqldbmanager.Close();
            }
        }

        public object GetMenusCollection(string PrevApp, string LoginId)
        {
            List<clsJsonMember.JsonMenus> objMenus = new List<clsJsonMember.JsonMenus>();

            try
            {
                List<clsJsonMember.JsonMenus> lstMenus = new List<clsJsonMember.JsonMenus>();
                Sqldbmanager.Open();
                Sqldbmanager.CreateParameters(4);
                Sqldbmanager.AddParameters(0, "@ParentId", 0);
                Sqldbmanager.AddParameters(1, "@SID", 4);
                Sqldbmanager.AddParameters(2, "@PrevApp", PrevApp);
                Sqldbmanager.AddParameters(3, "@LoginId", LoginId);
                dr = Sqldbmanager.ExecuteReader(CommandType.StoredProcedure, "USP_GetMenus");
                while (dr.Read())
                {
                    clsJsonMember.JsonMenus MenuItems = new clsJsonMember.JsonMenus();
                    MenuItems.MenuId = Convert.ToInt32(dr["id"]);
                    MenuItems.ParentId = Convert.ToInt32(dr["parentid"]);
                    MenuItems.MenuName = dr["menu"].ToString();
                    MenuItems.URL = Convert.ToString(dr["URL"]);
                    MenuItems.ChildMenus = GetChildMenu(MenuItems.MenuId, 4, PrevApp, LoginId);
                    lstMenus.Add(MenuItems);
                }

                return lstMenus;
            }
            catch (Exception Ex)
            {
                clsCommonClass clsOCmn = new clsCommonClass();
                clsOCmn.LogError("MainMenu", "BindMenu", Ex.Message);
                throw;
            }
            finally
            {
                dr.Close();
                Sqldbmanager.Close();
            }
        }

        public List<clsJsonMember.JsonMenus> GetChildMenu(Int32 ParentId, Int32 SID, string PrevApp, string LoginId)
        {
            try
            {
                IDataReader dr;
                List<clsJsonMember.JsonMenus> lstMenuItems = new List<clsJsonMember.JsonMenus>();
                Sqldbmanager.Open();
                Sqldbmanager.CreateParameters(4);
                Sqldbmanager.AddParameters(0, "@ParentId", ParentId);
                Sqldbmanager.AddParameters(1, "@SID", SID);
                Sqldbmanager.AddParameters(2, "@PrevApp", PrevApp);
                Sqldbmanager.AddParameters(3, "@LoginId", LoginId);
                dr = Sqldbmanager.ExecuteReader(CommandType.StoredProcedure, "USP_GetMenus");
                while (dr.Read())
                {
                    clsJsonMember.JsonMenus MenuItems = new clsJsonMember.JsonMenus();
                    MenuItems.MenuId = Convert.ToInt32(dr["id"]);
                    MenuItems.ParentId = Convert.ToInt32(dr["parentid"]);
                    MenuItems.MenuName = dr["menu"].ToString();
                    MenuItems.URL = Convert.ToString(dr["URL"]);
                    MenuItems.ChildMenuCount = Convert.ToInt32(dr["ChildCount"]);
                    lstMenuItems.Add(MenuItems);
                }

                return lstMenuItems;
            }
            catch (Exception Ex)
            {
                clsCommonClass clsOCmn = new clsCommonClass();
                clsOCmn.LogError("MainMenu", "BindMenu", Ex.Message);
                throw;
            }
        }

        public void ActivityLog(int UserId, string ActionDtl, string Menu, string Category, string Item, string AssociatedItem)
        {
            try
            {
                Sqldbmanager.Open();
                Sqldbmanager.CreateParameters(6);
                Sqldbmanager.AddParameters(0, "@UserId", UserId);
                Sqldbmanager.AddParameters(1, "@Action", ActionDtl);
                Sqldbmanager.AddParameters(2, "@Menu", Menu);
                Sqldbmanager.AddParameters(3, "@Category", Category);
                Sqldbmanager.AddParameters(4, "@Item", Item);
                Sqldbmanager.AddParameters(5, "@AssociatedItem", AssociatedItem);

                int RowUpdated = Sqldbmanager.ExecuteNonQuery(CommandType.StoredProcedure, "ActivityLog_Pro");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Sqldbmanager.Close();
            }
        }

        public Object RollbackDrUnsavedWork()
        {

            try
            {
                Sqldbmanager.Open();
                Sqldbmanager.CreateParameters(1);
                Sqldbmanager.AddParameters(0, "@SessionId", System.Web.HttpContext.Current.Session["SessionId"]);
                return Sqldbmanager.ExecuteScalar(CommandType.StoredProcedure, "USP_RollbackDrUnsavedWork");
            }
            catch (Exception Ex)
            {
                clsCommonClass clsOCmn = new clsCommonClass();
                clsOCmn.LogError("Data Reconciliation", "RollbackDrUnsavedWork()", Ex.Message);
                throw;
            }
            finally
            {
                Sqldbmanager.Close();
            }
        }

        public DataTable GetDetailFTP()
        {
            DataTable dt;
            object objRet = new object();
            try
            {
                Sqldbmanager.Open();
                Sqldbmanager.CreateParameters(1);
                Sqldbmanager.AddParameters(0, "@ExeFor", "FTP_PATH");
                dt = Sqldbmanager.ExecuteDataTable(CommandType.StoredProcedure, "USP_Common");
                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Sqldbmanager.Close();
            }
            return dt;
        }

        public DataTable GetActivityLog_data()
        {
            DataTable dt;
            object objRet = new object();
            try
            {
                Sqldbmanager.Open();
                dt = Sqldbmanager.ExecuteDataTable(CommandType.StoredProcedure, "USP_ActivityLog");
            }
            catch (Exception){throw;}
            finally
            {Sqldbmanager.Close();}
            return dt;
        }

    }
}
