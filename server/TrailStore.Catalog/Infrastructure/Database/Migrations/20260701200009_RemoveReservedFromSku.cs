using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrailStore.Catalog.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class RemoveReservedFromSku : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reserved",
                schema: "catalog",
                table: "Skus");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Reserved",
                schema: "catalog",
                table: "Skus",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
