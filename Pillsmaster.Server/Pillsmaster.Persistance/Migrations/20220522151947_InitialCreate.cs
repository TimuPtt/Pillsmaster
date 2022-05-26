using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pillsmaster.Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicationDays",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TakesPerDay = table.Column<int>(type: "int", nullable: false),
                    CountPerTake = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationDays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    MedicineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TradeName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    InternationalName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PharmaType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ActiveIngredientCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.MedicineId);
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicineCount = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    IsEnoughToFinish = table.Column<bool>(type: "bit", nullable: false),
                    FoodStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlanStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicationDayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastTakeTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TakeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plans_MedicationDays_MedicationDayId",
                        column: x => x.MedicationDayId,
                        principalTable: "MedicationDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMedicines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserPlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMedicines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMedicines_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "MedicineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Takes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TakeDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Takes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Takes_Plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plans_MedicationDayId",
                table: "Plans",
                column: "MedicationDayId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Takes_PlanId",
                table: "Takes",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMedicines_MedicineId",
                table: "UserMedicines",
                column: "MedicineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Takes");

            migrationBuilder.DropTable(
                name: "UserMedicines");

            migrationBuilder.DropTable(
                name: "Plans");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "MedicationDays");
        }
    }
}
