using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciaNf.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "nf");

            migrationBuilder.CreateTable(
                name: "TB_EMPRESA",
                schema: "nf",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Cnpj = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_EMPRESA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_IMPOSTO",
                schema: "nf",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Aliquota = table.Column<decimal>(type: "decimal(2,2)", precision: 2, scale: 2, nullable: false),
                    BaseCalculo = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_IMPOSTO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_ITEM",
                schema: "nf",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImpostoId = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ITEM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_ITEM_TB_IMPOSTO_ImpostoId",
                        column: x => x.ImpostoId,
                        principalSchema: "nf",
                        principalTable: "TB_IMPOSTO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_NOTA_FISCAL",
                schema: "nf",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    EmissorId = table.Column<int>(type: "int", nullable: false),
                    DestinatarioId = table.Column<int>(type: "int", nullable: false),
                    ImpostoId = table.Column<int>(type: "int", nullable: false),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_NOTA_FISCAL", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_NOTA_FISCAL_TB_EMPRESA_DestinatarioId",
                        column: x => x.DestinatarioId,
                        principalSchema: "nf",
                        principalTable: "TB_EMPRESA",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TB_NOTA_FISCAL_TB_EMPRESA_EmissorId",
                        column: x => x.EmissorId,
                        principalSchema: "nf",
                        principalTable: "TB_EMPRESA",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TB_NOTA_FISCAL_TB_IMPOSTO_ImpostoId",
                        column: x => x.ImpostoId,
                        principalSchema: "nf",
                        principalTable: "TB_IMPOSTO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_NOTA_ITEM",
                schema: "nf",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotaId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Uuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_NOTA_ITEM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_NOTA_ITEM_TB_ITEM_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "nf",
                        principalTable: "TB_ITEM",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TB_NOTA_ITEM_TB_NOTA_FISCAL_NotaId",
                        column: x => x.NotaId,
                        principalSchema: "nf",
                        principalTable: "TB_NOTA_FISCAL",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ITEM_ImpostoId",
                schema: "nf",
                table: "TB_ITEM",
                column: "ImpostoId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_NOTA_FISCAL_DestinatarioId",
                schema: "nf",
                table: "TB_NOTA_FISCAL",
                column: "DestinatarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_NOTA_FISCAL_EmissorId",
                schema: "nf",
                table: "TB_NOTA_FISCAL",
                column: "EmissorId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_NOTA_FISCAL_ImpostoId",
                schema: "nf",
                table: "TB_NOTA_FISCAL",
                column: "ImpostoId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_NOTA_ITEM_ItemId",
                schema: "nf",
                table: "TB_NOTA_ITEM",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_NOTA_ITEM_NotaId",
                schema: "nf",
                table: "TB_NOTA_ITEM",
                column: "NotaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_NOTA_ITEM",
                schema: "nf");

            migrationBuilder.DropTable(
                name: "TB_ITEM",
                schema: "nf");

            migrationBuilder.DropTable(
                name: "TB_NOTA_FISCAL",
                schema: "nf");

            migrationBuilder.DropTable(
                name: "TB_EMPRESA",
                schema: "nf");

            migrationBuilder.DropTable(
                name: "TB_IMPOSTO",
                schema: "nf");
        }
    }
}
