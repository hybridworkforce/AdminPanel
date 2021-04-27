using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace chetan.Models
{
    public class registration
    {
        public int user_id { get; set; }
      
        public String user_name { get; set; }
        public String first_name { get; set; }
        public String last_name { get; set; }
        public String email { get; set; }
        public String password { get; set; }
        public String address { get; set; }
        public String mobile { get; set; }
        public String country { get; set; }
        public String state { get; set; }
        public String city { get; set; }

        public int user_role_id { get; set; }
    }
}