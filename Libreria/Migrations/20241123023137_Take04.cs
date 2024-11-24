using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libreria.Migrations
{
    /// <inheritdoc />
    public partial class Take04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidosClientes_Clientes_ClienteId",
                table: "PedidosClientes");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidosClientes_Libros_LibroId",
                table: "PedidosClientes");

            migrationBuilder.DropIndex(
                name: "IX_PedidosClientes_LibroId",
                table: "PedidosClientes");

            migrationBuilder.DropColumn(
                name: "LibroId",
                table: "PedidosClientes");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "PedidosClientes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "LibroPedidoCliente",
                columns: table => new
                {
                    LibrosId = table.Column<int>(type: "int", nullable: false),
                    PedidoClientesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibroPedidoCliente", x => new { x.LibrosId, x.PedidoClientesId });
                    table.ForeignKey(
                        name: "FK_LibroPedidoCliente_Libros_LibrosId",
                        column: x => x.LibrosId,
                        principalTable: "Libros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibroPedidoCliente_PedidosClientes_PedidoClientesId",
                        column: x => x.PedidoClientesId,
                        principalTable: "PedidosClientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LibroPedidoCliente_PedidoClientesId",
                table: "LibroPedidoCliente",
                column: "PedidoClientesId");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosClientes_Clientes_ClienteId",
                table: "PedidosClientes",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidosClientes_Clientes_ClienteId",
                table: "PedidosClientes");

            migrationBuilder.DropTable(
                name: "LibroPedidoCliente");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "PedidosClientes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "LibroId",
                table: "PedidosClientes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PedidosClientes_LibroId",
                table: "PedidosClientes",
                column: "LibroId");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosClientes_Clientes_ClienteId",
                table: "PedidosClientes",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosClientes_Libros_LibroId",
                table: "PedidosClientes",
                column: "LibroId",
                principalTable: "Libros",
                principalColumn: "Id");
        }
    }
}
