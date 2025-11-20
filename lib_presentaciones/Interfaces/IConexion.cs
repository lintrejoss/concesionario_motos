using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
namespace lib_presentaciones.Interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }

        DbSet<Cargos>? Cargos { get; set; }
        DbSet<Clientes>? Clientes { get; set; }
        DbSet<Compras>? Compras { get; set; }
        DbSet<Detalle_Compras>? Detalle_Compras { get; set; }
        DbSet<Detalle_Ventas>? Detalle_Ventas { get; set; }
        DbSet<Empleados>? Empleados { get; set; }
        DbSet<Marcas>? Marcas { get; set; }
        DbSet<Modelos>? Modelos { get; set; }
        DbSet<Motos>? Motos { get; set; }
        DbSet<Orden_Servicios>? Orden_Servicios { get; set; }
        DbSet<Pagos>? Pagos { get; set; }
        DbSet<Proveedores>? Proveedores { get; set; }
        DbSet<Repuestos>? Repuestos { get; set; }
        DbSet<Servicios>? Servicios { get; set; }
        DbSet<Ventas>? Ventas { get; set; }
        DbSet<Usuarios>? Usuarios { get; set; }
        
        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}

