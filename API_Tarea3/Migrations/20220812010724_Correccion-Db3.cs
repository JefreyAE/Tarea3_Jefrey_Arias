using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Tarea3.Migrations
{
    public partial class CorreccionDb3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Specialty",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Appointments");

            migrationBuilder.AddColumn<string>(
                name: "Specialty",
                table: "Agendas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Agendas",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Specialty",
                table: "Agendas");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Agendas");

            migrationBuilder.AddColumn<string>(
                name: "Specialty",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
