using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Zepto_Api_pro.Models;

namespace Zepto_Api_pro.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<DeliveryPartener> DeliveryParteners { get; set; }

    public virtual DbSet<DeliveryStatus> DeliveryStatuses { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrdersItem> OrdersItems { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<TblUserAudit> TblUserAudits { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }

    public virtual DbSet<VwOrderSummayDetail> VwOrderSummayDetails { get; set; }

    public virtual DbSet<VwProductSummary> VwProductSummaries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {

        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK__Addresse__091C2A1B6C68022B");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.User).WithMany(p => p.Addresses).HasConstraintName("FK__Addresses__UserI__4D94879B");
        });

        modelBuilder.Entity<DeliveryPartener>(entity =>
        {
            entity.HasKey(e => e.PartenerId).HasName("PK__Delivery__FE088EE534061AF0");
        });

        modelBuilder.Entity<DeliveryStatus>(entity =>
        {
            entity.HasKey(e => e.DeliveryId).HasName("PK__Delivery__626D8FEE85B7C7D7");

            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Order).WithMany(p => p.DeliveryStatuses).HasConstraintName("FK__DeliveryS__Order__6FE99F9F");

            entity.HasOne(d => d.Status).WithMany(p => p.DeliveryStatuses).HasConstraintName("FK__DeliveryS__Statu__70DDC3D8");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.InventoryId).HasName("PK__Inventor__F5FDE6D35A2A3A4A");

            entity.Property(e => e.LastUpdated).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Product).WithMany(p => p.Inventories).HasConstraintName("FK__Inventory__Produ__59FA5E80");

            entity.HasOne(d => d.Vendor).WithMany(p => p.Inventories).HasConstraintName("FK__Inventory__Vendo__59063A47");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAF8FB30A4C");

            entity.Property(e => e.OrderDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.User).WithMany(p => p.Orders).HasConstraintName("FK__Orders__UserID__5EBF139D");

            entity.HasOne(d => d.Vendor).WithMany(p => p.Orders).HasConstraintName("FK__Orders__VendorID__5DCAEF64");
        });

        modelBuilder.Entity<OrdersItem>(entity =>
        {
            entity.HasKey(e => e.OrdersItemsId).HasName("PK__OrdersIt__BB4FA313F77FB1C8");

            entity.HasOne(d => d.Order).WithMany(p => p.OrdersItems).HasConstraintName("FK__OrdersIte__Order__628FA481");

            entity.HasOne(d => d.Product).WithMany(p => p.OrdersItems).HasConstraintName("FK__OrdersIte__Produ__6383C8BA");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payments__9B556A58D5616547");

            entity.Property(e => e.PaidAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Order).WithMany(p => p.Payments).HasConstraintName("FK__Payments__OrderI__66603565");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6ED7E973484");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Category).WithMany(p => p.Products).HasConstraintName("FK__Products__Catego__5535A963");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__ProductC__19093A2BFF2C58F9");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Reviews__74BC79AE6A05BE6D");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Product).WithMany(p => p.Reviews).HasConstraintName("FK__Reviews__Product__75A278F5");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews).HasConstraintName("FK__Reviews__UserID__74AE54BC");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__Status__C8EE2043FEFF14DE");
        });

        modelBuilder.Entity<TblUserAudit>(entity =>
        {
            entity.HasKey(e => e.AuditId).HasName("PK__tbl_user__EDBFCB511F00EF8B");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("PK__Users__1797D0246DA55D8B");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("tr_user_Audit_fordelete");
                    tb.HasTrigger("tr_user_Audit_forinsert");
                    tb.HasTrigger("tr_user_fordelete");
                    tb.HasTrigger("tr_user_forinsert");
                });

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Role).HasDefaultValue("User");
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.HasKey(e => e.VendorId).HasName("PK__Vendors__EC65C4E301C2E2D1");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<VwOrderSummayDetail>(entity =>
        {
            entity.ToView("vw_OrderSummayDetails");
        });

        modelBuilder.Entity<VwProductSummary>(entity =>
        {
            entity.ToView("vw_ProductSummary");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
