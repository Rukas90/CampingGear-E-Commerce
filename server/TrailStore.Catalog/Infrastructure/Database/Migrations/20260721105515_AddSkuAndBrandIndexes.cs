using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrailStore.Catalog.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddSkuAndBrandIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Skus_Stock",
                schema: "catalog",
                table: "Skus",
                column: "Stock");

            migrationBuilder.CreateIndex(
                name: "IX_Skus_UnitPrice",
                schema: "catalog",
                table: "Skus",
                column: "UnitPrice");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_Slug",
                schema: "catalog",
                table: "Brands",
                column: "Slug",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Skus_Stock",
                schema: "catalog",
                table: "Skus");

            migrationBuilder.DropIndex(
                name: "IX_Skus_UnitPrice",
                schema: "catalog",
                table: "Skus");

            migrationBuilder.DropIndex(
                name: "IX_Brands_Slug",
                schema: "catalog",
                table: "Brands");
        }
    }
}
