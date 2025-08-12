using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Microservices.Services.GradosAPI.Migrations
{
    /// <inheritdoc />
    public partial class table_Grado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Grados",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Grados",
                columns: new[] { "GradoId", "GradoAbrev", "GradoCode", "GradoName", "IsActive" },
                values: new object[,]
                {
                    { 1, "Valm.", "100", "Vicealmirante", true },
                    { 2, "Contralm.", "200", "Contralmirante", true },
                    { 3, "C.de N.", "300", "Capitan de Navio", true },
                    { 4, "C.de F.", "400", "Capitan de Fragata", true },
                    { 5, "C.de C.", "500", "Capitan de Corbeta", true },
                    { 6, "Tte. 1", "600", "Teniente Primero", true },
                    { 7, "Tte. 2", "600", "Teniente Segundo", true },
                    { 8, "Afgta.", "800", "Alferez de Frataga  ", true },
                    { 9, "SPA", "1000", "Servidor Publico A", true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Grados",
                keyColumn: "GradoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Grados",
                keyColumn: "GradoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Grados",
                keyColumn: "GradoId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Grados",
                keyColumn: "GradoId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Grados",
                keyColumn: "GradoId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Grados",
                keyColumn: "GradoId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Grados",
                keyColumn: "GradoId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Grados",
                keyColumn: "GradoId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Grados",
                keyColumn: "GradoId",
                keyValue: 9);

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Grados");
        }
    }
}
