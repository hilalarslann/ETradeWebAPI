using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETrade.Dal.Migrations
{
    /// <inheritdoc />
    public partial class userUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Error",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Error",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
