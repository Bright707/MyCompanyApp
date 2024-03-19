using Microsoft.EntityFrameworkCore;
using MyCompanyAPI.Models;

namespace MyCompanyAPI.Data
{
    public class MyCompanyDbContext : DbContext
    {
        public MyCompanyDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Project> Projects { get; set; }
        public DbSet<Customer> Customers { get; set; }  
        public DbSet<Employee> Employees { get; set; }  
    }
}
