using Dominio.Entidades;

namespace Repositorio.Interfaces
{
    public interface IVentasAplicacion
    {
        void Configurar(string StringConexion);
        List<Ventas> PorTipo(Ventas? entidad);
        List<Ventas> Listar();
        Ventas? Guardar(Ventas? entidad);
        Ventas? Modificar(Ventas? entidad);
        Ventas? Borrar(Ventas? entidad);
    }
}
