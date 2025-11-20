using Dominio.Entidades;
using Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repositorio.Implementaciones
{
    public class Orden_ServiciosAplicacion : IOrden_ServiciosAplicacion
    {
        private IConexion? IConexion = null;

        public Orden_ServiciosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Orden_Servicios? Borrar(Orden_Servicios? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdOrden == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.Orden_Servicios!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Orden_Servicios? Guardar(Orden_Servicios? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.IdOrden != 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.Orden_Servicios!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Orden_Servicios> Listar()
        {
            return this.IConexion!.Orden_Servicios!.Take(50).ToList();
        }

        public List<Orden_Servicios> PorTipo(Orden_Servicios? entidad)
        {
            return this.IConexion!.Orden_Servicios!
                .Where(x => x.Descripcion!.Contains(entidad!.Descripcion!))
                .Take(50)
                .ToList();
        }

        public Orden_Servicios? Modificar(Orden_Servicios? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdOrden == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<Orden_Servicios>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}