using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace integradora555.Migrations
{
    public partial class servidor2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Casa",
                columns: table => new
                {
                    CasaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreDeCasa = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    domicilio = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    NombreDueño = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    imagenDeCasa = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    alquilada = table.Column<bool>(type: "bit", nullable: false),
                    eliminada = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casa", x => x.CasaId);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    clienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Dni = table.Column<int>(type: "int", nullable: false),
                    FechaDeNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.clienteId);
                });

            migrationBuilder.CreateTable(
                name: "Alquiler",
                columns: table => new
                {
                    AlquilerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaDeAlquiler = table.Column<DateTime>(type: "datetime2", nullable: false),
                    clienteId = table.Column<int>(type: "int", nullable: false),
                    casaId = table.Column<int>(type: "int", nullable: false),
                    ClienteNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CasaNombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alquiler", x => x.AlquilerId);
                    table.ForeignKey(
                        name: "FK_Alquiler_Casa_casaId",
                        column: x => x.casaId,
                        principalTable: "Casa",
                        principalColumn: "CasaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alquiler_Cliente_clienteId",
                        column: x => x.clienteId,
                        principalTable: "Cliente",
                        principalColumn: "clienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Devolucion",
                columns: table => new
                {
                    DevolucionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaDevolucion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlqulerId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    CasaId = table.Column<int>(type: "int", nullable: false),
                    ClienteNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CasaNombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devolucion", x => x.DevolucionId);
                    table.ForeignKey(
                        name: "FK_Devolucion_Casa_CasaId",
                        column: x => x.CasaId,
                        principalTable: "Casa",
                        principalColumn: "CasaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Devolucion_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "clienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alquiler_casaId",
                table: "Alquiler",
                column: "casaId");

            migrationBuilder.CreateIndex(
                name: "IX_Alquiler_clienteId",
                table: "Alquiler",
                column: "clienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Devolucion_CasaId",
                table: "Devolucion",
                column: "CasaId");

            migrationBuilder.CreateIndex(
                name: "IX_Devolucion_ClienteId",
                table: "Devolucion",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alquiler");

            migrationBuilder.DropTable(
                name: "Devolucion");

            migrationBuilder.DropTable(
                name: "Casa");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
