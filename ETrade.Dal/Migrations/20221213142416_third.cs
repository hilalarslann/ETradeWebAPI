using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETrade.Dal.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_SubCategories_SubId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_SubCategories_SubId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Categories_SubId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "SubId",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "SubId",
                table: "Products",
                newName: "SubCatId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_SubId",
                table: "Products",
                newName: "IX_Products_SubCatId");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "SubCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SubCategories_SubCatId",
                table: "Products",
                column: "SubCatId",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategories_Categories_CategoryId",
                table: "SubCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_SubCategories_SubCatId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategories_Categories_CategoryId",
                table: "SubCategories");

            migrationBuilder.DropIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "SubCategories");

            migrationBuilder.RenameColumn(
                name: "SubCatId",
                table: "Products",
                newName: "SubId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_SubCatId",
                table: "Products",
                newName: "IX_Products_SubId");

            migrationBuilder.AddColumn<int>(
                name: "SubId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_SubId",
                table: "Categories",
                column: "SubId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_SubCategories_SubId",
                table: "Categories",
                column: "SubId",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SubCategories_SubId",
                table: "Products",
                column: "SubId",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
