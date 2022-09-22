using ECommerce.Domain.Customers;
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
            builder.Property(customer => customer.Phone).IsRequired().HasColumnType("varchar(20)");
            builder.Property(customer => customer.Address).IsRequired().HasColumnType("varchar(100)");
            builder.Property(customer => customer.City).IsRequired().HasColumnType("varchar(30)");
            builder.Property(customer => customer.PostalCode).IsRequired().HasColumnType("varchar(10)");
            builder.Property(customer => customer.Country).IsRequired().HasColumnType("varchar(30)");

            builder.HasIndex(customer => customer.Name);
            builder.HasIndex(customer => customer.Email).IsUnique();
        }
    }
}
