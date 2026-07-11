using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrailStore.Ordering.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCheckoutSessionIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "ordering",
                table: "CheckoutSessions");

            migrationBuilder.RenameColumn(
                name: "SessionId",
                schema: "ordering",
                table: "CheckoutSessions",
                newName: "CartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CartId",
                schema: "ordering",
                table: "CheckoutSessions",
                newName: "SessionId");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "ordering",
                table: "CheckoutSessions",
                type: "uuid",
                nullable: true);
        }
    }
}
