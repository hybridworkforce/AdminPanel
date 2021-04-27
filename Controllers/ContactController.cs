using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using chetan.Models;

namespace chetan.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        database_Access_Layer.contactdb dblayer = new database_Access_Layer.contactdb();
        public ActionResult contact()
        {
            return View();
        }
        public ActionResult contact_info()
        {
            return View();
        }
        //add contacts
        public JsonResult contacts(contact cs)
        {
            string result = string.Empty;
            try
            {
                if (dblayer.contacts(cs) > 0)
                    result = "data inserted sucessfully";
                else
                    result = "failed";
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception here" + e);
                result = "failed";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        //all contact info
        public JsonResult Get_info_contact()
        {
            DataSet cs = dblayer.get_contact();
            List<contact> listrs = new List<contact>();
            foreach (DataRow cr in cs.Tables[0].Rows)
            {
                listrs.Add(new contact
                {
                    contact_id = Convert.ToInt32(cr["contact_id"]),
                    first_name = cr["first_name"].ToString(),
                    last_name = cr["last_name"].ToString(),
                    email = cr["email"].ToString(),
                    phone = cr["phone"].ToString(),
                    comment = cr["comment"].ToString(),
                   
                });
            }   
            return Json(listrs, JsonRequestBehavior.AllowGet);
        }


    }
}