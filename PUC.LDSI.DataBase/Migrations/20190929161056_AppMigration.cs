﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PUC.LDSI.DataBase.Migrations
{
    public partial class AppMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    AtualizadoEm = table.Column<DateTime>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    AtualizadoEm = table.Column<DateTime>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 150, nullable: true),
                    Email = table.Column<string>(maxLength: 150, nullable: true),
                    Matricula = table.Column<int>(nullable: false),
                    Senha = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Turmas",
                columns: table => new
                {
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    AtualizadoEm = table.Column<DateTime>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turmas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Avaliacoes",
                columns: table => new
                {
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    AtualizadoEm = table.Column<DateTime>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Materia = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    IdProfessor = table.Column<int>(nullable: false),
                    IdDisciplina = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Avaliacoes_Disciplinas_IdDisciplina",
                        column: x => x.IdDisciplina,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Avaliacoes_Professores_IdProfessor",
                        column: x => x.IdProfessor,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    AtualizadoEm = table.Column<DateTime>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 150, nullable: true),
                    Matricula = table.Column<int>(nullable: false),
                    Senha = table.Column<string>(nullable: true),
                    IdTurma = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alunos_Turmas_IdTurma",
                        column: x => x.IdTurma,
                        principalTable: "Turmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AvaliacaoQuestoes",
                columns: table => new
                {
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    AtualizadoEm = table.Column<DateTime>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<int>(nullable: false),
                    Enunciado = table.Column<string>(nullable: true),
                    IdAvaliacao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvaliacaoQuestoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvaliacaoQuestoes_Avaliacoes_IdAvaliacao",
                        column: x => x.IdAvaliacao,
                        principalTable: "Avaliacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Publicacoes",
                columns: table => new
                {
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    AtualizadoEm = table.Column<DateTime>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<int>(nullable: false),
                    IdAvaliacao = table.Column<int>(nullable: false),
                    TurmaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publicacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Publicacoes_Avaliacoes_IdAvaliacao",
                        column: x => x.IdAvaliacao,
                        principalTable: "Avaliacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Publicacoes_Turmas_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Provas",
                columns: table => new
                {
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    AtualizadoEm = table.Column<DateTime>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdAluno = table.Column<int>(nullable: false),
                    IdAvaliacao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Provas_Alunos_IdAluno",
                        column: x => x.IdAluno,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Provas_Avaliacoes_IdAvaliacao",
                        column: x => x.IdAvaliacao,
                        principalTable: "Avaliacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AvaliacaoOpcoes",
                columns: table => new
                {
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    AtualizadoEm = table.Column<DateTime>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: true),
                    Resposta = table.Column<bool>(nullable: false),
                    IdAvaliacaoQuestao = table.Column<int>(nullable: false),
                    QuestaoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvaliacaoOpcoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvaliacaoOpcoes_AvaliacaoQuestoes_QuestaoId",
                        column: x => x.QuestaoId,
                        principalTable: "AvaliacaoQuestoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProvaQuestoes",
                columns: table => new
                {
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    AtualizadoEm = table.Column<DateTime>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdAvaliacaoQuestao = table.Column<int>(nullable: false),
                    IdProva = table.Column<int>(nullable: false),
                    Nota = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvaQuestoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProvaQuestoes_AvaliacaoQuestoes_IdAvaliacaoQuestao",
                        column: x => x.IdAvaliacaoQuestao,
                        principalTable: "AvaliacaoQuestoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProvaQuestoes_Provas_IdProva",
                        column: x => x.IdProva,
                        principalTable: "Provas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProvaOpcoes",
                columns: table => new
                {
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    AtualizadoEm = table.Column<DateTime>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdQuestaoProva = table.Column<int>(nullable: false),
                    IdAvaliacaoOpcao = table.Column<int>(nullable: false),
                    Resposta = table.Column<bool>(nullable: false),
                    QuestaoProvaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvaOpcoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProvaOpcoes_AvaliacaoOpcoes_IdAvaliacaoOpcao",
                        column: x => x.IdAvaliacaoOpcao,
                        principalTable: "AvaliacaoOpcoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProvaOpcoes_ProvaQuestoes_QuestaoProvaId",
                        column: x => x.QuestaoProvaId,
                        principalTable: "ProvaQuestoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_IdTurma",
                table: "Alunos",
                column: "IdTurma");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoOpcoes_QuestaoId",
                table: "AvaliacaoOpcoes",
                column: "QuestaoId");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoQuestoes_IdAvaliacao",
                table: "AvaliacaoQuestoes",
                column: "IdAvaliacao");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_IdDisciplina",
                table: "Avaliacoes",
                column: "IdDisciplina");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_IdProfessor",
                table: "Avaliacoes",
                column: "IdProfessor");

            migrationBuilder.CreateIndex(
                name: "IX_ProvaOpcoes_IdAvaliacaoOpcao",
                table: "ProvaOpcoes",
                column: "IdAvaliacaoOpcao");

            migrationBuilder.CreateIndex(
                name: "IX_ProvaOpcoes_QuestaoProvaId",
                table: "ProvaOpcoes",
                column: "QuestaoProvaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProvaQuestoes_IdAvaliacaoQuestao",
                table: "ProvaQuestoes",
                column: "IdAvaliacaoQuestao");

            migrationBuilder.CreateIndex(
                name: "IX_ProvaQuestoes_IdProva",
                table: "ProvaQuestoes",
                column: "IdProva");

            migrationBuilder.CreateIndex(
                name: "IX_Provas_IdAluno",
                table: "Provas",
                column: "IdAluno");

            migrationBuilder.CreateIndex(
                name: "IX_Provas_IdAvaliacao",
                table: "Provas",
                column: "IdAvaliacao");

            migrationBuilder.CreateIndex(
                name: "IX_Publicacoes_IdAvaliacao",
                table: "Publicacoes",
                column: "IdAvaliacao");

            migrationBuilder.CreateIndex(
                name: "IX_Publicacoes_TurmaId",
                table: "Publicacoes",
                column: "TurmaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProvaOpcoes");

            migrationBuilder.DropTable(
                name: "Publicacoes");

            migrationBuilder.DropTable(
                name: "AvaliacaoOpcoes");

            migrationBuilder.DropTable(
                name: "ProvaQuestoes");

            migrationBuilder.DropTable(
                name: "AvaliacaoQuestoes");

            migrationBuilder.DropTable(
                name: "Provas");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Avaliacoes");

            migrationBuilder.DropTable(
                name: "Turmas");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
