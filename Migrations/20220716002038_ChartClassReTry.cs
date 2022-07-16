using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Axon.Migrations
{
    public partial class ChartClassReTry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chart_Employees_EmployeeID",
                table: "Chart");

            migrationBuilder.DropForeignKey(
                name: "FK_Chart_Patients_PatientID",
                table: "Chart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chart",
                table: "Chart");

            migrationBuilder.RenameTable(
                name: "Chart",
                newName: "Charts");

            migrationBuilder.RenameIndex(
                name: "IX_Chart_PatientID",
                table: "Charts",
                newName: "IX_Charts_PatientID");

            migrationBuilder.RenameIndex(
                name: "IX_Chart_EmployeeID",
                table: "Charts",
                newName: "IX_Charts_EmployeeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Charts",
                table: "Charts",
                column: "ChartID");

            migrationBuilder.AddForeignKey(
                name: "FK_Charts_Employees_EmployeeID",
                table: "Charts",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Charts_Patients_PatientID",
                table: "Charts",
                column: "PatientID",
                principalTable: "Patients",
                principalColumn: "PatientID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Charts_Employees_EmployeeID",
                table: "Charts");

            migrationBuilder.DropForeignKey(
                name: "FK_Charts_Patients_PatientID",
                table: "Charts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Charts",
                table: "Charts");

            migrationBuilder.RenameTable(
                name: "Charts",
                newName: "Chart");

            migrationBuilder.RenameIndex(
                name: "IX_Charts_PatientID",
                table: "Chart",
                newName: "IX_Chart_PatientID");

            migrationBuilder.RenameIndex(
                name: "IX_Charts_EmployeeID",
                table: "Chart",
                newName: "IX_Chart_EmployeeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chart",
                table: "Chart",
                column: "ChartID");

            migrationBuilder.AddForeignKey(
                name: "FK_Chart_Employees_EmployeeID",
                table: "Chart",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chart_Patients_PatientID",
                table: "Chart",
                column: "PatientID",
                principalTable: "Patients",
                principalColumn: "PatientID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
