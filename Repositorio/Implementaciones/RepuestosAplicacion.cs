using Dominio.Entidades;
using Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repositorio.Implementaciones
{
    public class RepuestosAplicacion : IRepuestosAplicacion
    {
        private IConexion? IConexion = null;

        public RepuestosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Repuestos? Borrar(Repuestos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdRepuesto == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.Repuestos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Repuestos? Guardar(Repuestos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.IdRepuesto != 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.Repuestos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Repuestos> Listar()
        {
            return this.IConexion!.Repuestos!.Take(50).ToList();
        }

        public List<Repuestos> PorTipo(Repuestos? entidad)
        {
            return this.IConexion!.Repuestos!
                .Where(x => x.Nombre!.Contains(entidad!.Nombre!))
                .Take(50)
                .ToList();
        }

        public Repuestos? Modificar(Repuestos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdRepuesto == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<Repuestos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}