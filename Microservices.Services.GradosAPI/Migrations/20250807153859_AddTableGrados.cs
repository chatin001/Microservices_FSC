using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Microservices.Services.GradosAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddTableGrados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grados",
                columns: table => new
                {
                    GradoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradoCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradoName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradoAbrev = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grados", x => x.GradoId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grados");
        }
    }
}
