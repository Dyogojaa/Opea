using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleFinanceiro.DAL.Migrations
{
    public partial class CriacaoBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Funcoes",
                keyColumn: "Id",
                keyValue: "2ea76483-3ff8-4389-9208-dbb28a693c00");

            migrationBuilder.DeleteData(
                table: "Funcoes",
                keyColumn: "Id",
                keyValue: "3edb4b13-dc12-488c-8b5a-0199cfc4fb24");

            migrationBuilder.InsertData(
                table: "Funcoes",
                columns: new[] { "Id", "ConcurrencyStamp", "Descricao", "Name", "NormalizedName" },
                values: new object[] { "103ad2b3-c364-4f6f-b680-24d1c8aa5985", "3e913ead-0bdc-41f5-8bc9-b0643306cfee", "Administrador do sistema", "Administrador", "ADMINISTRADOR" });

            migrationBuilder.InsertData(
                table: "Funcoes",
                columns: new[] { "Id", "ConcurrencyStamp", "Descricao", "Name", "NormalizedName" },
                values: new object[] { "1fb93163-39b2-4f85-957c-5dd888a5bb0a", "13a21779-2294-49e2-9eac-93688841d883", "Usuário do sistema", "Usuario", "USUARIO" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Funcoes",
                keyColumn: "Id",
                keyValue: "103ad2b3-c364-4f6f-b680-24d1c8aa5985");

            migrationBuilder.DeleteData(
                table: "Funcoes",
                keyColumn: "Id",
                keyValue: "1fb93163-39b2-4f85-957c-5dd888a5bb0a");

            migrationBuilder.InsertData(
                table: "Funcoes",
                columns: new[] { "Id", "ConcurrencyStamp", "Descricao", "Name", "NormalizedName" },
                values: new object[] { "3edb4b13-dc12-488c-8b5a-0199cfc4fb24", "07e4e7ed-5822-4d73-92eb-e828b4e86467", "Administrador do sistema", "Administrador", "ADMINISTRADOR" });

            migrationBuilder.InsertData(
                table: "Funcoes",
                columns: new[] { "Id", "ConcurrencyStamp", "Descricao", "Name", "NormalizedName" },
                values: new object[] { "2ea76483-3ff8-4389-9208-dbb28a693c00", "eb46d64c-5684-432d-a6fd-30d331b91848", "Usuário do sistema", "Usuario", "USUARIO" });
        }
    }
}
