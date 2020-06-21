using Microsoft.EntityFrameworkCore.Migrations;

namespace EventWorld.Data.Migrations
{
    public partial class EntitiesDetailsUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "EventTypes",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Events",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Events",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "EventTypes");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Events");
        }
    }
}
