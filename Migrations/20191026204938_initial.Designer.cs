﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProyectoFinanzas_Server.Models;

namespace ProyectoFinanzasServer.Migrations
{
    [DbContext(typeof(ProyectoFinanzasDBContext))]
    [Migration("20191026204938_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("ProyectoFinanzas_Server.Models.Clasificacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Clasificacion");
                });

            modelBuilder.Entity("ProyectoFinanzas_Server.Models.Cuenta", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Document");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Cuenta");
                });

            modelBuilder.Entity("ProyectoFinanzas_Server.Models.Subclasificacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Subclasificacion");
                });
#pragma warning restore 612, 618
        }
    }
}
