using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrailStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckoutSessions_ShippingMethods_ShippingMethodId",
                table: "CheckoutSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Options_OptionGroups_OptionGroupId",
                table: "Options");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckoutSessions_ShippingMethods_ShippingMethodId",
                table: "CheckoutSessions",
                column: "ShippingMethodId",
                principalTable: "ShippingMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Options_OptionGroups_OptionGroupId",
                table: "Options",
                column: "OptionGroupId",
                principalTable: "OptionGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckoutSessions_ShippingMethods_ShippingMethodId",
                table: "CheckoutSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Options_OptionGroups_OptionGroupId",
                table: "Options");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckoutSessions_ShippingMethods_ShippingMethodId",
                table: "CheckoutSessions",
                column: "ShippingMethodId",
                principalTable: "ShippingMethods",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Options_OptionGroups_OptionGroupId",
                table: "Options",
                column: "OptionGroupId",
                principalTable: "OptionGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
