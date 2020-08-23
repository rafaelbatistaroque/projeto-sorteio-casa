using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MinhaCasa.Infra.Migrations
{
    public partial class inical : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Familia",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Pontuacao = table.Column<int>(nullable: false),
                    QuantidadeCriteriosAtendidos = table.Column<int>(nullable: false),
                    CategoriaDependente = table.Column<int>(nullable: false),
                    CategoriaRenda = table.Column<int>(nullable: false),
                    CategoriaIdadePretendente = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Familia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    TipoVinculoFamiliar = table.Column<int>(nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    ValorRenda = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FamiliaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pessoa_Familia_FamiliaId",
                        column: x => x.FamiliaId,
                        principalTable: "Familia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProcessoSelecao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FamiliaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessoSelecao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessoSelecao_Familia_FamiliaId",
                        column: x => x.FamiliaId,
                        principalTable: "Familia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_FamiliaId",
                table: "Pessoa",
                column: "FamiliaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessoSelecao_FamiliaId",
                table: "ProcessoSelecao",
                column: "FamiliaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropTable(
                name: "ProcessoSelecao");

            migrationBuilder.DropTable(
                name: "Familia");
        }
    }
}
