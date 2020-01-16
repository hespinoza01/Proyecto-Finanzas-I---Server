using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinancecalcServer.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clasificacion",
                columns: table => new
                {
                    ClasificacionId = table.Column<Guid>(nullable: false),
                    Code = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clasificacion", x => x.ClasificacionId);
                });

            migrationBuilder.CreateTable(
                name: "Subclasificacion",
                columns: table => new
                {
                    SubclasificacionId = table.Column<Guid>(nullable: false),
                    Code = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ClasificacionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subclasificacion", x => x.SubclasificacionId);
                    table.ForeignKey(
                        name: "FK_Subclasificacion_Clasificacion_ClasificacionId",
                        column: x => x.ClasificacionId,
                        principalTable: "Clasificacion",
                        principalColumn: "ClasificacionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cuenta",
                columns: table => new
                {
                    CuentaId = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    SubclasificacionId = table.Column<Guid>(nullable: true),
                    Document = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuenta", x => x.CuentaId);
                    table.ForeignKey(
                        name: "FK_Cuenta_Subclasificacion_SubclasificacionId",
                        column: x => x.SubclasificacionId,
                        principalTable: "Subclasificacion",
                        principalColumn: "SubclasificacionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cuenta_SubclasificacionId",
                table: "Cuenta",
                column: "SubclasificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Subclasificacion_ClasificacionId",
                table: "Subclasificacion",
                column: "ClasificacionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cuenta");

            migrationBuilder.DropTable(
                name: "Subclasificacion");

            migrationBuilder.DropTable(
                name: "Clasificacion");
        }
    }
}
