using Dominio.Entidades;
namespace lib_presentaciones.Interfaces
{
    public interface IModelosPresentacion
    {
        Task<List<Modelos>> Listar();
        Task<List<Modelos>> PorTipo(Modelos? entidad);
        Task<Modelos?> Guardar(Modelos? entidad);
        Task<Modelos?> Modificar(Modelos? entidad);
        Task<Modelos?> Borrar(Modelos? entidad);
    }
}