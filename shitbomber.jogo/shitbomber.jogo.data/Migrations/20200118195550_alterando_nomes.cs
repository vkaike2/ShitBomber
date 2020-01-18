using Microsoft.EntityFrameworkCore.Migrations;

namespace shitbomber.jogo.data.Migrations
{
    public partial class alterando_nomes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Teste",
                table: "Teste");

            migrationBuilder.RenameTable(
                name: "Teste",
                newName: "tb_teste");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "tb_teste",
                newName: "name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_teste",
                table: "tb_teste",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_teste",
                table: "tb_teste");

            migrationBuilder.RenameTable(
                name: "tb_teste",
                newName: "Teste");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Teste",
                newName: "Nome");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teste",
                table: "Teste",
                column: "Id");
        }
    }
}
