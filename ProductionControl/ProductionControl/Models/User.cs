using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductionControl.Models
{
    public class User
    {
        private string _password;

        public int UserId;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserRole Role { get; set; }
        public string Password { get; set; }
    }

    public enum UserRole
    {
        Administrator,
        User,
        Official
    }
}