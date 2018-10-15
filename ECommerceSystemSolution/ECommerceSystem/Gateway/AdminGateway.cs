using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using ECommerceSystem.Models;
using ECommerceSystem.ViewModel;

namespace ECommerceSystem.Gateway
{
    public class AdminGateway
    {
        private SqlConnection con=new SqlConnection(WebConfigurationManager.ConnectionStrings["ECSDB"].ConnectionString);

        public List<UserType> GetAllUserType()
        {
            string query = @"select * from [dbo].[UserType]";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<UserType> aList = new List<UserType>();
            while (reader.Read())
            {
                UserType userType = new UserType();
                userType.UerTypeId = (int)reader["UserTypeId"];
                userType.UserTypeName = reader["UserTypeName"].ToString();
                aList.Add(userType);
            }
            reader.Close();
            con.Close();
            return aList;
        }
        public List<ProductType> GetAllProductCode()
        {
            string query = @"select * from [dbo].[ProductType]";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<ProductType> aList = new List<ProductType>();
            while (reader.Read())
            {
                ProductType productType = new ProductType();
                productType.ProductTypeId = (int)reader["ProductTypeId"];
                productType.ProductTypeName = reader["ProductTypeName"].ToString();
                aList.Add(productType);
            }
            reader.Close();
            con.Close();
            return aList;
        }
        public List<ProductTypeName> GetProductNameByProductTypeId(int productId)
        {
            string query = @"select * from ProductName where ProductTypeId='"+productId+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<ProductTypeName> aList = new List<ProductTypeName>();
            while (reader.Read())
            {
                ProductTypeName productTypeName = new ProductTypeName();
                productTypeName.ProductNameId = (int)reader["ProductNameId"];
                productTypeName.ProductName = reader["ProductName"].ToString();
                aList.Add(productTypeName);
            }
            reader.Close();
            con.Close();
            return aList;
        }

        public int SaveUser(User user)
        {
            string query = @"INSERT INTO [dbo].[User]
           ([UserTypeId]
           ,[UserName]
           ,[UserEmail]
           ,[UserContactNo]
           ,[DateOfBirth]
           ,[Password])
     VALUES('" + user.UserTypeId + "','" + user.UserName + "','" + user.UserEmail + "','" + user.UserContactNo + "','" + 
               user.DateOfBirth + "','" + user.Password + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int rowAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowAffected;
        }
        public int SaveProduct(Product product)
        {
            string query = @"INSERT INTO [dbo].[Product]
           ([ProductTypeId]
            ,[ProductNameId]
           ,[ProductImage]
           ,[CompanyName]
           ,[ProductDescription]
           ,[ProductPrice])
     VALUES('" + product.ProductTypeId + "','" + product.ProductNameId + "','" + product.UploadFile + "','" + product.CompanyName + "','" + product.Description + "','" + product.ProductPrice + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int rowAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowAffected;
        }
        public List<SalesRecord> GetAllSalesRecord()
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
            con.Close();
            return aList;
        }
        
    }
}