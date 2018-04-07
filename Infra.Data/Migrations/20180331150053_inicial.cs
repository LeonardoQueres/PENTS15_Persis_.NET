using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Infra.Data.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    Cnpj = table.Column<string>(maxLength: 14, nullable: true),
                    InscricaoMunicipal = table.Column<string>(maxLength: 50, nullable: true),
                    RazaoSocial = table.Column<string>(maxLength: 100, nullable: true),
                    ReceitaBruta = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedor_Id",
                table: "Fornecedor",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fornecedor");
        }
    }
}
