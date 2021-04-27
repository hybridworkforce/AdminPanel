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
    public class contactdb
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        //add contact
        public int contacts(contact ct)
        {
            int sqlExecutionResult;
            SqlCommand cmd = new SqlCommand("sp_contact", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@first_name", ct.first_name);
            cmd.Parameters.AddWithValue("@last_name", ct.last_name);
            cmd.Parameters.AddWithValue("@email", ct.email);
            cmd.Parameters.AddWithValue("@phone", ct.phone);
            cmd.Parameters.AddWithValue("@comment", ct.comment);

            con.Open();
            sqlExecutionResult = cmd.ExecuteNonQuery();
            con.Close();
            return sqlExecutionResult;
        }
        //view
        public DataSet get_contact()
        {
            SqlCommand cmd = new SqlCommand("sp_contact_get", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
}