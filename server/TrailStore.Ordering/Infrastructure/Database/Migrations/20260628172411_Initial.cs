using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrailStore.Ordering.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ordering");

            migrationBuilder.CreateTable(
                name: "CheckoutSessions",
                schema: "ordering",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SessionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    EmailAddress = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ShippingAddress_CountryCode = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    ShippingAddress_RecipientFirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ShippingAddress_RecipientLastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ShippingAddress_Company = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ShippingAddress_AddressLine = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    ShippingAddress_ApartmentSuite = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    ShippingAddress_City = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ShippingAddress_Region = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ShippingAddress_PostalCode = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    ShippingAddress_PhoneNumber = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    BillingAddress_CountryCode = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    BillingAddress_RecipientFirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    BillingAddress_RecipientLastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    BillingAddress_Company = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    BillingAddress_AddressLine = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    BillingAddress_ApartmentSuite = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    BillingAddress_City = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    BillingAddress_Region = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    BillingAddress_PostalCode = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    BillingAddress_PhoneNumber = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    ShippingAddressAsBillingAddress = table.Column<bool>(type: "boolean", nullable: false),
                    ShippingMethodId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckoutSessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShippingZone",
                schema: "ordering",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CountryCodes = table.Column<string[]>(type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingZone", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShippingMethod",
                schema: "ordering",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ZoneId = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    FlatFee = table.Column<decimal>(type: "numeric", nullable: false),
                    FreeShippingThreshold = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingMethod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShippingMethod_ShippingZone_ZoneId",
                        column: x => x.ZoneId,
                        principalSchema: "ordering",
                        principalTable: "ShippingZone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShippingMethod_ZoneId",
                schema: "ordering",
                table: "ShippingMethod",
                column: "ZoneId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckoutSessions",
                schema: "ordering");

            migrationBuilder.DropTable(
                name: "ShippingMethod",
                schema: "ordering");

            migrationBuilder.DropTable(
                name: "ShippingZone",
                schema: "ordering");
        }
    }
}
