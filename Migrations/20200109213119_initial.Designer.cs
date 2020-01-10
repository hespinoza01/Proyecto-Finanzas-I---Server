﻿// <auto-generated />
using System;
using Financecalc_Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FinancecalcServer.Migrations
{
    [DbContext(typeof(FinancecalcDBContext))]
    [Migration("20200109213119_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Financecalc_Server.Models.Clasificacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Clasificacion");
                });

            modelBuilder.Entity("Financecalc_Server.Models.Cuenta", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Document");

                    b.Property<string>("Name");

                    b.Property<int?>("SubclasificationId");

                    b.HasKey("Id");

                    b.HasIndex("SubclasificationId");

                    b.ToTable("Cuenta");
                });

            modelBuilder.Entity("Financecalc_Server.Models.Subclasificacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ClasificationId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("ClasificationId");

                    b.ToTable("Subclasificacion");
                });

            modelBuilder.Entity("Financecalc_Server.Models.Cuenta", b =>
                {
                    b.HasOne("Financecalc_Server.Models.Subclasificacion", "Subclasification")
                        .WithMany("Cuentas")
                        .HasForeignKey("SubclasificationId");
                });

            modelBuilder.Entity("Financecalc_Server.Models.Subclasificacion", b =>
                {
                    b.HasOne("Financecalc_Server.Models.Clasificacion", "Clasification")
                        .WithMany("Subclasifications")
                        .HasForeignKey("ClasificationId");
                });
#pragma warning restore 612, 618
        }
    }
}