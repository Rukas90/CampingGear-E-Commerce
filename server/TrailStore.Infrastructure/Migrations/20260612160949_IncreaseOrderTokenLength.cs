using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrailStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IncreaseOrderTokenLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "Orders",
                type: "character(32)",
                fixedLength: true,
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character(22)",
                oldFixedLength: true,
                oldMaxLength: 22);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "Orders",
                type: "character(22)",
                fixedLength: true,
                maxLength: 22,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character(32)",
                oldFixedLength: true,
                oldMaxLength: 32);
        }
    }
}
