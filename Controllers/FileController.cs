
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace chetan.Controllers
{
    public class FileController : Controller
    {
        // GET: File
       public ActionResult doc_files()
       {
            return View();
        }
        public ActionResult doc_filesproj()
        {
            return View();
        }
        [HttpPost]
        public ActionResult doc_files(HttpPostedFileBase file)
        {
            if(file!=null && file.ContentLength > 0)
            {
                string filename = Path.GetFileName(file.FileName);
                string fileext = Path.GetExtension(filename);
                if(fileext==".pdf" || fileext== ".docx" || fileext== ".xlsx")
                {
                    string filepath = Path.Combine(Server.MapPath("~/Upload"), filename);
                    string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

                    SqlConnection sqlconn = new SqlConnection(con);
                    SqlCommand cmd = new SqlCommand("sp_filedoc",sqlconn);
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
            return View();
        }

    }
}