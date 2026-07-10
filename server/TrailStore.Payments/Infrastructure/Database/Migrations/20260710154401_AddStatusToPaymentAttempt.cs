using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrailStore.Payments.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusToPaymentAttempt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "payments",
                table: "Payments",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                schema: "payments",
                table: "Payments");
        }
    }
}
