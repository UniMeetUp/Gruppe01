using Microsoft.EntityFrameworkCore.Migrations;

namespace UniMeetUpServer.Migrations
{
    public partial class AddedUserGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Group_GroupId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_GroupId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Group",
                newName: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "Group",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "User",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_GroupId",
                table: "User",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Group_GroupId",
                table: "User",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
