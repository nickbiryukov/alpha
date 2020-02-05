﻿// <auto-generated />
using System;
using Alpha.Reservation.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Alpha.Reservation.API.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20200205084350_UpdateUser3")]
    partial class UpdateUser3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Alpha.Reservation.Data.Entities.Reservation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<bool>("IsConfirmed")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("ReservationEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("ReservationStart")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.HasIndex("UserId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Alpha.Reservation.Data.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Office Manager"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Employee"
                        });
                });

            modelBuilder.Entity("Alpha.Reservation.Data.Entities.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Board")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("Projector")
                        .HasColumnType("bit");

                    b.Property<int>("Seat")
                        .HasColumnType("int")
                        .HasMaxLength(1000);

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Alpha.Reservation.Data.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("10000000-0000-0000-0000-000000000000"),
                            Login = "Manager",
                            Name = "ManagerName",
                            PasswordHash = "9xHnygSC9V42fWBY8eqA8Q==.Yif8svarnDn8f+N3bhQ/6MyUSSIoo55uXIWv9XtFxyE=",
                            RoleId = 1,
                            Surname = "ManagerSurname"
                        },
                        new
                        {
                            Id = new Guid("20000000-0000-0000-0000-000000000000"),
                            Login = "Employee",
                            Name = "EmployeeName",
                            PasswordHash = "9xHnygSC9V42fWBY8eqA8Q==.Yif8svarnDn8f+N3bhQ/6MyUSSIoo55uXIWv9XtFxyE=",
                            RoleId = 2,
                            Surname = "EmployeeSurname"
                        });
                });

            modelBuilder.Entity("Alpha.Reservation.Data.Entities.Reservation", b =>
                {
                    b.HasOne("Alpha.Reservation.Data.Entities.Room", "Room")
                        .WithMany("Reservations")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Alpha.Reservation.Data.Entities.User", "User")
                        .WithMany("Reservations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Alpha.Reservation.Data.Entities.User", b =>
                {
                    b.HasOne("Alpha.Reservation.Data.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
