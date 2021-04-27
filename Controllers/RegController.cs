using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using chetan.Models;
using CrystalDecisions.CrystalReports.Engine;
using System.Configuration;
using System.IO;

namespace chetan.Controllers
{

    public class RegController : Controller
    {
        // GET: Reg

        database_Access_Layer.singupdb dblayer = new database_Access_Layer.singupdb();
      
        public ActionResult singup()
        {
            return View();
        }
        public ActionResult user_data()
        {
            return View();
        }
        public ActionResult user_update(int id)
        {
            return View();
        }

        //-----------ADD USER---------------

        [HttpPost]
        public JsonResult Regsiter(registration rs)
        {
            string result = string.Empty;
            try
            {
                if (dblayer.Add_record(rs) > 0)
                    result = "User Registered successsfully!";
                else
                    result = "Registration Failed !!";
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception here" + e);
                result = "failed";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        //GET USER_DATA
        public JsonResult Get_user()
        {
            DataSet ds = dblayer.Get_userinfo();
            List<registration> listrs = new List<registration>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                listrs.Add(new registration
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
        //user data by id
        public JsonResult Get_userbyid(int id)
        {
            DataSet ds = dblayer.Get_userinfobyid(id);
            List<registration> listrs = new List<registration>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                listrs.Add(new registration
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

        //UPDATE
        [HttpPost]
        public JsonResult update_record(registration rs)
        {
            string result = string.Empty;
            try
            {
                if (dblayer.update_user(rs) > 0)
                    result = "Updated user successfully";
                else
                    result = "update failed!!";
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception here" + e);
                result = "failed";
            }
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        //DELETE

        public JsonResult delete_record(int id)
        {
            string res = string.Empty;
            try
            {
                dblayer.deletedata(id);
                res = "data deleted";
            }
            catch (Exception)
            {
                res = "failed";
            }
            return Json(res, JsonRequestBehavior.AllowGet);

        }
        //repoart pdf
        public ActionResult ExportPdf()
        {
            DataSet ds = dblayer.reportuser();
            List<registration> listrs = new List<registration>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                listrs.Add(new registration
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
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report"), "userlist.rpt"));
            rd.SetDataSource(listrs);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "ReportUser.Pdf");
        }
        //repoart excel
        public ActionResult ExportExcel()
        {
            DataSet ds = dblayer.excel();
            List<registration> listrs = new List<registration>();
            foreach (DataRow da in ds.Tables[0].Rows)
            {
                listrs.Add(new registration
                {
                    user_id = Convert.ToInt32(da["user_id"]),
                    user_name = da["user_name"].ToString(),
                    first_name = da["first_name"].ToString(),
                    last_name = da["last_name"].ToString(),
                    email = da["email"].ToString(),
                    password = da["password"].ToString(),
                    address = da["address"].ToString(),
                    mobile = da["mobile"].ToString(),
                    country = da["country"].ToString(),
                    state = da["state"].ToString(),
                    city = da["city"].ToString(),
                    user_role_id = Convert.ToInt32(da["user_role_id"])
                });
            }
            ReportDocument re = new ReportDocument();
            re.Load(Path.Combine(Server.MapPath("~/Report"), "userlist.rpt"));
            re.SetDataSource(listrs);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            Stream stream = re.ExportToStream(CrystalDecisions.Shared.ExportFormatType.ExcelWorkbook);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "ReportUser.xlsx");


        }
    }
}