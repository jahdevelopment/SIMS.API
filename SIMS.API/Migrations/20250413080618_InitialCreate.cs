using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SIMS.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Colour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Brand", "Colour", "Quantity", "Reference", "Size", "UnitPrice" },
                values: new object[] { 1, "Nike", "Black", 15, "NK001", "10", 120.00m });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Brand", "Colour", "Quantity", "Reference", "Size", "UnitPrice" },
                values: new object[] { 2, "Adidas", "White", 10, "AD002", "9", 100.00m });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Brand", "Colour", "Quantity", "Reference", "Size", "UnitPrice" },
                values: new object[] { 3, "Puma", "Blue", 20, "PM003", "8", 90.00m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
