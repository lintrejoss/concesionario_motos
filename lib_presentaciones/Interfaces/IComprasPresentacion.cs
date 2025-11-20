using Dominio.Entidades;
namespace lib_presentaciones.Interfaces
{
    public interface IComprasPresentacion
    {
        Task<List<Compras>> Listar();
        Task<List<Compras>> PorTipo(Compras? entidad);
        Task<Compras?> Guardar(Compras? entidad);
        Task<Compras?> Modificar(Compras? entidad);
        Task<Compras?> Borrar(Compras? entidad);
    }
}