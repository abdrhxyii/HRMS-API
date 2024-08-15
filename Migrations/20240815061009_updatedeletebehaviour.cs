using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HumanResource.Migrations
{
    /// <inheritdoc />
    public partial class updatedeletebehaviour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Employees_EmployeeID",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalEmployeeDetails_OfficeLocations_OfficeLocationId",
                table: "ProfessionalEmployeeDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Employees_EmployeeID",
                table: "Documents",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionalEmployeeDetails_OfficeLocations_OfficeLocationId",
                table: "ProfessionalEmployeeDetails",
                column: "OfficeLocationId",
                principalTable: "OfficeLocations",
                principalColumn: "OfficeLocationId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Employees_EmployeeID",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalEmployeeDetails_OfficeLocations_OfficeLocationId",
                table: "ProfessionalEmployeeDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Employees_EmployeeID",
                table: "Documents",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionalEmployeeDetails_OfficeLocations_OfficeLocationId",
                table: "ProfessionalEmployeeDetails",
                column: "OfficeLocationId",
                principalTable: "OfficeLocations",
                principalColumn: "OfficeLocationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
