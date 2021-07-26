﻿// <auto-generated />
using System;
using CustomerPortal.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CustomerPortal.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CustomerPortal.Models.MutualFundTransactionDetail", b =>
                {
                    b.Property<int>("MutualFundId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MutualFundName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MutualFundUnits")
                        .HasColumnType("int");

                    b.Property<int>("PortfolioId")
                        .HasColumnType("int");

                    b.Property<int?>("PortfolioTransactionDetailId")
                        .HasColumnType("int");

                    b.HasKey("MutualFundId");

                    b.HasIndex("PortfolioTransactionDetailId");

                    b.ToTable("MutualFundDetails");
                });

            modelBuilder.Entity("CustomerPortal.Models.PortfolioTransactionDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MutualFundDetailId")
                        .HasColumnType("int");

                    b.Property<int>("PortfolioId")
                        .HasColumnType("int");

                    b.Property<int?>("StockDetailId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PortfolioDetails");
                });

            modelBuilder.Entity("CustomerPortal.Models.StockTransactionDetail", b =>
                {
                    b.Property<int>("StockDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PortfolioId")
                        .HasColumnType("int");

                    b.Property<int?>("PortfolioTransactionDetailId")
                        .HasColumnType("int");

                    b.Property<int>("StockCount")
                        .HasColumnType("int");

                    b.Property<string>("StockName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StockDetailId");

                    b.HasIndex("PortfolioTransactionDetailId");

                    b.ToTable("StockDetails");
                });

            modelBuilder.Entity("CustomerPortal.Models.MutualFundTransactionDetail", b =>
                {
                    b.HasOne("CustomerPortal.Models.PortfolioTransactionDetail", null)
                        .WithMany("MutualFundDetailsList")
                        .HasForeignKey("PortfolioTransactionDetailId");
                });

            modelBuilder.Entity("CustomerPortal.Models.StockTransactionDetail", b =>
                {
                    b.HasOne("CustomerPortal.Models.PortfolioTransactionDetail", null)
                        .WithMany("StockDetailsList")
                        .HasForeignKey("PortfolioTransactionDetailId");
                });

            modelBuilder.Entity("CustomerPortal.Models.PortfolioTransactionDetail", b =>
                {
                    b.Navigation("MutualFundDetailsList");

                    b.Navigation("StockDetailsList");
                });
#pragma warning restore 612, 618
        }
    }
}