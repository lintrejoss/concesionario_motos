using Dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IRepuestosPresentacion
    {
        Task<List<Repuestos>> Listar();
        Task<List<Repuestos>> PorTipo(Repuestos? entidad);
        Task<Repuestos?> Guardar(Repuestos? entidad);
        Task<Repuestos?> Modificar(Repuestos? entidad);
        Task<Repuestos?> Borrar(Repuestos? entidad);
        
    }
}