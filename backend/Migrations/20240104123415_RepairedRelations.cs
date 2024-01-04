using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class RepairedRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Liked_AspNetUsers_UserId",
                table: "Liked");

            migrationBuilder.DropForeignKey(
                name: "FK_Saves_AspNetUsers_UserId",
                table: "Saves");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFollowsCategories_AspNetUsers_UserId",
                table: "UserFollowsCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFollowsCategories_Categories_CategoryId",
                table: "UserFollowsCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Saves",
                table: "Saves");

            migrationBuilder.DropIndex(
                name: "IX_Saves_UserId",
                table: "Saves");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Liked",
                table: "Liked");

            migrationBuilder.DropIndex(
                name: "IX_Liked_UserId",
                table: "Liked");

            migrationBuilder.AlterColumn<Guid>(
                name: "PostId",
                table: "Saves",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PostId",
                table: "Liked",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Saves",
                table: "Saves",
                columns: new[] { "UserId", "PostId" });

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
                name: "FK_Saves_AspNetUsers_UserId",
                table: "Saves",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollowsCategories_AspNetUsers_UserId",
                table: "UserFollowsCategories",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollowsCategories_Categories_CategoryId",
                table: "UserFollowsCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Liked_AspNetUsers_UserId",
                table: "Liked");

            migrationBuilder.DropForeignKey(
                name: "FK_Saves_AspNetUsers_UserId",
                table: "Saves");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFollowsCategories_AspNetUsers_UserId",
                table: "UserFollowsCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFollowsCategories_Categories_CategoryId",
                table: "UserFollowsCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Saves",
                table: "Saves");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Liked",
                table: "Liked");

            migrationBuilder.AlterColumn<Guid>(
                name: "PostId",
                table: "Saves",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "PostId",
                table: "Liked",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Saves",
                table: "Saves",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Liked",
                table: "Liked",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Saves_UserId",
                table: "Saves",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Liked_UserId",
                table: "Liked",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Liked_AspNetUsers_UserId",
                table: "Liked",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Saves_AspNetUsers_UserId",
                table: "Saves",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollowsCategories_AspNetUsers_UserId",
                table: "UserFollowsCategories",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFollowsCategories_Categories_CategoryId",
                table: "UserFollowsCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
