using Dominio.Entidades;

namespace Repositorio.Interfaces
{
    public interface ICargosAplicacion
    {
        void Configurar(string StringConexion);
        List<Cargos> PorTipo(Cargos? entidad);
        List<Cargos> Listar();
        Cargos? Guardar(Cargos? entidad);
        Cargos? Modificar(Cargos? entidad);
        Cargos? Borrar(Cargos? entidad);
    }
}

