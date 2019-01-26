using Microsoft.EntityFrameworkCore.Migrations;

namespace EstonianWeather.Data.Migrations
{
    public partial class RenameColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequestedLocation",
                table: "FinnishForecasts",
                newName: "RequestLocation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequestLocation",
                table: "FinnishForecasts",
                newName: "RequestedLocation");
        }
    }
}
