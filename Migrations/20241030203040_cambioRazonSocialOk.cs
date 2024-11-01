using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_ArgenMotos.Migrations
{
    /// <inheritdoc />
    public partial class cambioRazonSocialOk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RazonSocial",
                table: "Proveedores",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RazonSocial",
                table: "Proveedores",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
