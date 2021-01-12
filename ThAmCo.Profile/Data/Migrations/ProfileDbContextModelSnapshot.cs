﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ThAmCo.Profile.Data;

namespace ThAmCo.Profile.Data.Migrations
{
    [DbContext(typeof(ProfileDbContext))]
    partial class ProfileDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ThAmCo.Profile.Data.Entities.ProfileAddress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("AddressLine1")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Postcode")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid?>("ProfileId")
                        .HasColumnType("char(36)");

                    b.Property<string>("TownCity")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("ThAmCo.Profile.Data.Entities.ProfileEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Forename")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Surname")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Username")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("ThAmCo.Profile.Data.Entities.ProfileAddress", b =>
                {
                    b.HasOne("ThAmCo.Profile.Data.Entities.ProfileEntity", null)
                        .WithMany("Addresses")
                        .HasForeignKey("ProfileId");
                });
#pragma warning restore 612, 618
        }
    }
}