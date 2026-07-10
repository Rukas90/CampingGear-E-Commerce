using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrailStore.Payments.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddCascadeDeleteToPaymentAttempt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentAttempt_Payments_PaymentId",
                schema: "payments",
                table: "PaymentAttempt");

            migrationBuilder.AlterColumn<Guid>(
                name: "PaymentId",
                schema: "payments",
                table: "PaymentAttempt",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentAttempt_Payments_PaymentId",
                schema: "payments",
                table: "PaymentAttempt",
                column: "PaymentId",
                principalSchema: "payments",
                principalTable: "Payments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentAttempt_Payments_PaymentId",
                schema: "payments",
                table: "PaymentAttempt");

            migrationBuilder.AlterColumn<Guid>(
                name: "PaymentId",
                schema: "payments",
                table: "PaymentAttempt",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentAttempt_Payments_PaymentId",
                schema: "payments",
                table: "PaymentAttempt",
                column: "PaymentId",
                principalSchema: "payments",
                principalTable: "Payments",
                principalColumn: "Id");
        }
    }
}
