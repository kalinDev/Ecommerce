using ECommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Data.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(customer => customer.Id);
            builder.Property(customer => customer.Id).ValueGeneratedOnAdd();
            builder.Property(customer => customer.Name).IsRequired().HasColumnType("varchar(100)");
            builder.Property(customer => customer.Email).IsRequired().HasColumnType("varchar(100)");
            builder.Property(customer => customer.DeletedAt).HasColumnType("datetime2");
            builder.Property(customer => customer.BirthDate).IsRequired().HasColumnType("datetime2");
            builder.Property(customer => customer.Password).IsRequired().HasColumnType("varchar(20)");

            builder.HasMany(customer => customer.Addresses).WithOne(address => address.Customer).HasForeignKey(address => address.CustomerId).OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(customer => customer.Name);
            builder.HasIndex(customer => customer.Email).IsUnique();
        }
    }
}
