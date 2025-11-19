using Dominio.Entidades;

namespace Repositorio.Interfaces
{
    public interface IModelosAplicacion
    {
        void Configurar(string StringConexion);
        List<Modelos> PorTipo(Modelos? entidad);
        List<Modelos> Listar();
        Modelos? Guardar(Modelos? entidad);
        Modelos? Modificar(Modelos? entidad);
        Modelos? Borrar(Modelos? entidad);
    }
}
