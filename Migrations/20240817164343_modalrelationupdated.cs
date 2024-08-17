using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HumanResource.Migrations
{
    /// <inheritdoc />
    public partial class modalrelationupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobModals_Departments_DepartmentModalDepartmentId",
                table: "JobModals");

            migrationBuilder.DropForeignKey(
                name: "FK_JobModals_OfficeLocations_OfficeLocationModalOfficeLocationId",
                table: "JobModals");

            migrationBuilder.DropIndex(
                name: "IX_JobModals_DepartmentModalDepartmentId",
                table: "JobModals");

            migrationBuilder.DropIndex(
                name: "IX_JobModals_OfficeLocationModalOfficeLocationId",
                table: "JobModals");

            migrationBuilder.DropColumn(
                name: "DepartmentModalDepartmentId",
                table: "JobModals");

            migrationBuilder.DropColumn(
                name: "OfficeLocationModalOfficeLocationId",
                table: "JobModals");

            migrationBuilder.CreateIndex(
                name: "IX_JobModals_DepartmentId",
                table: "JobModals",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_JobModals_OfficeLocationId",
                table: "JobModals",
                column: "OfficeLocationId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobModals_Departments_DepartmentId",
                table: "JobModals");

            migrationBuilder.DropForeignKey(
                name: "FK_JobModals_OfficeLocations_OfficeLocationId",
                table: "JobModals");

            migrationBuilder.DropIndex(
                name: "IX_JobModals_DepartmentId",
                table: "JobModals");

            migrationBuilder.DropIndex(
                name: "IX_JobModals_OfficeLocationId",
                table: "JobModals");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentModalDepartmentId",
                table: "JobModals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OfficeLocationModalOfficeLocationId",
                table: "JobModals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobModals_DepartmentModalDepartmentId",
                table: "JobModals",
                column: "DepartmentModalDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_JobModals_OfficeLocationModalOfficeLocationId",
                table: "JobModals",
                column: "OfficeLocationModalOfficeLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobModals_Departments_DepartmentModalDepartmentId",
                table: "JobModals",
                column: "DepartmentModalDepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobModals_OfficeLocations_OfficeLocationModalOfficeLocationId",
                table: "JobModals",
                column: "OfficeLocationModalOfficeLocationId",
                principalTable: "OfficeLocations",
                principalColumn: "OfficeLocationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
