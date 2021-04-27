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
    public class SupplierOnboarddb
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        //add suppliers
        public int suppplier_add(supplieronboard sb)
        {
            int sqlExecutionRes;
            SqlCommand cmd = new SqlCommand("sp_supplier_add",con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@supplier_name",sb.supplier_name);
            cmd.Parameters.AddWithValue("@account_number", sb.account_number);
            cmd.Parameters.AddWithValue("@email", sb.email);
            cmd.Parameters.AddWithValue("@address", sb.address);
            cmd.Parameters.AddWithValue("@document_types", sb.document_types);
            cmd.Parameters.AddWithValue("@file_uploder", sb.file_uploder);
            cmd.Parameters.AddWithValue("@comments", sb.comments);
            cmd.Parameters.AddWithValue("@rules_type",sb.rules_type);
            cmd.Parameters.AddWithValue("@rules", sb.rules);
            cmd.Parameters.AddWithValue("@signature_by", sb.signature_by);
            cmd.Parameters.AddWithValue("@date", DateTime.Now);

            con.Open();
            sqlExecutionRes = cmd.ExecuteNonQuery();
            con.Close();
            return sqlExecutionRes;
        }
        //all display data
        public DataSet get_supplier_info()
        {
            SqlCommand cmd = new SqlCommand("Sp_supplier_get", con);

            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();

            da.Fill(ds);

            return ds;
        }
        //UPDATE supplier
       public int update_supplier(supplieronboard rs)
        {
            int sqlExecutionResult;
            SqlCommand cmd = new SqlCommand("sp_supplierupdate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@supplier_id", rs.supplier_id);
            cmd.Parameters.AddWithValue("@supplier_name", rs.supplier_name);
            cmd.Parameters.AddWithValue("@account_number", rs.account_number);
            cmd.Parameters.AddWithValue("@email", rs.email);
            cmd.Parameters.AddWithValue("@address", rs.address);
            cmd.Parameters.AddWithValue("@document_type", rs.document_types);
            cmd.Parameters.AddWithValue("@file_uploder", rs.file_uploder);
            cmd.Parameters.AddWithValue("@comments", rs.comments);
            cmd.Parameters.AddWithValue("@rules_type", rs.rules_type);
            cmd.Parameters.AddWithValue("@rules", rs.rules);
            cmd.Parameters.AddWithValue("@signature_by", rs.signature_by);
            cmd.Parameters.AddWithValue("@date", DateTime.Now);
            con.Open();
            sqlExecutionResult = cmd.ExecuteNonQuery();
            con.Close();
            return sqlExecutionResult;
        }
        //GET USER BY ID
        public DataSet Get_supplierbyid(int id)
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
        public void delete_supplier(int id)
        {
            SqlCommand com = new SqlCommand("sp_supplierdel", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@supplier_id", id);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        //report savw view
        public int report_add(reports re)
        {
            int sqlExecutionRes;
            SqlCommand cmd = new SqlCommand("sp_reports_add", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@report_name", re.report_name);
            cmd.Parameters.AddWithValue("@supplier_id", re.supplier_id);
            cmd.Parameters.AddWithValue("@supplier_name", re.supplier_name);
            cmd.Parameters.AddWithValue("@account_number", re.account_number);
            cmd.Parameters.AddWithValue("@email", re.email);
            cmd.Parameters.AddWithValue("@address", re.address);
            cmd.Parameters.AddWithValue("@document_types", re.document_types);
            cmd.Parameters.AddWithValue("@comments", re.comments);
            cmd.Parameters.AddWithValue("@rules_type", re.rules_type);
            cmd.Parameters.AddWithValue("@rules", re.rules);

            con.Open();
            sqlExecutionRes = cmd.ExecuteNonQuery();
            con.Close();
            return sqlExecutionRes;
        }


    }
}