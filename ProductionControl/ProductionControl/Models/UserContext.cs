using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProductionControl.Models
{
    public class UserContext : DbContext
    {
        public UserContext(string nameOrConnectionString = "DatabaseConnection") : base(nameOrConnectionString)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}