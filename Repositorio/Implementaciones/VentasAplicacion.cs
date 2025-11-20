using Dominio.Entidades;
using Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repositorio.Implementaciones
{
    public class VentasAplicacion : IVentasAplicacion
    {
        private IConexion? IConexion = null;

        public VentasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Ventas? Borrar(Ventas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdVenta == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.Ventas!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Ventas? Guardar(Ventas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.IdVenta != 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.Ventas!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Ventas> Listar()
        {
            return this.IConexion!.Ventas!.Take(50).ToList();
        }

        public List<Ventas> PorTipo(Ventas? entidad)
        {
            return this.IConexion!.Ventas!
                .Where(x => x.Descripcion!.Contains(entidad!.Descripcion!))
                .Take(50)
                .ToList();
        }

        public Ventas? Modificar(Ventas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdVenta == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<Ventas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}