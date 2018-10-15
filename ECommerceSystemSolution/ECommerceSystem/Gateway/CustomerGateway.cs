using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using ECommerceSystem.Models;

namespace ECommerceSystem.Gateway
{
    public class CustomerGateway
    {
        private SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ECSDB"].ConnectionString);

        public List<Product> GetProductListByProductTypeId(int productTypeId)
        {
            string query = @"select * from [dbo].[Product] where ProductTypeId='" + productTypeId + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Product> aList = new List<Product>();
            while (reader.Read())
            {
                Product product = new Product();
                product.ProductId = (int)reader["ProductId"];
                product.ProductTypeId = (int)reader["ProductTypeId"];
                product.ProductNameId = (int)reader["ProductNameId"];
                product.UploadFile = reader["ProductImage"].ToString();
                product.Description = reader["ProductDescription"].ToString();
                product.CompanyName = reader["CompanyName"].ToString();
                product.ProductPrice = Convert.ToDouble(reader["ProductPrice"].ToString());
                aList.Add(product);
            }
            reader.Close();
            con.Close();
            return aList;
        }
        public Product GetProductByProductTypeId(int productTypeId)
        {
            string query = @"select * from [dbo].[Product] where ProductTypeId='" + productTypeId + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            Product product = new Product();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                product.ProductId = (int)reader["ProductId"];
                product.ProductTypeId = (int)reader["ProductTypeId"];
                product.ProductNameId = (int)reader["ProductNameId"];
                product.UploadFile = reader["ProductImage"].ToString();
                product.Description = reader["ProductDescription"].ToString();
                product.CompanyName = reader["CompanyName"].ToString();
                product.ProductPrice = Convert.ToDouble(reader["ProductPrice"].ToString());
            }
            reader.Close();
            con.Close();
            return product;
        }
        public Product GetProductByProductId(int productId)
        {
            string query = @"select * from [dbo].[Product] where ProductId='" + productId + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            Product product = new Product();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                product.ProductId = (int)reader["ProductId"];
                product.ProductTypeId = (int)reader["ProductTypeId"];
                product.ProductNameId = (int)reader["ProductNameId"];
                product.UploadFile = reader["ProductImage"].ToString();
                product.Description = reader["ProductDescription"].ToString();
                product.CompanyName = reader["CompanyName"].ToString();
                product.ProductPrice = Convert.ToDouble(reader["ProductPrice"].ToString());
            }
            reader.Close();
            con.Close();
            return product;
        }

        public int SendOrder(SalesRecord record)
        {
            string query = @"INSERT INTO [dbo].[SalesRecord]
           ([CustomerId]
           ,[ProductId])
     VALUES('" + record.CustomerId + "','" + record.ProductId + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int rowAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowAffected;
        }
        public bool IsSellOrderAlreadyExist(SalesRecord record)
        {
            string query = @"SELECT * FROM SalesRecord WHERE (ProductId=@ProductId and CustomerId=@CustomerId)";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            bool isExist = false;
            cmd.Parameters.AddWithValue("@ProductId", record.ProductId);
            cmd.Parameters.AddWithValue("@CustomerId", record.CustomerId);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            isExist = reader.HasRows;
            reader.Close();
            con.Close();
            return isExist;
        }
    }
}