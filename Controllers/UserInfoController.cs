using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using chetan.Models;

namespace chetan.Controllers
{
    public class UserInfoController : Controller
    {
        database_Access_Layer.singupdb dblayer = new database_Access_Layer.singupdb();
        // GET: UserInfo
        public ActionResult User_Info()
        {
            return View();
        }
        //update
        public ActionResult User_update(int id)
        {
            return View();
        }
        //all user info
        public JsonResult Get_info()
        {
            DataSet ds = dblayer.get_userinfo();
            List<user> listrs = new List<user>();
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                listrs.Add(new user
                {
                    user_id = Convert.ToInt32(dr["user_id"]),
                    user_name = dr["user_name"].ToString(),
                    first_name = dr["first_name"].ToString(),
                    last_name = dr["last_name"].ToString(),
                    email = dr["email"].ToString(),
                    password = dr["password"].ToString(),
                    address = dr["address"].ToString(),
                    mobile = dr["mobile"].ToString(),
                    country = dr["country"].ToString(),
                    state = dr["state"].ToString(),
                    city = dr["city"].ToString(),
                    user_role_id = Convert.ToInt32(dr["user_role_id"])
                });
            }
            return Json(listrs, JsonRequestBehavior.AllowGet);
        }
        // Update records

        public JsonResult update_record(register rs)

        {

            string res = string.Empty;

            try

            {

                dblayer.update_record(rs);

                res = "Updated";

            }

            catch (Exception)

            {

                res = "failed";

            }

            return Json(res, JsonRequestBehavior.AllowGet);



        }

    }
}