using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Pharmacy.Migrations
{
    public partial class secondupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "Reciever",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "Sender",
                table: "Message");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Pharmacy",
                newName: "Address_town");

            migrationBuilder.RenameColumn(
                name: "PharmacyID",
                table: "Order",
                newName: "Pharmacy_id");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Order",
                newName: "Date_time");

            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Message",
                newName: "Status");

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

            migrationBuilder.AddColumn<string>(
                name: "Address_street",
                table: "Pharmacy",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Customer_id",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "status2",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "M_date_time",
                table: "Message",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Reciever_id",
                table: "Message",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Sender_id",
                table: "Message",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_district",
                table: "Pharmacy");

            migrationBuilder.DropColumn(
                name: "Address_no",
                table: "Pharmacy");

            migrationBuilder.DropColumn(
                name: "Address_street",
                table: "Pharmacy");

            migrationBuilder.DropColumn(
                name: "Customer_id",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "status2",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "M_date_time",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "Reciever_id",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "Sender_id",
                table: "Message");

            migrationBuilder.RenameColumn(
                name: "Address_town",
                table: "Pharmacy",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "Pharmacy_id",
                table: "Order",
                newName: "PharmacyID");

            migrationBuilder.RenameColumn(
                name: "Date_time",
                table: "Order",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Message",
                newName: "Time");

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "Message",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reciever",
                table: "Message",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sender",
                table: "Message",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
