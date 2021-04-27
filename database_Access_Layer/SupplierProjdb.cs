using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using chetan.Models;
using System.IO;

namespace chetan.database_Access_Layer
{
    public class SupplierProjdb
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        //add suppliers
        public int Supp_add(supplieronboard sb)
        {
            int sqlExecutionRes;
            SqlCommand cmd = new SqlCommand("sp_supplier_add", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@supplier_name", sb.supplier_name);
            cmd.Parameters.AddWithValue("@account_number", sb.account_number);
            cmd.Parameters.AddWithValue("@email", sb.email);
            cmd.Parameters.AddWithValue("@address", sb.address);
            cmd.Parameters.AddWithValue("@document_types", sb.document_types);
            cmd.Parameters.AddWithValue("@comments", sb.comments);
            cmd.Parameters.AddWithValue("@rules_type", sb.rules_type);
            cmd.Parameters.AddWithValue("@rules", sb.rules);
            cmd.Parameters.AddWithValue("@signature_by", sb.signature_by);

            con.Open();
            sqlExecutionRes = cmd.ExecuteNonQuery();
            con.Close();
            return sqlExecutionRes;
        }
        //add suppliers file
        public int Supp_add_file(supplieronboard sb)
        {
            int sqlExecutionRes;
            SqlCommand cmd = new SqlCommand("sp_supplier_add_file", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@supplier_id", sb.supplier_id);
            cmd.Parameters.AddWithValue("@file_name", sb.file_name);
            cmd.Parameters.AddWithValue("@file_uploder", sb.file_uploder);

            con.Open();
            sqlExecutionRes = cmd.ExecuteNonQuery();
            con.Close();
            return sqlExecutionRes;
        }
        //all suplier view
        public DataSet getsuppliersinfo()
        {
            SqlCommand cmd = new SqlCommand("Sp_supplier_get", con);

            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();

            da.Fill(ds);

            return ds;
        }
        //GET USER BY ID
        public DataSet Getsupplierbyids(int id)
        {
            SqlCommand cmd = new SqlCommand("sp_supplibyid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@supplier_id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        // Delete record
        public void deletesuppliers(int id)
        {
            SqlCommand com = new SqlCommand("sp_supplierdel", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@supplier_id", id);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
    }
}