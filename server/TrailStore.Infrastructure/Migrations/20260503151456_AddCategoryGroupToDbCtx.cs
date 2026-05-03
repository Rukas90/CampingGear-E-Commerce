using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrailStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryGroupToDbCtx : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_CategoryGroup_GroupId",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryGroup",
                table: "CategoryGroup");

            migrationBuilder.RenameTable(
                name: "CategoryGroup",
                newName: "CategoryGroups");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryGroup_Slug",
                table: "CategoryGroups",
                newName: "IX_CategoryGroups_Slug");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryGroups",
                table: "CategoryGroups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_CategoryGroups_GroupId",
                table: "Categories",
                column: "GroupId",
                principalTable: "CategoryGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_CategoryGroups_GroupId",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryGroups",
                table: "CategoryGroups");

            migrationBuilder.RenameTable(
                name: "CategoryGroups",
                newName: "CategoryGroup");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryGroups_Slug",
                table: "CategoryGroup",
                newName: "IX_CategoryGroup_Slug");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryGroup",
                table: "CategoryGroup",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_CategoryGroup_GroupId",
                table: "Categories",
                column: "GroupId",
                principalTable: "CategoryGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
