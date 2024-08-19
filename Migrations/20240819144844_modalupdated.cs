using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HumanResource.Migrations
{
    /// <inheritdoc />
    public partial class modalupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectModals_Employees_EmployeeModalEmployeeID",
                table: "ProjectModals");

            migrationBuilder.DropIndex(
                name: "IX_ProjectModals_EmployeeModalEmployeeID",
                table: "ProjectModals");

            migrationBuilder.DropColumn(
                name: "EmployeeModalEmployeeID",
                table: "ProjectModals");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectModals_EmployeeID",
                table: "ProjectModals",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectModals_Employees_EmployeeID",
                table: "ProjectModals",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectModals_Employees_EmployeeID",
                table: "ProjectModals");

            migrationBuilder.DropIndex(
                name: "IX_ProjectModals_EmployeeID",
                table: "ProjectModals");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeModalEmployeeID",
                table: "ProjectModals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectModals_EmployeeModalEmployeeID",
                table: "ProjectModals",
                column: "EmployeeModalEmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectModals_Employees_EmployeeModalEmployeeID",
                table: "ProjectModals",
                column: "EmployeeModalEmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
