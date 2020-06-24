using Microsoft.EntityFrameworkCore.Migrations;

namespace EventWorld.Data.Migrations
{
    public partial class AddedEventImagePath2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Events",
                nullable: false,
                oldClrType: typeof(long));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "ImagePath",
                table: "Events",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
