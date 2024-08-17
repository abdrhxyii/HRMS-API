using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HumanResource.Migrations
{
    /// <inheritdoc />
    public partial class newmodalupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttendanceModal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChecksIn = table.Column<TimeSpan>(type: "time", nullable: true),
                    ChecksOut = table.Column<TimeSpan>(type: "time", nullable: true),
                    Break = table.Column<TimeSpan>(type: "time", nullable: true),
                    WorkingHours = table.Column<TimeSpan>(type: "time", nullable: true),
                    AttendanceStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceModal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttendanceModal_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectModal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    EmployeeModalEmployeeID = table.Column<int>(type: "int", nullable: true),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectModal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectModal_Employees_EmployeeModalEmployeeID",
                        column: x => x.EmployeeModalEmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceModal_EmployeeID",
                table: "AttendanceModal",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectModal_EmployeeModalEmployeeID",
                table: "ProjectModal",
                column: "EmployeeModalEmployeeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttendanceModal");

            migrationBuilder.DropTable(
                name: "ProjectModal");
        }
    }
}
