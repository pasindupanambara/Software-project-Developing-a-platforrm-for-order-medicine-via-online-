using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Pharmacy.Migrations
{
    public partial class thirdupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_district",
                table: "Pharmacy");

            migrationBuilder.DropColumn(
                name: "Address_no",
                table: "Pharmacy");

            migrationBuilder.RenameColumn(
                name: "Address_town",
                table: "Pharmacy",
                newName: "district");

            migrationBuilder.RenameColumn(
                name: "Address_street",
                table: "Pharmacy",
                newName: "Address");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "district",
                table: "Pharmacy",
                newName: "Address_town");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Pharmacy",
                newName: "Address_street");

            migrationBuilder.AddColumn<string>(
                name: "Address_district",
                table: "Pharmacy",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_no",
                table: "Pharmacy",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
