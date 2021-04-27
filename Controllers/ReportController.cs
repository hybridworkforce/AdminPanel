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
    public class ReportController : Controller
    {
        // GET: Report
        database_Access_Layer.Reprortsupplier dblayer = new database_Access_Layer.Reprortsupplier();
        public ActionResult SupplierReport()
        {
            return View();
        }
        public ActionResult SupplierReportpro()
        {
            return View();
        }
      
        //repoart pdf
        public ActionResult SpExportPdf()
        {
            DataSet ds = dblayer.supplier_repoert();

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
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report"), "SupplierReport.rpt"));
            rd.SetDataSource(listrs);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "ReportAllSupplier.Pdf");
        }
        //excel
        public ActionResult SpExportExcel()
        {
            DataSet ds = dblayer.supplier_repoert();

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
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report"), "SupplierReport.rpt"));
            rd.SetDataSource(listrs);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.ExcelWorkbook);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "ReportAllSupplier.xlsx");
        }

    }
}