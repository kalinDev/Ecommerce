using ECommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data {
  public class ApiDbContext : DbContext {
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Address> Addresses { get; set; }

    public ApiDbContext(DbContextOptions<ApiDbContext> options)
        : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                   e => e.GetProperties().Where(p => p.ClrType ==
                                                     typeof(string))))
          property.SetColumnType("varchar(100)");

      modelBuilder.ApplyConfigurationsFromAssembly(
          typeof(ApiDbContext).Assembly);
    }
  }
}
