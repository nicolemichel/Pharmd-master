﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Phramd.Models;

namespace Phramd.Migrations
{
    [DbContext(typeof(PhramdContext))]
    partial class PhramdContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Phramd.Models.CalendarModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UserID");

                    b.Property<string>("apple")
                        .HasMaxLength(100);

                    b.Property<DateTime>("emailadded");

                    b.Property<DateTime>("emailremoved");

                    b.Property<string>("gmail")
                        .HasMaxLength(100);

                    b.Property<string>("microsoft")
                        .HasMaxLength(100);

                    b.HasKey("id");

                    b.HasIndex("UserID");

                    b.ToTable("CalendarModel");
                });

            modelBuilder.Entity("Phramd.Models.DTFormatsDB", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Date");

                    b.Property<string>("Day");

                    b.Property<string>("Hour");

                    b.Property<string>("Minutes");

                    b.Property<string>("Month");

                    b.Property<string>("Seconds");

                    b.Property<string>("Time");

                    b.Property<string>("Year");

                    b.Property<int>("userId");

                    b.HasKey("id");

                    b.HasIndex("userId");

                    b.ToTable("DateTimeFormats");
                });

            modelBuilder.Entity("Phramd.Models.NewsDB", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("articles")
                        .IsRequired();

                    b.Property<string>("country")
                        .IsRequired();

                    b.Property<string>("status")
                        .IsRequired();

                    b.Property<string>("time")
                        .IsRequired();

                    b.Property<int>("userId");

                    b.HasKey("id");

                    b.HasIndex("userId");

                    b.ToTable("News");
                });

            modelBuilder.Entity("Phramd.Models.PhotoAccounts", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UserID");

                    b.Property<string>("apple")
                        .HasMaxLength(100);

                    b.Property<DateTime>("emailadded");

                    b.Property<DateTime>("emailremoved");

                    b.Property<string>("gmail")
                        .HasMaxLength(100);

                    b.Property<string>("microsoft")
                        .HasMaxLength(100);

                    b.HasKey("id");

                    b.HasIndex("UserID");

                    b.ToTable("PhotoAccounts");
                });

            modelBuilder.Entity("Phramd.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("canceldate");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("signupdate");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Phramd.Models.WeatherDB", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("city")
                        .IsRequired();

                    b.Property<string>("country")
                        .IsRequired();

                    b.Property<string>("status")
                        .IsRequired();

                    b.Property<string>("unit")
                        .IsRequired();

                    b.Property<int>("userId");

                    b.HasKey("id");

                    b.HasIndex("userId");

                    b.ToTable("Weather");
                });

            modelBuilder.Entity("Phramd.Models.CalendarModel", b =>
                {
                    b.HasOne("Phramd.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Phramd.Models.DTFormatsDB", b =>
                {
                    b.HasOne("Phramd.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Phramd.Models.NewsDB", b =>
                {
                    b.HasOne("Phramd.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Phramd.Models.PhotoAccounts", b =>
                {
                    b.HasOne("Phramd.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Phramd.Models.WeatherDB", b =>
                {
                    b.HasOne("Phramd.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
