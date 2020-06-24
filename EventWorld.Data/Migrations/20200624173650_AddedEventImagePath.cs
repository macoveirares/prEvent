using Microsoft.EntityFrameworkCore.Migrations;

namespace EventWorld.Data.Migrations
{
    public partial class AddedEventImagePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ImagePath",
                table: "Events",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Events");
        }
    }
}
