using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrailStore.Catalog.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryRelationToGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Categories_GroupId",
                schema: "catalog",
                table: "Categories",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_CategoryGroups_GroupId",
                schema: "catalog",
                table: "Categories",
                column: "GroupId",
                principalSchema: "catalog",
                principalTable: "CategoryGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_CategoryGroups_GroupId",
                schema: "catalog",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_GroupId",
                schema: "catalog",
                table: "Categories");
        }
    }
}
