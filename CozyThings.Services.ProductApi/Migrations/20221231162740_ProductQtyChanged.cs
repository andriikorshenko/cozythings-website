using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CozyThings.Services.ProductApi.Migrations
{
    /// <inheritdoc />
    public partial class ProductQtyChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImageUrl",
                value: "https://cozythings.blob.core.windows.net/cozythings/chair-1.jpg");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImageUrl",
                value: "https://cozythings.blob.core.windows.net/cozythings/sofa-1.jpg");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImageUrl",
                value: "https://cozythings.blob.core.windows.net/cozythings/table-1.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImageUrl",
                value: "https://cozythings.blob.core.windows.net/cozythings/BCN__courtesy_Knoll.jpg");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImageUrl",
                value: "https://cozythings.blob.core.windows.net/cozythings/20-12-2022%2018-24-48.jpg");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImageUrl",
                value: "https://cozythings.blob.core.windows.net/cozythings/table-de-repas-design-bois-%C2%A9-17.jpg");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Products",
                columns: new[] { "Id", "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 14, "Tables", "Some unique description #4...", "https://cozythings.blob.core.windows.net/cozythings/1580774388-16629622_master.jpg", "Giga Comfy R-Model", 1299.98 });
        }
    }
}
