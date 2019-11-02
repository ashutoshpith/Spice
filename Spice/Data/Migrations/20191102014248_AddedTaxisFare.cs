using Microsoft.EntityFrameworkCore.Migrations;

namespace Spice.Data.Migrations
{
    public partial class AddedTaxisFare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Taxi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorId = table.Column<string>(nullable: true),
                    RateCode = table.Column<float>(nullable: false),
                    PassengerCount = table.Column<float>(nullable: false),
                    TripTimeInSecs = table.Column<float>(nullable: false),
                    TripDistance = table.Column<float>(nullable: false),
                    PaymentType = table.Column<string>(nullable: true),
                    FareAmount = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxi", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Taxi");
        }
    }
}
