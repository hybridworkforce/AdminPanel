using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace chetan.Models
{
    public class queue
    {
        public string Supplier_name { get; set; }
        public string email { get; set; }
        public int account_no { get; set; }
        public int total_doc { get; set; }
        public DateTime date { get; set; }
    }
}