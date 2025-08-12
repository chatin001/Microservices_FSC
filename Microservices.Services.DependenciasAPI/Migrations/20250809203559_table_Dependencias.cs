using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Microservices.Services.DependenciasAPI.Migrations
{
    /// <inheritdoc />
    public partial class table_Dependencias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dependencias",
                columns: table => new
                {
                    DependenciaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DependenciaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DependenciaAbrev = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependencias", x => x.DependenciaId);
                });

            migrationBuilder.InsertData(
                table: "Dependencias",
                columns: new[] { "DependenciaId", "DependenciaAbrev", "DependenciaName", "IsActive" },
                values: new object[,]
                {
                    { 1, "DIRECOMAR", "Direccion General de Economia", true },
                    { 2, "DIPERADMON", "Direccion de Administracion de Personal", true },
                    { 3, "DIRESNA", "Escuela Naval del Peru", true },
                    { 4, "COMFUIMAR", "Fuerza de Infanteria de la Marina", true },
                    { 5, "COMFOES", "Fuerza de Operacines Especiales", true },
                    { 6, "DIFOSECE", "Fondo de Seguro y Cesacion", true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dependencias");
        }
    }
}
