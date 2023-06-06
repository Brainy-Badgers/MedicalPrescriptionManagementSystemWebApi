using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalPrescriptionManagementSystemWebApi.Migrations
{
    public partial class addmedicineprescriptiontable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicinePrescription_Medicines_MedicineId",
                table: "MedicinePrescription");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicinePrescription_Prescriptions_PrescriptionId",
                table: "MedicinePrescription");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicinePrescription",
                table: "MedicinePrescription");

            migrationBuilder.RenameTable(
                name: "MedicinePrescription",
                newName: "MedicinePrescriptions");

            migrationBuilder.RenameIndex(
                name: "IX_MedicinePrescription_PrescriptionId",
                table: "MedicinePrescriptions",
                newName: "IX_MedicinePrescriptions_PrescriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicinePrescription_MedicineId",
                table: "MedicinePrescriptions",
                newName: "IX_MedicinePrescriptions_MedicineId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicinePrescriptions",
                table: "MedicinePrescriptions",
                column: "MedicinePrescriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicinePrescriptions_Medicines_MedicineId",
                table: "MedicinePrescriptions",
                column: "MedicineId",
                principalTable: "Medicines",
                principalColumn: "MedicineId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicinePrescriptions_Prescriptions_PrescriptionId",
                table: "MedicinePrescriptions",
                column: "PrescriptionId",
                principalTable: "Prescriptions",
                principalColumn: "PrescriptionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicinePrescriptions_Medicines_MedicineId",
                table: "MedicinePrescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicinePrescriptions_Prescriptions_PrescriptionId",
                table: "MedicinePrescriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicinePrescriptions",
                table: "MedicinePrescriptions");

            migrationBuilder.RenameTable(
                name: "MedicinePrescriptions",
                newName: "MedicinePrescription");

            migrationBuilder.RenameIndex(
                name: "IX_MedicinePrescriptions_PrescriptionId",
                table: "MedicinePrescription",
                newName: "IX_MedicinePrescription_PrescriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicinePrescriptions_MedicineId",
                table: "MedicinePrescription",
                newName: "IX_MedicinePrescription_MedicineId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicinePrescription",
                table: "MedicinePrescription",
                column: "MedicinePrescriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicinePrescription_Medicines_MedicineId",
                table: "MedicinePrescription",
                column: "MedicineId",
                principalTable: "Medicines",
                principalColumn: "MedicineId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicinePrescription_Prescriptions_PrescriptionId",
                table: "MedicinePrescription",
                column: "PrescriptionId",
                principalTable: "Prescriptions",
                principalColumn: "PrescriptionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
