using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrailStore.Ordering.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class ReduceTokenLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Token",
                schema: "ordering",
                table: "Orders",
                type: "character(25)",
                fixedLength: true,
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character(26)",
                oldFixedLength: true,
                oldMaxLength: 26);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                oldType: "character(25)",
                oldFixedLength: true,
                oldMaxLength: 25);
        }
    }
}
