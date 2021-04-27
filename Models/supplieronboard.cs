using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace chetan.Models
{
    public class supplieronboard
    {
        public int supplier_id { get; set; }
        public string supplier_name { get; set; }
        public int account_number { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string document_types { get; set; }
        public string file_name { get; set; }
        public string file_uploder { get; set; }
        public string comments { get; set; }
        public string rules_type { get; set; }
        public string rules { get; set; }
        public string signature_by { get; set; }
        public DateTime date { get; set; }
    }
    public class reports
    {
        public int report_id { get; set; }
        public string report_name { get; set; }
        public int supplier_id { get; set; }
        public string supplier_name { get; set; }
        public string account_number { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string document_types { get; set; }
        public string comments { get; set; }
        public string rules_type { get; set; }
        public string rules { get; set; }
    }
}