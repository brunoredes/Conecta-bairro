﻿// <auto-generated />
using System;
using ConectaBairro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConectaBairro.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ConectaBairro.Domain.Models.Conta", b =>
                {
                    b.Property<byte>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<byte>("Id"));

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Tipo de conta baseado no ENUM da aplicação: 0 para organizador, 1 para Munícipe");

                    b.HasKey("Id");

                    b.ToTable("tipo_conta", (string)null);

                    b.HasData(
                        new
                        {
                            Id = (byte)1,
                            Tipo = "Organizador"
                        },
                        new
                        {
                            Id = (byte)2,
                            Tipo = "Municipe"
                        });
                });

            modelBuilder.Entity("ConectaBairro.Domain.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("DataNascimento")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<byte>("TipoContaId")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("TipoContaId");

                    b.ToTable("usuario", (string)null);
                });

            modelBuilder.Entity("ConectaBairro.Domain.Models.Usuario", b =>
                {
                    b.HasOne("ConectaBairro.Domain.Models.Conta", "TipoDeConta")
                        .WithMany("Usuarios")
                        .HasForeignKey("TipoContaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoDeConta");
                });

            modelBuilder.Entity("ConectaBairro.Domain.Models.Conta", b =>
                {
                    b.Navigation("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
