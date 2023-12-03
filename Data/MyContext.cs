using InsuranceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace InsuranceApp.Data
{
    public class MyContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<InsurancePlan> InsurancePlans { get; set; }
        public DbSet<InsurancePolicy> InsurancePolicies { get; set; }
        public DbSet<InsuranceScheme> InsuranceSchemes { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<SchemeDetails> SchemeDetails { get; set; }
        public DbSet<Admin> Admins { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options) { }


    }
}
