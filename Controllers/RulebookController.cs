using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using chetan.Models;
using CrystalDecisions.CrystalReports.Engine;
using System.Configuration;
using System.IO;

namespace chetan.Controllers
{
    public class RulebookController : Controller
    {
        // GET: Rulebook
        database_Access_Layer.rulebookdb dblayer = new database_Access_Layer.rulebookdb();
        public ActionResult Rulebook()
        {
            return View();
        }
        public ActionResult Ruleedit(int id)
        {
            return View();
        }
        public ActionResult Ruulebookproj()
        {
            return View();
        }
        public ActionResult Ruleeditpro(int id)
        {
            return View();
        }

        //display all supplier data

        public JsonResult Get_rule()
        {
            DataSet ds = dblayer.get_rule_info();

            List<supplieronboard> listrs = new List<supplieronboard>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                listrs.Add(new supplieronboard
                {
                    supplier_id = Convert.ToInt32(dr["supplier_id"]),
                    supplier_name = dr["supplier_name"].ToString(),
                   
                    rules_type = dr["rules_type"].ToString(),
                    rules = dr["rules"].ToString()
                  
,
                });
            }
            return Json(listrs, JsonRequestBehavior.AllowGet);
        }
        //id by role
        public JsonResult Get_ruleid(int id)
        {
            DataSet ds = dblayer.Get_rulebyid(id);

            List<supplieronboard> listrs = new List<supplieronboard>();

            foreach (DataRow cs in ds.Tables[0].Rows)
            {
                listrs.Add(new supplieronboard
                {
                    supplier_id = Convert.ToInt32(cs["supplier_id"]),
                   
                    rules_type = cs["rules_type"].ToString(),
                    rules = cs["rules"].ToString()
                });
            }
            return Json(listrs, JsonRequestBehavior.AllowGet);
        }
        public JsonResult updated_rules(supplieronboard rs)
        {
            string result = string.Empty;
            try
            {
                if (dblayer.update_rule(rs) > 0)
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
        //report
        public ActionResult ExportPdf()
        {
            DataSet ds = dblayer.Report_rule();

            List<supplieronboard> listrs = new List<supplieronboard>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                listrs.Add(new supplieronboard
                {
                    supplier_id = Convert.ToInt32(dr["supplier_id"]),
                    supplier_name = dr["supplier_name"].ToString(),

                    rules_type = dr["rules_type"].ToString(),
                    rules = dr["rules"].ToString()

,
                });
            }
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report"), "Rulebuk.rpt"));
            rd.SetDataSource(listrs);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "ReportRuleBook.Pdf");

        }
        //execal
        public ActionResult ExportExcel()
        {
            DataSet ds = dblayer.Report_rule();

            List<supplieronboard> listrs = new List<supplieronboard>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                listrs.Add(new supplieronboard
                {
                    supplier_id = Convert.ToInt32(dr["supplier_id"]),
                    supplier_name = dr["supplier_name"].ToString(),

                    rules_type = dr["rules_type"].ToString(),
                    rules = dr["rules"].ToString()

,
                });
            }
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report"), "Rulebuk.rpt"));
            rd.SetDataSource(listrs);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.ExcelWorkbook);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "ReportRuleBook.xlsx");

        }
    }
      
    
}