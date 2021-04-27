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
    public class singupdb
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
         //ADD_USER
        public int Add_record(registration rs)
        {
            int sqlExecutionResult;
            SqlCommand cmd = new SqlCommand("Sp_userinfo", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@user_name", rs.user_name);
            cmd.Parameters.AddWithValue("@first_name", rs.first_name);
            cmd.Parameters.AddWithValue("@last_name", rs.last_name);
            cmd.Parameters.AddWithValue("@email", rs.email);
            cmd.Parameters.AddWithValue("@password", rs.password);
            cmd.Parameters.AddWithValue("@address", rs.address);
            cmd.Parameters.AddWithValue("@mobile", rs.mobile);
            cmd.Parameters.AddWithValue("@country", rs.country);
            cmd.Parameters.AddWithValue("@state", rs.state);
            cmd.Parameters.AddWithValue("@city", rs.city);
            cmd.Parameters.AddWithValue("@user_role_id", rs.user_role_id);

            con.Open();
            sqlExecutionResult = cmd.ExecuteNonQuery();
            con.Close();
            return sqlExecutionResult;
        }
        //GET_USER_DATA
        public DataSet Get_userinfo()
        {
            SqlCommand cmd = new SqlCommand("sp_user_get", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        //GET USER BY ID
        public DataSet Get_userinfobyid(int id)
        {
            SqlCommand cmd = new SqlCommand("sp_userbyid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@user_id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        //UPDATE
       public int update_user(registration rs)
           {
               int sqlExecutionResult;
               SqlCommand cmd = new SqlCommand("sp_user_update", con);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@user_id", rs.user_id);
               cmd.Parameters.AddWithValue("@user_name", rs.user_name);
               cmd.Parameters.AddWithValue("@first_name", rs.first_name);
               cmd.Parameters.AddWithValue("@last_name", rs.last_name);
               cmd.Parameters.AddWithValue("@email", rs.email);
               cmd.Parameters.AddWithValue("@password", rs.password);
               cmd.Parameters.AddWithValue("@address", rs.address);
               cmd.Parameters.AddWithValue("@mobile", rs.mobile);
               cmd.Parameters.AddWithValue("@country", rs.country);
               cmd.Parameters.AddWithValue("@state", rs.state);
               cmd.Parameters.AddWithValue("@city", rs.city);
               cmd.Parameters.AddWithValue("@user_role_id", rs.user_role_id);

               con.Open();
               sqlExecutionResult = cmd.ExecuteNonQuery();
               con.Close();
               return sqlExecutionResult;
       }

        // Delete record
        public void deletedata(int id)
        {
            SqlCommand com = new SqlCommand("sp_userdel", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@user_id", id);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        //report
        public DataSet reportuser()
        {
            SqlCommand cmd = new SqlCommand("sp_user_get", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        //excel report
        public DataSet excel()
        {
            SqlCommand cmd = new SqlCommand("sp_user_get", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
}