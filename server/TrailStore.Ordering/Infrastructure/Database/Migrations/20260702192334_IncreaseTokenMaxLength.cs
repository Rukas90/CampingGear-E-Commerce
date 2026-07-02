using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrailStore.Ordering.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class IncreaseTokenMaxLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Token",
                schema: "ordering",
                table: "Orders",
                type: "character(26)",
                fixedLength: true,
                maxLength: 26,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character(15)",
                oldFixedLength: true,
                oldMaxLength: 15);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Token",
                schema: "ordering",
                table: "Orders",
                type: "character(15)",
                fixedLength: true,
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character(26)",
                oldFixedLength: true,
                oldMaxLength: 26);
        }
    }
}
