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
    public class rulebookdb
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        //Display all record
        public DataSet get_rule_info()
        {
            SqlCommand cmd = new SqlCommand("Sp_getrules", con);

            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();

            da.Fill(ds);

            return ds;
        }
        //id by rules
       
        public DataSet Get_rulebyid(int id)
        {
            SqlCommand cmd = new SqlCommand("sp_rulebyid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@supplier_id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        //UPDATE supplier
        public int update_rule(supplieronboard rs)
        {
            int sqlExecutionResult;
            SqlCommand cmd = new SqlCommand("sp_rulespplierupdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@supplier_id", rs.supplier_id);
            cmd.Parameters.AddWithValue("@supplier_name", rs.supplier_name);            
            cmd.Parameters.AddWithValue("@rules_type", rs.rules_type);
            cmd.Parameters.AddWithValue("@rules", rs.rules);
          
            con.Open();
            sqlExecutionResult = cmd.ExecuteNonQuery();
            con.Close();
            return sqlExecutionResult;
        }
        //report pdf or excel
        public DataSet Report_rule()
        {
            SqlCommand cmd = new SqlCommand("Sp_getrules", con);

            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();

            da.Fill(ds);

            return ds;
        }


    }
}