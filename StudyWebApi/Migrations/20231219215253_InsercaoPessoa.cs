using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudyWebApi.Migrations
{
    /// <inheritdoc />
    public partial class InsercaoPessoa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusCurso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataIngresso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IDCursoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pessoa_Cursos_IDCursoID",
                        column: x => x.IDCursoID,
                        principalTable: "Cursos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_IDCursoID",
                table: "Pessoa",
                column: "IDCursoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pessoa");
        }
    }
}
