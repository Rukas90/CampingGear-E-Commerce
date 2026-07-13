using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrailStore.Ordering.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdToCheckoutWithCheckConstraintForEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "ordering",
                table: "CheckoutSessions",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_CheckoutSessions_EmailRequiredForUser",
                schema: "ordering",
                table: "CheckoutSessions",
                sql: "\"UserId\" IS NULL OR \"EmailAddress\" IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_CheckoutSessions_EmailRequiredForUser",
                schema: "ordering",
                table: "CheckoutSessions");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "ordering",
                table: "CheckoutSessions");
        }
    }
}
