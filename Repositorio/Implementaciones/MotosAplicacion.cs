using Dominio.Entidades;
using Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repositorio.Implementaciones
{
    public class MotosAplicacion : IMotosAplicacion
    {
        private IConexion? IConexion = null;

        public MotosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Motos? Borrar(Motos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdMoto == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.Motos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Motos? Guardar(Motos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.IdMoto != 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.Motos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Motos> Listar()
        {
            return this.IConexion!.Motos!.Take(50).ToList();
        }

        public List<Motos> PorTipo(Motos? entidad)
        {
            return this.IConexion!.Motos!
                .Where(x => x.NumeroChasis!.Contains(entidad!.NumeroChasis!))
                .Take(50)
                .ToList();
        }

        public Motos? Modificar(Motos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdMoto == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<Motos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}