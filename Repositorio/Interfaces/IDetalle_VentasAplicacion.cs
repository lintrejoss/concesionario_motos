using Dominio.Entidades;

namespace Repositorio.Interfaces
{
    public interface IDetalle_VentasAplicacion
    {
        void Configurar(string StringConexion);
        List<Detalle_Ventas> PorTipo(Detalle_Ventas? entidad);
        List<Detalle_Ventas> Listar();
        Detalle_Ventas? Guardar(Detalle_Ventas? entidad);
        Detalle_Ventas? Modificar(Detalle_Ventas? entidad);
        Detalle_Ventas? Borrar(Detalle_Ventas? entidad);
    }
}

