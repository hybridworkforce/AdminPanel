using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace chetan.Models
{
    public class documents
    {
        public int id { get; set; }
        public string file_name { get; set; }
        public string file_ext { get; set; }
        public string file_path { get; set; }
       
    }
}