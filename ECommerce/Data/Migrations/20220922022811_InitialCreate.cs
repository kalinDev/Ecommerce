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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(20)", nullable: false),
                    Address = table.Column<string>(type: "varchar(100)", nullable: false),
                    City = table.Column<string>(type: "varchar(30)", nullable: false),
                    PostalCode = table.Column<string>(type: "varchar(10)", nullable: false),
                    Country = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

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
                name: "Customers");
        }
    }
}
