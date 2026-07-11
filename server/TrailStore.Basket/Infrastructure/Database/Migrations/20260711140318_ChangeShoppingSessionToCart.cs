using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrailStore.Basket.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class ChangeShoppingSessionToCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_ShoppingSessions_SessionId",
                schema: "basket",
                table: "CartItems");

            migrationBuilder.RenameColumn(
                name: "SessionId",
                schema: "basket",
                table: "CartItems",
                newName: "CartId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_SessionId",
                schema: "basket",
                table: "CartItems",
                newName: "IX_CartItems_CartId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "basket",
                table: "ShoppingSessions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_ShoppingSessions_CartId",
                schema: "basket",
                table: "CartItems",
                column: "CartId",
                principalSchema: "basket",
                principalTable: "ShoppingSessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_ShoppingSessions_CartId",
                schema: "basket",
                table: "CartItems");

            migrationBuilder.RenameColumn(
                name: "CartId",
                schema: "basket",
                table: "CartItems",
                newName: "SessionId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_CartId",
                schema: "basket",
                table: "CartItems",
                newName: "IX_CartItems_SessionId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "basket",
                table: "ShoppingSessions",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_ShoppingSessions_SessionId",
                schema: "basket",
                table: "CartItems",
                column: "SessionId",
                principalSchema: "basket",
                principalTable: "ShoppingSessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
