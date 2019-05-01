using Microsoft.EntityFrameworkCore.Migrations;

namespace Biblioteca.DAL.Migrations
{
    public partial class TarjetaP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Tarjeta_TarjetaId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Pagos_Tarjeta_TarjetaId",
                table: "Pagos");

            migrationBuilder.DropForeignKey(
                name: "FK_PagosHistoriall_Tarjeta_TarjetaId",
                table: "PagosHistoriall");

            migrationBuilder.DropForeignKey(
                name: "FK_Retenciones_Tarjeta_TarjetaId",
                table: "Retenciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tarjeta",
                table: "Tarjeta");

            migrationBuilder.RenameTable(
                name: "Tarjeta",
                newName: "Tarjetas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tarjetas",
                table: "Tarjetas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Tarjetas_TarjetaId",
                table: "Clientes",
                column: "TarjetaId",
                principalTable: "Tarjetas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pagos_Tarjetas_TarjetaId",
                table: "Pagos",
                column: "TarjetaId",
                principalTable: "Tarjetas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PagosHistoriall_Tarjetas_TarjetaId",
                table: "PagosHistoriall",
                column: "TarjetaId",
                principalTable: "Tarjetas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Retenciones_Tarjetas_TarjetaId",
                table: "Retenciones",
                column: "TarjetaId",
                principalTable: "Tarjetas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Tarjetas_TarjetaId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Pagos_Tarjetas_TarjetaId",
                table: "Pagos");

            migrationBuilder.DropForeignKey(
                name: "FK_PagosHistoriall_Tarjetas_TarjetaId",
                table: "PagosHistoriall");

            migrationBuilder.DropForeignKey(
                name: "FK_Retenciones_Tarjetas_TarjetaId",
                table: "Retenciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tarjetas",
                table: "Tarjetas");

            migrationBuilder.RenameTable(
                name: "Tarjetas",
                newName: "Tarjeta");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tarjeta",
                table: "Tarjeta",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Tarjeta_TarjetaId",
                table: "Clientes",
                column: "TarjetaId",
                principalTable: "Tarjeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pagos_Tarjeta_TarjetaId",
                table: "Pagos",
                column: "TarjetaId",
                principalTable: "Tarjeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PagosHistoriall_Tarjeta_TarjetaId",
                table: "PagosHistoriall",
                column: "TarjetaId",
                principalTable: "Tarjeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Retenciones_Tarjeta_TarjetaId",
                table: "Retenciones",
                column: "TarjetaId",
                principalTable: "Tarjeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
