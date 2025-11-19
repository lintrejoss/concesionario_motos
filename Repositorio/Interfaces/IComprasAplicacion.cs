using Dominio.Entidades;

namespace Repositorio.Interfaces
{
    public interface IComprasAplicacion
    {
        void Configurar(string StringConexion);
        List<Compras> PorTipo(Compras? entidad);
        List<Compras> Listar();
        Compras? Guardar(Compras? entidad);
        Compras? Modificar(Compras? entidad);
        Compras? Borrar(Compras? entidad);
    }
}
