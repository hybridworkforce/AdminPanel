using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using chetan.Models;
using System.Data;


namespace chetan.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        database_Access_Layer.logindb dblayer = new database_Access_Layer.logindb();
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult Projectowner()
        {
            return View();
        }
        public ActionResult Processowner()
        {
            return View();
        }
        public ActionResult Clerk()
        {
            return View();
        }

        public JsonResult userlogin(registration us)
        {
            int result = dblayer.userlogin(us);

            if (result > 0)
            {
                Session["user"] = us.email; 
            }
            else
            {
                result = -1;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}