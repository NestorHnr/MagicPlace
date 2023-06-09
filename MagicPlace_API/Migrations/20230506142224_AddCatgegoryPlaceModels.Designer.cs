﻿// <auto-generated />
using System;
using MagicPlace_API.DataAdapters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MagicPlace_API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230506142224_AddCatgegoryPlaceModels")]
    partial class AddCatgegoryPlaceModels
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MagicPlace_API.Models.CategoryPlace", b =>
                {
                    b.Property<int>("NuCategory")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("PlaceId")
                        .HasColumnType("int");

                    b.Property<string>("SpecialDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("NuCategory");

                    b.HasIndex("PlaceId");

                    b.ToTable("CategoriesPlaces");
                });

            modelBuilder.Entity("MagicPlace_API.Models.Place", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Cost")
                        .HasColumnType("float");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ocupants")
                        .HasColumnType("int");

                    b.Property<string>("Service")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SquareMeters")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Places");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cost = 5.0,
                            DateCreate = new DateTime(2023, 5, 6, 9, 22, 24, 401, DateTimeKind.Local).AddTicks(9941),
                            DateUpdate = new DateTime(2023, 5, 6, 9, 22, 24, 401, DateTimeKind.Local).AddTicks(9955),
                            Detail = "test",
                            ImageUrl = "test",
                            Name = "Test",
                            Ocupants = 5,
                            Service = "",
                            SquareMeters = 5
                        });
                });

            modelBuilder.Entity("MagicPlace_API.Models.CategoryPlace", b =>
                {
                    b.HasOne("MagicPlace_API.Models.Place", "Place")
                        .WithMany()
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Place");
                });
#pragma warning restore 612, 618
        }
    }
}
