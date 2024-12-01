using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SistemaVentas.Models;

public partial class DbventasContext : DbContext
{
    public DbventasContext()
    {
    }

    public DbventasContext(DbContextOptions<DbventasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Inventario> Inventarios { get; set; }

    public virtual DbSet<MovimientoCompra> MovimientoCompras { get; set; }

    public virtual DbSet<MovimientoVenta> MovimientoVentas { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-66N41P8\\SQLEXPRESS;Initial Catalog=DBVENTAS;Integrated Security=True;Encrypt=False");
    */
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.IdCargo).HasName("PK__Cargos__6C985625CAB54114");

            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.NombreCargo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SalarioBase).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Clientes__D5946642870BAD29");

            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__Empleado__CE6D8B9EA858742E");

            entity.Property(e => e.Clave)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaContratacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Usuario)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCargoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdCargo)
                .HasConstraintName("FK__Empleados__IdCar__44FF419A");
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Inventar__0988921037F2D60D");

            entity.Property(e => e.IdProducto).ValueGeneratedNever();
            entity.Property(e => e.FechaUltimaActualizacion).HasColumnType("datetime");
            entity.Property(e => e.PrecioCompra).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PrecioVenta).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<MovimientoCompra>(entity =>
        {
            entity.HasKey(e => e.IdCompra).HasName("PK__Movimien__0A5CDB5CDA824285");

            entity.ToTable("Movimiento_Compras");

            entity.Property(e => e.Detalle).HasColumnType("text");
            entity.Property(e => e.FechaCompra).HasColumnType("datetime");
            entity.Property(e => e.TotalCompra).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.MovimientoCompras)
                .HasForeignKey(d => d.IdProveedor)
                .HasConstraintName("FK__Movimient__IdPro__4222D4EF");
        });

        modelBuilder.Entity<MovimientoVenta>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("PK__Movimien__BC1240BD764D497B");

            entity.ToTable("Movimiento_Ventas");

            entity.Property(e => e.Detalle).HasColumnType("text");
            entity.Property(e => e.FechaVenta).HasColumnType("datetime");
            entity.Property(e => e.TotalVenta).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.MovimientoVenta)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Movimient__IdCli__3F466844");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__098892101BD7ABA3");

            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PrecioCompra).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PrecioVenta).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("PK__Proveedo__E8B631AFDD8BCBC7");

            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NombreEmpresa)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
