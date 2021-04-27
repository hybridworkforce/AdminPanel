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
    public class QueueMgtdb
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        //ADD_queue
        public int Add_queue(queue rs)
        {
            int sqlExecutionResult;
            SqlCommand cmd = new SqlCommand("Sp_queueadd", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Supplier_name", rs.Supplier_name);
            cmd.Parameters.AddWithValue("@email", rs.email);
            cmd.Parameters.AddWithValue("@account_no", rs.account_no);
            cmd.Parameters.AddWithValue("@total_doc", rs.total_doc);
            cmd.Parameters.AddWithValue("@date", rs.date);

            con.Open();
            sqlExecutionResult = cmd.ExecuteNonQuery();
            con.Close();
            return sqlExecutionResult;
        }
        //GET_QUEUE_DATA
        public DataSet Get_queueinfo()
        {
            SqlCommand cmd = new SqlCommand("sp_queue", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
}