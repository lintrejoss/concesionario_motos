using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Repositorio.Interfaces;
using System.Globalization;

namespace Repositorio.Implementaciones
{
    public class Detalle_VentasAplicacion : IDetalle_VentasAplicacion
    {
        private IConexion? IConexion = null;

        public Detalle_VentasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Detalle_Ventas? Borrar(Detalle_Ventas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdDetalle == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.Detalle_Ventas!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Detalle_Ventas? Guardar(Detalle_Ventas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.IdDetalle != 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.Detalle_Ventas!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Detalle_Ventas> Listar()
        {
            return this.IConexion!.Detalle_Ventas!.Take(50).ToList();
        }

        public List<Detalle_Ventas> PorTipo(Detalle_Ventas? entidad)
        {
            return this.IConexion!.Detalle_Ventas!
                .Where(x => x.Descripcion!.Contains(entidad!.Descripcion!))
                .Take(50)
                .ToList();
        }

        public Detalle_Ventas? Modificar(Detalle_Ventas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdDetalle == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<Detalle_Ventas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}