using ECommerce.Domain.Customers;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) 
        { 

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApiDbContext).Assembly);
        }   

    }
}
