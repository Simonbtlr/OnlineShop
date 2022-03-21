using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace OnlineShop.Server.Migrations
{
    public partial class ProductVarients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductVariants",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    ProductTypeId = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    OriginalPrice = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariants", x => new { x.ProductId, x.ProductTypeId });
                    table.ForeignKey(
                        name: "FK_ProductVariants_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductVariants_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "По умолчанию" },
                    { 2, "В мягкой обложке" },
                    { 3, "Электронная книга" },
                    { 4, "Аудиокнига" },
                    { 5, "Стрим" },
                    { 6, "Blu-ray" },
                    { 7, "VHS" },
                    { 8, "PC" },
                    { 9, "PlayStation" },
                    { 10, "Xbox" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/ru/b/bb/Half-Life_Alyx_Coverart.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/ru/e/ee/Detroit_Become_Human.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "https://elamigosedition.com/uploads/posts/2021-02/1613136021_valheim-cover-download.webp");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "https://i.redd.it/roocnhykls851.png");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImageUrl",
                value: "https://cdn.ananasposter.ru/image/cache/catalog/poster/games/80/26094-1000x830.jpg");

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "ProductId", "ProductTypeId", "OriginalPrice", "Price" },
                values: new object[,]
                {
                    { 1, 2, 1645m, 1565.75m },
                    { 1, 3, 0m, 1530.85m },
                    { 1, 4, 1645m, 1480.5m },
                    { 2, 2, 1830m, 1740.5m },
                    { 3, 2, 0m, 925.25m },
                    { 4, 5, 0m, 225.25m },
                    { 4, 6, 0m, 290m },
                    { 4, 7, 0m, 149.5m },
                    { 5, 5, 0m, 225.25m },
                    { 6, 5, 0m, 225.5m },
                    { 7, 8, 1085m, 920.25m },
                    { 7, 9, 0m, 1030.75m },
                    { 7, 10, 1085m, 1009.05m },
                    { 8, 8, 1628m, 1383.8m },
                    { 9, 8, 0m, 369.75m },
                    { 10, 1, 515m, 360.5m },
                    { 11, 1, 599m, 419.3m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_ProductTypeId",
                table: "ProductVariants",
                column: "ProductTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductVariants");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "numeric(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 1645m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 1830m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 975m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Price",
                value: 299m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "Price",
                value: 299m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "Price",
                value: 299m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ImageUrl", "Price" },
                values: new object[] { "https://cdn.akamai.steamstatic.com/steam/apps/546560/header.jpg?t=1641577012", 1085m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ImageUrl", "Price" },
                values: new object[] { "https://cdn.akamai.steamstatic.com/steam/apps/1222140/header.jpg?t=1625648054", 1628m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ImageUrl", "Price" },
                values: new object[] { "https://cdn.akamai.steamstatic.com/steam/apps/892970/header.jpg?t=1647419457", 435m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ImageUrl", "Price" },
                values: new object[] { "https://cdn.akamai.steamstatic.com/steam/apps/620980/header.jpg?t=1622461922", 515m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ImageUrl", "Price" },
                values: new object[] { "https://cdn.akamai.steamstatic.com/steam/apps/526870/header.jpg?t=1637686926", 599m });
        }
    }
}
