using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdaTech.Api.Migrations
{
    /// <inheritdoc />
    public partial class Alunos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cep = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Rua = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Bairro = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Cidade = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Uf = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alunos");
        }
    }
}
