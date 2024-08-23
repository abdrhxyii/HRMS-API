using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HumanResource.Migrations
{
    /// <inheritdoc />
    public partial class updatedpayroll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payrolls_Employees_EmployeeID",
                table: "Payrolls");

            migrationBuilder.DropForeignKey(
                name: "FK_Payrolls_Employees_EmployeeModalEmployeeID",
                table: "Payrolls");

            migrationBuilder.DropIndex(
                name: "IX_Payrolls_EmployeeModalEmployeeID",
                table: "Payrolls");

            migrationBuilder.DropColumn(
                name: "EmployeeModalEmployeeID",
                table: "Payrolls");

            migrationBuilder.AddForeignKey(
                name: "FK_Payrolls_Employees_EmployeeID",
                table: "Payrolls",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payrolls_Employees_EmployeeID",
                table: "Payrolls");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeModalEmployeeID",
                table: "Payrolls",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payrolls_EmployeeModalEmployeeID",
                table: "Payrolls",
                column: "EmployeeModalEmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Payrolls_Employees_EmployeeID",
                table: "Payrolls",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payrolls_Employees_EmployeeModalEmployeeID",
                table: "Payrolls",
                column: "EmployeeModalEmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID");
        }
    }
}
