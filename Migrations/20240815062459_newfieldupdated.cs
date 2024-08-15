using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HumanResource.Migrations
{
    /// <inheritdoc />
    public partial class newfieldupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeContacts_Employees_EmployeeID",
                table: "EmployeeContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalEmployeeDetails_Employees_EmployeeID",
                table: "ProfessionalEmployeeDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeContacts_Employees_EmployeeID",
                table: "EmployeeContacts",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionalEmployeeDetails_Employees_EmployeeID",
                table: "ProfessionalEmployeeDetails",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeContacts_Employees_EmployeeID",
                table: "EmployeeContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalEmployeeDetails_Employees_EmployeeID",
                table: "ProfessionalEmployeeDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeContacts_Employees_EmployeeID",
                table: "EmployeeContacts",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionalEmployeeDetails_Employees_EmployeeID",
                table: "ProfessionalEmployeeDetails",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
