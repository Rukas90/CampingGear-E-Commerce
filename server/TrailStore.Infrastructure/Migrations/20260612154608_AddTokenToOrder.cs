using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrailStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTokenToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Token",
                table: "Orders");
        }
    }
}
