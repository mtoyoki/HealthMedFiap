using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Versao01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ESPECIALIDADE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESPECIALIDADE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PACIENTE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Cpf = table.Column<string>(type: "VARCHAR(11)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PACIENTE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MEDICO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Crm = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    EspecialidadeId = table.Column<int>(type: "INT", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Cpf = table.Column<string>(type: "VARCHAR(11)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MEDICO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MEDICO_ESPECIALIDADE_EspecialidadeId",
                        column: x => x.EspecialidadeId,
                        principalTable: "ESPECIALIDADE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AGENDA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicoId = table.Column<int>(type: "INT", nullable: false),
                    DataHora = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Valor = table.Column<double>(type: "FLOAT", nullable: false),
                    Disponivel = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AGENDA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AGENDA_MEDICO_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "MEDICO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CONSULTA_MEDICA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgendaId = table.Column<int>(type: "INT", nullable: false),
                    PacienteId = table.Column<int>(type: "INT", nullable: false),
                    Situacao = table.Column<int>(type: "INT", nullable: false),
                    JustificativaSituacao = table.Column<string>(type: "VARCHAR(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONSULTA_MEDICA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CONSULTA_MEDICA_AGENDA_AgendaId",
                        column: x => x.AgendaId,
                        principalTable: "AGENDA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CONSULTA_MEDICA_PACIENTE_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "PACIENTE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AGENDA_MedicoId",
                table: "AGENDA",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_CONSULTA_MEDICA_AgendaId",
                table: "CONSULTA_MEDICA",
                column: "AgendaId");

            migrationBuilder.CreateIndex(
                name: "IX_CONSULTA_MEDICA_PacienteId",
                table: "CONSULTA_MEDICA",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_MEDICO_EspecialidadeId",
                table: "MEDICO",
                column: "EspecialidadeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CONSULTA_MEDICA");

            migrationBuilder.DropTable(
                name: "AGENDA");

            migrationBuilder.DropTable(
                name: "PACIENTE");

            migrationBuilder.DropTable(
                name: "MEDICO");

            migrationBuilder.DropTable(
                name: "ESPECIALIDADE");
        }
    }
}
