using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HumanResource.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDepartmentForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalEmployeeDetails_Departments_DepartmentId",
                table: "ProfessionalEmployeeDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProfessionalEmployeeDetails_EmployeeID",
                table: "ProfessionalEmployeeDetails");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeContacts_EmployeeID",
                table: "EmployeeContacts");

            migrationBuilder.AlterColumn<int>(
                name: "OfficeLocationId",
                table: "ProfessionalEmployeeDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeID",
                table: "ProfessionalEmployeeDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "ProfessionalEmployeeDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeID",
                table: "EmployeeContacts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeID",
                table: "Documents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalEmployeeDetails_EmployeeID",
                table: "ProfessionalEmployeeDetails",
                column: "EmployeeID",
                unique: true,
                filter: "[EmployeeID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeContacts_EmployeeID",
                table: "EmployeeContacts",
                column: "EmployeeID",
                unique: true,
                filter: "[EmployeeID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionalEmployeeDetails_Departments_DepartmentId",
                table: "ProfessionalEmployeeDetails",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalEmployeeDetails_Departments_DepartmentId",
                table: "ProfessionalEmployeeDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProfessionalEmployeeDetails_EmployeeID",
                table: "ProfessionalEmployeeDetails");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeContacts_EmployeeID",
                table: "EmployeeContacts");

            migrationBuilder.AlterColumn<int>(
                name: "OfficeLocationId",
                table: "ProfessionalEmployeeDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeID",
                table: "ProfessionalEmployeeDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "ProfessionalEmployeeDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeID",
                table: "EmployeeContacts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeID",
                table: "Documents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalEmployeeDetails_EmployeeID",
                table: "ProfessionalEmployeeDetails",
                column: "EmployeeID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeContacts_EmployeeID",
                table: "EmployeeContacts",
                column: "EmployeeID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionalEmployeeDetails_Departments_DepartmentId",
                table: "ProfessionalEmployeeDetails",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
