﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PUC.LDSI.DataBase.Context;

namespace PUC.LDSI.DataBase.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20191014021734_AppMigration2")]
    partial class AppMigration2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PUC.LDSI.Domain.Entities.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AtualizadoEm");

                    b.Property<DateTime>("CriadoEm");

                    b.Property<int>("IdTurma");

                    b.Property<int>("Matricula");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("Senha")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("IdTurma");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("PUC.LDSI.Domain.Entities.Avaliacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AtualizadoEm");

                    b.Property<DateTime>("CriadoEm");

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<int>("IdDisciplina");

                    b.Property<int>("IdProfessor");

                    b.Property<string>("Materia")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("IdDisciplina");

                    b.HasIndex("IdProfessor");

                    b.ToTable("Avaliacoes");
                });

            modelBuilder.Entity("PUC.LDSI.Domain.Entities.AvaliacaoOpcao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AtualizadoEm");

                    b.Property<DateTime>("CriadoEm");

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<int>("IdAvaliacaoQuestao");

                    b.Property<int?>("QuestaoId");

                    b.Property<bool>("Resposta");

                    b.HasKey("Id");

                    b.HasIndex("QuestaoId");

                    b.ToTable("AvaliacaoOpcoes");
                });

            modelBuilder.Entity("PUC.LDSI.Domain.Entities.AvaliacaoQuestao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AtualizadoEm");

                    b.Property<DateTime>("CriadoEm");

                    b.Property<string>("Enunciado")
                        .IsRequired();

                    b.Property<int>("IdAvaliacao");

                    b.Property<int>("Tipo");

                    b.HasKey("Id");

                    b.HasIndex("IdAvaliacao");

                    b.ToTable("AvaliacaoQuestoes");
                });

            modelBuilder.Entity("PUC.LDSI.Domain.Entities.Disciplina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AtualizadoEm");

                    b.Property<DateTime>("CriadoEm");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.ToTable("Disciplinas");
                });

            modelBuilder.Entity("PUC.LDSI.Domain.Entities.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AtualizadoEm");

                    b.Property<DateTime>("CriadoEm");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<int>("Matricula");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("Senha")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Professores");
                });

            modelBuilder.Entity("PUC.LDSI.Domain.Entities.Prova", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AtualizadoEm");

                    b.Property<DateTime>("CriadoEm");

                    b.Property<int>("IdAluno");

                    b.Property<int>("IdAvaliacao");

                    b.HasKey("Id");

                    b.HasIndex("IdAluno");

                    b.HasIndex("IdAvaliacao");

                    b.ToTable("Provas");
                });

            modelBuilder.Entity("PUC.LDSI.Domain.Entities.ProvaOpcao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AtualizadoEm");

                    b.Property<int?>("AvaliacaoOpcaoId");

                    b.Property<DateTime>("CriadoEm");

                    b.Property<int>("IdAvaliacaoOpcao");

                    b.Property<int>("IdQuestaoProva");

                    b.Property<int?>("QuestaoProvaId");

                    b.Property<bool>("Resposta");

                    b.HasKey("Id");

                    b.HasIndex("AvaliacaoOpcaoId");

                    b.HasIndex("QuestaoProvaId");

                    b.ToTable("ProvaOpcoes");
                });

            modelBuilder.Entity("PUC.LDSI.Domain.Entities.ProvaQuestao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AtualizadoEm");

                    b.Property<DateTime>("CriadoEm");

                    b.Property<int>("IdAvaliacaoQuestao");

                    b.Property<int>("IdProva");

                    b.Property<double>("Nota");

                    b.HasKey("Id");

                    b.HasIndex("IdAvaliacaoQuestao");

                    b.HasIndex("IdProva");

                    b.ToTable("ProvaQuestoes");
                });

            modelBuilder.Entity("PUC.LDSI.Domain.Entities.Publicacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AtualizadoEm");

                    b.Property<DateTime>("CriadoEm");

                    b.Property<DateTime>("DataFim");

                    b.Property<DateTime>("DataInicio");

                    b.Property<int>("IdAvaliacao");

                    b.Property<int?>("TurmaId");

                    b.Property<int>("Valor");

                    b.HasKey("Id");

                    b.HasIndex("IdAvaliacao");

                    b.HasIndex("TurmaId");

                    b.ToTable("Publicacoes");
                });

            modelBuilder.Entity("PUC.LDSI.Domain.Entities.Turma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AtualizadoEm");

                    b.Property<DateTime>("CriadoEm");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Turmas");
                });

            modelBuilder.Entity("PUC.LDSI.Domain.Entities.Aluno", b =>
                {
                    b.HasOne("PUC.LDSI.Domain.Entities.Turma", "Turma")
                        .WithMany("Alunos")
                        .HasForeignKey("IdTurma")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PUC.LDSI.Domain.Entities.Avaliacao", b =>
                {
                    b.HasOne("PUC.LDSI.Domain.Entities.Disciplina", "Disciplina")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("IdDisciplina")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PUC.LDSI.Domain.Entities.Professor", "Professor")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("IdProfessor")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PUC.LDSI.Domain.Entities.AvaliacaoOpcao", b =>
                {
                    b.HasOne("PUC.LDSI.Domain.Entities.AvaliacaoQuestao", "Questao")
                        .WithMany("Opcoes")
                        .HasForeignKey("QuestaoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PUC.LDSI.Domain.Entities.AvaliacaoQuestao", b =>
                {
                    b.HasOne("PUC.LDSI.Domain.Entities.Avaliacao", "Avaliacao")
                        .WithMany("Questoes")
                        .HasForeignKey("IdAvaliacao")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PUC.LDSI.Domain.Entities.Prova", b =>
                {
                    b.HasOne("PUC.LDSI.Domain.Entities.Aluno", "Aluno")
                        .WithMany("Provas")
                        .HasForeignKey("IdAluno")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PUC.LDSI.Domain.Entities.Avaliacao", "Avaliacao")
                        .WithMany("Provas")
                        .HasForeignKey("IdAvaliacao")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PUC.LDSI.Domain.Entities.ProvaOpcao", b =>
                {
                    b.HasOne("PUC.LDSI.Domain.Entities.AvaliacaoOpcao", "AvaliacaoOpcao")
                        .WithMany()
                        .HasForeignKey("AvaliacaoOpcaoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PUC.LDSI.Domain.Entities.ProvaQuestao", "QuestaoProva")
                        .WithMany("Opcao")
                        .HasForeignKey("QuestaoProvaId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PUC.LDSI.Domain.Entities.ProvaQuestao", b =>
                {
                    b.HasOne("PUC.LDSI.Domain.Entities.AvaliacaoQuestao", "AvaliacaoQuestao")
                        .WithMany()
                        .HasForeignKey("IdAvaliacaoQuestao")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PUC.LDSI.Domain.Entities.Prova", "Prova")
                        .WithMany("Questoes")
                        .HasForeignKey("IdProva")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("PUC.LDSI.Domain.Entities.Publicacao", b =>
                {
                    b.HasOne("PUC.LDSI.Domain.Entities.Avaliacao", "Avaliacao")
                        .WithMany("Publicacoes")
                        .HasForeignKey("IdAvaliacao")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PUC.LDSI.Domain.Entities.Turma", "Turma")
                        .WithMany("Publicacoes")
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
