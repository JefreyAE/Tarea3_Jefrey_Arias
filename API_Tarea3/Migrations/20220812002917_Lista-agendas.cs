using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Tarea3.Migrations
{
    public partial class Listaagendas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Agendas_AppointmentId",
                table: "Agendas");

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_AppointmentId",
                table: "Agendas",
                column: "AppointmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Agendas_AppointmentId",
                table: "Agendas");

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_AppointmentId",
                table: "Agendas",
                column: "AppointmentId",
                unique: true);
        }
    }
}
