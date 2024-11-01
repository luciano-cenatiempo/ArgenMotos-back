using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_ArgenMotos.Migrations
{
    /// <inheritdoc />
    public partial class cambioIdsCorrecto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VendedorId",
                table: "Vendedores",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProveedorId",
                table: "Proveedores",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "OrdenDeCompraId",
                table: "OrdenesDeCompra",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "FacturaId",
                table: "Facturas",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CobranzaId",
                table: "Cobranzas",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Clientes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ArticuloId",
                table: "Articulos",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Vendedores",
                newName: "VendedorId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Proveedores",
                newName: "ProveedorId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "OrdenesDeCompra",
                newName: "OrdenDeCompraId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Facturas",
                newName: "FacturaId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cobranzas",
                newName: "CobranzaId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Clientes",
                newName: "ClienteId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Articulos",
                newName: "ArticuloId");
        }
    }
}
