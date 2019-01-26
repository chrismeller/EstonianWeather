﻿// <auto-generated />
using System;
using EstonianWeather.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EstonianWeather.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190126123403_RenameColumns")]
    partial class RenameColumns
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EstonianWeather.Data.Models.FinnishForecast", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DewPoint");

                    b.Property<string>("GeopHeight");

                    b.Property<string>("HighCloudCover");

                    b.Property<string>("Humidity");

                    b.Property<string>("LandSeaMask");

                    b.Property<string>("Location");

                    b.Property<string>("LowCloudCover");

                    b.Property<string>("MaximumWind");

                    b.Property<string>("MediumCloudCover");

                    b.Property<string>("Precipitation1h");

                    b.Property<string>("PrecipitationAmount");

                    b.Property<string>("Pressure");

                    b.Property<string>("RadiationDiffuseAccumulation");

                    b.Property<string>("RadiationGlobalAccumulation");

                    b.Property<string>("RadiationLWAccumulation");

                    b.Property<string>("RadiationNetSurfaceLWAccumulation");

                    b.Property<string>("RadiationNetSurfaceSWAccumulation");

                    b.Property<Guid>("RequestId");

                    b.Property<string>("RequestLocation");

                    b.Property<DateTimeOffset>("RequestedAt");

                    b.Property<string>("Temperature");

                    b.Property<string>("Time")
                        .HasMaxLength(20);

                    b.Property<string>("TotalCloudCover");

                    b.Property<string>("WeatherSymbol3");

                    b.Property<string>("WindDirection");

                    b.Property<string>("WindGust");

                    b.Property<string>("WindSpeedMS");

                    b.Property<string>("WindUMS");

                    b.Property<string>("WindVMS");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("RequestId");

                    b.HasIndex("RequestedAt");

                    b.HasIndex("Time");

                    b.ToTable("FinnishForecasts");
                });
#pragma warning restore 612, 618
        }
    }
}
