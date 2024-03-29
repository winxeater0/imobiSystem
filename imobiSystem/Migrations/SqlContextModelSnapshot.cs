﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using imobiSystem.Infrastrusture.Data;

#nullable disable

namespace imobiSystem.API.Migrations
{
    [DbContext(typeof(SqlContext))]
    partial class SqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("imobiSystem.Domain.Entities.Corretor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Corretores");
                });

            modelBuilder.Entity("imobiSystem.Domain.Entities.Imovel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Alugado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataAlugado")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InquilinoId")
                        .HasColumnType("int");

                    b.Property<int>("ProprietarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InquilinoId");

                    b.HasIndex("ProprietarioId");

                    b.ToTable("Imoveis");
                });

            modelBuilder.Entity("imobiSystem.Domain.Entities.Inquilino", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Inquilinos");
                });

            modelBuilder.Entity("imobiSystem.Domain.Entities.Proprietario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Proprietarios");
                });

            modelBuilder.Entity("InquilinoCorretor", b =>
                {
                    b.Property<int>("InquilinosId")
                        .HasColumnType("int");

                    b.Property<int>("CorretoresId")
                        .HasColumnType("int");

                    b.HasKey("InquilinosId", "CorretoresId");

                    b.HasIndex("CorretoresId");

                    b.ToTable("InquilinoCorretor");
                });

            modelBuilder.Entity("ProprietarioCorretor", b =>
                {
                    b.Property<int>("ProprietariosId")
                        .HasColumnType("int");

                    b.Property<int>("CorretoresId")
                        .HasColumnType("int");

                    b.HasKey("ProprietariosId", "CorretoresId");

                    b.HasIndex("CorretoresId");

                    b.ToTable("ProprietarioCorretor");
                });

            modelBuilder.Entity("imobiSystem.Domain.Entities.Imovel", b =>
                {
                    b.HasOne("imobiSystem.Domain.Entities.Inquilino", "Inquilino")
                        .WithMany("Imoveis")
                        .HasForeignKey("InquilinoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("imobiSystem.Domain.Entities.Proprietario", "Proprietario")
                        .WithMany("Imoveis")
                        .HasForeignKey("ProprietarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inquilino");

                    b.Navigation("Proprietario");
                });

            modelBuilder.Entity("InquilinoCorretor", b =>
                {
                    b.HasOne("imobiSystem.Domain.Entities.Corretor", null)
                        .WithMany()
                        .HasForeignKey("CorretoresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("imobiSystem.Domain.Entities.Inquilino", null)
                        .WithMany()
                        .HasForeignKey("InquilinosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProprietarioCorretor", b =>
                {
                    b.HasOne("imobiSystem.Domain.Entities.Corretor", null)
                        .WithMany()
                        .HasForeignKey("CorretoresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("imobiSystem.Domain.Entities.Proprietario", null)
                        .WithMany()
                        .HasForeignKey("ProprietariosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("imobiSystem.Domain.Entities.Inquilino", b =>
                {
                    b.Navigation("Imoveis");
                });

            modelBuilder.Entity("imobiSystem.Domain.Entities.Proprietario", b =>
                {
                    b.Navigation("Imoveis");
                });
#pragma warning restore 612, 618
        }
    }
}
