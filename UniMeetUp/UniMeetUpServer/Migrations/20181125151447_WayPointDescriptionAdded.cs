using Microsoft.EntityFrameworkCore.Migrations;

namespace UniMeetUpServer.Migrations
{
    public partial class WayPointDescriptionAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Waypoint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Waypoint");
        }
    }
}
