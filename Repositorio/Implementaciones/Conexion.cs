using Dominio.Entidades;
using Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace Repositorio.Implementaciones
{
    public partial class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
        public DbSet<Cargos>? Cargos { get; set; }
        public DbSet<Clientes>? Clientes { get; set; }
        public DbSet<Compras>? Compras { get; set; }
        public DbSet<Detalle_Compras>? Detalle_Compras { get; set; }
        public DbSet<Detalle_Ventas>? Detalle_Ventas { get; set; }
        public DbSet<Empleados>? Empleados { get; set; }
        public DbSet<Marcas>? Marcas { get; set; }
        public DbSet<Modelos>? Modelos { get; set; }
        public DbSet<Motos>? Motos { get; set; }
        public DbSet<Orden_Servicios>? Orden_Servicios { get; set; }
        public DbSet<Pagos>? Pagos { get; set; }
        public DbSet<Proveedores>? Proveedores { get; set; }
        public DbSet<Repuestos>? Repuestos { get; set; }
        public DbSet<Servicios>? Servicios { get; set; }
        public DbSet<Ventas>? Ventas { get; set; }
        public DbSet<Usuarios>? Usuarios { get; set; }
    }
}
