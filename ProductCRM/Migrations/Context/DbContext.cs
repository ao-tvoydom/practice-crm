using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Migrations.Entities;

namespace Migrations.Context
{
    public partial class CRMDbContext : DbContext
    {
        public CRMDbContext()
        {
        }

        public CRMDbContext(DbContextOptions<DbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductCategory> ProductCategories { get; set; } = null!;
        public virtual DbSet<ProductInWarehouse> ProductInWarehouses { get; set; } = null!;
        public virtual DbSet<Shipment> Shipments { get; set; } = null!;
        public virtual DbSet<ShipmentContent> ShipmentContents { get; set; } = null!;
        public virtual DbSet<Supply> Supplies { get; set; } = null!;
        public virtual DbSet<Warehouse> Warehouses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProductCRMDatabase;Integrated Security=True");
                
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.ColorHex)
                    .HasMaxLength(6)
                    .HasColumnName("ColorHEX");

                entity.Property(e => e.Name).HasMaxLength(40);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Name).HasMaxLength(75);
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("ProductCategory");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ProductCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductCategory_Category");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductCategories)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductCategory_Product");
            });

            modelBuilder.Entity<ProductInWarehouse>(entity =>
            {
                entity.ToTable("ProductInWarehouse");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductInWarehouses)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductInWarehouse_Product");

                entity.HasOne(d => d.Warehouse)
                    .WithMany(p => p.ProductInWarehouses)
                    .HasForeignKey(d => d.WarehouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductInWarehouse_Warehouse");
            });

            modelBuilder.Entity<Shipment>(entity =>
            {
                entity.ToTable("Shipment");

                entity.Property(e => e.ContactPhone).HasMaxLength(15);

                entity.Property(e => e.ShipmentEndDate).HasColumnType("datetime");

                entity.Property(e => e.ShipmentStartDate).HasColumnType("datetime");

                entity.Property(e => e.TargetAddress).HasMaxLength(120);
            });

            modelBuilder.Entity<ShipmentContent>(entity =>
            {
                entity.ToTable("ShipmentContent");

                entity.HasOne(d => d.ProductWarehouse)
                    .WithMany(p => p.ShipmentContents)
                    .HasForeignKey(d => d.ProductWarehouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShipmentContent_ProductInWarehouse");

                entity.HasOne(d => d.Shipment)
                    .WithMany(p => p.ShipmentContents)
                    .HasForeignKey(d => d.ShipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShipmentContent_Shipment");
            });

            modelBuilder.Entity<Supply>(entity =>
            {
                entity.ToTable("Supply");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.SupplierName).HasMaxLength(100);

                entity.HasOne(d => d.ProductInWarehouse)
                    .WithMany(p => p.Supplies)
                    .HasForeignKey(d => d.ProductInWarehouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Supply_ProductInWarehouse");
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.ToTable("Warehouse");

                entity.Property(e => e.Address).HasMaxLength(120);

                entity.Property(e => e.Name).HasMaxLength(60);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
