using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HumanResource.Migrations
{
    /// <inheritdoc />
    public partial class dbsetupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttendanceModals_Employees_EmployeeID",
                table: "AttendanceModals");

            migrationBuilder.DropForeignKey(
                name: "FK_JobModals_Departments_DepartmentId",
                table: "JobModals");

            migrationBuilder.DropForeignKey(
                name: "FK_JobModals_OfficeLocations_OfficeLocationId",
                table: "JobModals");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectModals_Employees_EmployeeID",
                table: "ProjectModals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectModals",
                table: "ProjectModals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobModals",
                table: "JobModals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AttendanceModals",
                table: "AttendanceModals");

            migrationBuilder.RenameTable(
                name: "ProjectModals",
                newName: "Projects");

            migrationBuilder.RenameTable(
                name: "JobModals",
                newName: "Jobs");

            migrationBuilder.RenameTable(
                name: "AttendanceModals",
                newName: "Attendances");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectModals_EmployeeID",
                table: "Projects",
                newName: "IX_Projects_EmployeeID");

            migrationBuilder.RenameIndex(
                name: "IX_JobModals_OfficeLocationId",
                table: "Jobs",
                newName: "IX_Jobs_OfficeLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_JobModals_DepartmentId",
                table: "Jobs",
                newName: "IX_Jobs_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_AttendanceModals_EmployeeID",
                table: "Attendances",
                newName: "IX_Attendances_EmployeeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendances",
                table: "Attendances",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Employees_EmployeeID",
                table: "Attendances",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Departments_DepartmentId",
                table: "Jobs",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_OfficeLocations_OfficeLocationId",
                table: "Jobs",
                column: "OfficeLocationId",
                principalTable: "OfficeLocations",
                principalColumn: "OfficeLocationId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Employees_EmployeeID",
                table: "Projects",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Employees_EmployeeID",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Departments_DepartmentId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_OfficeLocations_OfficeLocationId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Employees_EmployeeID",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendances",
                table: "Attendances");

            migrationBuilder.RenameTable(
                name: "Projects",
                newName: "ProjectModals");

            migrationBuilder.RenameTable(
                name: "Jobs",
                newName: "JobModals");

            migrationBuilder.RenameTable(
                name: "Attendances",
                newName: "AttendanceModals");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_EmployeeID",
                table: "ProjectModals",
                newName: "IX_ProjectModals_EmployeeID");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_OfficeLocationId",
                table: "JobModals",
                newName: "IX_JobModals_OfficeLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_DepartmentId",
                table: "JobModals",
                newName: "IX_JobModals_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendances_EmployeeID",
                table: "AttendanceModals",
                newName: "IX_AttendanceModals_EmployeeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectModals",
                table: "ProjectModals",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobModals",
                table: "JobModals",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AttendanceModals",
                table: "AttendanceModals",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceModals_Employees_EmployeeID",
                table: "AttendanceModals",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobModals_Departments_DepartmentId",
                table: "JobModals",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobModals_OfficeLocations_OfficeLocationId",
                table: "JobModals",
                column: "OfficeLocationId",
                principalTable: "OfficeLocations",
                principalColumn: "OfficeLocationId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectModals_Employees_EmployeeID",
                table: "ProjectModals",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
