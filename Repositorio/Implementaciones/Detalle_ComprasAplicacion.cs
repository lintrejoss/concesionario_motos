using Dominio.Entidades;
using Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repositorio.Implementaciones
{
    public class Detalle_ComprasAplicacion : IDetalle_ComprasAplicacion
    {
        private IConexion? IConexion = null;

        public Detalle_ComprasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Detalle_Compras? Borrar(Detalle_Compras? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdDetalle == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.Detalle_Compras!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Detalle_Compras? Guardar(Detalle_Compras? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.IdDetalle != 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.Detalle_Compras!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Detalle_Compras> Listar()
        {
            return this.IConexion!.Detalle_Compras!.Take(50).ToList();
        }

        public List<Detalle_Compras> PorTipo(Detalle_Compras? entidad)
        {
            return this.IConexion!.Detalle_Compras!
                .Where(x => x.Descripcion!.Contains(entidad!.Descripcion!))
                .Take(50)
                .ToList();
        }

        public Detalle_Compras? Modificar(Detalle_Compras? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdDetalle == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<Detalle_Compras>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}