using Dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IDetalle_VentasPresentacion
    {
        Task<List<Detalle_Ventas>> Listar();
        Task<List<Detalle_Ventas>> PorTipo(Detalle_Ventas? entidad);
        Task<Detalle_Ventas?> Guardar(Detalle_Ventas? entidad);
        Task<Detalle_Ventas?> Modificar(Detalle_Ventas? entidad);
        Task<Detalle_Ventas?> Borrar(Detalle_Ventas? entidad);
    }
}