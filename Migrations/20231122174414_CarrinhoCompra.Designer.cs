﻿// <auto-generated />
using System;
using InduMovel.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InduMovel.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231122174414_CarrinhoCompra")]
    partial class CarrinhoCompra
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("InduMovel.Models.CarrinhoItem", b =>
                {
                    b.Property<int>("CarrinhoItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CarrinhoId")
                        .HasColumnType("TEXT");

                    b.Property<int?>("MovelId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantidade")
                        .HasColumnType("INTEGER");

                    b.HasKey("CarrinhoItemId");

                    b.HasIndex("MovelId");

                    b.ToTable("CarrinhoItens");
                });

            modelBuilder.Entity("InduMovel.Models.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("InduMovel.Models.Movel", b =>
                {
                    b.Property<int>("MovelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Ativo")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmProducao")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImagemPequenaUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImagemUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("TEXT");

                    b.Property<double>("Valor")
                        .HasColumnType("REAL");

                    b.HasKey("MovelId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Moveis");
                });

            modelBuilder.Entity("InduMovel.Models.CarrinhoItem", b =>
                {
                    b.HasOne("InduMovel.Models.Movel", "Movel")
                        .WithMany()
                        .HasForeignKey("MovelId");

                    b.Navigation("Movel");
                });

            modelBuilder.Entity("InduMovel.Models.Movel", b =>
                {
                    b.HasOne("InduMovel.Models.Categoria", "Categoria")
                        .WithMany("Moveis")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("InduMovel.Models.Categoria", b =>
                {
                    b.Navigation("Moveis");
                });
#pragma warning restore 612, 618
        }
    }
}