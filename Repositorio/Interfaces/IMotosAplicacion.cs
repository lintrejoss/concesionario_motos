using Dominio.Entidades;

namespace Repositorio.Interfaces
{
    public interface IMotosAplicacion
    {
        void Configurar(string StringConexion);
        List<Motos> PorTipo(Motos? entidad);
        List<Motos> Listar();
        Motos? Guardar(Motos? entidad);
        Motos? Modificar(Motos? entidad);
        Motos? Borrar(Motos? entidad);
    }
}
