using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrailStore.Identity.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class RenameFamilyIdAndDropUserIdOnRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_RefreshFamilies_RefreshFamilyId",
                schema: "identity",
                table: "RefreshToken");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_Users_UserId",
                schema: "identity",
                table: "RefreshToken");

            migrationBuilder.DropIndex(
                name: "IX_RefreshToken_RefreshFamilyId",
                schema: "identity",
                table: "RefreshToken");

            migrationBuilder.DropIndex(
                name: "IX_RefreshToken_UserId",
                schema: "identity",
                table: "RefreshToken");

            migrationBuilder.DropColumn(
                name: "RefreshFamilyId",
                schema: "identity",
                table: "RefreshToken");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "identity",
                table: "RefreshToken");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_FamilyId",
                schema: "identity",
                table: "RefreshToken",
                column: "FamilyId");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_RefreshFamilies_FamilyId",
                schema: "identity",
                table: "RefreshToken",
                column: "FamilyId",
                principalSchema: "identity",
                principalTable: "RefreshFamilies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_RefreshFamilies_FamilyId",
                schema: "identity",
                table: "RefreshToken");

            migrationBuilder.DropIndex(
                name: "IX_RefreshToken_FamilyId",
                schema: "identity",
                table: "RefreshToken");

            migrationBuilder.AddColumn<Guid>(
                name: "RefreshFamilyId",
                schema: "identity",
                table: "RefreshToken",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "identity",
                table: "RefreshToken",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_RefreshFamilyId",
                schema: "identity",
                table: "RefreshToken",
                column: "RefreshFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UserId",
                schema: "identity",
                table: "RefreshToken",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_RefreshFamilies_RefreshFamilyId",
                schema: "identity",
                table: "RefreshToken",
                column: "RefreshFamilyId",
                principalSchema: "identity",
                principalTable: "RefreshFamilies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_Users_UserId",
                schema: "identity",
                table: "RefreshToken",
                column: "UserId",
                principalSchema: "identity",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
