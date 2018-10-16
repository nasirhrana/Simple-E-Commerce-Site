using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using ECommerceSystem.Models;

namespace ECommerceSystem.Gateway
{
    public class SupplierGateway
    {
        private SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ECSDB"].ConnectionString);
        public List<SalesRecord> GetAllSalesRecord()
        {
            try
            {
                string query = @"select * from SalesRecord ";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<SalesRecord> aList = new List<SalesRecord>();
                while (reader.Read())
                {
                    SalesRecord salesRecord = new SalesRecord();
                    salesRecord.SalesRecordId = (int)reader["SalesId"];
                    salesRecord.ProductId = (int)reader["ProductId"];
                    salesRecord.CustomerId = (int)reader["CustomerId"];
                    aList.Add(salesRecord);
                }
                reader.Close();
                return aList;
            }
            catch (Exception exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }


        }
    }
}