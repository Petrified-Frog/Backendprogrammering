using Microsoft.EntityFrameworkCore.Migrations;

namespace Uppgift_3_Entityframework_codeFirst.Migrations
{
    public partial class fixtypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ESmail",
                table: "Guests",
                newName: "Email");

            migrationBuilder.AlterColumn<short>(
                name: "PaymentMethod",
                table: "Reservations",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Guests",
                newName: "ESmail");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentMethod",
                table: "Reservations",
                type: "int",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");
        }
    }
}
