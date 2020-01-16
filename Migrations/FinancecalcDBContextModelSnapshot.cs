﻿// <auto-generated />
using System;
using Financecalc_Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FinancecalcServer.Migrations
{
    [DbContext(typeof(FinancecalcDBContext))]
    partial class FinancecalcDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Financecalc_Server.Models.Clasificacion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ClasificacionId");

                    b.Property<int>("Code");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Clasificacion");
                });

            modelBuilder.Entity("Financecalc_Server.Models.Cuenta", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CuentaId");

                    b.Property<string>("Code");

                    b.Property<string>("Document");

                    b.Property<string>("Name");

                    b.Property<Guid?>("SubclasificacionId");

                    b.HasKey("Id");

                    b.HasIndex("SubclasificacionId");

                    b.ToTable("Cuenta");
                });

            modelBuilder.Entity("Financecalc_Server.Models.Subclasificacion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("SubclasificacionId");

                    b.Property<Guid?>("ClasificacionId");

                    b.Property<int>("Code");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("ClasificacionId");

                    b.ToTable("Subclasificacion");
                });

            modelBuilder.Entity("Financecalc_Server.Models.Cuenta", b =>
                {
                    b.HasOne("Financecalc_Server.Models.Subclasificacion", "Subclasification")
                        .WithMany("Cuentas")
                        .HasForeignKey("SubclasificacionId");
                });

            modelBuilder.Entity("Financecalc_Server.Models.Subclasificacion", b =>
                {
                    b.HasOne("Financecalc_Server.Models.Clasificacion", "Clasification")
                        .WithMany("Subclasifications")
                        .HasForeignKey("ClasificacionId");
                });
#pragma warning restore 612, 618
        }
    }
}
