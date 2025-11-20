using Dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IVentasPresentacion
    {
        Task<List<Ventas>> Listar();
        Task<List<Ventas>> PorTipo(Ventas? entidad);
        Task<Ventas?> Guardar(Ventas? entidad);
        Task<Ventas?> Modificar(Ventas? entidad);
        Task<Ventas?> Borrar(Ventas? entidad);
        
    }
}