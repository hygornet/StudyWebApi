using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudyWebApi.Migrations
{
    /// <inheritdoc />
    public partial class Alteracoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_Cursos_IDCursoID",
                table: "Pessoa");

            migrationBuilder.RenameColumn(
                name: "IDCursoID",
                table: "Pessoa",
                newName: "IDCurso");

            migrationBuilder.RenameIndex(
                name: "IX_Pessoa_IDCursoID",
                table: "Pessoa",
                newName: "IX_Pessoa_IDCurso");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Cursos_IDCurso",
                table: "Pessoa",
                column: "IDCurso",
                principalTable: "Cursos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_Cursos_IDCurso",
                table: "Pessoa");

            migrationBuilder.RenameColumn(
                name: "IDCurso",
                table: "Pessoa",
                newName: "IDCursoID");

            migrationBuilder.RenameIndex(
                name: "IX_Pessoa_IDCurso",
                table: "Pessoa",
                newName: "IX_Pessoa_IDCursoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Cursos_IDCursoID",
                table: "Pessoa",
                column: "IDCursoID",
                principalTable: "Cursos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
