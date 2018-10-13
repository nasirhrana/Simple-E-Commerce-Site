using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerceSystem.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Please Select User Type")]
        public int UserTypeId { get; set; }
        [Required(ErrorMessage = "Please Enter User Name ")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please Enter Email ")]
        [EmailAddress]
        public string UserEmail { get; set; }
        [Required(ErrorMessage = "Please Enter Contact NO ")]
        [RegularExpression("([0-9]+)")] 
        public string UserContactNo { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Please Enter Password ")]
        
        public string Password { get; set; }
        [Required(ErrorMessage = "Please Re-Enter Password ")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}