using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Infra.Data.Migrations
{
    public partial class processo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Processo",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    Cnpj = table.Column<string>(maxLength: 14, nullable: true),
                    FiscalResponsavel = table.Column<string>(maxLength: 100, nullable: true),
                    FornecedorId = table.Column<string>(nullable: false),
                    Numero = table.Column<string>(maxLength: 30, nullable: true),
                    Relato = table.Column<DateTime>(nullable: false),
                    RelatoFiscalizacao = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Processo_Fornecedor_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Processo_FornecedorId",
                table: "Processo",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Processo_Id",
                table: "Processo",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Processo");
        }
    }
}
