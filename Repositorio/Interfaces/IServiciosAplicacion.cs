using Dominio.Entidades;

namespace Repositorio.Interfaces
{
    public interface IServiciosAplicacion
    {
        void Configurar(string StringConexion);
        List<Servicios> PorTipo(Servicios? entidad);
        List<Servicios> Listar();
        Servicios? Guardar(Servicios? entidad);
        Servicios? Modificar(Servicios? entidad);
        Servicios? Borrar(Servicios? entidad);
    }
}
