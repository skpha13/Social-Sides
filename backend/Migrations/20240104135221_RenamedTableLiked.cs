using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class RenamedTableLiked : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Liked_AspNetUsers_UserId",
                table: "Liked");

            migrationBuilder.DropForeignKey(
                name: "FK_Liked_Posts_PostId",
                table: "Liked");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Liked",
                table: "Liked");

            migrationBuilder.RenameTable(
                name: "Liked",
                newName: "Likes");

            migrationBuilder.RenameIndex(
                name: "IX_Liked_PostId",
                table: "Likes",
                newName: "IX_Likes_PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Likes",
                table: "Likes",
                columns: new[] { "UserId", "PostId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_AspNetUsers_UserId",
                table: "Likes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Posts_PostId",
                table: "Likes",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_AspNetUsers_UserId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Posts_PostId",
                table: "Likes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Likes",
                table: "Likes");

            migrationBuilder.RenameTable(
                name: "Likes",
                newName: "Liked");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_PostId",
                table: "Liked",
                newName: "IX_Liked_PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Liked",
                table: "Liked",
                columns: new[] { "UserId", "PostId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Liked_AspNetUsers_UserId",
                table: "Liked",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Liked_Posts_PostId",
                table: "Liked",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
