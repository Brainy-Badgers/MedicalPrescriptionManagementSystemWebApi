using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalPrescriptionManagementSystemWebApi.Migrations
{
    public partial class addprofilepiccolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfilePickUrl",
                table: "Patients",
                newName: "ProfilePicUrl");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicUrl",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ProfilePicUrl",
                table: "Patients",
                newName: "ProfilePickUrl");
        }
    }
}
