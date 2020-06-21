using Microsoft.EntityFrameworkCore.Migrations;

namespace EventWorld.Data.Migrations
{
    public partial class AddedDeletedToEnrollment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "EventGuests",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "EventGuests");
        }
    }
}
