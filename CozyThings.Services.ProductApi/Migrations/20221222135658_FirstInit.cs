using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CozyThings.Services.ProductApi.Migrations
{
    /// <inheritdoc />
    public partial class FirstInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Products",
                columns: new[] { "Id", "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 11, "Chairs", "Some unique description #1...", "https://cozythings.blob.core.windows.net/cozythings/BCN__courtesy_Knoll.jpg", "Ultra Comfy X-Model", 99.980000000000004 },
                    { 12, "Sofas", "Some unique description #2...", "https://cozythings.blob.core.windows.net/cozythings/20-12-2022%2018-24-48.jpg", "Mega Comfy Y-Model", 1099.98 },
                    { 13, "Tables", "Some unique description #3...", "https://cozythings.blob.core.windows.net/cozythings/table-de-repas-design-bois-%C2%A9-17.jpg", "Super Comfy M-Model", 999.98000000000002 },
                    { 14, "Tables", "Some unique description #4...", "https://cozythings.blob.core.windows.net/cozythings/1580774388-16629622_master.jpg", "Giga Comfy R-Model", 1299.98 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products",
                schema: "dbo");
        }
    }
}
