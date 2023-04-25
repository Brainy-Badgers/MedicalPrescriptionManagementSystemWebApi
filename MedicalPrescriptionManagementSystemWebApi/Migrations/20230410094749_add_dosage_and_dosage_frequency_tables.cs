using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalPrescriptionManagementSystemWebApi.Migrations
{
    public partial class add_dosage_and_dosage_frequency_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DosageFrequencies");

            migrationBuilder.DropTable(
                name: "Dosages");
        }
    }
}
