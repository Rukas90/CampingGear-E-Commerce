using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrailStore.Basket.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class RenameFromShoppingSessionsToCarts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_ShoppingSessions_CartId",
                schema: "basket",
                table: "CartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingSessions",
                schema: "basket",
                table: "ShoppingSessions");

            migrationBuilder.RenameTable(
                name: "ShoppingSessions",
                schema: "basket",
                newName: "Carts",
                newSchema: "basket");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                schema: "basket",
                table: "Carts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Carts_CartId",
                schema: "basket",
                table: "CartItems",
                column: "CartId",
                principalSchema: "basket",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Carts_CartId",
                schema: "basket",
                table: "CartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                schema: "basket",
                table: "Carts");

            migrationBuilder.RenameTable(
                name: "Carts",
                schema: "basket",
                newName: "ShoppingSessions",
                newSchema: "basket");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingSessions",
                schema: "basket",
                table: "ShoppingSessions",
                column: "Id");

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
    }
}
