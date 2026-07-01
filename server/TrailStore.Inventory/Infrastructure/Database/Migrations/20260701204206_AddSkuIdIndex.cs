using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrailStore.Inventory.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddSkuIdIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_SkuId",
                schema: "inventory",
                table: "InventoryItems",
                column: "SkuId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InventoryItems_SkuId",
                schema: "inventory",
                table: "InventoryItems");
        }
    }
}
