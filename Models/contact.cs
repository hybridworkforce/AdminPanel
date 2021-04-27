using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace chetan.Models
{
    public class contact
    {
        public int contact_id { get; set; }
        public String first_name { get; set; }
        public String last_name { get; set; }
        public String email { get; set; }
        public String phone { get; set; }
        public String comment { get; set; }
    }
}