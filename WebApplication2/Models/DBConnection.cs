using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class DBConnection : DbContext
    {
        public DbSet<Dapartment> Dapartment { get; set; }
        public DbSet<Employee> Employee { get; set; }
    }
}