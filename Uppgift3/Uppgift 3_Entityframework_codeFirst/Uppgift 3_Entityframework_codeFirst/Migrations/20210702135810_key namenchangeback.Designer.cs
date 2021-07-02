﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Uppgift_3_Entityframework_codeFirst.Data;

namespace Uppgift_3_Entityframework_codeFirst.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210702135810_key namenchangeback")]
    partial class keynamenchangeback
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GuestReservation", b =>
                {
                    b.Property<int>("GuestsID")
                        .HasColumnType("int");

                    b.Property<int>("ReservationsReservationNr")
                        .HasColumnType("int");

                    b.HasKey("GuestsID", "ReservationsReservationNr");

                    b.HasIndex("ReservationsReservationNr");

                    b.ToTable("GuestReservation");
                });

            modelBuilder.Entity("Uppgift_3_Entityframework_codeFirst.Models.Guest", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ReservationNr")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("Uppgift_3_Entityframework_codeFirst.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationNr")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CheckinDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckoutDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GuestId")
                        .HasColumnType("int");

                    b.Property<short>("PaymentMethod")
                        .HasColumnType("smallint");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("ReservationNr");

                    b.HasIndex("RoomId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Uppgift_3_Entityframework_codeFirst.Models.Room", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<short>("RoomType")
                        .HasColumnType("smallint");

                    b.HasKey("ID");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("GuestReservation", b =>
                {
                    b.HasOne("Uppgift_3_Entityframework_codeFirst.Models.Guest", null)
                        .WithMany()
                        .HasForeignKey("GuestsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Uppgift_3_Entityframework_codeFirst.Models.Reservation", null)
                        .WithMany()
                        .HasForeignKey("ReservationsReservationNr")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Uppgift_3_Entityframework_codeFirst.Models.Reservation", b =>
                {
                    b.HasOne("Uppgift_3_Entityframework_codeFirst.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });
#pragma warning restore 612, 618
        }
    }
}
