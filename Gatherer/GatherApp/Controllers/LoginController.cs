using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BAL;
using Newtonsoft.Json;
namespace GatherApp.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        clsLogin objLogin = new clsLogin();
        public ActionResult Index()
        {
            return View();
        }
        public string login(clsJsonMember.loginDetails obj)
        {
            System.Data.DataSet DS = objLogin.login(obj);
            string Det;
            if (DS.Tables[0].Rows.Count <= 0)
            {
                Det = "Incorrect";
            }
            else
            {
               Det = JsonConvert.SerializeObject(DS, Formatting.Indented);
            }
            return Det;
        }
    }
}
