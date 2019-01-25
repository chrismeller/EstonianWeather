using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EstonianWeather.Data.Migrations
{
    public partial class AddFinnish : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FinnishForecasts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RequestId = table.Column<Guid>(nullable: false),
                    RequestedLocation = table.Column<string>(nullable: true),
                    RequestedAt = table.Column<DateTimeOffset>(nullable: false),
                    Time = table.Column<string>(maxLength: 20, nullable: true),
                    Location = table.Column<string>(nullable: true),
                    GeopHeight = table.Column<string>(nullable: true),
                    Temperature = table.Column<string>(nullable: true),
                    Pressure = table.Column<string>(nullable: true),
                    Humidity = table.Column<string>(nullable: true),
                    WindDirection = table.Column<string>(nullable: true),
                    WindSpeedMS = table.Column<string>(nullable: true),
                    WindUMS = table.Column<string>(nullable: true),
                    WindVMS = table.Column<string>(nullable: true),
                    MaximumWind = table.Column<string>(nullable: true),
                    WindGust = table.Column<string>(nullable: true),
                    DewPoint = table.Column<string>(nullable: true),
                    TotalCloudCover = table.Column<string>(nullable: true),
                    WeatherSymbol3 = table.Column<string>(nullable: true),
                    LowCloudCover = table.Column<string>(nullable: true),
                    MediumCloudCover = table.Column<string>(nullable: true),
                    HighCloudCover = table.Column<string>(nullable: true),
                    Precipitation1h = table.Column<string>(nullable: true),
                    PrecipitationAmount = table.Column<string>(nullable: true),
                    RadiationGlobalAccumulation = table.Column<string>(nullable: true),
                    RadiationLWAccumulation = table.Column<string>(nullable: true),
                    RadiationNetSurfaceLWAccumulation = table.Column<string>(nullable: true),
                    RadiationNetSurfaceSWAccumulation = table.Column<string>(nullable: true),
                    RadiationDiffuseAccumulation = table.Column<string>(nullable: true),
                    LandSeaMask = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinnishForecasts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FinnishForecasts_Id",
                table: "FinnishForecasts",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FinnishForecasts_RequestId",
                table: "FinnishForecasts",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_FinnishForecasts_RequestedAt",
                table: "FinnishForecasts",
                column: "RequestedAt");

            migrationBuilder.CreateIndex(
                name: "IX_FinnishForecasts_Time",
                table: "FinnishForecasts",
                column: "Time");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinnishForecasts");
        }
    }
}
