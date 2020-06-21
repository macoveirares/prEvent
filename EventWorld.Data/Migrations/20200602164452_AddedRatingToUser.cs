using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventWorld.Data.Migrations
{
    public partial class AddedRatingToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PunishmentDate",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Users",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Users");

            migrationBuilder.AddColumn<DateTime>(
                name: "PunishmentDate",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
