using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace livrariaDB.Migrations
{
    /// <inheritdoc />
    public partial class emprestimo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "livro",
                columns: table => new
                {
                    livroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    livroTitulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    livroAutor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    livroPublicacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isbn = table.Column<int>(type: "int", nullable: false),
                    quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_livro", x => x.livroId);
                });

            migrationBuilder.CreateTable(
                name: "emprestimo",
                columns: table => new
                {
                    emprestimoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    livroId = table.Column<int>(type: "int", nullable: false),
                    dataEmprestimo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataDevolucao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cliente = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emprestimo", x => x.emprestimoId);
                    table.ForeignKey(
                        name: "FK_emprestimo_livro_livroId",
                        column: x => x.livroId,
                        principalTable: "livro",
                        principalColumn: "livroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_emprestimo_livroId",
                table: "emprestimo",
                column: "livroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "emprestimo");

            migrationBuilder.DropTable(
                name: "livro");
        }
    }
}
