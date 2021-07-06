using Microsoft.EntityFrameworkCore.Migrations;

namespace Uppgift_3_Entityframework_codeFirst.Migrations
{
    public partial class removedouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuestReservation");

            migrationBuilder.DropColumn(
                name: "GuestId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ReservationNr",
                table: "Guests");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GuestId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReservationNr",
                table: "Guests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GuestReservation",
                columns: table => new
                {
                    GuestsID = table.Column<int>(type: "int", nullable: false),
                    ReservationsReservationNr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestReservation", x => new { x.GuestsID, x.ReservationsReservationNr });
                    table.ForeignKey(
                        name: "FK_GuestReservation_Guests_GuestsID",
                        column: x => x.GuestsID,
                        principalTable: "Guests",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuestReservation_Reservations_ReservationsReservationNr",
                        column: x => x.ReservationsReservationNr,
                        principalTable: "Reservations",
                        principalColumn: "ReservationNr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GuestReservation_ReservationsReservationNr",
                table: "GuestReservation",
                column: "ReservationsReservationNr");
        }
    }
}
