﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebTeploobmen.Data;

#nullable disable

namespace WebTeploobmen.Migrations
{
    [DbContext(typeof(WebTeploobmenContext))]
    [Migration("20241222204025_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.36");

            modelBuilder.Entity("WebTeploobmen.Data.Variant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("diametr")
                        .HasColumnType("REAL");

                    b.Property<double>("gaztemp")
                        .HasColumnType("REAL");

                    b.Property<double>("gaztepl")
                        .HasColumnType("REAL");

                    b.Property<double>("haste")
                        .HasColumnType("REAL");

                    b.Property<double>("height")
                        .HasColumnType("REAL");

                    b.Property<double>("koef")
                        .HasColumnType("REAL");

                    b.Property<double>("mattemp")
                        .HasColumnType("REAL");

                    b.Property<double>("mattepl")
                        .HasColumnType("REAL");

                    b.Property<double>("rashod")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Variants");
                });
#pragma warning restore 612, 618
        }
    }
}