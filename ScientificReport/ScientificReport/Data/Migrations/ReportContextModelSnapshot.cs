﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ScientificReport.Data.DataAccess;

namespace ScientificReport.Migrations
{
    [DbContext(typeof(ReportContext))]
    partial class ReportContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ScientificReport.Data.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int?>("PublicationId");

                    b.HasKey("Id");

                    b.HasIndex("PublicationId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("ScientificReport.Data.Models.Publication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<int>("Status");

                    b.Property<string>("Time");

                    b.Property<string>("Topic");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Publications");
                });

            modelBuilder.Entity("ScientificReport.Data.Models.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contetnt");

                    b.Property<DateTime>("Date");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("ScientificReport.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthdate");

                    b.Property<string>("Department");

                    b.Property<string>("Faculty");

                    b.Property<string>("Graduation");

                    b.Property<DateTime>("GraduationDate");

                    b.Property<bool>("IsAdmin");

                    b.Property<bool>("IsApproved");

                    b.Property<string>("Name");

                    b.Property<int>("Role");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ScientificReport.Data.Models.Author", b =>
                {
                    b.HasOne("ScientificReport.Data.Models.Publication")
                        .WithMany("Authors")
                        .HasForeignKey("PublicationId");
                });

            modelBuilder.Entity("ScientificReport.Data.Models.Publication", b =>
                {
                    b.HasOne("ScientificReport.Data.Models.User")
                        .WithMany("Publications")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ScientificReport.Data.Models.Report", b =>
                {
                    b.HasOne("ScientificReport.Data.Models.User")
                        .WithMany("Reports")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
