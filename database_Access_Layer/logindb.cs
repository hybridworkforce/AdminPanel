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
    public class logindb
    {
        int userRole = 0;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        //check id & password vaild
        public int userlogin(registration us)
        {   
            //call sp

            SqlCommand cmd = new SqlCommand("sp_user_login",con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@email",us.email);
            cmd.Parameters.AddWithValue("@password", us.password);
           
            
            SqlParameter oblogin = new SqlParameter();
            //oblogin.ParameterName = "@Isvalid";
            //oblogin.Direction = ParameterDirection.Output;
            //oblogin.SqlDbType = SqlDbType.Bit;
            //cmd.Parameters.Add(oblogin);
            con.Open();
            
            int res = 0;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    res = (int)reader["user_id"];
                    userRole = (int)reader["user_role_id"];
                }
                if(res > 0)
                {
                    userRole = (int)reader["user_role_id"];
                }
                else
                {
                    userRole = -1;
                }
            }
            con.Close();
            return userRole;

        }
    }
}