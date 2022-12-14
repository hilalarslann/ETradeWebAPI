using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETrade.Dal.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_SubCategories_SubId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_SubId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "SubId",
                table: "Categories");
        }
    }
}
