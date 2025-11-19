using Dominio.Entidades;

namespace Repositorio.Interfaces
{
    public interface IClientesAplicacion
    {
        void Configurar(string StringConexion);
        List<Clientes> PorTipo(Clientes? entidad);
        List<Clientes> Listar();
        Clientes? Guardar(Clientes? entidad);
        Clientes? Modificar(Clientes? entidad);
        Clientes? Borrar(Clientes? entidad);
    }
}
