using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class ChangedFKUserFollowsCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFollowsCategories_AspNetUsers_UserId",
                table: "UserFollowsCategories");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollowsCategories_AspNetUsers_UserId",
                table: "UserFollowsCategories",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFollowsCategories_AspNetUsers_UserId",
                table: "UserFollowsCategories");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollowsCategories_AspNetUsers_UserId",
                table: "UserFollowsCategories",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
