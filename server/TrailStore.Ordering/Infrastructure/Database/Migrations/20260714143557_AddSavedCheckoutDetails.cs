using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrailStore.Ordering.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddSavedCheckoutDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SavedCheckoutDetails",
                schema: "ordering",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    EmailAddress = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    ShippingAddress_CountryCode = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    ShippingAddress_RecipientFirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ShippingAddress_RecipientLastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ShippingAddress_Company = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ShippingAddress_AddressLine = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    ShippingAddress_ApartmentSuite = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    ShippingAddress_City = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ShippingAddress_Region = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ShippingAddress_PostalCode = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    ShippingAddress_PhoneNumber = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    ShippingMethodId = table.Column<Guid>(type: "uuid", nullable: false),
                    BillingAddress_CountryCode = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    BillingAddress_RecipientFirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    BillingAddress_RecipientLastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    BillingAddress_Company = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    BillingAddress_AddressLine = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    BillingAddress_ApartmentSuite = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    BillingAddress_City = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    BillingAddress_Region = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    BillingAddress_PostalCode = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    BillingAddress_PhoneNumber = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    ShippingAddressAsBillingAddress = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedCheckoutDetails", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SavedCheckoutDetails",
                schema: "ordering");
        }
    }
}
