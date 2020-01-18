using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace shitbomber.jogo.data.Migrations
{
    public partial class teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teste",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teste", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teste");
        }
    }
}
