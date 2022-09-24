using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
public partial class InitialCreate : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Customers",
            columns: table => new
        {
            Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            Name = table.Column<string>(type: "varchar(100)", nullable: false),
            BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            Email = table.Column<string>(type: "varchar(100)", nullable: false),
            Password = table.Column<string>(type: "varchar(20)", nullable: false),
            DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
        },
        constraints: table =>
        {
            table.PrimaryKey("PK_Customers", x => x.Id);
        });

        migrationBuilder.CreateTable(
            name: "Addresses",
            columns: table => new
        {
            Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            Street = table.Column<string>(type: "varchar(50)", nullable: false),
            HouseNumber = table.Column<string>(type: "varchar(10)", nullable: false),
            PhoneNumber = table.Column<string>(type: "varchar(20)", nullable: false),
            Complement = table.Column<string>(type: "varchar(120)", nullable: true),
            District = table.Column<string>(type: "varchar(50)", nullable: false),
            ZipCode = table.Column<string>(type: "varchar(10)", nullable: false),
            City = table.Column<string>(type: "varchar(30)", nullable: false),
            State = table.Column<string>(type: "varchar(30)", nullable: false),
            CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
        },
        constraints: table =>
        {
            table.PrimaryKey("PK_Addresses", x => x.Id);
            table.ForeignKey(
                name: "FK_Addresses_Customers_CustomerId",
                column: x => x.CustomerId,
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        });

        migrationBuilder.CreateIndex(
            name: "IX_Addresses_CustomerId",
            table: "Addresses",
            column: "CustomerId");

        migrationBuilder.CreateIndex(
            name: "IX_Customers_Email",
            table: "Customers",
            column: "Email",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_Customers_Name",
            table: "Customers",
            column: "Name");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Addresses");

        migrationBuilder.DropTable(
            name: "Customers");
    }
}
}
