using Microsoft.EntityFrameworkCore.Migrations;

namespace egdbooking_v2.Data.Migrations
{
    public partial class DeleteNullBookings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

          migrationBuilder.Sql(@"
              DELETE FROM Bookings WHERE VesselID IS NULL;
          ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
