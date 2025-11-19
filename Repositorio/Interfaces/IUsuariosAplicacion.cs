using Dominio.Entidades;

namespace Repositorio.Interfaces
{
    public interface IUsuariosAplicacion
    {
        void Configurar(string StringConexion);
        List<Usuarios> PorTipo(Usuarios? entidad);
        List<Usuarios> Listar();
        Usuarios? Guardar(Usuarios? entidad);
        Usuarios? Modificar(Usuarios? entidad);
        Usuarios? Borrar(Usuarios? entidad);
    }
}
