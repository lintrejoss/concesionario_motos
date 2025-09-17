using lib_dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class Conexion : DbContext
    {
        public string? StringConexion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!);
        }

        public virtual DbSet<Cargos> Cargos { get; set; }

        public virtual DbSet<Clientes> Clientes { get; set; }

        public virtual DbSet<Compras> Compras { get; set; }

        public virtual DbSet<DetalleCompras> DetalleCompras { get; set; }

        public virtual DbSet<DetalleVentas> DetalleVentas { get; set; }

        public virtual DbSet<Empleados> Empleados { get; set; }

        public virtual DbSet<Marcas> Marcas { get; set; }

        public virtual DbSet<Modelos> Modelos { get; set; }

        public virtual DbSet<Motos> Motos { get; set; }

        public virtual DbSet<OrdenServicios> OrdenServicios { get; set; }

        public virtual DbSet<Pago> Pagos { get; set; }

        public virtual DbSet<Proveedore> Proveedores { get; set; }

        public virtual DbSet<Repuesto> Repuestos { get; set; }

        public virtual DbSet<Servicios> Servicios { get; set; }

        public virtual DbSet<Ventas> Ventas { get; set; }


        // Agregar DbSet para las demás entidades
    }
}