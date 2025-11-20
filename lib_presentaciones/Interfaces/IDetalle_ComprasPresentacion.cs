using Dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IDetalle_ComprasPresentacion
    {
        Task<List<Detalle_Compras>> Listar();
        Task<List<Detalle_Compras>> PorTipo(Detalle_Compras? entidad);
        Task<Detalle_Compras?> Guardar(Detalle_Compras? entidad);
        Task<Detalle_Compras?> Modificar(Detalle_Compras? entidad);
        Task<Detalle_Compras?> Borrar(Detalle_Compras? entidad);
    }
}