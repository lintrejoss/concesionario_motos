using Dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface ICargosPresentacion
    {
        Task<List<Cargos>> Listar();
        Task<List<Cargos>> PorTipo(Cargos? entidad);
        Task<Cargos?> Guardar(Cargos? entidad);
        Task<Cargos?> Modificar(Cargos? entidad);
        Task<Cargos?> Borrar(Cargos? entidad);
    }
}
