using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaxStrategy.Infra.Data.Migrations
{
    public partial class projetoinicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaxStrategyPai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(500)", nullable: false),
                    Estado = table.Column<string>(type: "VARCHAR(12)", nullable: false),
                    DthCricao = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DthConclusao = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxStrategyPai", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxStrategyFilho",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTaxStrategyPai = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(500)", nullable: false),
                    Estado = table.Column<string>(type: "VARCHAR(12)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxStrategyFilho", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxStrategyFilho_TaxStrategyPai_IdTaxStrategyPai",
                        column: x => x.IdTaxStrategyPai,
                        principalTable: "TaxStrategyPai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaxStrategyFilho_IdTaxStrategyPai",
                table: "TaxStrategyFilho",
                column: "IdTaxStrategyPai");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaxStrategyFilho");

            migrationBuilder.DropTable(
                name: "TaxStrategyPai");
        }
    }
}
