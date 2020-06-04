using Microsoft.EntityFrameworkCore.Migrations;

namespace TotalFlight.Infrastructure.Migrations
{
    public partial class Aircraftadditions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Eng1SerialNum",
                table: "Aircraft",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Eng2SerialNum",
                table: "Aircraft",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EngModel",
                table: "Aircraft",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prop1SerialNum",
                table: "Aircraft",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prop2SerialNum",
                table: "Aircraft",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PropModel",
                table: "Aircraft",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SerialNum",
                table: "Aircraft",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Eng1SerialNum",
                table: "Aircraft");

            migrationBuilder.DropColumn(
                name: "Eng2SerialNum",
                table: "Aircraft");

            migrationBuilder.DropColumn(
                name: "EngModel",
                table: "Aircraft");

            migrationBuilder.DropColumn(
                name: "Prop1SerialNum",
                table: "Aircraft");

            migrationBuilder.DropColumn(
                name: "Prop2SerialNum",
                table: "Aircraft");

            migrationBuilder.DropColumn(
                name: "PropModel",
                table: "Aircraft");

            migrationBuilder.DropColumn(
                name: "SerialNum",
                table: "Aircraft");
        }
    }
}
