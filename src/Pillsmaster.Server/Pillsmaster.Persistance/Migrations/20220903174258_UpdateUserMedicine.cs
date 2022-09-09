using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pillsmaster.Persistence.Migrations
{
    public partial class UpdateUserMedicine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PharmaType",
                table: "UserMedicines");

            migrationBuilder.AlterColumn<string>(
                name: "TradeName",
                table: "UserMedicines",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "InternationalName",
                table: "UserMedicines",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<int>(
                name: "PharmaTypeId",
                table: "UserMedicines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserMedicines_PharmaTypeId",
                table: "UserMedicines",
                column: "PharmaTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMedicines_PharmaTypes_PharmaTypeId",
                table: "UserMedicines",
                column: "PharmaTypeId",
                principalTable: "PharmaTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMedicines_PharmaTypes_PharmaTypeId",
                table: "UserMedicines");

            migrationBuilder.DropIndex(
                name: "IX_UserMedicines_PharmaTypeId",
                table: "UserMedicines");

            migrationBuilder.DropColumn(
                name: "PharmaTypeId",
                table: "UserMedicines");

            migrationBuilder.AlterColumn<string>(
                name: "TradeName",
                table: "UserMedicines",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "InternationalName",
                table: "UserMedicines",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "PharmaType",
                table: "UserMedicines",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }
    }
}
