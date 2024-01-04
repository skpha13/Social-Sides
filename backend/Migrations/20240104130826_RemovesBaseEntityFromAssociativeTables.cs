using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class RemovesBaseEntityFromAssociativeTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "UserFollowsCategories");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserFollowsCategories");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "UserFollowsCategories");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Saves");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Saves");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Saves");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Liked");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Liked");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Liked");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "UserFollowsCategories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "UserFollowsCategories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "UserFollowsCategories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Saves",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Saves",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Saves",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Liked",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Liked",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Liked",
                type: "datetime2",
                nullable: true);
        }
    }
}
