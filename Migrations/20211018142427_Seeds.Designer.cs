﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using gttgBackend.Models;

namespace gttgBackend.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20211018142427_Seeds")]
    partial class Seeds
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("gttgBackend.Models.EventData", b =>
                {
                    b.Property<int>("EventDataID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("EventName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int?>("TripDataID")
                        .HasColumnType("int");

                    b.HasKey("EventDataID");

                    b.HasIndex("TripDataID");

                    b.ToTable("EventList");

                    b.HasData(
                        new
                        {
                            EventDataID = 1,
                            Date = new DateTime(2054, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EventName = "Party hat trading convention",
                            Location = "Asteroid 9484643",
                            Price = 250f
                        });
                });

            modelBuilder.Entity("gttgBackend.Models.LodgingData", b =>
                {
                    b.Property<int>("LodgingDataID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlanetID")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("LodgingDataID");

                    b.ToTable("LodgingList");

                    b.HasData(
                        new
                        {
                            LodgingDataID = 1,
                            Location = "Middle of nowhere",
                            Name = "Costa Cafe",
                            PlanetID = 1,
                            Price = 49.99f,
                            Rating = 4
                        });
                });

            modelBuilder.Entity("gttgBackend.Models.PlanetData", b =>
                {
                    b.Property<int>("PlanetDataID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlanetDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlanetName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Population")
                        .HasColumnType("int");

                    b.Property<string>("Race")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("X")
                        .HasColumnType("int");

                    b.Property<int>("Y")
                        .HasColumnType("int");

                    b.HasKey("PlanetDataID");

                    b.ToTable("PLanetList");

                    b.HasData(
                        new
                        {
                            PlanetDataID = 1,
                            ImageName = "Anonym",
                            PlanetDescription = "First planet in DB",
                            PlanetName = "Planet1",
                            Population = 2,
                            Race = "F1",
                            X = 10,
                            Y = 50
                        });
                });

            modelBuilder.Entity("gttgBackend.Models.TravelType", b =>
                {
                    b.Property<int>("TravelTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<float>("Speed")
                        .HasColumnType("real");

                    b.HasKey("TravelTypeID");

                    b.ToTable("TravelTypeList");

                    b.HasData(
                        new
                        {
                            TravelTypeID = 1,
                            Name = "SpaceBus",
                            Price = 25.5f,
                            Speed = 7f
                        });
                });

            modelBuilder.Entity("gttgBackend.Models.TripData", b =>
                {
                    b.Property<int>("TripDataID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CurrentlySelectedLodgingLodgingDataID")
                        .HasColumnType("int");

                    b.Property<int?>("DestinationPlanetPlanetDataID")
                        .HasColumnType("int");

                    b.Property<float>("DistanceBetweenDestinations")
                        .HasColumnType("real");

                    b.Property<DateTime>("LodgingBookedFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LodgingBookedUntil")
                        .HasColumnType("datetime2");

                    b.Property<float>("LodgingPrice")
                        .HasColumnType("real");

                    b.Property<int?>("StartingPlanetPlanetDataID")
                        .HasColumnType("int");

                    b.Property<float>("TotalEventPrice")
                        .HasColumnType("real");

                    b.Property<float>("TotalTravelPrice")
                        .HasColumnType("real");

                    b.Property<float>("TravelTime")
                        .HasColumnType("real");

                    b.Property<int?>("TravelTypeID")
                        .HasColumnType("int");

                    b.HasKey("TripDataID");

                    b.HasIndex("CurrentlySelectedLodgingLodgingDataID");

                    b.HasIndex("DestinationPlanetPlanetDataID");

                    b.HasIndex("StartingPlanetPlanetDataID");

                    b.HasIndex("TravelTypeID");

                    b.ToTable("TripList");
                });

            modelBuilder.Entity("gttgBackend.Models.EventData", b =>
                {
                    b.HasOne("gttgBackend.Models.TripData", null)
                        .WithMany("AttendedEvents")
                        .HasForeignKey("TripDataID");
                });

            modelBuilder.Entity("gttgBackend.Models.TripData", b =>
                {
                    b.HasOne("gttgBackend.Models.LodgingData", "CurrentlySelectedLodging")
                        .WithMany()
                        .HasForeignKey("CurrentlySelectedLodgingLodgingDataID");

                    b.HasOne("gttgBackend.Models.PlanetData", "DestinationPlanet")
                        .WithMany()
                        .HasForeignKey("DestinationPlanetPlanetDataID");

                    b.HasOne("gttgBackend.Models.PlanetData", "StartingPlanet")
                        .WithMany()
                        .HasForeignKey("StartingPlanetPlanetDataID");

                    b.HasOne("gttgBackend.Models.TravelType", "TravelType")
                        .WithMany()
                        .HasForeignKey("TravelTypeID");

                    b.Navigation("CurrentlySelectedLodging");

                    b.Navigation("DestinationPlanet");

                    b.Navigation("StartingPlanet");

                    b.Navigation("TravelType");
                });

            modelBuilder.Entity("gttgBackend.Models.TripData", b =>
                {
                    b.Navigation("AttendedEvents");
                });
#pragma warning restore 612, 618
        }
    }
}
