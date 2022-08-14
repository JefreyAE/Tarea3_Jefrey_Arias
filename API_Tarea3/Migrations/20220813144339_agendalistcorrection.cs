using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Tarea3.Migrations
{
    public partial class agendalistcorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Agendas_AppointmentId",
                table: "Agendas",
                column: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendas_Appointments_AppointmentId",
                table: "Agendas",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendas_Appointments_AppointmentId",
                table: "Agendas");

            migrationBuilder.DropIndex(
                name: "IX_Agendas_AppointmentId",
                table: "Agendas");
        }
    }
}
