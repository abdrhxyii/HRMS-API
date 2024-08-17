using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HumanResource.Migrations
{
    /// <inheritdoc />
    public partial class dbcontextmodalupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttendanceModal_Employees_EmployeeID",
                table: "AttendanceModal");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectModal_Employees_EmployeeModalEmployeeID",
                table: "ProjectModal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectModal",
                table: "ProjectModal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AttendanceModal",
                table: "AttendanceModal");

            migrationBuilder.RenameTable(
                name: "ProjectModal",
                newName: "ProjectModals");

            migrationBuilder.RenameTable(
                name: "AttendanceModal",
                newName: "AttendanceModals");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectModal_EmployeeModalEmployeeID",
                table: "ProjectModals",
                newName: "IX_ProjectModals_EmployeeModalEmployeeID");

            migrationBuilder.RenameIndex(
                name: "IX_AttendanceModal_EmployeeID",
                table: "AttendanceModals",
                newName: "IX_AttendanceModals_EmployeeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectModals",
                table: "ProjectModals",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AttendanceModals",
                table: "AttendanceModals",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "JobModals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    DepartmentModalDepartmentId = table.Column<int>(type: "int", nullable: true),
                    OfficeLocationId = table.Column<int>(type: "int", nullable: true),
                    OfficeLocationModalOfficeLocationId = table.Column<int>(type: "int", nullable: true),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    JobStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobModals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobModals_Departments_DepartmentModalDepartmentId",
                        column: x => x.DepartmentModalDepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobModals_OfficeLocations_OfficeLocationModalOfficeLocationId",
                        column: x => x.OfficeLocationModalOfficeLocationId,
                        principalTable: "OfficeLocations",
                        principalColumn: "OfficeLocationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobModals_DepartmentModalDepartmentId",
                table: "JobModals",
                column: "DepartmentModalDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_JobModals_OfficeLocationModalOfficeLocationId",
                table: "JobModals",
                column: "OfficeLocationModalOfficeLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceModals_Employees_EmployeeID",
                table: "AttendanceModals",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectModals_Employees_EmployeeModalEmployeeID",
                table: "ProjectModals",
                column: "EmployeeModalEmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttendanceModals_Employees_EmployeeID",
                table: "AttendanceModals");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectModals_Employees_EmployeeModalEmployeeID",
                table: "ProjectModals");

            migrationBuilder.DropTable(
                name: "JobModals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectModals",
                table: "ProjectModals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AttendanceModals",
                table: "AttendanceModals");

            migrationBuilder.RenameTable(
                name: "ProjectModals",
                newName: "ProjectModal");

            migrationBuilder.RenameTable(
                name: "AttendanceModals",
                newName: "AttendanceModal");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectModals_EmployeeModalEmployeeID",
                table: "ProjectModal",
                newName: "IX_ProjectModal_EmployeeModalEmployeeID");

            migrationBuilder.RenameIndex(
                name: "IX_AttendanceModals_EmployeeID",
                table: "AttendanceModal",
                newName: "IX_AttendanceModal_EmployeeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectModal",
                table: "ProjectModal",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AttendanceModal",
                table: "AttendanceModal",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceModal_Employees_EmployeeID",
                table: "AttendanceModal",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectModal_Employees_EmployeeModalEmployeeID",
                table: "ProjectModal",
                column: "EmployeeModalEmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
