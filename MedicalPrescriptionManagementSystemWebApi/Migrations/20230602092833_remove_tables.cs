using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalPrescriptionManagementSystemWebApi.Migrations
{
    public partial class remove_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicinePrescription_DosageFrequencies_DosageFrequencyId",
                table: "MedicinePrescription");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicinePrescription_Dosages_DosageId",
                table: "MedicinePrescription");

            migrationBuilder.DropTable(
                name: "DosageFrequencies");

            migrationBuilder.DropTable(
                name: "Dosages");

            migrationBuilder.DropIndex(
                name: "IX_MedicinePrescription_DosageFrequencyId",
                table: "MedicinePrescription");

            migrationBuilder.DropIndex(
                name: "IX_MedicinePrescription_DosageId",
                table: "MedicinePrescription");

            migrationBuilder.DropColumn(
                name: "DosageFrequencyId",
                table: "MedicinePrescription");

            migrationBuilder.DropColumn(
                name: "DosageId",
                table: "MedicinePrescription");

            migrationBuilder.AddColumn<string>(
                name: "Dosage",
                table: "MedicinePrescription",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DosageFrequency",
                table: "MedicinePrescription",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dosage",
                table: "MedicinePrescription");

            migrationBuilder.DropColumn(
                name: "DosageFrequency",
                table: "MedicinePrescription");

            migrationBuilder.AddColumn<int>(
                name: "DosageFrequencyId",
                table: "MedicinePrescription",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DosageId",
                table: "MedicinePrescription",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DosageFrequencies",
                columns: table => new
                {
                    DosageFrequencyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DosageFrequencyInfo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DosageFrequencies", x => x.DosageFrequencyId);
                });

            migrationBuilder.CreateTable(
                name: "Dosages",
                columns: table => new
                {
                    DosageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DosageInfo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dosages", x => x.DosageId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicinePrescription_DosageFrequencyId",
                table: "MedicinePrescription",
                column: "DosageFrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicinePrescription_DosageId",
                table: "MedicinePrescription",
                column: "DosageId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicinePrescription_DosageFrequencies_DosageFrequencyId",
                table: "MedicinePrescription",
                column: "DosageFrequencyId",
                principalTable: "DosageFrequencies",
                principalColumn: "DosageFrequencyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicinePrescription_Dosages_DosageId",
                table: "MedicinePrescription",
                column: "DosageId",
                principalTable: "Dosages",
                principalColumn: "DosageId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
