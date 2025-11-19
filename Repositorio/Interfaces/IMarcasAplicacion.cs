using Dominio.Entidades;

namespace Repositorio.Interfaces
{
    public interface IMarcasAplicacion
    {
        void Configurar(string StringConexion);
        List<Marcas> PorTipo(Marcas? entidad);
        List<Marcas> Listar();
        Marcas? Guardar(Marcas? entidad);
        Marcas? Modificar(Marcas? entidad);
        Marcas? Borrar(Marcas? entidad);
    }
}

