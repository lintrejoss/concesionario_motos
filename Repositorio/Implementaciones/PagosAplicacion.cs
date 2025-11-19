using Dominio.Entidades;
using Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repositorio.Implementaciones
{
    public class CargosAplicacion : ICargosAplicacion
    {
        private IConexion? IConexion = null;

        public CargosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Cargos? Borrar(Cargos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdCargo == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.Cargos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Cargos? Guardar(Cargos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.IdCargo != 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.Cargos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Cargos> Listar()
        {
            return this.IConexion!.Cargos!.Take(50).ToList();
        }

        public List<Cargos> PorTipo(Cargos? entidad)
        {
            return this.IConexion!.Cargos!
                .Where(x => x.Nombre!.Contains(entidad!.Nombre!))
                .Take(50)
                .ToList();
        }

        public Cargos? Modificar(Cargos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdCargo == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<Cargos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}