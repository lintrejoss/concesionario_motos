using Dominio.Entidades;

namespace Repositorio.Interfaces
{
    public interface IOrden_ServiciosAplicacion
    {
        void Configurar(string StringConexion);
        List<Orden_Servicios> PorTipo(Orden_Servicios? entidad);
        List<Orden_Servicios> Listar();
        Orden_Servicios? Guardar(Orden_Servicios? entidad);
        Orden_Servicios? Modificar(Orden_Servicios? entidad);
        Orden_Servicios? Borrar(Orden_Servicios? entidad);
    }
}
