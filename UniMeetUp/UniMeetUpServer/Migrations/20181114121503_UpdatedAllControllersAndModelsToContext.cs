using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UniMeetUpServer.Migrations
{
    public partial class UpdatedAllControllersAndModelsToContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGroup_User_EmailAddress",
                table: "UserGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGroup",
                table: "UserGroup");

            migrationBuilder.DropIndex(
                name: "IX_UserGroup_EmailAddress",
                table: "UserGroup");

            migrationBuilder.DropColumn(
                name: "UserGroupId",
                table: "UserGroup");

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "UserGroup",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGroup",
                table: "UserGroup",
                columns: new[] { "EmailAddress", "GroupId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroup_User_EmailAddress",
                table: "UserGroup",
                column: "EmailAddress",
                principalTable: "User",
                principalColumn: "EmailAddress",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGroup_User_EmailAddress",
                table: "UserGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGroup",
                table: "UserGroup");

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "UserGroup",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "UserGroupId",
                table: "UserGroup",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGroup",
                table: "UserGroup",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroup_EmailAddress",
                table: "UserGroup",
                column: "EmailAddress");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroup_User_EmailAddress",
                table: "UserGroup",
                column: "EmailAddress",
                principalTable: "User",
                principalColumn: "EmailAddress",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
