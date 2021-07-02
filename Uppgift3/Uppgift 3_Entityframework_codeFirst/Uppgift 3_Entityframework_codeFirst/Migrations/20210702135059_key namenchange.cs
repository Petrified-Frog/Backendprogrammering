using Microsoft.EntityFrameworkCore.Migrations;

namespace Uppgift_3_Entityframework_codeFirst.Migrations
{
    public partial class keynamenchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuestReservation_Reservations_ReservationsReservationNr",
                table: "GuestReservation");

            migrationBuilder.RenameColumn(
                name: "ReservationNr",
                table: "Reservations",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "ReservationsReservationNr",
                table: "GuestReservation",
                newName: "ReservationsID");

            migrationBuilder.RenameIndex(
                name: "IX_GuestReservation_ReservationsReservationNr",
                table: "GuestReservation",
                newName: "IX_GuestReservation_ReservationsID");

            migrationBuilder.AddForeignKey(
                name: "FK_GuestReservation_Reservations_ReservationsID",
                table: "GuestReservation",
                column: "ReservationsID",
                principalTable: "Reservations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuestReservation_Reservations_ReservationsID",
                table: "GuestReservation");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Reservations",
                newName: "ReservationNr");

            migrationBuilder.RenameColumn(
                name: "ReservationsID",
                table: "GuestReservation",
                newName: "ReservationsReservationNr");

            migrationBuilder.RenameIndex(
                name: "IX_GuestReservation_ReservationsID",
                table: "GuestReservation",
                newName: "IX_GuestReservation_ReservationsReservationNr");

            migrationBuilder.AddForeignKey(
                name: "FK_GuestReservation_Reservations_ReservationsReservationNr",
                table: "GuestReservation",
                column: "ReservationsReservationNr",
                principalTable: "Reservations",
                principalColumn: "ReservationNr",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
