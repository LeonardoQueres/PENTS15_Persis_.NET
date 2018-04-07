using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Infra.Data.Migrations
{
    public partial class infracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Infracao",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    Agravante = table.Column<bool>(nullable: false),
                    Atenuante = table.Column<bool>(nullable: false),
                    Gravidade = table.Column<int>(nullable: false),
                    Multa = table.Column<decimal>(nullable: false),
                    ProcessoId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infracao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Infracao_Processo_ProcessoId",
                        column: x => x.ProcessoId,
                        principalTable: "Processo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Infracao_Id",
                table: "Infracao",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Infracao_ProcessoId",
                table: "Infracao",
                column: "ProcessoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Infracao");
        }
    }
}
