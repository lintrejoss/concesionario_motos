using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace lib_dominio.Entidades;

public partial class ConcesionarioContext : DbContext
{
    public ConcesionarioContext()
    {
    }

    public ConcesionarioContext(DbContextOptions<ConcesionarioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<DetalleCompra> DetalleCompras { get; set; }

    public virtual DbSet<DetalleVenta> DetalleVentas { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Modelo> Modelos { get; set; }

    public virtual DbSet<Moto> Motos { get; set; }

    public virtual DbSet<OrdenServicio> OrdenServicios { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    public virtual DbSet<Repuesto> Repuestos { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=concesionario;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.IdCargo).HasName("PK__Cargos__D3C09EC5616433B0");

            entity.Property(e => e.IdCargo).HasColumnName("id_cargo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Clientes__677F38F5FE87AE92");

            entity.HasIndex(e => e.Documento, "UQ__Clientes__A25B3E6150CAB5D4").IsUnique();

            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.Direccion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Documento)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("documento");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => e.IdCompra).HasName("PK__Compras__C4BAA604D9434B9F");

            entity.Property(e => e.IdCompra).HasColumnName("id_compra");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Proveedor).HasColumnName("proveedor");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("total");

            entity.HasOne(d => d.ProveedorNavigation).WithMany(p => p.Compras)
                .HasForeignKey(d => d.Proveedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Compras__proveed__5BE2A6F2");
        });

        modelBuilder.Entity<DetalleCompra>(entity =>
        {
            entity.HasKey(e => e.IdDetalle).HasName("PK__Detalle___4F1332DEFD9219E4");

            entity.ToTable("Detalle_Compras");

            entity.Property(e => e.IdDetalle).HasColumnName("id_detalle");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Compra).HasColumnName("compra");
            entity.Property(e => e.PrecioUnitario)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("precio_unitario");
            entity.Property(e => e.Repuesto).HasColumnName("repuesto");

            entity.HasOne(d => d.CompraNavigation).WithMany(p => p.DetalleCompras)
                .HasForeignKey(d => d.Compra)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Detalle_C__compr__5EBF139D");

            entity.HasOne(d => d.RepuestoNavigation).WithMany(p => p.DetalleCompras)
                .HasForeignKey(d => d.Repuesto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Detalle_C__repue__5FB337D6");
        });

        modelBuilder.Entity<DetalleVenta>(entity =>
        {
            entity.HasKey(e => e.IdDetalle).HasName("PK__Detalle___4F1332DEAB53E0A1");

            entity.ToTable("Detalle_Ventas");

            entity.Property(e => e.IdDetalle).HasColumnName("id_detalle");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.PrecioUnitario)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("precio_unitario");
            entity.Property(e => e.Repuesto).HasColumnName("repuesto");
            entity.Property(e => e.Venta).HasColumnName("venta");

            entity.HasOne(d => d.RepuestoNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.Repuesto)
                .HasConstraintName("FK__Detalle_V__repue__534D60F1");

            entity.HasOne(d => d.VentaNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.Venta)
                .HasConstraintName("FK__Detalle_V__venta__52593CB8");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__Empleado__88B51394C7BA70D1");

            entity.HasIndex(e => e.Documento, "UQ__Empleado__A25B3E61654FA8B1").IsUnique();

            entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");
            entity.Property(e => e.Cargo).HasColumnName("cargo");
            entity.Property(e => e.Documento)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("documento");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.CargoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.Cargo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Empleados__cargo__4AB81AF0");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.IdMarca).HasName("PK__Marcas__7E43E99E55835029");

            entity.Property(e => e.IdMarca).HasColumnName("id_marca");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Modelo>(entity =>
        {
            entity.HasKey(e => e.IdModelo).HasName("PK__Modelos__B3BFCFF1402B3D44");

            entity.Property(e => e.IdModelo).HasColumnName("id_modelo");
            entity.Property(e => e.Anio).HasColumnName("anio");
            entity.Property(e => e.Cilindraje).HasColumnName("cilindraje");
            entity.Property(e => e.Marca).HasColumnName("marca");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.MarcaNavigation).WithMany(p => p.Modelos)
                .HasForeignKey(d => d.Marca)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Modelos__marca__398D8EEE");
        });

        modelBuilder.Entity<Moto>(entity =>
        {
            entity.HasKey(e => e.IdMoto).HasName("PK__Motos__82C02307BEEBC725");

            entity.HasIndex(e => e.NumeroChasis, "UQ__Motos__56E95CABDFC9B759").IsUnique();

            entity.Property(e => e.IdMoto).HasColumnName("id_moto");
            entity.Property(e => e.Color)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("color");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("Disponible")
                .HasColumnName("estado");
            entity.Property(e => e.Modelo).HasColumnName("modelo");
            entity.Property(e => e.NumeroChasis)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("numero_chasis");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("precio");

            entity.HasOne(d => d.ModeloNavigation).WithMany(p => p.Motos)
                .HasForeignKey(d => d.Modelo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Motos__modelo__440B1D61");
        });

        modelBuilder.Entity<OrdenServicio>(entity =>
        {
            entity.HasKey(e => e.IdOrden).HasName("PK__Orden_Se__DD5B8F3321FB6887");

            entity.ToTable("Orden_Servicios");

            entity.Property(e => e.IdOrden).HasColumnName("id_orden");
            entity.Property(e => e.Cliente).HasColumnName("cliente");
            entity.Property(e => e.CostoTotal)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("costo_total");
            entity.Property(e => e.Empleado).HasColumnName("empleado");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Moto).HasColumnName("moto");
            entity.Property(e => e.Servicio).HasColumnName("servicio");

            entity.HasOne(d => d.ClienteNavigation).WithMany(p => p.OrdenServicios)
                .HasForeignKey(d => d.Cliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orden_Ser__clien__6477ECF3");

            entity.HasOne(d => d.EmpleadoNavigation).WithMany(p => p.OrdenServicios)
                .HasForeignKey(d => d.Empleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orden_Ser__emple__66603565");

            entity.HasOne(d => d.MotoNavigation).WithMany(p => p.OrdenServicios)
                .HasForeignKey(d => d.Moto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orden_Serv__moto__656C112C");

            entity.HasOne(d => d.ServicioNavigation).WithMany(p => p.OrdenServicios)
                .HasForeignKey(d => d.Servicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orden_Ser__servi__6754599E");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.IdPago).HasName("PK__Pagos__0941B07421C7DD1C");

            entity.Property(e => e.IdPago).HasColumnName("id_pago");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.MetodoPago)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("metodo_pago");
            entity.Property(e => e.Monto)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("monto");
            entity.Property(e => e.Venta).HasColumnName("venta");

            entity.HasOne(d => d.VentaNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.Venta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pagos__venta__571DF1D5");
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("PK__Proveedo__8D3DFE2830CD2C8D");

            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Repuesto>(entity =>
        {
            entity.HasKey(e => e.IdRepuesto).HasName("PK__Repuesto__9D97D13FF805663D");

            entity.HasIndex(e => e.Referencia, "UQ__Repuesto__85C4EB334DA5C75A").IsUnique();

            entity.Property(e => e.IdRepuesto).HasColumnName("id_repuesto");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("precio");
            entity.Property(e => e.Referencia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("referencia");
            entity.Property(e => e.Stock).HasColumnName("stock");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.IdServicio).HasName("PK__Servicio__6FD07FDCBEA8B8C7");

            entity.Property(e => e.IdServicio).HasColumnName("id_servicio");
            entity.Property(e => e.CostoBase)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("costo_base");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("PK__Ventas__459533BF5E0F6464");

            entity.Property(e => e.IdVenta).HasColumnName("id_venta");
            entity.Property(e => e.Cliente).HasColumnName("cliente");
            entity.Property(e => e.Empleado).HasColumnName("empleado");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Moto).HasColumnName("moto");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("total");

            entity.HasOne(d => d.ClienteNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.Cliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ventas__cliente__4D94879B");

            entity.HasOne(d => d.EmpleadoNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.Empleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ventas__empleado__4E88ABD4");

            entity.HasOne(d => d.MotoNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.Moto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ventas__moto__4F7CD00D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
