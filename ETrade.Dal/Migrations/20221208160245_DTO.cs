using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETrade.Dal.Migrations
{
    /// <inheritdoc />
    public partial class DTO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckPassword",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CheckPassword",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
