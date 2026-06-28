using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrailStore.Ordering.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class ApplyConfigurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShippingMethod_ShippingZone_ZoneId",
                schema: "ordering",
                table: "ShippingMethod");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShippingZone",
                schema: "ordering",
                table: "ShippingZone");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShippingMethod",
                schema: "ordering",
                table: "ShippingMethod");

            migrationBuilder.RenameTable(
                name: "ShippingZone",
                schema: "ordering",
                newName: "ShippingZones",
                newSchema: "ordering");

            migrationBuilder.RenameTable(
                name: "ShippingMethod",
                schema: "ordering",
                newName: "ShippingMethods",
                newSchema: "ordering");

            migrationBuilder.RenameIndex(
                name: "IX_ShippingMethod_ZoneId",
                schema: "ordering",
                table: "ShippingMethods",
                newName: "IX_ShippingMethods_ZoneId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShippingZones",
                schema: "ordering",
                table: "ShippingZones",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShippingMethods",
                schema: "ordering",
                table: "ShippingMethods",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingMethods_ShippingZones_ZoneId",
                schema: "ordering",
                table: "ShippingMethods",
                column: "ZoneId",
                principalSchema: "ordering",
                principalTable: "ShippingZones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShippingMethods_ShippingZones_ZoneId",
                schema: "ordering",
                table: "ShippingMethods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShippingZones",
                schema: "ordering",
                table: "ShippingZones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShippingMethods",
                schema: "ordering",
                table: "ShippingMethods");

            migrationBuilder.RenameTable(
                name: "ShippingZones",
                schema: "ordering",
                newName: "ShippingZone",
                newSchema: "ordering");

            migrationBuilder.RenameTable(
                name: "ShippingMethods",
                schema: "ordering",
                newName: "ShippingMethod",
                newSchema: "ordering");

            migrationBuilder.RenameIndex(
                name: "IX_ShippingMethods_ZoneId",
                schema: "ordering",
                table: "ShippingMethod",
                newName: "IX_ShippingMethod_ZoneId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShippingZone",
                schema: "ordering",
                table: "ShippingZone",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShippingMethod",
                schema: "ordering",
                table: "ShippingMethod",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingMethod_ShippingZone_ZoneId",
                schema: "ordering",
                table: "ShippingMethod",
                column: "ZoneId",
                principalSchema: "ordering",
                principalTable: "ShippingZone",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
