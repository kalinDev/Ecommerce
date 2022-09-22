﻿// <auto-generated />
using ECommerce.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ECommerce.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20220922022811_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ECommerce.Domain.Customers.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Name");

                    b.ToTable("Customers", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
