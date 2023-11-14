﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaxStrategy.Infra.Data.Context;

#nullable disable

namespace TaxStrategy.Infra.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TaxStrategy.Domain.Entities.TaxStrategyFilho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(500)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("VARCHAR(12)");

                    b.Property<int>("IdTaxStrategyPai")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdTaxStrategyPai");

                    b.ToTable("TaxStrategyFilho");
                });

            modelBuilder.Entity("TaxStrategy.Domain.Entities.TaxStrategyPai", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("VARCHAR(500)");

                    b.Property<DateTime?>("DthConclusao")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("DthCricao")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("VARCHAR(12)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id");

                    b.ToTable("TaxStrategyPai");
                });

            modelBuilder.Entity("TaxStrategy.Domain.Entities.TaxStrategyFilho", b =>
                {
                    b.HasOne("TaxStrategy.Domain.Entities.TaxStrategyPai", "TaxStrategyPai")
                        .WithMany()
                        .HasForeignKey("IdTaxStrategyPai")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TaxStrategyPai");
                });
#pragma warning restore 612, 618
        }
    }
}
