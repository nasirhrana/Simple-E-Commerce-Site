using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using ECommerceSystem.Models;

namespace ECommerceSystem.Gateway
{
    public class LoginGateway
    {
        private SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ECSDB"].ConnectionString);
        public List<User> CheckAccount(LoginModel aLogin)
        {
            try
            {
                string query = @"SELECT [UserId]
      ,[UserTypeId]
      ,[UserName]
      ,[UserEmail]
      ,[UserContactNo]
      ,[DateOfBirth]
      ,[Password]
  FROM [dbo].[User] where UserEmail='"+aLogin.Email+"' and Password='"+aLogin.Password+"'";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<User> aList = new List<User>();
                while (reader.Read())
                {
                    User user = new User();
                    user.UserId = (int)reader["UserId"];
                    user.UserTypeId = (int)reader["UserTypeId"];
                    user.UserName = reader["UserName"].ToString();
                    user.UserEmail = reader["UserEmail"].ToString();
                    aList.Add(user);
                   
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