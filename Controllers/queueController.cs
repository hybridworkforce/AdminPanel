using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using chetan.Models;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;

namespace chetan.Controllers
{
    public class queueController : Controller
    {
        // GET: queue
        database_Access_Layer.queuedb dblayer = new database_Access_Layer.queuedb();
        public ActionResult queue()
        {
            return View();
        }
        public ActionResult queuedata()
        {
            return View();
        }
        public JsonResult queue_add(queue rs)
        {
            string result = string.Empty;
            try
            {
                if (dblayer.Add_queue(rs) > 0)
                    result = "successsfully!";
                else
                    result = "Failed !!";
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception here" + e);
                result = "failed";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult get_queue()
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