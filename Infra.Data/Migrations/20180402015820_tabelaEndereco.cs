using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Infra.Data.Migrations
{
    public partial class tabelaEndereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    Bairro = table.Column<string>(maxLength: 100, nullable: false),
                    Cep = table.Column<string>(maxLength: 9, nullable: true),
                    Cidade = table.Column<string>(maxLength: 100, nullable: false),
                    Complemento = table.Column<string>(maxLength: 100, nullable: true),
                    Logradouro = table.Column<string>(maxLength: 100, nullable: false),
                    MetadataId = table.Column<string>(maxLength: 36, nullable: true),
                    Numero = table.Column<int>(nullable: true),
                    Uf = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_Id",
                table: "Endereco",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Endereco");
        }
    }
}
