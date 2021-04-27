using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using chetan.Models;

namespace chetan.Controllers
{
    public class SupplierOnboardController : Controller
    {
        // GET: SupplierOnboard
        database_Access_Layer.SupplierOnboarddb dblayer = new database_Access_Layer.SupplierOnboarddb();
        public ActionResult SupplierFrom()
        {
            return View();
        }
        //show details
        public ActionResult Supplierdata()
        {
            return View();
        }
      
        //update
        public ActionResult Supplieredit(int id)
        {
            return View();
        }
      

        //----------add------------
        //add supplier_onboard
        public JsonResult supplier(supplieronboard sd)
        {
            string result = string.Empty;
            try
            {
                if(dblayer.suppplier_add(sd)>0)
                    result = "Data Saved Successfully..!!";
                else
                    result = "Failed to save data..!!";
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception here" + e);
                result = "Data Saved failed..!!";
            }
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        //display all supplier data
        public JsonResult Get_supplier()
        {
            DataSet ds = dblayer.get_supplier_info();

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
                    date = Convert.ToDateTime (dr["date"])
,
                });
            }
            return Json(listrs, JsonRequestBehavior.AllowGet);
        }
        //by id
        public JsonResult Get_supplierid(int id)
        {
            DataSet ds = dblayer.Get_supplierbyid(id);

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
        //UPDATE
        public JsonResult update_record(supplieronboard rs)
        {
            string result = string.Empty;
            try
            {
                if (dblayer.update_supplier(rs) > 0) 
                result = "Supplier Updated Successfully ";
                else
                    result = "Failed..!!!";
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception here" + e);
                result = "update failed";
            }
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        //UPDATE
        public JsonResult update_recordproj(supplieronboard rs)
        {
            string result = string.Empty;
            try
            {
                if (dblayer.update_supplier(rs) > 0)
                    result = "Supplier Updated Successfully ";
                else
                    result = "Failed..!!!";
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception here" + e);
                result = "update failed";
            }
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        //DELETE
        public JsonResult delete_supplier(int id)
        {
            string res = string.Empty;
            try
            {
                dblayer.delete_supplier(id);
                res = "data deleted";
            }
            catch (Exception)
            {
                res = "failed";
            }
            return Json(res, JsonRequestBehavior.AllowGet);

        }
        //add report view save
        [HttpPost]
        public JsonResult repoets_add(reports ss)
        {
            string result = string.Empty;
            try
            {
                if (dblayer.report_add(ss) > 0)
                    result = "Report successsfully!";
                else
                    result = " Failed !!";
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception here" + e);
                result = "failed";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }



    }
}