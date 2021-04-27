using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using chetan.Models;

namespace chetan.Controllers
{
    public class UplodfileController : Controller
    {
        database_Access_Layer.fileinfodb dblayer = new database_Access_Layer.fileinfodb();
        public ActionResult File_info()
        {
            return View();
        }
        public ActionResult File_infoclerk()
        {
            return View();
        }
      
        //get file
        public JsonResult Get_file()
        {
            DataSet ds = dblayer.Get_fileinfo();
            List<documents> listrs = new List<documents>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                listrs.Add(new documents
                {
                    id = Convert.ToInt32(dr["id"]),
                    file_name = dr["file_name"].ToString(),
                    file_ext = dr["file_ext"].ToString(),
                    file_path = dr["file_path"].ToString(),
                  
                });
            }
            return Json(listrs, JsonRequestBehavior.AllowGet);
        }
        //DELETE
        [HttpPost]
        public JsonResult deletefile(int id)
        {
            string res = string.Empty;
            try
            {
                dblayer.deletes_file(id);
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