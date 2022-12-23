using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETrade.Dal.Migrations
{
    /// <inheritdoc />
    public partial class UserIdBasketMaster : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketMaster_Users_EntityId",
                table: "BasketMaster");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "BasketMaster",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BasketMaster_EntityId",
                table: "BasketMaster",
                newName: "IX_BasketMaster_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketMaster_Users_UserId",
                table: "BasketMaster",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketMaster_Users_UserId",
                table: "BasketMaster");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "BasketMaster",
                newName: "EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_BasketMaster_UserId",
                table: "BasketMaster",
                newName: "IX_BasketMaster_EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketMaster_Users_EntityId",
                table: "BasketMaster",
                column: "EntityId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
