using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pillsmaster.Persistence.Migrations
{
    public partial class Migration_Takes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserDetails_UserDetailsId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserDetailsId",
                table: "Users",
                newName: "userDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserDetailsId",
                table: "Users",
                newName: "IX_Users_userDetailsId");

            migrationBuilder.RenameColumn(
                name: "TakeDateTime",
                table: "Takes",
                newName: "TakeTime");

            migrationBuilder.RenameColumn(
                name: "LastTakeTime",
                table: "Plans",
                newName: "NextTakeTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Plans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TakesCount",
                table: "Plans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserDetails_userDetailsId",
                table: "Users",
                column: "userDetailsId",
                principalTable: "UserDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserDetails_userDetailsId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "TakesCount",
                table: "Plans");

            migrationBuilder.RenameColumn(
                name: "userDetailsId",
                table: "Users",
                newName: "UserDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_userDetailsId",
                table: "Users",
                newName: "IX_Users_UserDetailsId");

            migrationBuilder.RenameColumn(
                name: "TakeTime",
                table: "Takes",
                newName: "TakeDateTime");

            migrationBuilder.RenameColumn(
                name: "NextTakeTime",
                table: "Plans",
                newName: "LastTakeTime");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserDetails_UserDetailsId",
                table: "Users",
                column: "UserDetailsId",
                principalTable: "UserDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
