using Dominio.Entidades;
using Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repositorio.Implementaciones
{
    public class ComprasAplicacion : IComprasAplicacion
    {
        private IConexion? IConexion = null;

        public ComprasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Compras? Borrar(Compras? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdCompra == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.Compras!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Compras? Guardar(Compras? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.IdCompra != 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.Compras!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Compras> Listar()
        {
            return this.IConexion!.Compras!.Take(50).ToList();
        }

        public List<Compras> PorTipo(Compras? entidad)
        {
            return this.IConexion!.Compras!
                .Where(x => x.Descrpcion!.Contains(entidad!.Descrpcion!))
                .Take(50)
                .ToList();
        }

        public Compras? Modificar(Compras? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdCompra == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<Compras>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}