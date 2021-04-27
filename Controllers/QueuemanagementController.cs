using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using chetan.Models;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using System.Configuration;


namespace chetan.Controllers
{
    public class QueuemanagementController : Controller
    {
        database_Access_Layer.queuedb dblayer = new database_Access_Layer.queuedb();
        // GET: Queuemanagement
        public ActionResult queuemanagement()
        {
            return View();
        }
        public ActionResult Reports()
        {
            return View();
        }
        public ActionResult Download()
        {
            return View();
        }
        public ActionResult Upload()
        {
            return View();
        }
        public ActionResult RuleBook_Report()
        {
            return View();
        }
        public ActionResult queuemanagementproj()
        {
            return View();
        }
        public ActionResult repoetsselect()
        {
            return View();
        }
        public JsonResult get_queuemgt()
        {
            DataSet ds = dblayer.Get_queueinfo();

            List<queue> listrs = new List<queue>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                listrs.Add(new queue
                {
                    Supplier_name = dr["Supplier_name"].ToString(),
                    email = dr["email"].ToString(),
                    account_no = Convert.ToInt32(dr["account_no"]),
                    total_doc = Convert.ToInt32(dr["total_doc"]),
                    date = Convert.ToDateTime(dr["date"])
                });
            }
            return Json(listrs, JsonRequestBehavior.AllowGet);
        }
        
        //upload

        [HttpPost]
        public ActionResult doc_files(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                string filename = Path.GetFileName(file.FileName);
                string fileext = Path.GetExtension(filename);
                if (fileext == ".pdf" || fileext == ".docx" || fileext == ".xlsx")
                {
                    string filepath = Path.Combine(Server.MapPath("~/Upload"), filename);
                    string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                    SqlConnection sqlconn = new SqlConnection(con);
                    SqlCommand cmd = new SqlCommand("sp_filedoc", sqlconn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    sqlconn.Open();
                    cmd.Parameters.AddWithValue("file_name", filename);
                    cmd.Parameters.AddWithValue("file_ext", fileext);
                    cmd.Parameters.AddWithValue("file_path", filepath);
                    cmd.ExecuteNonQuery();
                    sqlconn.Close();
                    file.SaveAs(filepath);
                }
            }
            return RedirectToAction("doc_files");
        }
        //repoart pdf
        public ActionResult ExportPdfqu()
        {
            DataSet da = dblayer.Getqueueinfo();

            List<queue> listrs = new List<queue>();

            foreach (DataRow dc in da.Tables[0].Rows)
            {
                listrs.Add(new queue
                {
                    Supplier_name = dc["Supplier_name"].ToString(),
                    email = dc["email"].ToString(),
                    account_no = Convert.ToInt32(dc["account_no"]),
                    total_doc = Convert.ToInt32(dc["total_doc"]),
                    date = Convert.ToDateTime(dc["date"])
                });
            }
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report"), "Invoice.rpt"));
            rd.SetDataSource(listrs);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "ReportInvoice.Pdf");
        }
        //excel
        public ActionResult ExportExcelqu()
        {
            DataSet ds = dblayer.Getqueueinfo();

            List<queue> listrs = new List<queue>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                listrs.Add(new queue
                {
                    Supplier_name = dr["Supplier_name"].ToString(),
                    email = dr["email"].ToString(),
                    account_no = Convert.ToInt32(dr["account_no"]),
                    total_doc = Convert.ToInt32(dr["total_doc"]),
                    date = Convert.ToDateTime(dr["date"])
                });
            }
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report"), "Invoice.rpt"));
            rd.SetDataSource(listrs);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.ExcelWorkbook);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "ReportAllInvoice.xlsx");
        }
    }
}