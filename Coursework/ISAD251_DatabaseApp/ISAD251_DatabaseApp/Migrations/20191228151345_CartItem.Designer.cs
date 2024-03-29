﻿// <auto-generated />
using System;
using ISAD251_DatabaseApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ISAD251_DatabaseApp.Migrations
{
    [DbContext(typeof(ISAD251_JHarrisonContext))]
    [Migration("20191228151345_CartItem")]
    partial class CartItem
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ISAD251_DatabaseApp.Data.Models.ShoppingCartItem", b =>
                {
                    b.Property<int>("ShoppingCartItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount");

                    b.Property<int?>("ProductsProductId");

                    b.Property<string>("ShoppingCartID");

                    b.HasKey("ShoppingCartItemId");

                    b.HasIndex("ProductsProductId");

                    b.ToTable("ShoppingCartItems");
                });

            modelBuilder.Entity("ISAD251_DatabaseApp.Models.CafeCustomers", b =>
                {
                    b.Property<int>("CustId")
                        .HasColumnName("CustID");

                    b.Property<string>("CustFirstName")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("CustSurName")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.HasKey("CustId");

                    b.ToTable("Cafe_Customers");
                });

            modelBuilder.Entity("ISAD251_DatabaseApp.Models.CafeOrderDetails", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnName("OrderID");

                    b.Property<int>("ProductId")
                        .HasColumnName("ProductID");

                    b.Property<decimal?>("ProductOrderPrice")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<int>("Quantity");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("Cafe_Order_Details");
                });

            modelBuilder.Entity("ISAD251_DatabaseApp.Models.CafeOrders", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnName("OrderID");

                    b.Property<int>("CustId")
                        .HasColumnName("CustID");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("date");

                    b.Property<decimal?>("OrderTotalPrice")
                        .HasColumnType("decimal(18, 0)");

                    b.HasKey("OrderId");

                    b.HasIndex("CustId");

                    b.ToTable("Cafe_Orders");
                });

            modelBuilder.Entity("ISAD251_DatabaseApp.Models.CafeProducts", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnName("ProductID");

                    b.Property<int?>("ProductCalories");

                    b.Property<string>("ProductDetails")
                        .HasColumnType("text");

                    b.Property<string>("ProductImage");

                    b.Property<string>("ProductName")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<decimal?>("ProductPrice")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<string>("ProductType")
                        .HasMaxLength(5)
                        .IsUnicode(false);

                    b.HasKey("ProductId");

                    b.ToTable("Cafe_Products");
                });

            modelBuilder.Entity("ISAD251_DatabaseApp.Data.Models.ShoppingCartItem", b =>
                {
                    b.HasOne("ISAD251_DatabaseApp.Models.CafeProducts", "Products")
                        .WithMany()
                        .HasForeignKey("ProductsProductId");
                });

            modelBuilder.Entity("ISAD251_DatabaseApp.Models.CafeOrderDetails", b =>
                {
                    b.HasOne("ISAD251_DatabaseApp.Models.CafeOrders", "Order")
                        .WithMany("CafeOrderDetails")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("fk_Cafe_Order_Details_O");

                    b.HasOne("ISAD251_DatabaseApp.Models.CafeProducts", "Product")
                        .WithMany("CafeOrderDetails")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("fk_Cafe_Order_Details_P");
                });

            modelBuilder.Entity("ISAD251_DatabaseApp.Models.CafeOrders", b =>
                {
                    b.HasOne("ISAD251_DatabaseApp.Models.CafeCustomers", "Cust")
                        .WithMany("CafeOrders")
                        .HasForeignKey("CustId")
                        .HasConstraintName("fk_Cafe_Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
