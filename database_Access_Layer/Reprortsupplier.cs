using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using chetan.Models;

namespace chetan.database_Access_Layer
{
    public class Reprortsupplier
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        public DataSet supplier_repoert()
        {
            SqlCommand cmd = new SqlCommand("Sp_supplier_get", con);

            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();

            da.Fill(ds);

            return ds;
        }
       
    }
}