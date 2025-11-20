using Dominio.Entidades;
using Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repositorio.Implementaciones
{
    public class ModelosAplicacion : IModelosAplicacion
    {
        private IConexion? IConexion = null;

        public ModelosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Modelos? Borrar(Modelos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdModelo == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.Modelos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Modelos? Guardar(Modelos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.IdModelo != 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.Modelos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Modelos> Listar()
        {
            return this.IConexion!.Modelos!.Take(50).ToList();
        }

        public List<Modelos> PorTipo(Modelos? entidad)
        {
            return this.IConexion!.Modelos!
                .Where(x => x.Nombre!.Contains(entidad!.Nombre!))
                .Take(50)
                .ToList();
        }

        public Modelos? Modificar(Modelos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdModelo == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<Modelos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}