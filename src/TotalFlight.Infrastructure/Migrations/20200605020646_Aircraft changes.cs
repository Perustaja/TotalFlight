using Microsoft.EntityFrameworkCore.Migrations;

namespace TotalFlight.Infrastructure.Migrations
{
    public partial class Aircraftchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EngModel",
                table: "Aircraft");

            migrationBuilder.DropColumn(
                name: "PropModel",
                table: "Aircraft");

            migrationBuilder.AddColumn<string>(
                name: "Eng1Model",
                table: "Aircraft",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Eng2Model",
                table: "Aircraft",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prop1Model",
                table: "Aircraft",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prop2Model",
                table: "Aircraft",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Eng1Model",
                table: "Aircraft");

            migrationBuilder.DropColumn(
                name: "Eng2Model",
                table: "Aircraft");

            migrationBuilder.DropColumn(
                name: "Prop1Model",
                table: "Aircraft");

            migrationBuilder.DropColumn(
                name: "Prop2Model",
                table: "Aircraft");

            migrationBuilder.AddColumn<string>(
                name: "EngModel",
                table: "Aircraft",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PropModel",
                table: "Aircraft",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
