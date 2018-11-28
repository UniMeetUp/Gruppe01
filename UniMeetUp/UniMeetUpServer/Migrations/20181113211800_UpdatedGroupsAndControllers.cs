using Microsoft.EntityFrameworkCore.Migrations;

namespace UniMeetUpServer.Migrations
{
    public partial class UpdatedGroupsAndControllers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileMessage_Group_GroupId",
                table: "FileMessage");

            migrationBuilder.DropForeignKey(
                name: "FK_FileMessage_User_UserEmailAddress",
                table: "FileMessage");

            migrationBuilder.DropForeignKey(
                name: "FK_Location_Group_GroupId",
                table: "Location");

            migrationBuilder.DropForeignKey(
                name: "FK_Location_User_UserEmailAddress",
                table: "Location");

            migrationBuilder.DropForeignKey(
                name: "FK_Waypoint_Group_GroupId",
                table: "Waypoint");

            migrationBuilder.DropForeignKey(
                name: "FK_Waypoint_User_UserEmailAddress",
                table: "Waypoint");

            migrationBuilder.RenameColumn(
                name: "UserEmailAddress",
                table: "Waypoint",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Waypoint",
                newName: "WaypointId");

            migrationBuilder.RenameIndex(
                name: "IX_Waypoint_UserEmailAddress",
                table: "Waypoint",
                newName: "IX_Waypoint_UserId");

            migrationBuilder.RenameColumn(
                name: "UserEmailAddress",
                table: "Location",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Location",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Location_UserEmailAddress",
                table: "Location",
                newName: "IX_Location_UserId");

            migrationBuilder.RenameColumn(
                name: "UserEmailAddress",
                table: "FileMessage",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "FileMessage",
                newName: "FileMessageId");

            migrationBuilder.RenameIndex(
                name: "IX_FileMessage_UserEmailAddress",
                table: "FileMessage",
                newName: "IX_FileMessage_UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ChatMessage",
                newName: "ChatMessageId");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Waypoint",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Location",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "FileMessage",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FileMessage_Group_GroupId",
                table: "FileMessage",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FileMessage_User_UserId",
                table: "FileMessage",
                column: "UserId",
                principalTable: "User",
                principalColumn: "EmailAddress",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Location_Group_GroupId",
                table: "Location",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Location_User_UserId",
                table: "Location",
                column: "UserId",
                principalTable: "User",
                principalColumn: "EmailAddress",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Waypoint_Group_GroupId",
                table: "Waypoint",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Waypoint_User_UserId",
                table: "Waypoint",
                column: "UserId",
                principalTable: "User",
                principalColumn: "EmailAddress",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileMessage_Group_GroupId",
                table: "FileMessage");

            migrationBuilder.DropForeignKey(
                name: "FK_FileMessage_User_UserId",
                table: "FileMessage");

            migrationBuilder.DropForeignKey(
                name: "FK_Location_Group_GroupId",
                table: "Location");

            migrationBuilder.DropForeignKey(
                name: "FK_Location_User_UserId",
                table: "Location");

            migrationBuilder.DropForeignKey(
                name: "FK_Waypoint_Group_GroupId",
                table: "Waypoint");

            migrationBuilder.DropForeignKey(
                name: "FK_Waypoint_User_UserId",
                table: "Waypoint");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Waypoint",
                newName: "UserEmailAddress");

            migrationBuilder.RenameColumn(
                name: "WaypointId",
                table: "Waypoint",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Waypoint_UserId",
                table: "Waypoint",
                newName: "IX_Waypoint_UserEmailAddress");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Location",
                newName: "UserEmailAddress");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Location",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Location_UserId",
                table: "Location",
                newName: "IX_Location_UserEmailAddress");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "FileMessage",
                newName: "UserEmailAddress");

            migrationBuilder.RenameColumn(
                name: "FileMessageId",
                table: "FileMessage",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_FileMessage_UserId",
                table: "FileMessage",
                newName: "IX_FileMessage_UserEmailAddress");

            migrationBuilder.RenameColumn(
                name: "ChatMessageId",
                table: "ChatMessage",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Waypoint",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Location",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "FileMessage",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_FileMessage_Group_GroupId",
                table: "FileMessage",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FileMessage_User_UserEmailAddress",
                table: "FileMessage",
                column: "UserEmailAddress",
                principalTable: "User",
                principalColumn: "EmailAddress",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Location_Group_GroupId",
                table: "Location",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Location_User_UserEmailAddress",
                table: "Location",
                column: "UserEmailAddress",
                principalTable: "User",
                principalColumn: "EmailAddress",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Waypoint_Group_GroupId",
                table: "Waypoint",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Waypoint_User_UserEmailAddress",
                table: "Waypoint",
                column: "UserEmailAddress",
                principalTable: "User",
                principalColumn: "EmailAddress",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
