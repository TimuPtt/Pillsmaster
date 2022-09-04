using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pillsmaster.Persistence.Migrations
{
    public partial class InitialCreate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMedicines_Medicines_MedicineId",
                table: "UserMedicines");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserDetails_userDetailsId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UserMedicines_MedicineId",
                table: "UserMedicines");

            migrationBuilder.DropColumn(
                name: "MedicineId",
                table: "UserMedicines");

            migrationBuilder.DropColumn(
                name: "UserPlanId",
                table: "UserMedicines");

            migrationBuilder.DropColumn(
                name: "FoodStatus",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "PlanStatus",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "PharmaType",
                table: "Medicines");

            migrationBuilder.RenameColumn(
                name: "userDetailsId",
                table: "Users",
                newName: "UserDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_userDetailsId",
                table: "Users",
                newName: "IX_Users_UserDetailsId");

            migrationBuilder.RenameColumn(
                name: "MedicineId",
                table: "Medicines",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "ActiveIngredientCount",
                table: "UserMedicines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "InternationalName",
                table: "UserMedicines",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PharmaType",
                table: "UserMedicines",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TradeName",
                table: "UserMedicines",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FoodStatusId",
                table: "Plans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlanStatusId",
                table: "Plans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "UserMedicineId",
                table: "Plans",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "PharmaTypeId",
                table: "Medicines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FoodStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PharmaTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmaTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plans_FoodStatusId",
                table: "Plans",
                column: "FoodStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_PlanStatusId",
                table: "Plans",
                column: "PlanStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_UserMedicineId",
                table: "Plans",
                column: "UserMedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_PharmaTypeId",
                table: "Medicines",
                column: "PharmaTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_PharmaTypes_PharmaTypeId",
                table: "Medicines",
                column: "PharmaTypeId",
                principalTable: "PharmaTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_FoodStatuses_FoodStatusId",
                table: "Plans",
                column: "FoodStatusId",
                principalTable: "FoodStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_PlanStatuses_PlanStatusId",
                table: "Plans",
                column: "PlanStatusId",
                principalTable: "PlanStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_UserMedicines_UserMedicineId",
                table: "Plans",
                column: "UserMedicineId",
                principalTable: "UserMedicines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserDetails_UserDetailsId",
                table: "Users",
                column: "UserDetailsId",
                principalTable: "UserDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_PharmaTypes_PharmaTypeId",
                table: "Medicines");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_FoodStatuses_FoodStatusId",
                table: "Plans");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_PlanStatuses_PlanStatusId",
                table: "Plans");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_UserMedicines_UserMedicineId",
                table: "Plans");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserDetails_UserDetailsId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "FoodStatuses");

            migrationBuilder.DropTable(
                name: "PharmaTypes");

            migrationBuilder.DropTable(
                name: "PlanStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Plans_FoodStatusId",
                table: "Plans");

            migrationBuilder.DropIndex(
                name: "IX_Plans_PlanStatusId",
                table: "Plans");

            migrationBuilder.DropIndex(
                name: "IX_Plans_UserMedicineId",
                table: "Plans");

            migrationBuilder.DropIndex(
                name: "IX_Medicines_PharmaTypeId",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "ActiveIngredientCount",
                table: "UserMedicines");

            migrationBuilder.DropColumn(
                name: "InternationalName",
                table: "UserMedicines");

            migrationBuilder.DropColumn(
                name: "PharmaType",
                table: "UserMedicines");

            migrationBuilder.DropColumn(
                name: "TradeName",
                table: "UserMedicines");

            migrationBuilder.DropColumn(
                name: "FoodStatusId",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "PlanStatusId",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "UserMedicineId",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "PharmaTypeId",
                table: "Medicines");

            migrationBuilder.RenameColumn(
                name: "UserDetailsId",
                table: "Users",
                newName: "userDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserDetailsId",
                table: "Users",
                newName: "IX_Users_userDetailsId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Medicines",
                newName: "MedicineId");

            migrationBuilder.AddColumn<Guid>(
                name: "MedicineId",
                table: "UserMedicines",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserPlanId",
                table: "UserMedicines",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "FoodStatus",
                table: "Plans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlanStatus",
                table: "Plans",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PharmaType",
                table: "Medicines",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UserMedicines_MedicineId",
                table: "UserMedicines",
                column: "MedicineId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMedicines_Medicines_MedicineId",
                table: "UserMedicines",
                column: "MedicineId",
                principalTable: "Medicines",
                principalColumn: "MedicineId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserDetails_userDetailsId",
                table: "Users",
                column: "userDetailsId",
                principalTable: "UserDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
