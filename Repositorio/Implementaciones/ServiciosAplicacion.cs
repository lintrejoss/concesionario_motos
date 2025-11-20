using Dominio.Entidades;
using Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repositorio.Implementaciones
{
    public class ServiciosAplicacion : IServiciosAplicacion
    {
        private IConexion? IConexion = null;

        public ServiciosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Servicios? Borrar(Servicios? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdServicio == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.Servicios!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Servicios? Guardar(Servicios? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.IdServicio != 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.Servicios!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Servicios> Listar()
        {
            return this.IConexion!.Servicios!.Take(50).ToList();
        }

        public List<Servicios> PorTipo(Servicios? entidad)
        {
            return this.IConexion!.Servicios!
                .Where(x => x.Nombre!.Contains(entidad!.Nombre!))
                .Take(50)
                .ToList();
        }

        public Servicios? Modificar(Servicios? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdServicio == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<Servicios>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}