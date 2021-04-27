using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.Data;
using chetan.Models;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace chetan.Controllers
{
    public class SupplierProController : Controller
    {
        database_Access_Layer.SupplierProjdb dblayer = new database_Access_Layer.SupplierProjdb();
        // GET: SupplierPro
        public ActionResult Supp_from()
        {
            return View();
        }
        public ActionResult Supp_Data()
        {
            return View();
        }
        public ActionResult Supp_update(int id)
        {
            return View();
        }
        //add supplier_onboard
        [HttpPost]
        public JsonResult Addsupplier(supplieronboard sd)
        {

            // string result = string.Empty;         
            int result;         
            try
            {
                int idx = dblayer.Supp_add(sd);
                result = idx;
                /*  if (dblayer.Supp_add(sd) > 0)
                    result = "Data Saved Successfully..!!";
                else
                    result = "Failed to save data..!!"; */
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception here" + e);
                // result = "Data Saved failed..!!";
                result = -1;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public object doc_files(HttpPostedFile file, string sid)
        {
            try {
                if (file != null && file.ContentLength > 0)
                // if (Request.Files.Count > 0)
                {
                    // var sid = Request.Form["sid"];
                    // var file = Request.Files[0];
                    string filename = Path.GetFileName(file.FileName);
                    string fileext = Path.GetExtension(filename);
                    if (fileext == ".pdf" || fileext == ".docx" || fileext == ".xlsx")
                    {
                        string filepath = Path.Combine(Server.MapPath("~/Uploadfile"), filename);
                        supplieronboard sb = new supplieronboard();
                        sb.supplier_id = Int32.Parse(sid);
                        sb.file_name = filename;
                        sb.file_uploder = filepath;
                        dblayer.Supp_add_file(sb);
                        file.SaveAs(filepath);
                    }
                }
            }
            catch (Exception e) { }
            return new object { };
        }

        public JsonResult Getprosupplier()
        {
            DataSet ds = dblayer.getsuppliersinfo();

            List<supplieronboard> listrs = new List<supplieronboard>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                listrs.Add(new supplieronboard
                {
                    supplier_id = Convert.ToInt32(dr["supplier_id"]),
                    supplier_name = dr["supplier_name"].ToString(),
                    account_number = Convert.ToInt32(dr["account_number"]),
                    email = dr["email"].ToString(),
                    address = dr["address"].ToString(),
                    document_types = dr["document_types"].ToString(),
                    file_uploder = dr["file_uploder"].ToString(),
                    comments = dr["comments"].ToString(),
                    rules_type = dr["rules_type"].ToString(),
                    rules = dr["rules"].ToString(),
                    signature_by = dr["signature_by"].ToString(),
                    date = Convert.ToDateTime(dr["date"])
,
                });
            }
            return Json(listrs, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Get_supplierid(int id)
        {
            DataSet ds = dblayer.Getsupplierbyids(id);

            List<supplieronboard> listrs = new List<supplieronboard>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                listrs.Add(new supplieronboard
                {
                    supplier_id = Convert.ToInt32(dr["supplier_id"]),
                    supplier_name = dr["supplier_name"].ToString(),
                    account_number = Convert.ToInt32(dr["account_number"]),
                    email = dr["email"].ToString(),
                    address = dr["address"].ToString(),
                    document_types = dr["document_types"].ToString(),
                    file_uploder = dr["file_uploder"].ToString(),
                    comments = dr["comments"].ToString(),
                    rules_type = dr["rules_type"].ToString(),
                    rules = dr["rules"].ToString(),
                    signature_by = dr["signature_by"].ToString(),
                    date = Convert.ToDateTime(dr["date"])
,
                });
            }
            return Json(listrs, JsonRequestBehavior.AllowGet);
        }
        //delete
        public JsonResult deletesupplier(int id)
        {
            string res = string.Empty;
            try
            {
                dblayer.deletesuppliers(id);
                res = "data deleted";
            }
            catch (Exception)
            {
                res = "failed";
            }
            return Json(res, JsonRequestBehavior.AllowGet);

        }
    }
}