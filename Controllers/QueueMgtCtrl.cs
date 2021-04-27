using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using chetan.Models;

namespace chetan.Controllers
{
    public class QueueMgtCtrl : Controller
    {
        // GET: QueueMgtCtrl
        database_Access_Layer.queuedb dblayer = new database_Access_Layer.queuedb();
        public ActionResult queue()
        {
            return View();
        }
        public ActionResult QueueMgt()
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
    }
}