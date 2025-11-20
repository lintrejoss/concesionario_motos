using Dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IOrden_ServiciosPresentacion
    {
        Task<List<Orden_Servicios>> Listar();
        Task<List<Orden_Servicios>> PorTipo(Orden_Servicios? entidad);
        Task<Orden_Servicios?> Guardar(Orden_Servicios? entidad);
        Task<Orden_Servicios?> Modificar(Orden_Servicios? entidad);
        Task<Orden_Servicios?> Borrar(Orden_Servicios? entidad);
        
    }
}