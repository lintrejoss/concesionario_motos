using Dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IMotosPresentacion
    {
        Task<List<Motos>> Listar();
        Task<List<Motos>> PorTipo(Motos? entidad);
        Task<Motos?> Guardar(Motos? entidad);
        Task<Motos?> Modificar(Motos? entidad);
        Task<Motos?> Borrar(Motos? entidad);
        
    }
}