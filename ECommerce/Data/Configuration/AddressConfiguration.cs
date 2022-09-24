using ECommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Data.Configuration
{
public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Addresses");
        builder.HasKey(address => address.Id);
        builder.Property(address => address.Id).ValueGeneratedOnAdd();
        builder.Property(address => address.City).IsRequired().HasColumnType("varchar(30)");
        builder.Property(address => address.ZipCode).IsRequired().HasColumnType("varchar(10)");
        builder.Property(address => address.Complement).HasColumnType("varchar(120)");
        builder.Property(address => address.District).IsRequired().HasColumnType("varchar(50)");
        builder.Property(address => address.HouseNumber).IsRequired().HasColumnType("varchar(10)");
        builder.Property(address => address.PhoneNumber).IsRequired().HasColumnType("varchar(20)");
        builder.Property(address => address.Street).IsRequired().HasColumnType("varchar(50)");
        builder.Property(address => address.State).IsRequired().HasColumnType("varchar(30)");

        builder.HasOne(address => address.Customer).WithMany(customer => customer.Addresses).HasForeignKey(address => address.CustomerId);
    }
}
}
