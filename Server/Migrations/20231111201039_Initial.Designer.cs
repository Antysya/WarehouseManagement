﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Server;

#nullable disable

namespace Server.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231111201039_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataModel.OrderStatuses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OrderStatuses");
                });

            modelBuilder.Entity("DataModel.OrderTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OrderTypes");
                });

            modelBuilder.Entity("DataModel.Orders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderStatusId")
                        .HasColumnType("int");

                    b.Property<int>("OrderTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeCreate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OrderStatusId");

                    b.HasIndex("OrderTypeId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DataModel.ProductGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductGroup");
                });

            modelBuilder.Entity("DataModel.ProductStatusInOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductStatusInOrder");
                });

            modelBuilder.Entity("DataModel.ProductStatuses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductStatuses");
                });

            modelBuilder.Entity("DataModel.Products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BoxSize")
                        .HasColumnType("int");

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<int>("MaximumShelfLife")
                        .HasColumnType("int");

                    b.Property<int>("MinimumStock")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductGroupId")
                        .HasColumnType("int");

                    b.Property<int>("ProductStatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductGroupId");

                    b.HasIndex("ProductStatusId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DataModel.ProductsInOrders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.HasIndex("StatusId");

                    b.ToTable("ProductsInOrders");
                });

            modelBuilder.Entity("DataModel.ProductsOnShelves", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("ShelveId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("ShelveId");

                    b.ToTable("ProductsOnShelves");
                });

            modelBuilder.Entity("DataModel.Shelving", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Line")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("Row")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Shelving");
                });

            modelBuilder.Entity("DataModel.Orders", b =>
                {
                    b.HasOne("DataModel.OrderStatuses", "OrderStatuses")
                        .WithMany("Orders")
                        .HasForeignKey("OrderStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataModel.OrderTypes", "OrderTypes")
                        .WithMany("Orders")
                        .HasForeignKey("OrderTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderStatuses");

                    b.Navigation("OrderTypes");
                });

            modelBuilder.Entity("DataModel.Products", b =>
                {
                    b.HasOne("DataModel.ProductGroup", "ProductGroup")
                        .WithMany("Products")
                        .HasForeignKey("ProductGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataModel.ProductStatuses", "ProductStatuses")
                        .WithMany("Products")
                        .HasForeignKey("ProductStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductGroup");

                    b.Navigation("ProductStatuses");
                });

            modelBuilder.Entity("DataModel.ProductsInOrders", b =>
                {
                    b.HasOne("DataModel.Orders", "Orders")
                        .WithMany("ProductsInOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataModel.Products", "Products")
                        .WithMany("ProductsInOrders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataModel.ProductStatusInOrder", "ProductStatusInOrder")
                        .WithMany("ProductsInOrders")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orders");

                    b.Navigation("ProductStatusInOrder");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("DataModel.ProductsOnShelves", b =>
                {
                    b.HasOne("DataModel.Products", "Products")
                        .WithMany("ProductsOnShelves")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataModel.Shelving", "Shelving")
                        .WithMany("ProductsOnShelves")
                        .HasForeignKey("ShelveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Products");

                    b.Navigation("Shelving");
                });

            modelBuilder.Entity("DataModel.OrderStatuses", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("DataModel.OrderTypes", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("DataModel.Orders", b =>
                {
                    b.Navigation("ProductsInOrders");
                });

            modelBuilder.Entity("DataModel.ProductGroup", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("DataModel.ProductStatusInOrder", b =>
                {
                    b.Navigation("ProductsInOrders");
                });

            modelBuilder.Entity("DataModel.ProductStatuses", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("DataModel.Products", b =>
                {
                    b.Navigation("ProductsInOrders");

                    b.Navigation("ProductsOnShelves");
                });

            modelBuilder.Entity("DataModel.Shelving", b =>
                {
                    b.Navigation("ProductsOnShelves");
                });
#pragma warning restore 612, 618
        }
    }
}
