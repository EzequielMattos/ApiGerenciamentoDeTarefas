﻿// <auto-generated />
using System;
using GerenciamentoDeTarefas.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GerenciamentoDeTarefas.Migrations
{
    [DbContext(typeof(TarefaDataContext))]
    [Migration("20230913025019_CreateDatabase")]
    partial class CreateDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GerenciamentoDeTarefas.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Titulo");

                    b.HasKey("Id");

                    b.ToTable("Categoria", (string)null);
                });

            modelBuilder.Entity("GerenciamentoDeTarefas.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("GerenciamentoDeTarefas.Models.Tarefa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasDefaultValue(new DateTime(2023, 9, 12, 23, 50, 19, 284, DateTimeKind.Local).AddTicks(5768))
                        .HasColumnName("CreateDate");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("DATETIME")
                        .HasColumnName("DataVencimento");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Descricao");

                    b.Property<int>("Prioridade")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Status");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Titulo");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("UserId");

                    b.ToTable("Tarefa", (string)null);
                });

            modelBuilder.Entity("GerenciamentoDeTarefas.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasDefaultValue(new DateTime(2023, 9, 12, 23, 50, 19, 283, DateTimeKind.Local).AddTicks(3548))
                        .HasColumnName("CreateDate");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("UserRole", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RoleId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("GerenciamentoDeTarefas.Models.Tarefa", b =>
                {
                    b.HasOne("GerenciamentoDeTarefas.Models.Categoria", "Categoria")
                        .WithMany("Tarefas")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Tarefa_Categoria");

                    b.HasOne("GerenciamentoDeTarefas.Models.User", "User")
                        .WithMany("Tarefas")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Tarefa_User");

                    b.Navigation("Categoria");

                    b.Navigation("User");
                });

            modelBuilder.Entity("UserRole", b =>
                {
                    b.HasOne("GerenciamentoDeTarefas.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_UserRole_RoleId");

                    b.HasOne("GerenciamentoDeTarefas.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_UserRole_UserId");
                });

            modelBuilder.Entity("GerenciamentoDeTarefas.Models.Categoria", b =>
                {
                    b.Navigation("Tarefas");
                });

            modelBuilder.Entity("GerenciamentoDeTarefas.Models.User", b =>
                {
                    b.Navigation("Tarefas");
                });
#pragma warning restore 612, 618
        }
    }
}