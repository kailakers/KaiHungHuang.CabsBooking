using Microsoft.EntityFrameworkCore.Migrations;

namespace CabsBooking.Infrastructure.Migrations
{
    public partial class ColumnNameModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "comp_time",
                table: "Bookings_history",
                newName: "Comp_time");

            migrationBuilder.RenameColumn(
                name: "charge",
                table: "Bookings_history",
                newName: "Charge");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Comp_time",
                table: "Bookings_history",
                newName: "comp_time");

            migrationBuilder.RenameColumn(
                name: "Charge",
                table: "Bookings_history",
                newName: "charge");
        }
    }
}
