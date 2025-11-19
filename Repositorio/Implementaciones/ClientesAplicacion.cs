using Dominio.Entidades;
using Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repositorio.Implementaciones
{
    public class ClientesAplicacion : IClientesAplicacion
    {
        private IConexion? IConexion = null;

        public ClientesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Clientes? Borrar(Clientes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdCliente == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            this.IConexion!.Clientes!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Clientes? Guardar(Clientes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.IdCliente != 0)
                throw new Exception("lbYaSeGuardo");

            // Operaciones

            this.IConexion!.Clientes!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Clientes> Listar()
        {
            return this.IConexion!.Clientes!.Take(50).ToList();
        }

        public List<Clientes> PorTipo(Clientes? entidad)
        {
            return this.IConexion!.Clientes!
                .Where(x => x.Nombre!.Contains(entidad!.Nombre!))
                .Take(50)
                .ToList();
        }

        public Clientes? Modificar(Clientes? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.IdCliente == 0)
                throw new Exception("lbNoSeGuardo");

            // Operaciones

            var entry = this.IConexion!.Entry<Clientes>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}