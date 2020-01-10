using System;
using ISAD251_DatabaseApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ISAD251_DatabaseApp.Models
{
    public partial class ISAD251_JHarrisonContext : DbContext
    {
        public ISAD251_JHarrisonContext()
        {
        }

        public ISAD251_JHarrisonContext(DbContextOptions<ISAD251_JHarrisonContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CafeCustomers> CafeCustomers { get; set; }
        public virtual DbSet<CafeOrderDetails> CafeOrderDetails { get; set; }
        public virtual DbSet<CafeOrders> CafeOrders { get; set; }
        public virtual DbSet<CafeProducts> CafeProducts { get; set; }
        public virtual DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=socem1.uopnet.plymouth.ac.uk;Database=ISAD251_JHarrison;User Id=JHarrison; Password=ISAD251_22214613");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CafeCustomers>(entity =>
            {
                entity.HasKey(e => e.CustId);

                entity.ToTable("Cafe_Customers");

                entity.Property(e => e.CustId)
                    .HasColumnName("CustID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CustFirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CustSurName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CafeOrderDetails>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId });

                entity.ToTable("Cafe_Order_Details");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductOrderPrice).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.CafeOrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Cafe_Order_Details_O");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CafeOrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Cafe_Order_Details_P");
            });

            modelBuilder.Entity<CafeOrders>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.ToTable("Cafe_Orders");

                entity.Property(e => e.OrderId)
                    .HasColumnName("OrderID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CustId).HasColumnName("CustID");

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.OrderTotalPrice).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.CafeOrders)
                    .HasForeignKey(d => d.CustId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Cafe_Orders");
            });

            modelBuilder.Entity<CafeProducts>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.ToTable("Cafe_Products");

                entity.Property(e => e.ProductId)
                    .HasColumnName("ProductID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ProductDetails).HasColumnType("text");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProductPrice).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ProductType)
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

        }
    }
}
