using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Biblioteca.DAL.Migrations
{
    public partial class Primeramig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sucursales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 30, nullable: false),
                    Direccion = table.Column<string>(nullable: false),
                    Telefono = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    FechaApertura = table.Column<DateTime>(nullable: false),
                    ImagenURL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tarjeta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cargos = table.Column<decimal>(nullable: false),
                    Creada = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarjeta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Activos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(nullable: false),
                    Anio = table.Column<int>(nullable: false),
                    EstatusId = table.Column<int>(nullable: false),
                    Costo = table.Column<decimal>(nullable: false),
                    ImagenUrl = table.Column<string>(nullable: true),
                    NumCopias = table.Column<int>(nullable: false),
                    UbicacionId = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    ISBN = table.Column<string>(nullable: true),
                    Autor = table.Column<string>(nullable: true),
                    IndiceDewey = table.Column<string>(nullable: true),
                    Director = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activos_Estatus_EstatusId",
                        column: x => x.EstatusId,
                        principalTable: "Estatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activos_Sucursales_UbicacionId",
                        column: x => x.UbicacionId,
                        principalTable: "Sucursales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SucursalHoras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SucursalId = table.Column<int>(nullable: true),
                    DiaSemana = table.Column<int>(nullable: false),
                    HoraApertura = table.Column<int>(nullable: false),
                    HoraCierre = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SucursalHoras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SucursalHoras_Sucursales_SucursalId",
                        column: x => x.SucursalId,
                        principalTable: "Sucursales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: false),
                    Apellido = table.Column<string>(nullable: false),
                    Direccion = table.Column<string>(nullable: false),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    Telefono = table.Column<string>(nullable: true),
                    TarjetaId = table.Column<int>(nullable: true),
                    SucursalAsociadaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_Sucursales_SucursalAsociadaId",
                        column: x => x.SucursalAsociadaId,
                        principalTable: "Sucursales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clientes_Tarjeta_TarjetaId",
                        column: x => x.TarjetaId,
                        principalTable: "Tarjeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActivoId = table.Column<int>(nullable: true),
                    TarjetaId = table.Column<int>(nullable: true),
                    Desde = table.Column<DateTime>(nullable: false),
                    Hasta = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagos_Activos_ActivoId",
                        column: x => x.ActivoId,
                        principalTable: "Activos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pagos_Tarjeta_TarjetaId",
                        column: x => x.TarjetaId,
                        principalTable: "Tarjeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PagosHistoriall",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActivoId = table.Column<int>(nullable: true),
                    TarjetaId = table.Column<int>(nullable: true),
                    Pago = table.Column<DateTime>(nullable: false),
                    Facturado = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagosHistoriall", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PagosHistoriall_Activos_ActivoId",
                        column: x => x.ActivoId,
                        principalTable: "Activos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PagosHistoriall_Tarjeta_TarjetaId",
                        column: x => x.TarjetaId,
                        principalTable: "Tarjeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Retenciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActivoId = table.Column<int>(nullable: true),
                    TarjetaId = table.Column<int>(nullable: true),
                    RetencionPuesta = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retenciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Retenciones_Activos_ActivoId",
                        column: x => x.ActivoId,
                        principalTable: "Activos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Retenciones_Tarjeta_TarjetaId",
                        column: x => x.TarjetaId,
                        principalTable: "Tarjeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activos_EstatusId",
                table: "Activos",
                column: "EstatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Activos_UbicacionId",
                table: "Activos",
                column: "UbicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_SucursalAsociadaId",
                table: "Clientes",
                column: "SucursalAsociadaId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_TarjetaId",
                table: "Clientes",
                column: "TarjetaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_ActivoId",
                table: "Pagos",
                column: "ActivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_TarjetaId",
                table: "Pagos",
                column: "TarjetaId");

            migrationBuilder.CreateIndex(
                name: "IX_PagosHistoriall_ActivoId",
                table: "PagosHistoriall",
                column: "ActivoId");

            migrationBuilder.CreateIndex(
                name: "IX_PagosHistoriall_TarjetaId",
                table: "PagosHistoriall",
                column: "TarjetaId");

            migrationBuilder.CreateIndex(
                name: "IX_Retenciones_ActivoId",
                table: "Retenciones",
                column: "ActivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Retenciones_TarjetaId",
                table: "Retenciones",
                column: "TarjetaId");

            migrationBuilder.CreateIndex(
                name: "IX_SucursalHoras_SucursalId",
                table: "SucursalHoras",
                column: "SucursalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "PagosHistoriall");

            migrationBuilder.DropTable(
                name: "Retenciones");

            migrationBuilder.DropTable(
                name: "SucursalHoras");

            migrationBuilder.DropTable(
                name: "Activos");

            migrationBuilder.DropTable(
                name: "Tarjeta");

            migrationBuilder.DropTable(
                name: "Estatus");

            migrationBuilder.DropTable(
                name: "Sucursales");
        }
    }
}
