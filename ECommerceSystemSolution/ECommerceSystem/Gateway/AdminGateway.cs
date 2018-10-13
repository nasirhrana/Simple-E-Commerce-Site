using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using ECommerceSystem.Models;

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
    }
}