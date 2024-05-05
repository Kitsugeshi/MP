using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MP.Models;

public partial class MarketDbContext : DbContext
{
    public MarketDbContext()
    {
    }

    public MarketDbContext(DbContextOptions<MarketDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderProduct> OrderProducts { get; set; }

    public virtual DbSet<PickUpPoint> PickUpPoints { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductIssuance> ProductIssuances { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Seller> Sellers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-C0QRAI1;Initial Catalog=MarketDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clients__3214EC276A5CE4F2");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC2700C1B3D7");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.IdPickUpPoint).HasColumnName("ID_Pick_up_Point");
            entity.Property(e => e.IdRole).HasColumnName("ID_Role");
            entity.Property(e => e.Login).HasMaxLength(60);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(60);

            entity.HasOne(d => d.IdPickUpPointNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.IdPickUpPoint)
                .HasConstraintName("FK__Employees__ID_Pi__412EB0B6");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.IdRole)
                .HasConstraintName("FK__Employees__ID_Ro__403A8C7D");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__3214EC272640BC49");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.IdClient).HasColumnName("ID_Client");
            entity.Property(e => e.IdPickUpPoint).HasColumnName("ID_Pick_up_Point");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdClient)
                .HasConstraintName("FK__Orders__ID_Clien__46E78A0C");

            entity.HasOne(d => d.IdPickUpPointNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdPickUpPoint)
                .HasConstraintName("FK__Orders__ID_Pick___45F365D3");
        });

        modelBuilder.Entity<OrderProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Order_Pr__3214EC270B8B78AD");

            entity.ToTable("Order_Products");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.IdOrder).HasColumnName("ID_Order");
            entity.Property(e => e.IdProduct).HasColumnName("ID_Product");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.OrderProducts)
                .HasForeignKey(d => d.IdOrder)
                .HasConstraintName("FK__Order_Pro__ID_Or__49C3F6B7");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.OrderProducts)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("FK__Order_Pro__ID_Pr__4AB81AF0");
        });

        modelBuilder.Entity<PickUpPoint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pick_up___3214EC27855FEA42");

            entity.ToTable("Pick_up_Points");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Adress).HasMaxLength(30);
            entity.Property(e => e.Rating).HasColumnType("decimal(3, 2)");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC27B56C5FCD");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.IdSeller).HasColumnName("ID_Seller");
            entity.Property(e => e.Name).HasMaxLength(30);

            entity.HasOne(d => d.IdSellerNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdSeller)
                .HasConstraintName("FK__Products__ID_Sel__398D8EEE");
        });

        modelBuilder.Entity<ProductIssuance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product___3214EC27A0A015DD");

            entity.ToTable("Product_Issuance");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.DateOfIssuance)
                .HasMaxLength(16)
                .HasColumnName("Date_Of_Issuance");
            entity.Property(e => e.IdEmployee).HasColumnName("ID_Employee");
            entity.Property(e => e.IdOrder).HasColumnName("ID_Order");

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.ProductIssuances)
                .HasForeignKey(d => d.IdEmployee)
                .HasConstraintName("FK__Product_I__ID_Em__4D94879B");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.ProductIssuances)
                .HasForeignKey(d => d.IdOrder)
                .HasConstraintName("FK__Product_I__ID_Or__4E88ABD4");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC27AF727813");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(13);
        });

        modelBuilder.Entity<Seller>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sellers__3214EC27F85BEF19");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
