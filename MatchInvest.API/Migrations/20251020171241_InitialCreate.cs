using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatchInvest.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assessors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Certificacoes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Especializacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnosDeExperiencia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assessors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Investors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CapitalDisponivel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ApetiteRisco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Objetivos = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investors", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assessors");

            migrationBuilder.DropTable(
                name: "Investors");
        }
    }
}
